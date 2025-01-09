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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace NGANHANG.View
{
    public partial class frmMoTK : Form
    {
        string cmnd;
        public DataRow selectedRow { get; set; }
        public frmMoTK()
        {
            InitializeComponent();
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);
        }

        private void frmMoTK_Load(object sender, EventArgs e)
        {
            dSTK.EnforceConstraints = false;
            this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);

            this.TAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);
            SetData(selectedRow);
            textFieldReadOnly();
        }
        public void SetData(DataRow selectedRow)
        {
            txtCMND.Text =txtCMND1.Text= selectedRow["CMND"].ToString();
            deNGAYCAP.Text = Convert.ToDateTime(selectedRow["NGAYCAP"]).ToString("yyyy-MM-dd");
            txtHO.Text = selectedRow["HO"].ToString();
            txtTEN.Text = selectedRow["TEN"].ToString();
            txtPHAI.Text = selectedRow["PHAI"].ToString();
            txtSODT.Text = selectedRow["SODT"].ToString();
            txtDIACHI.Text = selectedRow["DIACHI"].ToString();
            txtMACN.Text = txtMACN1.Text = selectedRow["MACN"].ToString();
            txtSOTK.Text = txtSODU.Text = null;
            deNGAYMOTK.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void textFieldReadOnly()
        {
            txtCMND.ReadOnly =
            txtHO.ReadOnly =
            txtTEN.ReadOnly =
            txtDIACHI.ReadOnly =
            txtSODT.ReadOnly =
            deNGAYCAP.ReadOnly =
            txtPHAI.ReadOnly = 
            txtMACN.ReadOnly =
            txtMACN1.ReadOnly =
            deNGAYMOTK.ReadOnly = true;

        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtSOTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Account number must be numeric");
                txtSOTK.Text = "";
                txtSOTK.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlKiemTra1("SP_KIEMTRASTK", txtSOTK.Text) == 1)
                {
                    MessageBox.Show("Account number already exists");
                    txtSOTK.Text = "";
                    txtSOTK.Focus();
                    return;
                }
            }
            if (!long.TryParse(txtSODU.Text, out long sodu))
            {
                MessageBox.Show("Balance must be numeric");
                txtSODU.Text = "";
                txtSODU.Focus();
                return;
            }
            String cmd = "INSERT INTO LINK0.NGANHANG.DBO.TAIKHOAN (SOTK, CMND, SODU, MACN, NGAYMOTK) VALUES ('" + txtSOTK.Text + "', '" + txtCMND.Text + "', '" + txtSODU.Text + "', '" + txtMACN1.Text + "', '" + deNGAYMOTK.Text + "')";
            frmTaiKhoan.f_undoTK.Push(txtSOTK.Text);
            frmTaiKhoan.f_stk = txtSOTK.Text;
            if (Program.ExecSqlNonQuery(cmd) == 0)
            {
                MessageBox.Show("Account created successfully!");
                frmTaiKhoan.cancelTempStack();
                String undo = "DELETE LINK0.NGANHANG.DBO.TAIKHOAN WHERE SOTK = '" + txtSOTK.Text + "'";
                frmMain.undoTK.Push(undo);
                frmMain.redoTK.Push(cmd);
                this.Close();
            }
            newForm.frmTaiKhoan.Refresh();
            this.Close();
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCMND1_EditValueChanged(object sender, EventArgs e)
        {
            cmnd = txtCMND1.Text;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtCMND1.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Identity card number must be numeric");
                txtCMND1.Text = "";
                txtCMND1.Focus();
                return;
            }

            int connectionResult = Program.KetNoi();

            if (connectionResult == 1)
            {
                SqlDataReader reader = Program.ExecSqlDataReader("SP_THONGTINKHACHHANG" + "'" + cmnd + "'");
                if (reader != null && reader.Read())
                {
                    txtCMND.Text = reader["CMND"].ToString();
                    txtHO.Text = reader["HO"].ToString();
                    txtTEN.Text = reader["TEN"].ToString();
                    txtDIACHI.Text = reader["DIACHI"].ToString();
                    txtPHAI.Text = reader["PHAI"].ToString();
                    txtSODT.Text = reader["SODT"].ToString();
                    deNGAYCAP.Text = reader["NGAYCAP"].ToString();
                    txtMACN.Text = reader["MACN"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer not found!");
                }
                reader.Close();
            }
        }

        private void txtSOTK_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
