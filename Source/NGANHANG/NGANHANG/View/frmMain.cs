using NGANHANG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;


namespace NGANHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Stack<String> undoNhanVien = new Stack<String>();

        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            newForm.frmTaiKhoan = new frmTaiKhoan(this);
            newForm.frmRegister = new frmRegister(this);
            newForm.frmLogin = new frmLogin(this);
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

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmLogin.MdiParent = this;
            if (!checkExist.checkFormLogin) newForm.frmLogin.Show();
            else newForm.frmLogin.BringToFront();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmLogin.Close();
            newForm.frmRegister.Close();
            newForm.frmNhanVien.Close();
            newForm.frmKH.Close();
            newForm.frmTaiKhoan.Close(); 
            btnDangXuat.Enabled = btnTaoTK.Enabled = btnNV.Enabled = btnKH.Enabled = btnTaiKhoan.Enabled = btnGui.Enabled = btnRut.Enabled = btnChuyen.Enabled;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "NGANHANG")
            {
                newForm.frmRegister.rdoNH.Checked = true;
                newForm.frmRegister.rdoCN.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH")
            {
                newForm.frmRegister.rdoCN.Checked = true;
                newForm.frmRegister.rdoNH.Enabled = false;
            }
            else
            {
                MessageBox.Show("Vai trò không hợp lệ!");
            }
            newForm.frmRegister.MdiParent = this;
            if (!checkExist.checkFormRegister) newForm.frmRegister.Show();
            else newForm.frmRegister.BringToFront();
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnGui.Enabled = true;
            barbtnRut.Enabled = true;
            barbtnChuyen.Enabled = true;
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.btnGhi.Enabled = false;
            newForm.frmTaiKhoan.Show();
        }


        private void btnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.mGroup == "NGANHANG")
            {
                btnGui.Enabled = btnRut.Enabled = btnChuyen.Enabled = false;
            }
            else
            {
                btnGui.Enabled = btnRut.Enabled = btnChuyen.Enabled = true;
            }
            newForm.frmTaiKhoan.ChangeEnable_TT_Tat();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.ChangeClick_TaiKhoan();
            newForm.frmTaiKhoan.MdiParent = this;
            if (!checkExist.checkFormTaiKhoan) newForm.frmTaiKhoan.Show();
            else newForm.frmTaiKhoan.BringToFront();
            
            newForm.frmTaiKhoan.ReloadData();
        }

        private void btnGui_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.Show();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.lbGuiTien.Visible = newForm.frmTaiKhoan.lbSoTienGui.Visible = newForm.frmTaiKhoan.txtSoTienGui.Visible = newForm.frmTaiKhoan.btnXacNhanGui.Visible = newForm.frmTaiKhoan.btnHuy.Visible = true;
        }
        private void btnRut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.Show();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.lbRutTien.Visible = newForm.frmTaiKhoan.lbSoTienRut.Visible = newForm.frmTaiKhoan.txtSoTienRut.Visible = newForm.frmTaiKhoan.btnXacNhanRut.Visible = newForm.frmTaiKhoan.btnHuy.Visible = true;
        }
        private void btnChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmTaiKhoan.MdiParent = this;
            newForm.frmTaiKhoan.Show();
            newForm.frmTaiKhoan.ChangeVisible();
            newForm.frmTaiKhoan.lbChuyenTien.Visible = newForm.frmTaiKhoan.lbSTKNhan.Visible = newForm.frmTaiKhoan.lbSoTienChuyen.Visible = newForm.frmTaiKhoan.txtSTKNhan.Visible = newForm.frmTaiKhoan.txtSoTienChuyen.Visible = newForm.frmTaiKhoan.btnXacNhanChuyen.Visible = newForm.frmTaiKhoan.btnHuy.Visible = newForm.frmTaiKhoan.btnCheck.Visible = true;
        }

        private void btnNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmNhanVien.MdiParent = this;
            if (!checkExist.checkFormNhanVien) newForm.frmNhanVien.Show();
            else newForm.frmNhanVien.BringToFront();
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmKH.MdiParent = this;
            if (!checkExist.checkFormKH) newForm.frmKH.Show();
            else newForm.frmKH.BringToFront();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newForm.frmReportSaoKe.MdiParent = this;
            if (!checkExist.checkReportSaoKe) newForm.frmReportSaoKe.Show();
            else newForm.frmReportSaoKe.BringToFront();
/*            if (Program.mGroup == "CHINHANH")
            {
                newForm.frmKH.cbCN.Enabled = false;
            }*/
        }
    }
}
