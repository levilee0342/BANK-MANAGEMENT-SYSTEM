using DevExpress.XtraEditors;
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

namespace NGANHANG.View
{
    public partial class frmRegister : DevExpress.XtraEditors.XtraForm
    {
        private frmMain mainForm;
        string role = Program.mGroup;
        public frmRegister(frmMain mainForm)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.mainForm = mainForm;
            txtPass.PasswordChar = '*';
            txtRePass.PasswordChar = '*';
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtRePass.Text))
                {
                    MessageBox.Show("Username, password, and branch selection cannot be empty.");
                    return;
                }
                if (txtPass.Text != txtRePass.Text)
                {
                    MessageBox.Show("Confirmation password does not match!");
                    txtRePass.Text = "";
                    txtRePass.Focus();
                    return;
                }
                string maNV = txtMANV.Text;
                string login = txtUser.Text;
                string password = txtPass.Text;

                if (rdoNH.Checked)
                {
                    role = "NGANHANG";
                }
                else if (rdoCN.Checked)
                {
                    role = "CHINHANH";
                }
                else if (rdoKH.Checked)
                {
                    role = "KHACHHANG";
                }

                using (SqlConnection connection = new SqlConnection(Program.connstr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_TAOTAIKHOAN", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LGNAME", login);
                        command.Parameters.AddWithValue("@PASS", password);
                        command.Parameters.AddWithValue("@USERNAME", maNV);
                        command.Parameters.AddWithValue("@ROLE", role);

                        SqlParameter returnParameter = command.Parameters.Add("ReturnValue", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            command.ExecuteNonQuery();
                            int result = (int)returnParameter.Value;
                            if (result == 0)
                            {
                                MessageBox.Show("Account created successfully!");
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Errors.Count > 0)
                            {
                                string lastErrorMessage = ex.Errors[ex.Errors.Count - 1].Message;
                                MessageBox.Show(lastErrorMessage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void txtTenDangNhap_MouseClick(object sender, EventArgs e)
        {
            string maNV = txtMANV.Text;
            Console.WriteLine(maNV);
            if (rdoNH.Checked)
            {
                role = "NGANHANG";
            }
            else if (rdoCN.Checked)
            {
                role = "CHINHANH";
            }
            else if (rdoKH.Checked)
            {
                role = "KHACHHANG";
            }

            if (Program.ExecSqlKiemTra1("SP_CHECK_USERNAME", maNV) == 1)
            {
                MessageBox.Show("The user already has an account in the system!");
                txtMANV.Focus();
                return;
            }

            if (role == "KHACHHANG")
            {
                if (Program.ExecSqlKiemTra1("SP_KIEMTRASTK", maNV) == 0)
                {
                    MessageBox.Show("The account number does not exist in the system!");
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (Program.ExecSqlKiemTra1("SP_KIEMTRANHANVIEN", maNV) == 0)
                {
                    MessageBox.Show("The employee ID does not exist in the system!");
                    txtMANV.Focus();
                    return;
                }
                else
                {
                    return;
                }
            }

        }

        private void rdoNH_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(Program.mGroup);
            role = "NGANHANG";
            lbmaNV.Visible = true;
            lbmaKH.Visible = false;
        }

        private void rdoKH_CheckedChanged(object sender, EventArgs e)
        {
            role = "KHACHHANG";
            lbmaNV.Visible = false;
            lbmaKH.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoCN_CheckedChanged(object sender, EventArgs e)
        {
            role = "CHINHANH";
            lbmaNV.Visible = true;
            lbmaKH.Visible = false;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Program.mGroup);
            if (role == "KHACHHANG")
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
                newForm.frmTraCuuKH.cbChiNhanh.Enabled = false;
                newForm.frmTraCuuKH.btnXacNhan3.Visible = false;
            }
            else
            {
                if (newForm.frmNhanVien == null || newForm.frmNhanVien.IsDisposed)
                {
                    newForm.frmNhanVien = new frmNhanVien();
                    checkExist.checkFormNhanVien = false;
                }

                if (!checkExist.checkFormNhanVien)
                {
                    newForm.frmNhanVien.MdiParent = this.mainForm;
                    newForm.frmNhanVien.Show();
                    checkExist.checkFormNhanVien = true;
                }
                else
                {
                    newForm.frmNhanVien.BringToFront();
                }
                newForm.frmNhanVien.btnXacNhan.Visible = true;
                newForm.frmNhanVien.btnHuy.Visible = true;
                newForm.frmNhanVien.cbChiNhanh.Enabled = false;
                newForm.frmNhanVien.Visible_ButtonNV();
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
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
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}