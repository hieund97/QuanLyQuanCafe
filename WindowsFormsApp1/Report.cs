using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fReport : Form
    {
        public fReport(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            dtpkBatDau.Value = fromDate;
            dtpkKetThuc.Value = toDate;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet.USP_GetListBillByDateForReport' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateForReportTableAdapter.Fill(this.QuanLyQuanCafeDataSet.USP_GetListBillByDateForReport, dtpkBatDau.Value, dtpkKetThuc.Value);

            this.rpViewer.RefreshReport();
        }
    }
}
