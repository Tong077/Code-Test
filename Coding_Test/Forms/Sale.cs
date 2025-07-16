using Coding_Test.DataContext;
using Coding_Test.Form;
using Coding_Test.Model;
using Coding_Test.Models.DTO;
using Coding_Test.Reports;
using Coding_Test.Service;
using DevExpress.ChartRangeControlClient.Core;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraMap.Native;
using DevExpress.XtraReports.UI;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;


using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BindingSource = System.Windows.Forms.BindingSource;

namespace Coding_Test
{
    public partial class Sale : DevExpress.XtraEditors.XtraForm
    {

        private BindingSource bindingSource = new BindingSource();
        private List<SaleDto> salesData = new List<SaleDto>();
        public Sale()
        {
            InitializeComponent();
        }

        private void btnGenerate_EditValueChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {


            DateTime? startDate = dtStart.Value.Date;

            DateTime? endDate = dtEnd.Value.Date.AddDays(1).AddTicks(-1);


            if (startDate == null || endDate == null)
            {
                MessageBox.Show("Please select a start and end date to generate the report.", "Date Range Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var sales = SalesService.GetSales(startDate, endDate);


            bindingSource.DataSource = sales;


            if (sales == null || sales.Count == 0)
            {
                MessageBox.Show("No data to generate report.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var report = new Coding_Test.Reports.SaleXtraReport(sales);
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreviewDialog();


        }

        private void Sale_Load(object sender, EventArgs e)
        {
            LoadData();
            showAll();

        }

        private void LoadData()
        {
            DateTime? startDate = dtStart.Checked ? dtStart.Value.Date : null;
            DateTime? endDate = dtEnd.Checked ? dtEnd.Value.Date : null;

            salesData = SalesService.GetSales(startDate, endDate);
            bindingSource.DataSource = salesData;
            dgSales.DataSource = bindingSource;

            dgSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSales.Font = new Font("Khmer OS Siemreap", 10);

            if (dgSales.Columns.Contains("Total"))
            {
                dgSales.Columns["Total"].DefaultCellStyle.Format = "C2";
                dgSales.Columns["Total"].HeaderText = "Total";
            }


        }



        public void showAll()
        {
            salesData = SalesService.GetSales(null, null);
            bindingSource.DataSource = salesData;
            dgSales.DataSource = bindingSource;

            dgSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSales.Font = new Font("Khmer OS Siemreap", 10);

            if (dgSales.Columns.Contains("Total"))
            {
                dgSales.Columns["Total"].DefaultCellStyle.Format = "C2";
                dgSales.Columns["Total"].HeaderText = "Total";
            }
        }


        private void ApplyFilter()
        {
            string productFilter = txtSearchProduct.Text.Trim().ToLower();
            DateTime? start = dtStart.Checked ? dtStart.Value.Date : null;
            DateTime? end = dtEnd.Checked ? dtEnd.Value.Date : null;

            var filtered = salesData
                .Where(s =>
                    (string.IsNullOrEmpty(productFilter) || s.ProductName?.ToLower().Contains(productFilter) == true) &&
                    (!start.HasValue || (s.SaleDate.HasValue && s.SaleDate.Value >= start.Value)) &&
                    (!end.HasValue || (s.SaleDate.HasValue && s.SaleDate.Value <= end.Value))
                )
                .ToList();

            bindingSource.DataSource = filtered;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
            ApplyFilter();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string input = txtSearchProduct.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                showAll();
            }
            else
            {
                ApplyFilter();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            
            var allSales = salesData; 

           
            DateTime? startDate = dtStart.Checked ? dtStart.Value.Date : null;
            DateTime? endDate = dtEnd.Checked ? dtEnd.Value.Date.AddDays(1).AddTicks(-1) : null;

           
            var filteredSales = allSales
                .Where(s =>
                    (!startDate.HasValue || (s.SaleDate.HasValue && s.SaleDate.Value >= startDate.Value)) &&
                    (!endDate.HasValue || (s.SaleDate.HasValue && s.SaleDate.Value <= endDate.Value))
                )
                .ToList();

           
            if (filteredSales == null || filteredSales.Count == 0)
            {
                MessageBox.Show("No data available for selected date range.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            var report = new Coding_Test.Reports.SaleXtraReport(filteredSales);

            // Optional: Set parameters in the report
            if (report.Parameters["StartDate"] != null && report.Parameters["EndDate"] != null)
            {
                report.Parameters["StartDate"].Value = startDate;
                report.Parameters["EndDate"].Value = endDate;
                report.Parameters["StartDate"].Visible = false;
                report.Parameters["EndDate"].Visible = false;
            }

         
            string filename = "Sale_Report";
            if (startDate.HasValue && endDate.HasValue)
            {
                filename = $"Sale_Report_{startDate:yyyyMMdd}_to_{endDate.Value.AddDays(-1):yyyyMMdd}";
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Export Report";
                sfd.Filter = "PDF Files (*.pdf)|*.pdf|Excel Files (*.xlsx)|*.xlsx|Word Files (*.docx)|*.docx";
                sfd.FileName = filename;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(sfd.FileName).ToLower();
                        switch (ext)
                        {
                            case ".pdf":
                                report.ExportToPdf(sfd.FileName);
                                break;
                            case ".xlsx":
                                report.ExportToXlsx(sfd.FileName);
                                break;
                            case ".docx":
                                report.ExportToDocx(sfd.FileName);
                                break;
                            default:
                                MessageBox.Show("Unsupported file format.");
                                return;
                        }

                        MessageBox.Show("Export successful!", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}