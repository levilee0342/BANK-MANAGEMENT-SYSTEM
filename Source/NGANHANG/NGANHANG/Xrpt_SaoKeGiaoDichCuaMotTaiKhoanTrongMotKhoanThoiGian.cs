using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian()
        {

        }

        public Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(string stk, string tungay, string denngay, string chinhanh)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = stk;
            DateTime tuNgayDate;
            DateTime denNgayDate;

            if (DateTime.TryParse(tungay, out tuNgayDate) && DateTime.TryParse(denngay, out denNgayDate))
            {
                string formattedTuNgay = tuNgayDate.ToString("dd/MM/yyyy");
                string formattedDenNgay = denNgayDate.ToString("dd/MM/yyyy");

                this.sqlDataSource1.Queries[0].Parameters[1].Value = tungay;
                this.sqlDataSource1.Queries[0].Parameters[2].Value = denngay;

                this.lbSTK.Text = stk;
                this.lbTungay.Text = formattedTuNgay;
                this.lbdenngay.Text = formattedDenNgay;
                this.lbCn.Text = chinhanh;

                this.sqlDataSource1.Fill();
            }
            else
            {
                throw new ArgumentException("Invalid date. Please enter the correct date format.");
            }
        }


    }
}
