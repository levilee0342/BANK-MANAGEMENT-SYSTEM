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
            txtPass.PasswordChar = '*';
            txtUser.KeyPress += new KeyPressEventHandler(txtUser_KeyPress);
            txtPass.KeyPress += new KeyPressEventHandler(txtPass_KeyPress);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || cbChiNhanh.SelectedItem == null)
                {
                    MessageBox.Show("Account or password cannot be left blank!");
                    return;
                }

                Program.mlogin = txtUser.Text;
                Program.password = txtPass.Text;

                int connectionResult = Program.KetNoi();
                if (connectionResult == 1)
                {
                    SqlDataReader reader = Program.ExecSqlDataReader("SP_LAYTHONGTINNHANVIEN" + "'" + Program.mlogin + "'");
                    if (reader != null && reader.Read())
                    {
                        Program.maNV = reader["MANV"].ToString();
                        Program.mHoten = reader["HOTEN"].ToString();
                        Program.mGroup = reader["TENNHOM"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Login error!");
                    }
                    MessageBox.Show("Login successful!");
                    reader?.Close();
                    groupControl1.Visible = false;
                    btnOK.Visible = btnCancel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Incorrect account or password!");
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error!");
            }

;            if (Program.mGroup == "KHACHHANG")
            {
                mainForm.btnTaoTK.Enabled = mainForm.btnNV.Enabled = mainForm.btnKH.Enabled = mainForm.btnTaiKhoan.Enabled  = false;
                mainForm.btnDangXuat.Enabled = mainForm.btnSaokegiaodich.Enabled = true;
            }
            else if(Program.mGroup == "NGANHANG"|| Program.mGroup == "CHINHANH")
            {
                mainForm.btnDangXuat.Enabled = mainForm.btnTaoTK.Enabled = mainForm.btnNV.Enabled = mainForm.btnKH.Enabled = mainForm.btnTaiKhoan.Enabled = mainForm.btnSaokegiaodich.Enabled = mainForm.btnLietketaikhoan.Enabled = mainForm.btnLietkekhachhang.Enabled = true;
            }
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTenCN = cbChiNhanh.SelectedItem.ToString();

            if (ComboBoxHelper.tenCnTenServerDictionary.TryGetValue(selectedTenCN, out string tenServer))
            {
                Program.servername = tenServer;
                Program.maChinhanh = ComboBoxHelper.timMaCN(selectedTenCN);
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
            if (txtUser.Text.Length >= 15 && !char.IsControl(e.KeyChar))
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
            if (txtPass.Text.Length >= 15 && !char.IsControl(e.KeyChar))
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
