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

namespace NGANHANG
{
    public partial class frmNhanVien : Form
    {
        private string selectedTenCN;
        private DataSet cloneDataSet;
        private SqlDataAdapter adapter;
        private int valueSaved = 0; // 1 them - 2 sua - 3 xoa 
        private string cmdInsert, cmdUpdate, cmdDelete;
        public frmNhanVien()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dSTK.EnforceConstraints = false;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSTK.NHANVIEN' table. You can move, or remove it, as needed.
            checkExist.checkFormNhanVien = true;
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            maNV_login.Caption = Program.maNV;
            hoTen_login.Caption = Program.mHoten;
            nhom_login.Caption = Program.mGroup;


            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            gridView1.OptionsBehavior.ReadOnly = true;
            textFieldReadOnly(true);

            dSTK.EnforceConstraints = false;
            /*this.nHANVIENTableAdapter1.Connection.ConnectionString = Program.connstr;
            this.nHANVIENTableAdapter1.Fill(this.dSTK.NHANVIEN);
            */

            string query = "select * from NhanVien where TrangThaiXoa = 0";
            adapter = new SqlDataAdapter(query, Program.conn);
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);


            if (Program.mGroup == "NGANHANG")
            {
                cbChiNhanh.Enabled = true; // bật tắt theo phân quyền
                enableButtons(false);
            }
            else if (Program.mGroup == "CHINHANH")
            {
                cbChiNhanh.Enabled = false;
                enableButtons(true);
            }
            else
            {
                cbChiNhanh.Enabled = false;
                enableButtons(false);
            }

