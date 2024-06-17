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

namespace NGANHANG.View
{
    public partial class frmChuyenChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        public static String maNVChuyen_Cu, chiNhanhChuyen;
        public frmChuyenChiNhanh()
        {
            InitializeComponent();
            if (!ComboBoxHelper.checkLogin) ComboBoxHelper.PopulateComboBox(cbChiNhanh);
            else ComboBoxHelper.ImportDataDic(cbChiNhanh);
        }

        private void ChuyenChiNhanh_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Program.ExecSqlKiemTra1("SP_KIEMTRANHANVIEN", txtMaNV.Text) == 1)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                txtMaNV.Text = "";
                txtMaNV.Focus();
                return;
            }
        
       // String chinhanhChuyen = cbChiNhanh.Equals("BENTHANH") ? "TANDINH" : "BENTHANH";
        String cmd = $"EXEC SP_CHUYENNHANVIEN {maNVChuyen_Cu}, {cbChiNhanh.SelectedItem}, {txtMaNV.Text}";
            if (Program.ExecSqlNonQuery(cmd) == 0)
            {
                MessageBox.Show("Thành công");
                this.Close();
            }
}

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve TENCN from selected item
            string selectedTenCN = cbChiNhanh.SelectedItem.ToString();

            // Retrieve TENSERVER using selected TENCN from the dictionary
            if (ComboBoxHelper.tenCnTenServerDictionary.TryGetValue(selectedTenCN, out string tenServer))
            {
                // Store TENSERVER in a variable or use it as needed
                string selectedTenServer = tenServer;

                // You can also display TENSERVER in another control if needed
                Program.servername = selectedTenServer;
                ComboBoxHelper.tenCN_Help = selectedTenCN;
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