using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGANHANG.View;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace NGANHANG
{
    public partial class frmNhanVien : Form
    {
        private string selectedTenCN;
        private DataSet cloneDataSet;
        private SqlDataAdapter adapter;
        private int valueSaved = 0; // 1 them - 2 sua - 3 xoa 
        private string undoInsert, undoUpdate, undoDelete;
        private int vitri;
        private bool checkLuu = false;
        public static int redoTimesNhanVien = 0;
        private string maNV, ho, ten, cmnd, diaChi, phai, sdt;
        String f_manv;
        public static Stack<String> f_undoNhanVien = new Stack<String>();
        public static Stack<String> f_redoNhanVien = new Stack<String>();
        public frmNhanVien()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dSTK.EnforceConstraints = false;
            khaiBaoSuKien();

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            checkExist.checkFormNhanVien = true;
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            maNV_login.Caption = Program.maNV;
            hoTen_login.Caption = Program.mHoten;
            nhom_login.Caption = Program.mGroup;


            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            gridView1.OptionsBehavior.ReadOnly = true;
            textFieldReadOnly(true);

            dSTK.EnforceConstraints = false;

            string query = "select * from NhanVien where TrangThaiXoa = 0";
            adapter = new SqlDataAdapter(query, Program.conn);
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);

            authoButtons();


        }

        public void Visible_ButtonNV()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPhucHoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnReload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThoat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCCN.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private int GetRowHandleByMANV(GridView gridView, string manv)
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                var cellValue = gridView.GetRowCellValue(i, "MANV")?.ToString().Trim();

                if (cellValue != null && cellValue.Equals(manv.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return GridControl.InvalidRowHandle;
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbChiNhanh.SelectedItem != null)
                {
                    string selectedText = cbChiNhanh.SelectedItem.ToString();
                    string query = string.Empty;

                    if (selectedText == ComboBoxHelper.tenCN_Help)
                    {
                        query = "select * from NhanVien where TrangThaiXoa = 0";
                    }
                    else
                    {
                        btnThoat.Enabled = btnLuu.Enabled = false;
                        query = "select * from LINK0.NGANHANG.dbo.NhanVien where TrangThaiXoa = 0 and MACN = '" + ComboBoxHelper.timMaCN(selectedText) + "'";
                    }

                    // Load data into the DataSet
                    adapter = new SqlDataAdapter(query, Program.conn);
                    this.dSTK.NHANVIEN.Clear();
                    adapter.Fill(this.dSTK.NHANVIEN);
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
            vitri = bdsNV.Position;
            txtMaNV.Text = "";
            txtHo.Text = "";
            txtTenNV.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtPhai.Text = "";
            txtSDT.Text = "";
            textFieldReadOnly(false);
            gcNV.Enabled = false;
            enableButtons(false);
            cbChiNhanh.Enabled = false;
            btnThoat.Enabled = true;
            checkLuu = false;
            txtCMND.Focus();
        }


        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valueSaved = 2;
            vitri = bdsNV.Position;
            textFieldReadOnly(false);
            gcNV.Enabled = false;
            enableButtons(false);
            cbChiNhanh.Enabled = false;
            btnThoat.Enabled = true;
            txtMaNV.Enabled = false;
            undoUpdate = "EXEC SP_SUANHANVIEN " +
                        "'" + txtMaNV.Text + "', " +
                        "N'" + txtHo.Text + "', " +
                        "N'" + txtTenNV.Text + "', " +
                        "'" + txtCMND.Text + "', " +
                        "N'" + txtDiaChi.Text + "', " +
                        "N'" + txtPhai.Text + "', " +
                        "'" + txtSDT.Text + "', " +
                        "'" + Program.maChinhanh + "', " +
                        "0";
            maNV = txtMaNV.Text; ho = txtHo.Text; ten = txtTenNV.Text; cmnd = txtCMND.Text; diaChi = txtDiaChi.Text; phai = txtPhai.Text; sdt = txtSDT.Text;
            checkLuu = false;
        }


        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string temp_role = string.Empty;
            int connectionResult = Program.KetNoi();

            if (connectionResult == 1)
            {
                SqlDataReader reader = Program.ExecSqlDataReader("SP_LAYQUYENTHEONHANVIEN" + "'" + txtMaNV.Text + "'");
                if (reader != null && reader.Read())
                {
                    temp_role = reader["name"].ToString().Trim();
                    Console.WriteLine(temp_role);
                }
                reader?.Close();
            }
            Console.WriteLine(temp_role);
            vitri = bdsNV.Position;
            if (txtMaNV.Text.Replace(" ", "") == Program.maNV)
            {
                MessageBox.Show("You cannot delete yourself.");
                bdsNV.Position = vitri;
                return;
            }
            else if (temp_role == "NGANHANG")
            {
                MessageBox.Show("You cannot delete an employee belonging to the banking group!");
                bdsNV.Position = vitri;
                return;
            }
            if (Program.ExecSqlKiemTra1("SP_KIEMTRAGIAODICHNHANVIEN", txtMaNV.Text) == 1)
            {
                MessageBox.Show("The employee has made a transaction!");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                undoDelete = "UPDATE NhanVien SET TrangThaiXoa = '0' WHERE MANV = '" + txtMaNV.Text + "'";
                f_undoNhanVien.Push(txtMaNV.Text);
                string cmd = "EXEC SP_XOANHANVIEN '" + txtMaNV.Text + "'";
                try
                {
                    cancelTempStack();
                    frmMain.undoNhanVien.Push(undoDelete);
                    frmMain.redoNhanVien.Push(cmd);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    if (Program.ExecSqlKiemTra1("SP_XOANHANVIEN", txtMaNV.Text) == 0)
                    {
                        MessageBox.Show("Deleted successfully!");
                    }
                    this.dSTK.NHANVIEN.Clear();
                    adapter.Fill(this.dSTK.NHANVIEN);

                    authoButtons();
                }
                catch (Exception ex)
                {
                    frmMain.undoNhanVien.Pop();
                    frmMain.redoNhanVien.Pop();
                    MessageBox.Show("An error occurred while deleting the employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Program.conn.Close();
                }
            }


        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                redoTimesNhanVien += 1;
                string cmd = frmMain.undoNhanVien.Pop();
                frmMain.temp_undoNhanVien.Push(cmd);
                frmMain.temp_redoNhanVien.Push(frmMain.redoNhanVien.Pop());

                SqlCommand command = new SqlCommand(cmd, Program.conn);
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                command.ExecuteNonQuery();
                string query = "select * from NhanVien where TrangThaiXoa = 0";
                adapter = new SqlDataAdapter(query, Program.conn);
                this.dSTK.NHANVIEN.Clear();
                adapter.Fill(this.dSTK.NHANVIEN);

                authoButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while restoring the employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
            }
            string temp = f_undoNhanVien.Pop();
            int rowHandle = GetRowHandleByMANV(gridView1, temp);
            f_redoNhanVien.Push(temp);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                redoTimesNhanVien -= 1;
                string cmd = frmMain.temp_redoNhanVien.Pop();
                frmMain.redoNhanVien.Push(cmd);
                frmMain.undoNhanVien.Push(frmMain.temp_undoNhanVien.Pop());
                SqlCommand command = new SqlCommand(cmd, Program.conn);
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                command.ExecuteNonQuery();
                this.dSTK.NHANVIEN.Clear();
                adapter.Fill(this.dSTK.NHANVIEN);

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
            string temp = f_redoNhanVien.Pop();
            int rowHandle = GetRowHandleByMANV(gridView1, temp);
            f_undoNhanVien.Push(temp);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        public static void cancelTempStack()
        {
            if (redoTimesNhanVien != 0)
            {
                frmMain.temp_undoNhanVien.Clear();
                frmMain.temp_redoNhanVien.Clear();
                f_redoNhanVien.Clear();
                redoTimesNhanVien = 0;
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = "select * from NhanVien where TrangThaiXoa = 0";
            adapter = new SqlDataAdapter(query, Program.conn);
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);

            authoButtons();

        }

        private void btnCCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            if (txtMaNV.Text.Replace(" ", "") == Program.maNV)
            {
                MessageBox.Show("You cannot transfer yourself.");
                bdsNV.Position = vitri;
                return;
            }
            frmChuyenChiNhanh frmChuyenChiNhanh = new frmChuyenChiNhanh();
            frmChuyenChiNhanh.maNVChuyen_Cu = txtMaNV.Text;
            frmChuyenChiNhanh.maNVMoi = GetMaNVMoi(txtMaNV.Text);
            frmChuyenChiNhanh.ShowDialog();
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);
            authoButtons();
            f_manv = txtMaNV.Text;
            f_undoNhanVien.Push(txtMaNV.Text);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (valueSaved == 1)
            {
                if (!string.IsNullOrWhiteSpace(txtMaNV.Text) &&
                !string.IsNullOrWhiteSpace(txtHo.Text) &&
                !string.IsNullOrWhiteSpace(txtTenNV.Text) &&
                !string.IsNullOrWhiteSpace(txtCMND.Text) &&
                !string.IsNullOrWhiteSpace(txtPhai.Text) &&
                !string.IsNullOrWhiteSpace(txtSDT.Text))
                {

                    string cmd = "EXEC SP_THEMNHANVIEN " +
                                 "'" + txtMaNV.Text + "', " +
                                 "N'" + txtHo.Text + "', " +
                                 "N'" + txtTenNV.Text + "', " +
                                 "'" + txtCMND.Text + "', " +
                                 "N'" + txtDiaChi.Text + "', " +
                                 "N'" + txtPhai.Text + "', " +
                                 "'" + txtSDT.Text + "', " +
                                 "'" + Program.maChinhanh + "', " +
                                 "0";

                    f_manv = txtMaNV.Text;
                    f_undoNhanVien.Push(txtMaNV.Text);
                    SqlCommand command = new SqlCommand(cmd, Program.conn);
                    try
                    {
                        cancelTempStack();
                        undoInsert = "DELETE FROM NhanVien WHERE MANV = '" + txtMaNV.Text + "'";
                        frmMain.undoNhanVien.Push(undoInsert);
                        frmMain.redoNhanVien.Push(cmd);
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Added successfully!");
                        checkLuu = true;

                        gcNV.Enabled = true;
                        gridView1.OptionsBehavior.ReadOnly = true;
                        textFieldReadOnly(true);
                        this.dSTK.NHANVIEN.Clear();
                        adapter.Fill(this.dSTK.NHANVIEN);
                        txtMaNV.Enabled = true;
                        authoButtons();
                        bdsNV.Position = vitri;
                        if(f_manv != null)
            {
                int rowHandle = GetRowHandleByMANV(gridView1, f_manv);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle;
                }
            }

                        valueSaved = -1;
                    }
                    catch (Exception ex)
                    {
                        frmMain.undoNhanVien.Pop();
                        frmMain.redoNhanVien.Pop();
                        MessageBox.Show("An error occurred while adding the employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Kiểm tra xem các trường dữ liệu không rỗng trước khi thực hiện câu lệnh UPDATE
                if (!string.IsNullOrEmpty(txtMaNV.Text) && !string.IsNullOrEmpty(txtHo.Text) &&
                    !string.IsNullOrEmpty(txtTenNV.Text) && !string.IsNullOrEmpty(txtCMND.Text) &&
                    !string.IsNullOrEmpty(txtPhai.Text) && !string.IsNullOrEmpty(txtSDT.Text))
                {
                    string cmd = "EXEC SP_SUANHANVIEN " +
                                 "'" + txtMaNV.Text + "', " +
                                 "N'" + txtHo.Text + "', " +
                                 "N'" + txtTenNV.Text + "', " +
                                 "'" + txtCMND.Text + "', " +
                                 "N'" + txtDiaChi.Text + "', " +
                                 "N'" + txtPhai.Text + "', " +
                                 "'" + txtSDT.Text + "', " +
                                 "'" + Program.maChinhanh + "', " +
                                 "0";

                    f_manv = txtMaNV.Text;
                    f_undoNhanVien.Push(txtMaNV.Text);
                    SqlCommand command = new SqlCommand(cmd, Program.conn);
                    try
                    {
                        cancelTempStack();
                        frmMain.undoNhanVien.Push(undoUpdate);
                        frmMain.redoNhanVien.Push(cmd);
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Edited successfully!");
                        checkLuu = true;

                        gcNV.Enabled = true;
                        gridView1.OptionsBehavior.ReadOnly = true;
                        textFieldReadOnly(true);
                        this.dSTK.NHANVIEN.Clear();
                        adapter.Fill(this.dSTK.NHANVIEN);
                        txtMaNV.Enabled = true;
                        authoButtons();
                        bdsNV.Position = vitri;
                        if (f_manv != null)
                        {
                            int rowHandle = GetRowHandleByMANV(gridView1, f_manv);
                            if (rowHandle != GridControl.InvalidRowHandle)
                            {
                                gridView1.FocusedRowHandle = rowHandle;
                            }
                        }
                        valueSaved = -1;
                    }
                    catch (Exception ex)
                    {
                        frmMain.undoNhanVien.Pop();
                        frmMain.redoNhanVien.Pop();
                        MessageBox.Show("An error occurred while editing the employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnLuu.Enabled == false) ;
            else if (!checkLuu)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit without saving?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }
            gcNV.Enabled = true;
            gridView1.OptionsBehavior.ReadOnly = true;
            textFieldReadOnly(true);
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);
            txtMaNV.Enabled = true;
            authoButtons();
            bdsNV.Position = vitri;
            if(f_manv != null)
            {
                int rowHandle = GetRowHandleByMANV(gridView1, f_manv);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle;
                }
            }
            valueSaved = -1;

        }
        private void textFieldReadOnly(Boolean check)
        {
            if (check)
            {
                txtMaNV.ReadOnly =
                txtHo.ReadOnly =
                txtTenNV.ReadOnly =
                txtCMND.ReadOnly =
                txtDiaChi.ReadOnly =
                txtPhai.ReadOnly =
                txtSDT.ReadOnly = true;
            }
            else
            {
                txtMaNV.ReadOnly =
                txtHo.ReadOnly =
                txtTenNV.ReadOnly =
                txtCMND.ReadOnly =
                txtDiaChi.ReadOnly =
                txtPhai.ReadOnly =
                txtSDT.ReadOnly = false;
            }
        }
        private void enableButtons(Boolean check)
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnRedo.Enabled
          = btnReload.Enabled = btnLuu.Enabled = btnThoat.Enabled = btnCCN.Enabled = check;
        }

        private void txtPhai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Prevent keyboard input
            txtPhai.ShowPopup();
        }

        private void txtPhai_Click(object sender, EventArgs e)
        {
            txtPhai.ShowPopup();
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtMaNV.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ' ' && txtHo.Text.EndsWith(" "))
            {
                e.Handled = true;
            }
            if (txtHo.Text.Length >= 40 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtTenNV.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtCMND.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar)
                && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '\'')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ' ' && txtDiaChi.Text.EndsWith(" "))
            {
                e.Handled = true;
            }
            if (txtDiaChi.Text.Length >= 100 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtMaNV.Text != "") || (valueSaved == 2 && txtMaNV.Text != maNV)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtMaNV.Text == "") || (valueSaved == 2 && txtMaNV.Text == maNV)) btnLuu.Enabled = false;
        }

        private void txtHo_EditValueChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtHo.Text != "") || (valueSaved == 2 && txtHo.Text != ho)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtHo.Text == "") || (valueSaved == 2 && txtHo.Text == ho)) btnLuu.Enabled = false;
        }

        private void txtCMND_EditValueChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtCMND.Text != "") || (valueSaved == 2 && txtCMND.Text != cmnd)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtCMND.Text == "") || (valueSaved == 2 && txtCMND.Text == cmnd)) btnLuu.Enabled = false;
            if(valueSaved == 1)
            {
                string tmpMaNV = layNhanVienBangCMND(txtCMND.Text);
                if (tmpMaNV != null) txtMaNV.Text = tmpMaNV;  
            }
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtSDT.Text != "") || (valueSaved == 2 && txtSDT.Text != sdt)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtSDT.Text == "") || (valueSaved == 2 && txtSDT.Text == sdt)) btnLuu.Enabled = false;
        }

        private void txtTenNV_EditValueChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtTenNV.Text != "") || (valueSaved == 2 && txtTenNV.Text != ten)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtTenNV.Text == "") || (valueSaved == 2 && txtTenNV.Text == ten)) btnLuu.Enabled = false;
        }

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtDiaChi.Text != "") || (valueSaved == 2 && txtDiaChi.Text != diaChi)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtDiaChi.Text == "") || (valueSaved == 2 && txtDiaChi.Text == diaChi)) btnLuu.Enabled = false;
        }

        private void gcNV_Click(object sender, EventArgs e)
        {

        }

        private void txtPhai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((valueSaved == 1 && txtPhai.Text != "") || (valueSaved == 2 && txtPhai.Text != phai)) btnLuu.Enabled = true;
            else if ((valueSaved == 1 && txtPhai.Text == "") || (valueSaved == 2 && txtPhai.Text == phai)) btnLuu.Enabled = false;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSDT.Text.Length >= 15 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void khaiBaoSuKien()
        {
            txtMaNV.KeyPress += new KeyPressEventHandler(txtMaNV_KeyPress);
            txtHo.KeyPress += new KeyPressEventHandler(txtHo_KeyPress);
            txtTenNV.KeyPress += new KeyPressEventHandler(txtTen_KeyPress);
            txtCMND.KeyPress += new KeyPressEventHandler(txtCMND_KeyPress);
            txtDiaChi.KeyPress += new KeyPressEventHandler(txtDiaChi_KeyPress);
            txtSDT.KeyPress += new KeyPressEventHandler(txtSDT_KeyPress);
        }

        private void authoButtons()
        {
            if (Program.mGroup == "NGANHANG")
            {
                cbChiNhanh.Enabled = true; // bật tắt theo phân quyền
                enableButtons(false);
            }
            else if (Program.mGroup == "CHINHANH")
            {
                cbChiNhanh.Enabled = false;
                enableButtons(true);
                btnLuu.Enabled = btnThoat.Enabled = false;
            }
            else
            {
                cbChiNhanh.Enabled = false;
                enableButtons(false);
            }
            btnPhucHoi.Enabled = (frmMain.undoNhanVien.Count != 0);
            btnRedo.Enabled = (redoTimesNhanVien != 0);
        }
        public static string GetMaNVMoi(string manv)
        {
            string result = string.Empty;

            using (SqlConnection conn = new SqlConnection(Program.connstr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_LAYMANVMOI", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@MANV", SqlDbType.NChar, 10)).Value = manv;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader["MANV"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return result;
        }

        public static string layNhanVienBangCMND(string CMND)
        {
            string result = string.Empty;

            using (SqlConnection conn = new SqlConnection(Program.connstr))
            {
                try
                {
                    string cmd = "SELECT NV.MANV FROM LINK0.NGANHANG.dbo.NhanVien NV WHERE NV.CMND = @CMND";

                    SqlCommand command = new SqlCommand(cmd, conn);
                    command.Parameters.AddWithValue("@CMND", CMND);

                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader["MANV"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return result;
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            if (Program.ExecSqlKiemTra1("SP_CHECK_USERNAME", txtMaNV.Text) == 1)
            {
                MessageBox.Show("The user already has an account in the system!");
                return;
            }
            else
            {
                newForm.frmRegister.txtMANV.Text = txtMaNV.Text;
                Console.WriteLine(newForm.frmRegister.txtMANV);
                this.Close();
            }
        }

    }
}
