namespace Coding_Test
{
    partial class Sale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            panel1 = new Panel();
            dgSales = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dtStart = new DateTimePicker();
            dtEnd = new DateTimePicker();
            btnReport = new Button();
            btnSearch = new Button();
            txtSearchProduct = new TextBox();
            btnShow = new Button();
            btnExport = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSales).BeginInit();
            SuspendLayout();
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 543);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Size = new Size(1718, 20);
            // 
            // panel1
            // 
            panel1.Controls.Add(dgSales);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 504);
            panel1.TabIndex = 4;
            // 
            // dgSales
            // 
            dgSales.BackgroundColor = SystemColors.ButtonFace;
            dgSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSales.Dock = DockStyle.Fill;
            dgSales.Location = new Point(0, 0);
            dgSales.Name = "dgSales";
            dgSales.RowHeadersWidth = 51;
            dgSales.Size = new Size(1080, 504);
            dgSales.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1121, 165);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 7;
            label1.Text = "Start date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1387, 157);
            label2.Name = "label2";
            label2.Size = new Size(76, 24);
            label2.TabIndex = 8;
            label2.Text = "End date";
            // 
            // dtStart
            // 
            dtStart.Location = new Point(1121, 206);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(222, 23);
            dtStart.TabIndex = 12;
            // 
            // dtEnd
            // 
            dtEnd.Location = new Point(1387, 206);
            dtEnd.Name = "dtEnd";
            dtEnd.Size = new Size(222, 23);
            dtEnd.TabIndex = 13;
            // 
            // btnReport
            // 
            btnReport.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReport.Location = new Point(1121, 264);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(309, 37);
            btnReport.TabIndex = 15;
            btnReport.Text = "GeneRate Report";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(1120, 81);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(147, 37);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search ";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(1120, 12);
            txtSearchProduct.Multiline = true;
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(355, 48);
            txtSearchProduct.TabIndex = 18;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // btnShow
            // 
            btnShow.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShow.Location = new Point(1295, 81);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(121, 37);
            btnShow.TabIndex = 20;
            btnShow.Text = "Show All";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExport.Location = new Point(1107, 468);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(309, 37);
            btnExport.TabIndex = 22;
            btnExport.Text = "Export Report as a Pdf";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // Sale
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1718, 563);
            Controls.Add(btnExport);
            Controls.Add(btnShow);
            Controls.Add(txtSearchProduct);
            Controls.Add(btnSearch);
            Controls.Add(btnReport);
            Controls.Add(dtEnd);
            Controls.Add(dtStart);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(ribbonStatusBar1);
            Name = "Sale";
            Text = "Sale";
            Load += Sale_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;
        private DevExpress.XtraEditors.ButtonEdit btnGenerate;
        private Button btnReport;
        private DataGridView dgSales;
        private Button btnSearch;
        private TextBox txtSearchProduct;
        private Button btnShow;
        private Button btnExport;
    }
}