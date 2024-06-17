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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace NGANHANG.View
{
    public partial class frmKH : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        private SqlDataAdapter adapter;
        public frmKH()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void frmKH_Load(object sender, EventArgs e)
        {
            checkExist.checkFormKH = true;
            ComboBoxHelper.ImportDataDic(cbCN);
            cbCN.SelectedItem = ComboBoxHelper.tenCN_Help;
            dSTK.EnforceConstraints = false;
            this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);

/*            this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TaiKhoanTableAdapter.Fill(this.DS1.TaiKhoan);*/
            colReadOnly(true);

            if (Program.mGroup == "NGANHANG")
            {
                cbCN.Enabled = true; // bật tắt theo phân quyền
                enableButtons(false);
            }
            else if (Program.mGroup == "CHINHANH")
            {
                cbCN.Enabled = false;
                enableButtons(true);
            }
            else
            {
                cbCN.Enabled = false;
                enableButtons(false);
            }
            if (frmMain.undoNhanVien.Count == 0) btnPhucHoi.Enabled = false;
        }
        private void colReadOnly(Boolean check)
        {
            colCMND.OptionsColumn.ReadOnly =
            colHO.OptionsColumn.ReadOnly =
            colTEN.OptionsColumn.ReadOnly =
            colDIACHI.OptionsColumn.ReadOnly =
            colPHAI.OptionsColumn.ReadOnly =
            colNGAYCAP.OptionsColumn.ReadOnly =
            colSODT.OptionsColumn.ReadOnly =
            colMACN.OptionsColumn.ReadOnly = check;

            /*if (Program.mGroup == "NGANHANG")
            {
                cbCN.Enabled = true; // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnMotaikhoan.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH")
            {
                cbCN.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnMotaikhoan.Enabled = true;
            }
            else
            {
                cbCN.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnMotaikhoan.Enabled = false;
            }*/
        }
        private void enableButtons(Boolean check)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnMotaikhoan.Enabled = btnThoat.Enabled
          = btnGhi.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = check;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                vitri = bdsKH.Position;
                panel2.Enabled = true;
                gcKH.Enabled = false;
                bdsKH.AddNew();

                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnMotaikhoan.Enabled = btnThoat.Enabled = false;
                btnGhi.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = true;
                txtCMND.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKH.Position;
            panel2.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnMotaikhoan.Enabled = btnThoat.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcKH.Enabled = false;
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsTK.Count > 0)
            {
                MessageBox.Show("Khách hàng bạn muốn xóa đã lập tài khoản, nên không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa khách hàng này ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bdsKH.RemoveCurrent();
                    this.kHACHHANGTableAdapter.Update(this.dSTK.KHACHHANG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xóa khách hàng. \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (bdsKH.Count == 0)
            {
                btnXoa.Enabled = false;
            }
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHO.Text))
            {
                MessageBox.Show("Họ khách hàng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHO.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTEN.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTEN.Focus();
                return;
            }

            try
            {
                bdsKH.EndEdit();
                bdsKH.ResetCurrentItem();
                if (dSTK.HasChanges())
                {
                    this.kHACHHANGTableAdapter.Update(this.dSTK.KHACHHANG);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("PRIMARY"))
                {
                    MessageBox.Show("CMND bị trùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi ghi nhân viên. Bạn kiểm tra lại thông tin nhân viên trước khi ghi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            btnGhi.Enabled = btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            gcKH.Enabled = true;
            panel2.Enabled = false;
            btnMotaikhoan.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKH.CancelEdit();
            if (btnThem.Enabled == false) bdsKH.Position = vitri;
            gcKH.Enabled = true;
            panel2.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnMotaikhoan.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.kHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);
        }
        private frmMoTaiKhoan frmMoTaiKhoanInstance;

        private void btnMotaikhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMoTaiKhoanInstance == null || frmMoTaiKhoanInstance.IsDisposed)
            {
                GridView gridView1 = (GridView)gcKH.MainView;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    DataRowView selectedRowView = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
                    DataRow selectedRow = selectedRowView.Row;

                    frmMoTaiKhoanInstance = new frmMoTaiKhoan();
                    frmMoTaiKhoanInstance.selectedRow = selectedRow;
                    frmMoTaiKhoanInstance.FormClosed += FrmMoTaiKhoan_FormClosed;
                    frmMoTaiKhoanInstance.Show();
                }
            }
            else
            {
                frmMoTaiKhoanInstance.BringToFront();
            }
        }
        private void FrmMoTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMoTaiKhoanInstance = null;
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void kHACHHANGBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void gcKH_Click(object sender, EventArgs e)
        {

        }
    }
}