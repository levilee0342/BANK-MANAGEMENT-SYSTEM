using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian()
        {

        }

        public Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(string stk, string tungay, string denngay)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = stk;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = tungay;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = denngay;
            this.sqlDataSource1.Fill();
            this.lbSTK.Text = stk;
            this.lbTungay.Text = tungay;
            this.lbdenngay.Text = denngay;
            this.lbCn.Text = newForm.frmReportSaoKe.cbChiNhanh.Text;

        }

    }
}
