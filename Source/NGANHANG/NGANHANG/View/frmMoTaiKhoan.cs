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


namespace NGANHANG.View
{
    public partial class frmMoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public DataRow selectedRow { get; set; }
        public frmMoTaiKhoan()
        {
            InitializeComponent();
        }

        private void MoTaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSTK.KHACHHANG' table. You can move, or remove it, as needed.
            /*this.kHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);*/
            /*            // TODO: This line of code loads data into the 'dSTK.TAIKHOAN' table. You can move, or remove it, as needed.
                        this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);
                        // TODO: This line of code loads data into the 'dSTK.TAIKHOAN' table. You can move, or remove it, as needed.
                        this.tAIKHOANTableAdapter1.Fill(this.dSTK.TAIKHOAN);*/
            dSTK.EnforceConstraints = false;
            this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);

            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);

            txtCMND.Enabled = txtDIACHI.Enabled = dteNGAYCAP.Enabled = txtHO.Enabled = txtTEN.Enabled
                = cmbPHAI.Enabled = txtSODT.Enabled = txtMACN.Enabled = false;
            SetData(selectedRow);
        }
        public void SetData(DataRow selectedRow)
        {
            txtCMND.Text = selectedRow["CMND"].ToString();
            dteNGAYCAP.Text = selectedRow["NGAYCAP"].ToString();
            txtHO.Text = selectedRow["HO"].ToString();
            txtTEN.Text = selectedRow["TEN"].ToString();
            cmbPHAI.Text = selectedRow["PHAI"].ToString();
            txtSODT.Text = selectedRow["SODT"].ToString();
            txtDIACHI.Text = selectedRow["DIACHI"].ToString();
            txtMACN.Text = selectedRow["MACN"].ToString();
        }
        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void KiemTraKhachHang(String cmnd)
        {
            DataRow[] rows = dSTK.KHACHHANG.Select("CMND = '" + cmnd + "'");
            if (rows.Length > 0)
            {
                DataRow selectedRow = rows[0];
                SetData(selectedRow);
                txtNhapCMND.Enabled = false;
            }
            else
            {
                MessageBox.Show("CMND chưa tồn tại.Bạn có thể đăng ký mở tài khoản mới.");
                txtNhapCMND.Enabled = true;
            }
        }
        public void ThemTaiKhoan(string soTK, string CMND, string soDu, string maCN)
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                Program.KetNoi();

                string cmd = "INSERT INTO TAIKHOAN (SOTK, CMND, SODU, MACN, NGAYMOTK) VALUES ('" + soTK + "', '" + CMND + "', '" + soDu + "', '" + maCN + "',getdate()";
                Program.ExecSqlNonQuery(cmd);
                MessageBox.Show("Tài khoản đã được thêm thành công vào cơ sở dữ liệu!");

                // Đóng kết nối sau khi thêm dữ liệu thành công
                Program.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm tài khoản: " + ex.Message);
            }
        }
        private bool Check_SOTK(string soTK, string CMND)
        {
            if (Regex.IsMatch(txtSOTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txtSOTK.Text = "";
                txtSOTK.Focus();
                return false;
            }
            else
            {
                if (Program.ExecSqlKiemTra1("SP_KIEMTRASTK", txtSOTK.Text) == 1)
                {
                    MessageBox.Show("Số tài khoản đã tồn tại");
                    txtSOTK.Text = "";
                    txtSOTK.Focus();
                    return false;
                }
                else
                {
                    txtCMND.Focus();
                    return true;
                }
            }
        }
        private void btKT_Click(object sender, EventArgs e)
        {
            KiemTraKhachHang(txtNhapCMND.Text.Trim());
        }

        private void btXN_Click(object sender, EventArgs e)
        {
            string soTK = txtSOTK.Text.Trim();
            string CMND = txtCMND.Text.Trim();
            string soDu = txtSODU.Text.Trim();
            string maCN = txtMACN.Text.Trim();
            if (!Check_SOTK(soTK, CMND))
            {
                return;
            }
            ThemTaiKhoan(soTK, CMND, soDu, maCN);
            this.Close();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tAIKHOANBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void tAIKHOANBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }
    }
}