            if (frmMain.undoNhanVien.Count == 0) btnPhucHoi.Enabled = false;

        }



        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cbChiNhanh.SelectedItem != null && cbChiNhanh.SelectedItem.ToString() != ComboBoxHelper.tenCN_Help)
                {
                    enableButtons(false);

                    string query = "select * from LINK1.NGANHANG.dbo.NhanVien";
                    adapter = new SqlDataAdapter(query, Program.conn);

                    this.dSTK.NHANVIEN.Clear();
                    adapter.Fill(this.dSTK.NHANVIEN);
                }
                else if (cbChiNhanh.SelectedItem != null && cbChiNhanh.SelectedItem.ToString() == ComboBoxHelper.tenCN_Help)
                {
                    enableButtons(true);
                    btnThoat.Enabled = btnLuu.Enabled = false;

                    string query = "select * from NhanVien where TrangThaiXoa = 0";
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
            this.dSTK.NHANVIEN.Clear();
            textFieldReadOnly(false);
            gcNV.Enabled = false;
            enableButtons(false);
            cbChiNhanh.Enabled = false;
            btnThoat.Enabled = btnLuu.Enabled = true;
            rdoTTX.Enabled = false;
        }


        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valueSaved = 2;
            textFieldReadOnly(false);
            gcNV.Enabled = false;
            enableButtons(false);
            cbChiNhanh.Enabled = false;
            btnThoat.Enabled = btnLuu.Enabled = true;
            cmdUpdate = "UPDATE NhanVien " +
            "SET " +
            "HO = N'" + txtHo.Text + "', " +
            "TEN = N'" + txtTenNV.Text + "', " +
            "CMND = '" + txtCMND.Text + "', " +
            "DIACHI = '" + txtDiaChi.Text + "', " +
            "PHAI = '" + txtPhai.Text + "', " +
            "SODT = '" + txtSDT.Text + "', " +
            "MACN = '" + ComboBoxHelper.tenCN_Help + "', " +
            "TrangThaiXoa = " + (rdoTTX.Checked ? "1" : "0") + " " +
            "WHERE MANV = '" + txtMaNV.Text + "'";

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmdDelete = "UPDATE NhanVien SET TrangThaiXoa = '0' WHERE MANV = '" + txtMaNV.Text + "'";

                string cmd = "UPDATE NhanVien SET TrangThaiXoa = '1' WHERE MANV = @MaNV";
                SqlCommand command = new SqlCommand(cmd, Program.conn);
                command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

                try
                {
                    frmMain.undoNhanVien.Push(cmdDelete);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    command.ExecuteNonQuery();

                    this.dSTK.NHANVIEN.Clear();
                    adapter.Fill(this.dSTK.NHANVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SqlCommand command = new SqlCommand(frmMain.undoNhanVien.Pop(), Program.conn);
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                command.ExecuteNonQuery();
                this.dSTK.NHANVIEN.Clear();
                adapter.Fill(this.dSTK.NHANVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi phục hồi nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = "select * from NhanVien where TrangThaiXoa = 0";
            adapter = new SqlDataAdapter(query, Program.conn);
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);

        }

        private void btnCCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChuyenChiNhanh frmChuyenChiNhanh = new frmChuyenChiNhanh();
            frmChuyenChiNhanh.maNVChuyen_Cu = txtMaNV.Text;
            frmChuyenChiNhanh.Show();
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
                    string cmd = "INSERT INTO NhanVien(MANV, HO, TEN, CMND, DIACHI, PHAI, SODT, MACN, TrangThaiXoa) " +
                                 "VALUES (@MaNV, @Ho, @Ten, @CMND, @DiaChi, @Phai, @SDT, @MaCN, '0')";

                    SqlCommand command = new SqlCommand(cmd, Program.conn);
                    command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    command.Parameters.AddWithValue("@Ho", txtHo.Text);
                    command.Parameters.AddWithValue("@Ten", txtTenNV.Text);
                    command.Parameters.AddWithValue("@CMND", txtCMND.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("@Phai", txtPhai.Text);
                    command.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    command.Parameters.AddWithValue("@MaCN", ComboBoxHelper.tenCN_Help);
                    try
                    {
                        cmdInsert = "DELETE FROM NhanVien WHERE MANV = '" + txtMaNV.Text + "'";
                        frmMain.undoNhanVien.Push(cmdInsert);
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.conn.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                }
            }
            else if (valueSaved == 2)
            {
                // Kiểm tra xem các trường dữ liệu không rỗng trước khi thực hiện câu lệnh UPDATE
                if (!string.IsNullOrEmpty(txtMaNV.Text) && !string.IsNullOrEmpty(txtHo.Text) &&
                    !string.IsNullOrEmpty(txtTenNV.Text) && !string.IsNullOrEmpty(txtCMND.Text) &&
                    !string.IsNullOrEmpty(txtPhai.Text) && !string.IsNullOrEmpty(txtSDT.Text))
                {

                    string cmd = "UPDATE NhanVien SET " +
                                 "HO = @Ho, " +
                                 "TEN = @Ten, " +
                                 "CMND = @CMND, " +
                                 "DIACHI = @DiaChi, " +
                                 "PHAI = @Phai, " +
                                 "SODT = @SDT, " +
                                 "MACN = @MaCN, " +
                                 "TrangThaiXoa = @TrangThaiXoa " +
                                 "WHERE MANV = @MaNV";

                    SqlCommand command = new SqlCommand(cmd, Program.conn);
                    command.Parameters.AddWithValue("@Ho", txtHo.Text);
                    command.Parameters.AddWithValue("@Ten", txtTenNV.Text);
                    command.Parameters.AddWithValue("@CMND", txtCMND.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("@Phai", txtPhai.Text);
                    command.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    command.Parameters.AddWithValue("@MaCN", ComboBoxHelper.tenCN_Help);
                    command.Parameters.AddWithValue("@TrangThaiXoa", rdoTTX.Checked);
                    command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

                    try
                    {
                        frmMain.undoNhanVien.Push(cmdUpdate);
                        if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi hiệu chỉnh nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.conn.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                }

            }


        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcNV.Enabled = true;
            gridView1.OptionsBehavior.ReadOnly = true;
            textFieldReadOnly(true);
            this.dSTK.NHANVIEN.Clear();
            adapter.Fill(this.dSTK.NHANVIEN);

            enableButtons(true);
            cbChiNhanh.Enabled = true;
            btnThoat.Enabled = btnLuu.Enabled = false;

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
                rdoTTX.Enabled = false;
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
                rdoTTX.Enabled = true;
            }
        }
        private void enableButtons(Boolean check)
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled
          = btnReload.Enabled = btnLuu.Enabled = btnThoat.Enabled = btnCCN.Enabled = check;
        }
    }
}
