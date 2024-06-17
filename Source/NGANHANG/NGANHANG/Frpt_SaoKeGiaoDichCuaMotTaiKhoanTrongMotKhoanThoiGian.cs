using DevExpress.XtraReports.UI;
using NGANHANG.View;
using System;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian : Form
    {
        public Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian()
        {
            InitializeComponent();
        }

        private void tAIKHOANBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.ImportDataDic(cbChiNhanh);
            cbChiNhanh.SelectedItem = ComboBoxHelper.tenCN_Help;
            checkExist.checkReportSaoKe = true;
            dSTK.EnforceConstraints = false;
            this.tAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tAIKHOANTableAdapter.Fill(this.dSTK.TAIKHOAN);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stk = txtSTK.Text;
            string tungay = DEtungay.Text;
            string denngay = DEdenngay.Text;
            Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian rpt = new Xrpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian(stk, tungay, denngay);
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
