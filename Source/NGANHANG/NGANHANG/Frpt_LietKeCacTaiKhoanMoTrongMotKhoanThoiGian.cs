using DevExpress.XtraReports.UI;
using NGANHANG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NGANHANG
{
    public partial class Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian : Form
    {
        public Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian()
        {
            InitializeComponent();
        }

        public void Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian_Load(object sender, EventArgs e)
        {
            maNV_login.Caption = Program.maNV;
            hoTen_login.Caption = Program.mHoten;
            if (Program.mGroup == "NGANHANG")
            {
                nhom_login.Caption = "Ngân hàng";
            }
            else if (Program.mGroup == "CHINHANH")
            {
                nhom_login.Caption = "Chi nhánh";
            }
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            checkExist.checkReportTaiKhoan = true;
            dSTK.EnforceConstraints = false;
            cbChiNhanh.Items.Add("All branches");

            if (Program.mGroup == "NGANHANG") cbChiNhanh.Enabled = true;
            else cbChiNhanh.Enabled = false;


        }
        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXembaocao_Click(object sender, EventArgs e)
        {
            string tuNgay = DEtungay.Text;
            string denNgay = DEdenngay.Text;
            string maCN = "";
            string tieuDe = "";
            if (cbChiNhanh.Text.Trim() == "All branches")
            {
                maCN = "HAICN";
                tieuDe = "ACCOUNTS OPENED AT ALL BRANCHES";
            }
            else
            {
                maCN = ComboBoxHelper.timMaCN((cbChiNhanh.Text.Trim()));
                tieuDe = "ACCOUNTS OPENED AT BRANCH " + cbChiNhanh.Text.ToUpper(); ;
            }

            Xrpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian rptTaiKhoan = new Xrpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian(tuNgay, denNgay, maCN);
            rptTaiKhoan.lbTieuDe.Text = tieuDe;
            ReportPrintTool print = new ReportPrintTool(rptTaiKhoan);
            print.ShowPreviewDialog();
        }

        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            tAIKHOANGridControl.Visible = true;
            string tuNgay = DEtungay.Text;
            string denNgay = DEdenngay.Text;
            string maCN;
            if (cbChiNhanh.Text.Trim() == "All branches")
            {
                maCN = "HAICN";
            }
            else
            {
                maCN = ComboBoxHelper.timMaCN((cbChiNhanh.Text.Trim()));
            }
            Program.KetNoi();
            try
            {
                string query = string.Empty;
                query = "EXEC SP_LIETKECACTAIKHOANMOTRONGMOTKHOANTHOIGIANCUACHINHANH @NGAYBD, @NGAYKT, @MACN";
                using (SqlCommand command = new SqlCommand(query, Program.conn))
                {
                    command.Parameters.Add(new SqlParameter("@NGAYBD", SqlDbType.DateTime)).Value = tuNgay;
                    command.Parameters.Add(new SqlParameter("@NGAYKT", SqlDbType.DateTime)).Value = denNgay;
                    command.Parameters.Add(new SqlParameter("@MACN", SqlDbType.NChar, 9)).Value = maCN;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    tAIKHOANGridControl.DataSource = null;
                    tAIKHOANGridControl.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void Check_NgayMoTaiKhoan(string tungay, string denngay)
        {
            DateTime dateTungay;
            DateTime dateDenngay;
            if (DateTime.TryParse(tungay, out dateTungay) && DateTime.TryParse(denngay, out dateDenngay))
            {
                if (dateTungay > dateDenngay)
                {
                    MessageBox.Show("Invalid date");
                    return;
                }
            }
        }

        private void DEdenngay_EditValueChanged(object sender, EventArgs e)
        {
            Check_NgayMoTaiKhoan(DEtungay.Text, DEdenngay.Text);
        }

        private void DEtungay_EditValueChanged(object sender, EventArgs e)
        {
            Check_NgayMoTaiKhoan(DEtungay.Text, DEdenngay.Text);
        }
    }
}
