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
    public partial class frmTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        String stk, stknhan, sotien;
        String stkOld;
        private frmMain mainForm;
        public frmTaiKhoan(frmMain mainForm)
        {
            InitializeComponent();
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            this.WindowState = FormWindowState.Maximized;
            this.mainForm = mainForm;
        }
        public void ReloadData()
        {
            // Load lại dữ liệu tài khoản
            this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);
        }
        public void ChangeClick_TaiKhoan()
        {
            gridView1.OptionsBehavior.ReadOnly = true;
            lbTTTK.Enabled = true;
            ChangeEnable_GD_Bat();
            gcTK.Enabled = true;
            lbTTTK.Visible = true;
            btnGhi.Enabled = btnPhuchoi.Enabled = false;
        }
        public void ChangeVisible()
        {
            lbRutTien.Visible = lbSoTienRut.Visible = txtSoTienRut.Visible = btnXacNhanRut.Visible = false;
            lbChuyenTien.Visible = lbSTKNhan.Visible = lbSoTienChuyen.Visible = txtSoTienChuyen.Visible = txtSTKNhan.Visible = btnXacNhanChuyen.Visible = btnCheck.Visible = false;
            lbGuiTien.Visible = lbSoTienGui.Visible = txtSoTienGui.Visible = btnXacNhanGui.Visible = btnHuy.Visible = false;
        }
        public void ChangeEnable_TT()
        {
            txtSTK.Enabled = txtCMND.Enabled = txtSoDu.Enabled = txtCN.Enabled = DENgayMTK.Enabled = true;
        }
        public void ChangeEnable_TT_Tat()
        {
            txtSTK.Enabled = false;
            txtCMND.Enabled = false;
            txtSoDu.Enabled = false;
            txtCN.Enabled = false;
            DENgayMTK.Enabled = false;
        }
        public void ChangeEnable_GD_Tat()
        {
            lbRutTien.Enabled = lbSoTienRut.Enabled = txtSoTienRut.Enabled = btnXacNhanRut.Enabled = false;
            lbChuyenTien.Enabled = lbSTKNhan.Enabled = lbSoTienChuyen.Enabled = txtSoTienChuyen.Enabled = txtSTKNhan.Enabled = btnXacNhanChuyen.Enabled = false;
            lbGuiTien.Enabled = lbSoTienGui.Enabled = txtSoTienGui.Enabled = btnXacNhanGui.Enabled = false;
            btnHuy.Enabled = true;
        }
        public void ChangeEnable_GD_Bat()
        {
            lbRutTien.Enabled = lbSoTienRut.Enabled = txtSoTienRut.Enabled = btnXacNhanRut.Enabled = true;
            lbChuyenTien.Enabled = lbSTKNhan.Enabled = lbSoTienChuyen.Enabled = txtSoTienChuyen.Enabled = txtSTKNhan.Enabled = btnXacNhanChuyen.Enabled = true;
            lbGuiTien.Enabled = lbSoTienGui.Enabled = txtSoTienGui.Enabled = btnXacNhanGui.Enabled = true;
            btnHuy.Enabled = true;
        }
    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tAIKHOANBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            maNV_login.Caption = Program.maNV;
            hoTen_login.Caption = Program.mHoten;
            if(Program.mGroup == "NGANHANG")
            {
                nhom_login.Caption = "Ngân hàng";
            }
            else if(Program.mGroup == "CHINHANH")
            {
                nhom_login.Caption = "Chi nhánh";
            }
            checkExist.checkFormTaiKhoan = true;
            dSTK.EnforceConstraints = false;
            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);

        }

        private void mACNTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra nếu form đã được khởi tạo
            if (mainForm != null)
            {
                // Tạo một instance mới của frmKH
                frmKH newfrmKH = new frmKH();

                // Gán frmMain làm MDI parent cho frmKH
                newfrmKH.MdiParent = mainForm;

                // Hiển thị frmKH
                newfrmKH.Show();
            }

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbGuiTien_Click(object sender, EventArgs e)
        {

        }

        private void btnXacNhanGui_Click(object sender, EventArgs e)
        {
            if(!long.TryParse(txtSoTienGui.Text, out long soTienGui))
            {
                MessageBox.Show("Nhập sai định dạng, số tiền gửi phải là số lớn hơn 100000!");
                txtSoTienGui.Text = "";
                txtSoTienGui.Focus();
                return;
            }
            else if (Int64.Parse(txtSoTienGui.Text) < 100000)
            {
                MessageBox.Show("Số tiền gửi phải lớn hơn 100000");
                txtSoTienGui.Text = "";
                txtSoTienGui.Focus();
                return;
            }
            try
            {
                Program.ExecSqlDataReader("SP_GIAODICHGUIRUT" + "'GT', '" + sotien + "', '" + stk + "', '" + Program.maNV + "'");
                MessageBox.Show("Giao dịch gửi tiền thành công!");
                txtSoTienGui.Text = "";
                // Sau khi giao dịch thành công, reload dữ liệu trên frmTaiKhoan
                frmTaiKhoan f = Application.OpenForms.OfType<frmTaiKhoan>().FirstOrDefault();
                if (f != null)
                {
                    f.ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btnXacNhanRut_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtSoTienRut.Text, out long soTienGui))
            {
                MessageBox.Show("Nhập sai định dạng, số tiền rút phải là số lớn hơn 100000!");
                txtSoTienRut.Text = "";
                txtSoTienRut.Focus();
                return;
            }
            else if (Int64.Parse(txtSoTienRut.Text) < 100000)
            {
                MessageBox.Show("Số tiền gửi phải lớn hơn 100000");
                txtSoTienRut.Text = "";
                txtSoTienRut.Focus();
                return;
            }
            try
            {
                Program.ExecSqlDataReader("SP_GIAODICHGUIRUT" + "'RT', '" + sotien + "', '" + stk + "', '" + Program.maNV + "'");
                MessageBox.Show("Giao dịch rút tiền thành công!");
                txtSoTienRut.Text = "";
                // Sau khi giao dịch thành công, reload dữ liệu trên frmTaiKhoan
                frmTaiKhoan f = Application.OpenForms.OfType<frmTaiKhoan>().FirstOrDefault();
                if (f != null)
                {
                    f.ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btnXacNhanChuyen_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtSoTienChuyen.Text, out long soTienGui))
            {
                MessageBox.Show("Nhập sai định dạng, số tiền chuyển phải là số!");
                txtSoTienRut.Text = "";
                txtSoTienRut.Focus();
                return;
            }
            try
            {
                Program.ExecSqlDataReader("SP_GIAODICHCHUYENTIEN" + "'" + stknhan + "', " + "'" + stk + "', " + "'" + sotien + "', '" + Program.maNV + "'");
                MessageBox.Show("Giao dịch chuyển tiền thành công!");

                // Sau khi giao dịch thành công, reload dữ liệu trên frmTaiKhoan
                frmTaiKhoan f = Application.OpenForms.OfType<frmTaiKhoan>().FirstOrDefault();
                if (f != null)
                {
                    f.ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void txtSoTienChuyen_EditValueChanged(object sender, EventArgs e)
        {
            sotien = txtSoTienChuyen.Text;
        }

        private void pnGiaoDich_Paint(object sender, PaintEventArgs e)
        {
        }

        private void sOTKTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            stk = txtSTK.Text;
        }
        private void txtSoTienGui_EditValueChanged(object sender, EventArgs e)
        {
            sotien = txtSoTienGui.Text;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ReloadData();
            ChangeClick_TaiKhoan();
            ChangeEnable_TT_Tat();
            ChangeVisible();
        }

        private void lbChuyenTien_Click(object sender, EventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stk = txtSTK.Text;
            
            if (Program.ExecSqlKiemTra1("SP_KIEMTRATAIKHOAN", stk) == 1)
            {
                MessageBox.Show("Tài khoản này đã có thực hiện giao dịch hoặc còn số dư trong tài khoản, không thể xóa!");
                return;
            }
            else
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Xác nhận xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra xem người dùng đã xác nhận hay không
                if (result == DialogResult.Yes)
                {
                    Program.KetNoi();
                    string cmd = "DELETE FROM TAIKHOAN WHERE SOTK = '" + stk + "'";
                    Program.ExecSqlNonQuery(cmd);
                    MessageBox.Show("Tài khoản đã được xóa thành công!");
                }
                else return;
            }
        }

        private void gcTK_Click(object sender, EventArgs e)
        {
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtSTK.Focus();
            stkOld = txtSTK.Text;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            ChangeEnable_GD_Tat();
            ChangeEnable_TT();
            btnHuy.Enabled = false;
        }

        private void txtSoDu_EditValueChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtSTKNhan.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txtSTKNhan.Text = "";
                txtSTKNhan.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlKiemTra1("SP_KIEMTRASTK", txtSTKNhan.Text) == 0)
                {
                    MessageBox.Show("Số tài khoản không tồn tại");
                    txtSTKNhan.Text = "";
                    txtSTKNhan.Focus();
                    return;
                }
                else txtSoTienChuyen.Focus();
            }
        }

        private void txtSoTienRut_EditValueChanged(object sender, EventArgs e)
        {
            sotien = txtSoTienRut.Text;
        }
        private void txtSTKNhan_EditValueChanged(object sender, EventArgs e)
        {
            stknhan = txtSTKNhan.Text;
        }

    }
}