
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
using NGANHANG.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian : Form
    {
        private frmMain mainForm;
        String stk, tungay, denngay;
        public Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(frmMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian_Load(object sender, EventArgs e)
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
            else if (Program.mGroup == "KHACHHANG")
            {
                nhom_login.Caption = "Khách hàng";
                int connectionResult = Program.KetNoi();

                if (connectionResult == 1)
                {
                    SqlDataReader reader = Program.ExecSqlDataReader("SP_LAYTHONGTINKHACHHANG" + "'" + Program.maNV + "'");
                    if (reader != null && reader.Read())
                    {
                        Program.mHoten = reader["HOTEN"].ToString();
                    }
                }
                hoTen_login.Caption = Program.mHoten;
            }
            checkExist.checkReportSaoKe = true;
            dSTK.EnforceConstraints = false;
            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsView.RowAutoHeight = true;
            // Sử dụng RepositoryItemMemoEdit
            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
            tAIKHOANGridControl.RepositoryItems.Add(memoEdit);
            var colLOAIGIAODICH = gridView1.Columns["LOAIGD"];
            if (colLOAIGIAODICH != null)
            {
                colLOAIGIAODICH.Width = 250;
                colLOAIGIAODICH.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                colLOAIGIAODICH.ColumnEdit = memoEdit;
            }

        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            if (newForm.frmTraCuuKH == null || newForm.frmTraCuuKH.IsDisposed)
            {
                newForm.frmTraCuuKH = new frmTraCuuKhachHang();
                checkExist.checkFormTraCuuKH = false;
            }

            if (!checkExist.checkFormTraCuuKH)
            {
                newForm.frmTraCuuKH.MdiParent = this.mainForm;
                newForm.frmTraCuuKH.Show();
                checkExist.checkFormTraCuuKH = true;
            }
            else
            {
                newForm.frmTraCuuKH.BringToFront();
            }
            newForm.frmTraCuuKH.btnXacNhan3.Visible = newForm.frmTraCuuKH.btnXacNhan2.Visible = false;
        }

        private void txtSTK_EditValueChanged_1(object sender, EventArgs e)
        {
            newForm.frmTraCuuKH.btnXacNhan2.Visible = false;
        }
        public void Check_SoTaiKhoan(string stk)
        {
            if (!string.IsNullOrEmpty(txtSTK.Text))
            {
                if (Program.mGroup == "NGANHANG" || Program.mGroup == "CHINHANH")
                {
                    if (Program.ExecSqlKiemTra1("SP_KIEMTRASTK", stk) == 0)
                    {
                        MessageBox.Show("Account number does not exist!");
                        txtSTK.Text = "";
                        txtSTK.Focus();
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Account number cannot be empty!");
                txtSTK.Text = "";
                txtSTK.Focus();
                return;
            }
        }
        public void Check_NgaySaoKe(string tungay, string denngay)
        {
            DateTime dateTungay;
            DateTime dateDenngay;
            if (DateTime.TryParse(tungay, out dateTungay) && DateTime.TryParse(denngay, out dateDenngay))
            {
                if (dateTungay > dateDenngay)
                {
                    MessageBox.Show("Invalid date!");
                    return;
                }
            }
        }
        public void DENgayBatDau_MouseClick(object sender, EventArgs e)
        {
            Check_SoTaiKhoan(txtSTK.Text);
        }

        public void DENgayKetThuc_MouseClick(object sender, EventArgs e)
        {
            Check_SoTaiKhoan(txtSTK.Text);
        }


        private void DEtungay_EditValueChanged(object sender, EventArgs e)
        {
            Check_NgaySaoKe(DEtungay.Text, DEdenngay.Text);
            DEtungay.Focus();
        }

        private void DEdenngay_EditValueChanged(object sender, EventArgs e)
        {
            Check_NgaySaoKe(DEtungay.Text, DEdenngay.Text);
            DEdenngay.Focus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXembaocao_Click(object sender, EventArgs e)
        {
            stk = txtSTK.Text;
            tungay = DEtungay.Text;
            denngay = DEdenngay.Text;
            string macn = "";

            string cmd = "SELECT MACN FROM TAIKHOAN WHERE SOTK = @SOTK";
            Program.KetNoi();
            using (SqlCommand command = new SqlCommand(cmd, Program.conn))
            {
                command.Parameters.AddWithValue("@SOTK", stk);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        macn = (reader.GetString(0).Trim() == "BENTHANH" ? "Bến Thành" : "Tân Định");
                        Console.WriteLine(macn);
                    }
                }
            }

            Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian rpt = new Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(stk, tungay, denngay, macn);
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            tAIKHOANGridControl.Visible = true;
            stk = txtSTK.Text;
            tungay = DEtungay.Text;
            denngay = DEdenngay.Text;
            Program.KetNoi();
            try
            {
                string query = string.Empty;
                query = "EXEC SP_SAOKEGIAODICHMOTTAIKHOANTRONGMOTKHOANTHOIGIAN @SOTAIKHOAN, @NGAYBD, @NGAYKT";
                using (SqlCommand command = new SqlCommand(query, Program.conn))
                {
                    command.Parameters.Add(new SqlParameter("@SOTAIKHOAN", SqlDbType.NChar, 9)).Value = stk;
                    command.Parameters.Add(new SqlParameter("@NGAYBD", SqlDbType.DateTime)).Value = tungay;
                    command.Parameters.Add(new SqlParameter("@NGAYKT", SqlDbType.DateTime)).Value = denngay;
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
    }
}

