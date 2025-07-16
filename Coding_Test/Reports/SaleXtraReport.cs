using Coding_Test.Models.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Coding_Test.Reports
{
    public partial class SaleXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
     

        public SaleXtraReport(List<SaleDto> data)
        {
            InitializeComponent();
            this.DataSource = data;
            this.DataMember = "";

        }

        private void xrTableCell6_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
