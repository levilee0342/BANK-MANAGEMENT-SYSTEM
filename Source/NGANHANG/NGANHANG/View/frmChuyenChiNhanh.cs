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
using System.Data.SqlClient;
namespace NGANHANG.View
{
    public partial class frmChuyenChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        public static String maNVChuyen_Cu, chiNhanhChuyen, maNVMoi;
        private Boolean checkAutoFill = false;
        private string selectedTenCN;
        public frmChuyenChiNhanh()
        {
            InitializeComponent();
            if (!ComboBoxHelper.checkLogin) ComboBoxHelper.PopulateComboBox(cbChiNhanh);
            else ComboBoxHelper.ImportDataDic(cbChiNhanh);
        }

        private void ChuyenChiNhanh_Load(object sender, EventArgs e)
        {
            cbChiNhanh.Items.Remove(ComboBoxHelper.tenCN_Help);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((Program.ExecSqlKiemTra1("SP_KIEMTRANHANVIEN", txtMaNV.Text) == 1) && checkAutoFill == false)
            {
                MessageBox.Show("Employee ID already exists");
                txtMaNV.Text = "";
                txtMaNV.Focus();
                return;
            }

            // String chinhanhChuyen = cbChiNhanh.Equals("BENTHANH") ? "TANDINH" : "BENTHANH";
            String cmd = $"EXEC SP_CHUYENNHANVIEN_SONGSONG {maNVChuyen_Cu}, {ComboBoxHelper.timMaCN(selectedTenCN)}, {txtMaNV.Text}";
            if (Program.ExecSqlNonQuery(cmd) == 0)
            {
                MessageBox.Show("Successful");
                frmNhanVien.cancelTempStack();
                String undoChuyen = $"EXEC SP_UNDO_CHUYENNHANVIEN_SONGSONG {maNVChuyen_Cu}, {ComboBoxHelper.timMaCN(ComboBoxHelper.tenCN_Help)}, {txtMaNV.Text}";
                frmMain.undoNhanVien.Push(undoChuyen);
                frmMain.redoNhanVien.Push(cmd);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTenCN = cbChiNhanh.SelectedItem.ToString();
            if (ComboBoxHelper.tenCnTenServerDictionary.TryGetValue(selectedTenCN, out string tenServer))
            {
                if (Program.ExecSqlKiemTra2("SP_KIEMTRATONTAINHANVIEN", maNVMoi, ComboBoxHelper.timMaCN(selectedTenCN)) == 1)
                {
                    txtMaNV.Text = maNVMoi;
                    txtMaNV.Enabled = false;
                    checkAutoFill = true;
                }
                else
                {
                    txtMaNV.Text = "";
                    txtMaNV.Enabled = true;
                    checkAutoFill = false;
                }
            }
            else
            {
                MessageBox.Show("TENSERVER not found for selected TENCN.");
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbChiNhanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Prevent keyboard input
            cbChiNhanh.DroppedDown = true;
        }

        private void cbChiNhanh_Click(object sender, EventArgs e)
        {
            cbChiNhanh.DroppedDown = true;
        }


    }
}