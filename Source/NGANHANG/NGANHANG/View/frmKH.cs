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
using DevExpress.XtraGrid;

namespace NGANHANG.View
{
    public partial class frmKH : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        private SqlDataAdapter adapter;
        private int valueSaved = 0;
        private bool checkLuu = false;
        private string undoInsert, undoUpdate, undoDelete;
        public static int redoTimesKhachHang = 0;
        String f_makh;
        public static Stack<String> f_undoKH = new Stack<String>();
        public static Stack<String> f_redoKH = new Stack<String>();
        public frmKH()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmKH_Load(object sender, EventArgs e)
        {
            try
            {
                checkExist.checkFormKH = true;
                ComboBoxHelper.ImportDataDic(cmbCN);

                maNV_login.Caption = Program.maNV;
                hoTen_login.Caption = Program.mHoten;
                nhom_login.Caption = Program.mGroup;

                cmbCN.SelectedItem = ComboBoxHelper.tenCN_Help;
                dSTK.EnforceConstraints = false;

                this.KhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);

                this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.TaiKhoanTableAdapter.Fill(this.dSTK.TAIKHOAN);

                colReadOnly(true);
                textFieldReadOnly(true);

                if (Program.mGroup == "NGANHANG")
                {
                    cmbCN.Enabled = true;
                    enableButtons(false);
                }
                else if (Program.mGroup == "CHINHANH")
                {
                    cmbCN.Enabled = false;
                    enableButtons(true);
                }
                else
                {
                    cmbCN.Enabled = false;
                    enableButtons(false);
                }

                if (frmMain.undoKhachHang.Count == 0)
                {
                    btnPhucHoi.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void colReadOnly(Boolean check)
        {
            colCMND.OptionsColumn.ReadOnly =
            colHO.OptionsColumn.ReadOnly =
            colTEN.OptionsColumn.ReadOnly =
            colDIACHI.OptionsColumn.ReadOnly =
            colPHAI.OptionsColumn.ReadOnly =
            colNGAYCAP.OptionsColumn.ReadOnly =
            colSODT.OptionsColumn.ReadOnly = check;
        }
        private void enableButtons(Boolean check)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnMotaikhoan.Enabled = btnThoat.Enabled
          = btnGhi.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnRedo.Enabled = barSubItem1.Enabled = check;
        }

        private void textFieldReadOnly(Boolean check)
        {
            txtCMND.ReadOnly =
            txtHO.ReadOnly =
            txtTEN.ReadOnly =
            txtDIACHI.ReadOnly =
            txtSODT.ReadOnly =
            dteNGAYCAP.ReadOnly =
            txtPHAI.ReadOnly = check;
            txtMACN.ReadOnly = true;
        }
        private int GetRowHandleByCMND(GridView gridView, string cmnd)
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                var cellValue = gridView.GetRowCellValue(i, "CMND")?.ToString().Trim();

                if (cellValue != null && cellValue.Equals(cmnd.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return GridControl.InvalidRowHandle;
        }
        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enableButtons(false);
                if (cmbCN.SelectedItem != null)
                {
                    string selectedText = cmbCN.SelectedItem.ToString();
                    string query = string.Empty;

                    if (selectedText == ComboBoxHelper.tenCN_Help)
                    {
                        query = "select * from KhachHang";
                    }
                    else
                    {
                        query = "select * from LINK2.NGANHANG.dbo.KhachHang where MACN ='" + ComboBoxHelper.timMaCN(selectedText) + "'";
                    }

                    // Load data into the DataSet
                    adapter = new SqlDataAdapter(query, Program.conn);
                    this.dSTK.KHACHHANG.Clear();
                    dSTK.EnforceConstraints = false;
                    adapter.Fill(this.dSTK.KHACHHANG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valueSaved = 1;
            textFieldReadOnly(false);
            gcKH.Enabled = false;
            enableButtons(false);
            btnGhi.Enabled = btnThoat.Enabled = true;
            bdsKH.AddNew();
            string selectedTenCN = cmbCN.SelectedItem.ToString();
            string maCN = (selectedTenCN == "BẾN THÀNH" ? "BENTHANH" : "TANDINH");
            txtMACN.Text = maCN;
            txtCMND.Focus();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valueSaved = 2;
            textFieldReadOnly(false);
            gcKH.Enabled = false;
            enableButtons(false);
            btnGhi.Enabled = btnThoat.Enabled = true;
            txtCMND.ReadOnly = true;
            DateTime ngayCap = dteNGAYCAP.DateTime;
            string ngayCapFormatted = ngayCap.ToString("yyyy-MM-dd");
            undoUpdate = "EXEC SP_SUAKHACHHANG " +
                         "'" + txtCMND.Text + "', " +
                        "N'" + txtHO.Text + "', " +
                        "N'" + txtTEN.Text + "', " +
                        "N'" + txtDIACHI.Text + "', " +
                        "N'" + txtPHAI.Text + "', " +
                        "N'" + ngayCapFormatted + "', " +
                        "'" + txtSODT.Text + "', " +
                        "'" + Program.maChinhanh + "'";
            checkLuu = false;
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsTK.Count > 0)
            {
                MessageBox.Show("The customer you want to delete has an account, so it cannot be deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string cmd = "DELETE FROM KhachHang WHERE CMND = '" + txtCMND.Text + "'";
                SqlCommand command = new SqlCommand(cmd, Program.conn);
                try
                {
                    cancelTempStack();
                    DateTime ngayCap = dteNGAYCAP.DateTime;
                    string ngayCapFormatted = ngayCap.ToString("yyyy-MM-dd");
                    string undoDelete = "EXEC SP_THEMKHACHHANG " +
                                 "'" + txtCMND.Text + "', " +
                                 "N'" + txtHO.Text + "', " +
                                 "N'" + txtTEN.Text + "', " +
                                 "N'" + txtDIACHI.Text + "', " +
                                 "N'" + txtPHAI.Text + "', " +
                                 "N'" + ngayCapFormatted + "', " +
                                 "'" + txtSODT.Text + "', " +
                                 "'" + Program.maChinhanh + "'";
                    f_makh = txtCMND.Text;
                    f_undoKH.Push(txtCMND.Text);
                    frmMain.undoKhachHang.Push(undoDelete);
                    frmMain.redoKhachHang.Push(cmd);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    command.ExecuteNonQuery();

                    dSTK.EnforceConstraints = false;
                    this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);

                    authoButtons();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Program.conn.Close();
                }
            }

            if (bdsKH.Count == 0)
            {
                btnXoa.Enabled = false;
            }
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectedTenCN = cmbCN.SelectedItem.ToString();
            string maCN = (selectedTenCN.Trim() == "Bến Thành" ? "BENTHANH" : "TANDINH");
            if (valueSaved == 1)
            {
                if (!string.IsNullOrWhiteSpace(txtCMND.Text) &&
                    !string.IsNullOrWhiteSpace(txtHO.Text) &&
                    !string.IsNullOrWhiteSpace(txtTEN.Text) &&
                    !string.IsNullOrWhiteSpace(dteNGAYCAP.Text) &&
                    !string.IsNullOrWhiteSpace(txtPHAI.Text) &&
                    !string.IsNullOrWhiteSpace(txtSODT.Text) &&
                    !string.IsNullOrWhiteSpace(txtDIACHI.Text))
                {

                    DateTime ngayCap = dteNGAYCAP.DateTime;
                    string ngayCapFormatted = ngayCap.ToString("yyyy-MM-dd");
                    string cmd = "EXEC SP_THEMKHACHHANG " +
                                 "'" + txtCMND.Text + "', " +
                                 "N'" + txtHO.Text + "', " +
                                 "N'" + txtTEN.Text + "', " +
                                 "N'" + txtDIACHI.Text + "', " +
                                 "N'" + txtPHAI.Text + "', " +
                                 "N'" + ngayCapFormatted + "', " +
                                 "'" + txtSODT.Text + "', " +
                                 "'" + Program.maChinhanh + "'";
                    f_makh = txtCMND.Text;
                    f_undoKH.Push(txtCMND.Text);
                    SqlCommand command = new SqlCommand(cmd, Program.conn);
                    try
                    {
                        cancelTempStack();
                        undoInsert = "DELETE FROM KhachHang WHERE CMND = '" + txtCMND.Text + "'";
                        Console.WriteLine(undoInsert);
                        frmMain.undoKhachHang.Push(undoInsert);
                        frmMain.redoKhachHang.Push(cmd);
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Added successfully!");

                        gcKH.Enabled = true;
                        enableButtons(true);
                        textFieldReadOnly(true);
                        btnGhi.Enabled = btnPhucHoi.Enabled = false;
                        authoButtons();
                        dSTK.EnforceConstraints = false;
                        this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);
                        if (f_makh != null)
                        {
                            int rowHandle = GetRowHandleByCMND(gridView1, f_makh);
                            if (rowHandle != GridControl.InvalidRowHandle)
                            {
                                gridView1.FocusedRowHandle = rowHandle;
                            }
                        }
                        valueSaved = -1;
                    }
                    catch (Exception ex)
                    {
                        frmMain.undoKhachHang.Pop();
                        frmMain.redoKhachHang.Pop();
                        MessageBox.Show("An error occurred while adding the customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the required information.");
                }
            }
            else if (valueSaved == 2)
            {
                if (!string.IsNullOrEmpty(txtCMND.Text) &&
                    !string.IsNullOrEmpty(txtHO.Text) &&
                    !string.IsNullOrEmpty(txtTEN.Text) &&
                    !string.IsNullOrEmpty(dteNGAYCAP.Text) &&
                    !string.IsNullOrEmpty(txtPHAI.Text) &&
                    !string.IsNullOrEmpty(txtSODT.Text) &&
                    !string.IsNullOrEmpty(txtDIACHI.Text))
                {
                    DateTime ngayCap = dteNGAYCAP.DateTime;
                    string ngayCapFormatted = ngayCap.ToString("yyyy-MM-dd");
                    string cmd = "EXEC SP_SUAKHACHHANG " +
                                 "'" + txtCMND.Text + "', " +
                                 "N'" + txtHO.Text + "', " +
                                 "N'" + txtTEN.Text + "', " +
                                 "N'" + txtDIACHI.Text + "', " +
                                 "N'" + txtPHAI.Text + "', " +
                                 "N'" + ngayCapFormatted + "', " +
                                 "'" + txtSODT.Text + "', " +
                                 "'" + Program.maChinhanh + "'";
                    f_makh = txtCMND.Text;
                    f_undoKH.Push(txtCMND.Text);
                    SqlCommand command = new SqlCommand(cmd, Program.conn);
                    try
                    {
                        cancelTempStack();
                        frmMain.undoKhachHang.Push(undoUpdate);
                        frmMain.redoKhachHang.Push(cmd);
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Edited successfully!");

                        gcKH.Enabled = true;
                        enableButtons(true);
                        textFieldReadOnly(true);
                        btnGhi.Enabled = btnPhucHoi.Enabled = false;
                        authoButtons();
                        dSTK.EnforceConstraints = false;
                        this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);
                        if (f_makh != null)
                        {
                            int rowHandle = GetRowHandleByCMND(gridView1, f_makh);
                            if (rowHandle != GridControl.InvalidRowHandle)
                            {
                                gridView1.FocusedRowHandle = rowHandle;
                            }
                        }
                        valueSaved = -1;
                    }
                    catch (Exception ex)
                    {
                        frmMain.undoKhachHang.Pop();
                        frmMain.redoKhachHang.Pop();
                        MessageBox.Show("An error occurred while editing the customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the required information.");
                }
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                redoTimesKhachHang += 1;
                string cmd = frmMain.undoKhachHang.Pop();
                Console.WriteLine(cmd);
                frmMain.temp_undoKhachHang.Push(cmd);
                frmMain.temp_redoKhachHang.Push(frmMain.redoKhachHang.Pop());

                SqlCommand command = new SqlCommand(cmd, Program.conn);
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                command.ExecuteNonQuery();
                this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);

                authoButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while restoring the customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
            }
            string temp = f_undoKH.Pop();
            int rowHandle = GetRowHandleByCMND(gridView1, temp);
            f_redoKH.Push(temp);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                redoTimesKhachHang -= 1;
                string cmd = frmMain.temp_redoKhachHang.Pop();
                frmMain.redoKhachHang.Push(cmd);
                frmMain.undoKhachHang.Push(frmMain.temp_undoKhachHang.Pop());
                SqlCommand command = new SqlCommand(cmd, Program.conn);
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                command.ExecuteNonQuery();
                this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);

                authoButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrying the operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
            }
            string temp = f_redoKH.Pop();
            int rowHandle = GetRowHandleByCMND(gridView1, temp);
            f_undoKH.Push(temp);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                dSTK.EnforceConstraints = false;
                this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);
                authoButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the data " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textFieldReadOnly(true);
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKH.CancelEdit();
            if (btnThem.Enabled == false) bdsKH.Position = vitri;
            gcKH.Enabled = true;
            enableButtons(true);
            textFieldReadOnly(true);
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            authoButtons();
            dSTK.EnforceConstraints = false;
            this.KhachHangTableAdapter.Fill(this.dSTK.KHACHHANG);
            if (f_makh != null)
            {
                int rowHandle = GetRowHandleByCMND(gridView1, f_makh);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle;
                }
            }
            valueSaved = -1;
            
        }

        private void txtPhai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            txtPHAI.ShowPopup();
        }

        private void txtPhai_Click(object sender, EventArgs e)
        {
            txtPHAI.ShowPopup();
        }

        private frmMoTK frmMoTaiKhoanInstance;
        private void btnCN1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMoTaiKhoanInstance == null || frmMoTaiKhoanInstance.IsDisposed)
            {
                GridView gridView1 = (GridView)gcKH.MainView;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    DataRowView selectedRowView = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
                    DataRow selectedRow = selectedRowView.Row;

                    frmMoTaiKhoanInstance = new frmMoTK();
                    frmMoTaiKhoanInstance.selectedRow = selectedRow;
                    frmMoTaiKhoanInstance.FormClosed += FrmMoTaiKhoan_FormClosed;
                    frmMoTaiKhoanInstance.Show();
                }
            }
            else
            {
                frmMoTaiKhoanInstance.BringToFront();
            }
            frmMoTaiKhoanInstance.txtCMND1.ReadOnly = true;
        }

        private void btnCN2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMoTaiKhoanInstance == null || frmMoTaiKhoanInstance.IsDisposed)
            {
                GridView gridView1 = (GridView)gcKH.MainView;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    DataRowView selectedRowView = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
                    DataRow selectedRow = selectedRowView.Row;

                    frmMoTaiKhoanInstance = new frmMoTK();
                    frmMoTaiKhoanInstance.selectedRow = selectedRow;
                    frmMoTaiKhoanInstance.FormClosed += FrmMoTaiKhoan_FormClosed;
                    frmMoTaiKhoanInstance.Show();
                }
            }
            else
            {
                frmMoTaiKhoanInstance.BringToFront();
            }
            frmMoTaiKhoanInstance.txtCMND.Text = "";
            frmMoTaiKhoanInstance.txtHO.Text = "";
            frmMoTaiKhoanInstance.txtTEN.Text = "";
            frmMoTaiKhoanInstance.txtDIACHI.Text = "";
            frmMoTaiKhoanInstance.txtPHAI.Text = "";
            frmMoTaiKhoanInstance.txtSODT.Text = "";
            frmMoTaiKhoanInstance.deNGAYCAP.Text = "";
            frmMoTaiKhoanInstance.txtCMND1.Text = "";

            frmMoTaiKhoanInstance.txtCMND1.Focus();
            frmMoTaiKhoanInstance.btnCheck.Visible = true;
        }
        private void FrmMoTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMoTaiKhoanInstance = null;
        }
        public static void cancelTempStack()
        {
            if (redoTimesKhachHang != 0)
            {
                frmMain.temp_undoKhachHang.Clear();
                frmMain.temp_redoKhachHang.Clear();
                f_redoKH.Clear();
                redoTimesKhachHang = 0;
            }
        }

        private void authoButtons()
        {
            if (Program.mGroup == "NGANHANG")
            {
                cmbCN.Enabled = true; // bật tắt theo phân quyền
                enableButtons(false);
            }
            else if (Program.mGroup == "CHINHANH")
            {
                cmbCN.Enabled = false;
                enableButtons(true);
                btnGhi.Enabled = btnThoat.Enabled = false;
            }
            else
            {
                cmbCN.Enabled = false;
                enableButtons(false);
            }
            btnPhucHoi.Enabled = (frmMain.undoKhachHang.Count != 0);
            btnRedo.Enabled = (redoTimesKhachHang != 0);
        }
    }
}