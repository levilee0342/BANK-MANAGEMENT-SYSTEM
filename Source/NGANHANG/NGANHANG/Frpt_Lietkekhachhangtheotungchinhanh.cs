using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using NGANHANG.View;
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

namespace NGANHANG
{
    public partial class Frpt_Lietkekhachhangtheotungchinhanh : DevExpress.XtraEditors.XtraForm
    {
        string macn = string.Empty;
        public Frpt_Lietkekhachhangtheotungchinhanh()
        {
            InitializeComponent();
        }

        private void Frpt_Lietkekhachhangtheotungchinhanh_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            cbChiNhanh.Items.Add("All branches");
            dSTK.EnforceConstraints = false;
            checkExist.checkReportKH = true;
            this.kHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHACHHANGTableAdapter.Fill(this.dSTK.KHACHHANG);
        }
        private void kHACHHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void cbChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbChiNhanh.Text.Trim() == "All branches")
            {
                macn = "TATCA";
            }
            else
            {
                macn = ComboBoxHelper.timMaCN((cbChiNhanh.Text.Trim()));
            }
        }

        private void btnXem_Click_1(object sender, EventArgs e)
        {

            gcLKKH.Visible = true;
            Program.KetNoi();
            try
            {
                string query = string.Empty;
                query = "SP_LIETKEKHACHHANGTHEOTUNGCHINHANH @MACN";
                using (SqlCommand command = new SqlCommand(query, Program.conn))
                {
                    command.Parameters.Add(new SqlParameter("@MACN", SqlDbType.NChar, 10)).Value = macn;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    gcLKKH.DataSource = null;
                    gcLKKH.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Xrpt_LietKeKhachHangTheoTungChiNhanh report = new Xrpt_LietKeKhachHangTheoTungChiNhanh(macn);
            if (cbChiNhanh.Text.Trim() == "All branches")
            {
                report.lblTieude.Text = "LIST OF CUSTOMERS OF " + cbChiNhanh.Text.ToUpper();
            }
            else
            {
                report.lblTieude.Text = "LIST OF CUSTOMERS OF BRANCH " + cbChiNhanh.Text.ToUpper();
            }
            ReportPrintTool print = new ReportPrintTool(report);
            print.ShowPreviewDialog();
        }
    }
}