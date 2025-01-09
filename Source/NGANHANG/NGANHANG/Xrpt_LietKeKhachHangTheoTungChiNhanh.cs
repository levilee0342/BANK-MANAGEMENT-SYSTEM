using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class Xrpt_LietKeKhachHangTheoTungChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_LietKeKhachHangTheoTungChiNhanh(string macn)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = macn;
            this.sqlDataSource1.Fill();
        }
    }
}
