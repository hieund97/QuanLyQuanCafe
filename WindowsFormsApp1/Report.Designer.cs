namespace WindowsFormsApp1
{
    partial class fReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReport));
            this.USP_GetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyQuanCafeDataSet = new WindowsFormsApp1.QuanLyQuanCafeDataSet();
            this.rpViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpkBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpkKetThuc = new System.Windows.Forms.DateTimePicker();
            this.USP_GetListBillByDateForReportTableAdapter = new WindowsFormsApp1.QuanLyQuanCafeDataSetTableAdapters.USP_GetListBillByDateForReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanCafeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_GetListBillByDateForReportBindingSource
            // 
            this.USP_GetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.USP_GetListBillByDateForReportBindingSource.DataSource = this.QuanLyQuanCafeDataSet;
            // 
            // QuanLyQuanCafeDataSet
            // 
            this.QuanLyQuanCafeDataSet.DataSetName = "QuanLyQuanCafeDataSet";
            this.QuanLyQuanCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpViewer
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_GetListBillByDateForReportBindingSource;
            this.rpViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpViewer.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Report1.rdlc";
            this.rpViewer.Location = new System.Drawing.Point(3, 4);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.ServerReport.BearerToken = null;
            this.rpViewer.Size = new System.Drawing.Size(794, 858);
            this.rpViewer.TabIndex = 0;
            // 
            // dtpkBatDau
            // 
            this.dtpkBatDau.Location = new System.Drawing.Point(12, 833);
            this.dtpkBatDau.Name = "dtpkBatDau";
            this.dtpkBatDau.Size = new System.Drawing.Size(200, 20);
            this.dtpkBatDau.TabIndex = 1;
            this.dtpkBatDau.Visible = false;
            // 
            // dtpkKetThuc
            // 
            this.dtpkKetThuc.Location = new System.Drawing.Point(588, 833);
            this.dtpkKetThuc.Name = "dtpkKetThuc";
            this.dtpkKetThuc.Size = new System.Drawing.Size(200, 20);
            this.dtpkKetThuc.TabIndex = 2;
            this.dtpkKetThuc.Visible = false;
            // 
            // USP_GetListBillByDateForReportTableAdapter
            // 
            this.USP_GetListBillByDateForReportTableAdapter.ClearBeforeFill = true;
            // 
            // fReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 865);
            this.Controls.Add(this.dtpkKetThuc);
            this.Controls.Add(this.dtpkBatDau);
            this.Controls.Add(this.rpViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanCafeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpViewer;
        private System.Windows.Forms.DateTimePicker dtpkBatDau;
        private System.Windows.Forms.DateTimePicker dtpkKetThuc;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateForReportBindingSource;
        private QuanLyQuanCafeDataSet QuanLyQuanCafeDataSet;
        private QuanLyQuanCafeDataSetTableAdapters.USP_GetListBillByDateForReportTableAdapter USP_GetListBillByDateForReportTableAdapter;
    }
}