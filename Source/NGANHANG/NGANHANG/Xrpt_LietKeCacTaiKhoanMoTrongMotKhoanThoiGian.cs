using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class Xrpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian : DevExpress.XtraReports.UI.XtraReport
    {
        public string tieuDe = "";
        public Xrpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian(string tuNgay, string denNgay, string maCN)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            DateTime tuNgayDate;
            DateTime denNgayDate;
            if (DateTime.TryParse(tuNgay, out tuNgayDate) && DateTime.TryParse(denNgay, out denNgayDate))
            {
                string formattedTuNgay = tuNgayDate.ToString("dd/MM/yyyy");
                string formattedDenNgay = denNgayDate.ToString("dd/MM/yyyy");

                this.sqlDataSource1.Queries[0].Parameters[0].Value = tuNgay;
                this.sqlDataSource1.Queries[0].Parameters[1].Value = denNgay;
                this.sqlDataSource1.Queries[0].Parameters[2].Value = maCN;
                this.lbTungay.Text = formattedTuNgay;
                this.lbdenngay.Text = formattedDenNgay;

                this.sqlDataSource1.Fill();
            }
            else
            {
                throw new ArgumentException("The date is invalid. Please enter the correct date format.");
            }
        }

    }
}
