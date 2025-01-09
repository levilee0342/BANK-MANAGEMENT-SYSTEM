using DevExpress.XtraEditors;
using NGANHANG.DSTKTableAdapters;
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
    public partial class frmTraCuuKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmTraCuuKhachHang()
        {
            InitializeComponent();
        }
        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }
        private void frmTraCuuKhachHang_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "NGANHANG")
            {
                cbChiNhanh.Enabled = true;
            }
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            // Vô hiệu hóa các ràng buộc của DataSet dSTK (nếu cần thiết)
            dSTK.EnforceConstraints = false;

            // Thiết lập kết nối cho table adapter của KHACHHANG và TAIKHOAN
            this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);

            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }


        // Xử lý sự kiện FocusedRowChanged của GridView
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (e.FocusedRowHandle >= 0)
            {
                // Lấy dòng được chọn
                DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);

                if (row != null)
                {
                    // Cập nhật các TextEdit với dữ liệu từ dòng được chọn
                    txtCMND.EditValue = row["CMND"];
                    txtHo.EditValue = row["HO"];
                    txtTen.EditValue = row["TEN"];
                    txtPhai.EditValue = row["PHAI"];
                    txtDiaChi.EditValue = row["DIACHI"];
                    txtMACN_KH.EditValue = row["MACN_KH"];
                    txtSTK.EditValue = row["SOTK"];
                    txtSoDu.EditValue = row["SODU"];
                    DENgaymotk.EditValue = row["NGAYMOTK"];
                    txtMACN_TK.EditValue = row["MACN_TK"];

                }
            }
        }
        private void pnTTKH_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kHACHHANGBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            newForm.frmReportSaoKe.txtSTK.Text = txtSTK.Text;
            this.Close();
        }
        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.KetNoi();
            try
            {
                if (cbChiNhanh.SelectedItem != null)
                {
                    string selectedText = cbChiNhanh.SelectedItem.ToString();
                    Console.WriteLine(selectedText);
                    string query = string.Empty;
                    string macn = string.Empty;
                    macn = ComboBoxHelper.timMaCN(selectedText.Trim());
                    query = "EXEC SP_THONGTIN_TAIKHOAN_KHACHHANG @MACN";
                    using (SqlCommand command = new SqlCommand(query, Program.conn))
                    {
                        command.Parameters.Add(new SqlParameter("@MACN", SqlDbType.NChar, 10)).Value = macn;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        kHACHHANGGridControl.DataSource = null;
                        kHACHHANGGridControl.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnXacNhan2_Click(object sender, EventArgs e)
        {
            if (Program.ExecSqlKiemTra1("SP_CHECK_USERNAME", txtSTK.Text) == 1)
            {
                MessageBox.Show("The user already has an account in the system!");
                return;
            }
            else
            {
                newForm.frmRegister.txtMANV.Text = txtSTK.Text;
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan3_Click(object sender, EventArgs e)
        {
            if(newForm.frmTaiKhoan.txtSTK.Text.Trim() == txtSTK.Text.Trim())
            {
                MessageBox.Show("This is the account number currently performing a transfer transaction, please choose a different account number!");
                return;
            }
            else
            {
                newForm.frmTaiKhoan.txtSTKNhan.Text = txtSTK.Text.Trim();
                newForm.frmTaiKhoan.txtSoTienChuyen.Focus();
                this.Close();
            }
        }

        private void tENLabel_Click(object sender, EventArgs e)
        {

        }

        private void nGAYMOTKLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
