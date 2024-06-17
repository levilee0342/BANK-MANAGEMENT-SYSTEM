using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NGANHANG.View
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private frmMain mainForm;
        public frmLogin(frmMain mainForm)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if(!ComboBoxHelper.checkLogin) ComboBoxHelper.PopulateComboBox(cbChiNhanh);
            else ComboBoxHelper.ImportDataDic(cbChiNhanh);
            cbChiNhanh.Select();
            this.mainForm = mainForm;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkDangKy_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the username and password are not empty
                if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || cbChiNhanh.SelectedItem == null)
                {
                    MessageBox.Show("Username, password, and branch selection cannot be empty.");
                    return;
                }

                // Set the login credentials
                Program.mlogin = txtUser.Text;
                Program.password = txtPass.Text;
                // Connect to the database
                int connectionResult = Program.KetNoi();

                if (connectionResult == 1)
                {
                    SqlDataReader reader = Program.ExecSqlDataReader("SP_LayThongTinNhanVien" + "'" + Program.mlogin + "'");
                    if (reader != null && reader.Read())
                    {
                        Program.maNV = reader["MANV"].ToString();
                        Program.mHoten = reader["HOTEN"].ToString();
                        Program.mGroup = reader["TENNHOM"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu trả về từ stored procedure.");
                    }
                    MessageBox.Show("Đăng nhập thành công!");
                    // Cần đóng SqlDataReader sau khi sử dụng
                    reader?.Close();
                    groupControl1.Visible = false;
                    btnOK.Visible = btnCancel.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred 1: " + ex.Message);
            }

;            if (Program.mGroup == "KHACHHANG")
            {
                mainForm.btnDangNhap.Enabled = mainForm.btnTaoTK.Enabled = mainForm.btnNV.Enabled = mainForm.btnKH.Enabled = mainForm.btnTaiKhoan.Enabled = false;
                mainForm.btnDangXuat.Enabled = true;
            }
            else
            {
                mainForm.btnDangXuat.Enabled = mainForm.btnTaoTK.Enabled = mainForm.btnNV.Enabled = mainForm.btnKH.Enabled = mainForm.btnTaiKhoan.Enabled = true;
            }
        }



        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve TENCN from selected item
            string selectedTenCN = cbChiNhanh.SelectedItem.ToString();

            // Retrieve TENSERVER using selected TENCN from the dictionary
            if (ComboBoxHelper.tenCnTenServerDictionary.TryGetValue(selectedTenCN, out string tenServer))
            {
                // Store TENSERVER in a variable or use it as needed
                string selectedTenServer = tenServer;

                // You can also display TENSERVER in another control if needed
                Program.servername = selectedTenServer;
                ComboBoxHelper.tenCN_Help = selectedTenCN;
            }
            else
            {
                MessageBox.Show("TENSERVER not found for selected TENCN.");
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            Program.mloginDN = txtUser.Text;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            Program.passwordDN = txtPass.Text;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void cbChiNhanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Prevent keyboard input
            cbChiNhanh.DroppedDown = true;
        }



        private void cbChiNhanh_Click(object sender, EventArgs e)
        {
            cbChiNhanh.DroppedDown = true;
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}