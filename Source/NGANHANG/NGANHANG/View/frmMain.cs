
﻿using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using NGANHANG.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace NGANHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Stack<String> undoNhanVien = new Stack<String>();
        public static Stack<String> redoNhanVien = new Stack<String>();
        public static Stack<String> temp_undoNhanVien = new Stack<String>();
        public static Stack<String> temp_redoNhanVien = new Stack<String>();

        public static Stack<String> undoKhachHang = new Stack<String>();
        public static Stack<String> redoKhachHang = new Stack<String>();
        public static Stack<String> temp_undoKhachHang = new Stack<String>();
        public static Stack<String> temp_redoKhachHang = new Stack<String>();

        public static Stack<String> undoTK = new Stack<String>();
        public static Stack<String> redoTK = new Stack<String>();
        public static Stack<String> temp_undoTK = new Stack<String>();
        public static Stack<String> temp_redoTK = new Stack<String>();
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            newForm.frmTaiKhoan = new frmTaiKhoan(this);
            newForm.frmRegister = new frmRegister(this);
            newForm.frmLogin = new frmLogin(this);
            newForm.frmReportSaoKe = new Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(this);
        }
        public void Off_Button()
        {
            btnGui.Enabled = false;
            btnRut.Enabled = false;
            btnChuyen.Enabled = false;

        }
        
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//Login
            Off_Button();
            newForm.frmLogin.MdiParent = this;
            if (!checkExist.checkFormLogin)
            {
                newForm.frmLogin.Show();
            } 
            else newForm.frmLogin.BringToFront();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//Logout
            newForm.frmLogin.Close(); 
            newForm.frmRegister.Close(); 
            newForm.frmNhanVien.Close(); 
            newForm.frmKH.Close(); 
            newForm.frmTaiKhoan.Close();
            newForm.frmReportSaoKe.Close();
            newForm.frmReportTaiKhoan.Close();
            newForm.frmTraCuuKH.Close();
            newForm.frmReportLietKeKH.Close();

            newForm.frmLogin.MdiParent = this;
            newForm.frmLogin = new frmLogin(this);
            newForm.frmRegister = new frmRegister(this);
            newForm.frmNhanVien = new frmNhanVien();
            newForm.frmKH = new frmKH();
            newForm.frmTaiKhoan = new frmTaiKhoan(this);
            newForm.frmReportSaoKe = new Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(this);
            newForm.frmReportTaiKhoan = new Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian();
            newForm.frmReportLietKeKH = new Frpt_Lietkekhachhangtheotungchinhanh();
            newForm.frmTraCuuKH = new frmTraCuuKhachHang();

            checkExist.logOut();
            undoNhanVien.Clear();
            redoNhanVien.Clear();
            temp_undoNhanVien.Clear();
            temp_redoNhanVien.Clear();

            undoKhachHang.Clear();
            redoKhachHang.Clear();
            temp_undoKhachHang.Clear();
            temp_redoKhachHang.Clear();

            undoTK.Clear();
            redoTK.Clear();
            temp_undoTK.Clear();
            temp_redoTK.Clear();

            frmNhanVien.f_undoNhanVien.Clear();
            frmNhanVien.f_redoNhanVien.Clear();

            frmKH.f_undoKH.Clear();
            frmKH.f_redoKH.Clear();

            frmTaiKhoan.f_undoTK.Clear();
            frmTaiKhoan.f_redoTK.Clear();


            btnDangXuat.Enabled = btnTaoTK.Enabled = btnNV.Enabled = btnKH.Enabled = btnTaiKhoan.Enabled 
            = btnGui.Enabled = btnRut.Enabled = btnChuyen.Enabled 
            = btnSaokegiaodich.Enabled = btnLietketaikhoan.Enabled = btnLietkekhachhang.Enabled = false;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//Tao tai khoan
            newForm.frmNhanVien.Close();
            newForm.frmTraCuuKH.Close();
            Console.WriteLine(Program.mGroup);
            Off_Button();
            if (newForm.frmRegister == null || newForm.frmRegister.IsDisposed)
            {
                newForm.frmRegister = new frmRegister(this);
                checkExist.checkFormRegister = false;
            }
            if (!checkExist.checkFormRegister)
            {
                newForm.frmRegister.MdiParent = this;
                newForm.frmRegister.Show();
                checkExist.checkFormRegister = true;
            }
            else
            {
                newForm.frmRegister.BringToFront();
            }
            if (Program.mGroup == "NGANHANG")
            {
                newForm.frmRegister.rdoNH.Checked = true;
                newForm.frmRegister.rdoCN.Enabled = false;
                newForm.frmRegister.rdoKH.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH")
            {
                newForm.frmRegister.rdoCN.Checked = true;
                newForm.frmRegister.rdoNH.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid role!");
            }
            newForm.frmRegister.txtMANV.Clear();
            newForm.frmRegister.txtMANV.Focus();
        }


        private void btnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {// Tai khoan form
            newForm.frmNhanVien.Close();
            if (Program.mGroup == "NGANHANG")
            {
                btnGui.Enabled = btnRut.Enabled = btnChuyen.Enabled = false;
                newForm.frmTaiKhoan.btnXoa.Enabled = newForm.frmTaiKhoan.btnUndo.Enabled = newForm.frmTaiKhoan.btnRedo.Enabled = newForm.frmTaiKhoan.btnReload.Enabled = false;
            }
            else
            {
                btnGui.Enabled = btnRut.Enabled = btnChuyen.Enabled = true;
            }
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.ChangeClick_TaiKhoan();
            newForm.frmTaiKhoan.MdiParent = this;
            if (!checkExist.checkFormTaiKhoan) newForm.frmTaiKhoan.Show();
            else newForm.frmTaiKhoan.BringToFront();
            newForm.frmTaiKhoan.ReloadData();
            if (frmTaiKhoan.f_stk != null)
            {
                int rowHandle = newForm.frmTaiKhoan.GetRowHandleBySTK(newForm.frmTaiKhoan.gridView1, frmTaiKhoan.f_stk);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    newForm.frmTaiKhoan.gridView1.FocusedRowHandle = rowHandle;
                }
            }
            else return;

        }

        private void btnGui_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.Show();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.btnXoa.Enabled = newForm.frmTaiKhoan.btnUndo.Enabled = newForm.frmTaiKhoan.btnRedo.Enabled = newForm.frmTaiKhoan.btnReload.Enabled = false;
            newForm.frmTaiKhoan.lbGuiTien.Visible = newForm.frmTaiKhoan.lbSoTienGui.Visible = newForm.frmTaiKhoan.txtSoTienGui.Visible = newForm.frmTaiKhoan.btnXacNhanGui.Visible = newForm.frmTaiKhoan.btnHuy.Visible = true;
            newForm.frmTaiKhoan.txtSoTienGui.Text = "";
        }
        private void btnRut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.Show();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.btnXoa.Enabled = newForm.frmTaiKhoan.btnUndo.Enabled = newForm.frmTaiKhoan.btnRedo.Enabled = newForm.frmTaiKhoan.btnReload.Enabled = false;
            newForm.frmTaiKhoan.lbRutTien.Visible = newForm.frmTaiKhoan.lbSoTienRut.Visible = newForm.frmTaiKhoan.txtSoTienRut.Visible = newForm.frmTaiKhoan.btnXacNhanRut.Visible = newForm.frmTaiKhoan.btnHuy.Visible = true;
            newForm.frmTaiKhoan.txtSoTienRut.Text = "";
        }
        private void btnChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.Show();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.btnXoa.Enabled = newForm.frmTaiKhoan.btnUndo.Enabled = newForm.frmTaiKhoan.btnRedo.Enabled = newForm.frmTaiKhoan.btnReload.Enabled = false;
            newForm.frmTaiKhoan.lbChuyenTien.Visible = newForm.frmTaiKhoan.lbSTKNhan.Visible = newForm.frmTaiKhoan.lbSoTienChuyen.Visible = newForm.frmTaiKhoan.txtSTKNhan.Visible = newForm.frmTaiKhoan.txtSoTienChuyen.Visible = newForm.frmTaiKhoan.btnXacNhanChuyen.Visible = newForm.frmTaiKhoan.btnHuy.Visible = true;
            newForm.frmTaiKhoan.txtSTKNhan.Text = newForm.frmTaiKhoan.txtSoTienChuyen.Text = "";
        }

        private void btnNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//Nhan Vien form
            Off_Button();
            if (newForm.frmNhanVien == null || newForm.frmNhanVien.IsDisposed)
            {
                newForm.frmNhanVien = new frmNhanVien();
                checkExist.checkFormNhanVien = false;
            }

            if (!checkExist.checkFormNhanVien)
            {
                newForm.frmNhanVien.MdiParent = this;
                newForm.frmNhanVien.Show();
                checkExist.checkFormNhanVien = true;
            }
            else
            {
                newForm.frmNhanVien.BringToFront();
            }
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//Khach hang form 
            newForm.frmNhanVien.Close();
            Off_Button();

            if (newForm.frmKH == null || newForm.frmKH.IsDisposed)
            {
                newForm.frmKH = new frmKH();
                checkExist.checkFormKH = false;
            }

            if (!checkExist.checkFormKH)
            {
                newForm.frmKH.MdiParent = this;
                newForm.frmKH.Show();
                checkExist.checkFormKH = true;
            }
            else
            {
                newForm.frmKH.BringToFront();
            }
            if (Program.mGroup == "CHINHANH")
            {
                newForm.frmKH.cmbCN.Enabled = false;
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {// Liet ke khach hang form
            newForm.frmNhanVien.Close();
            Off_Button();
            if (Program.mGroup == "CHINHANH")
            {
                newForm.frmReportLietKeKH.cbChiNhanh.Enabled = false;
            }
            newForm.frmReportLietKeKH.MdiParent = this;
            if (!checkExist.checkReportKH) newForm.frmReportLietKeKH.Show();
            else newForm.frmReportLietKeKH.BringToFront();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {// Sao ke giao dich form
            newForm.frmNhanVien.Close();
            newForm.frmTraCuuKH.Close();
            Off_Button();
            newForm.frmReportSaoKe.MdiParent = this;
            if (!checkExist.checkReportSaoKe) newForm.frmReportSaoKe.Show();
            else newForm.frmReportSaoKe.BringToFront();
            newForm.frmReportSaoKe.txtSTK.Text = "";
            newForm.frmReportSaoKe.DEtungay.Text = "";
            newForm.frmReportSaoKe.DEdenngay.Text = "";
            newForm.frmReportSaoKe.txtSTK.Focus();
            if (Program.mGroup == "KHACHHANG")
            {
                newForm.frmReportSaoKe.txtSTK.Text = Program.maNV;
                newForm.frmReportSaoKe.txtSTK.Enabled = false;
                newForm.frmReportSaoKe.btnxem.Enabled = false;
            }
            newForm.frmReportSaoKe.tAIKHOANGridControl.Visible = false;
        }

        private void btnLietketaikhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {// Liet ke tai khoan form
            newForm.frmNhanVien.Close();
            Off_Button();
            newForm.frmReportTaiKhoan.MdiParent = this;
            if (!checkExist.checkReportTaiKhoan) newForm.frmReportTaiKhoan.Show();
            else newForm.frmReportTaiKhoan.BringToFront();
            newForm.frmReportTaiKhoan.tAIKHOANGridControl.Visible = false;
            newForm.frmReportTaiKhoan.DEtungay.Text = "";
            newForm.frmReportTaiKhoan.DEdenngay.Text = "";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

    }
}
