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
        public frmRegister(frmMain mainForm)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.mainForm = mainForm;
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
                Program.maNV = txtMANV.Text;
                Program.mlogin = txtUser.Text;
                Program.password = txtPass.Text;
                if (rdoNH.Checked)
                {
                    Program.mGroup = "NGANHANG";
                }
                else if (rdoCN.Checked)
                {
                    Program.mGroup = "CHINHANH";
                }
                else if (rdoKH.Checked)
                {
                    Program.mGroup = "KHACHHANG";
                }
                Program.ExecSqlDataReader("SP_TAOTAIKHOAN" + "'" + Program.mlogin + "', " + "'" + Program.password + "', " + "'" + Program.maNV + "', '" + Program.mGroup + "'");
                MessageBox.Show("Tạo tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred 1: " + ex.Message);
            }
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void rdoNH_CheckedChanged(object sender, EventArgs e)
        {
            lbmaNV.Visible = true;
            lbmaKH.Visible = false;
        }

        private void rdoKH_CheckedChanged(object sender, EventArgs e)
        {
            lbmaNV.Visible = false;
            lbmaKH.Visible = true;
        }
    }
}