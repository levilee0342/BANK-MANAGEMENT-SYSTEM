
namespace NGANHANG
{
    partial class Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label nGAYMOTKLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXembaocao = new System.Windows.Forms.Button();
            this.DEdenngay = new DevExpress.XtraEditors.DateEdit();
            this.DEtungay = new DevExpress.XtraEditors.DateEdit();
            this.dSTK = new NGANHANG.DSTK();
            this.bdsTK = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new NGANHANG.DSTKTableAdapters.TableAdapterManager();
            this.tAIKHOANTableAdapter = new NGANHANG.DSTKTableAdapters.TAIKHOANTableAdapter();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.maNV_login = new DevExpress.XtraBars.BarButtonItem();
            this.hoTen_login = new DevExpress.XtraBars.BarButtonItem();
            this.nhom_login = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXemDuLieu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tAIKHOANGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYMOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            label3 = new System.Windows.Forms.Label();
            nGAYMOTKLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DEdenngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEdenngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEtungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEtungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tAIKHOANGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = System.Windows.Forms.Cursors.No;
            label3.Location = new System.Drawing.Point(542, 79);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 13);
            label3.TabIndex = 12;
            label3.Text = "To date";
            // 
            // nGAYMOTKLabel
            // 
            nGAYMOTKLabel.AutoSize = true;
            nGAYMOTKLabel.Cursor = System.Windows.Forms.Cursors.No;
            nGAYMOTKLabel.Location = new System.Drawing.Point(542, 28);
            nGAYMOTKLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nGAYMOTKLabel.Name = "nGAYMOTKLabel";
            nGAYMOTKLabel.Size = new System.Drawing.Size(54, 13);
            nGAYMOTKLabel.TabIndex = 10;
            nGAYMOTKLabel.Text = "From date";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 19);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(432, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "LIST ACCOUNTS OPENED WITHIN A SPECIFIED PERIOD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(633, 131);
            this.cbChiNhanh.Margin = new System.Windows.Forms.Padding(2);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(193, 21);
            this.cbChiNhanh.TabIndex = 16;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Branch";
            // 
            // btnXembaocao
            // 
            this.btnXembaocao.Location = new System.Drawing.Point(711, 178);
            this.btnXembaocao.Margin = new System.Windows.Forms.Padding(2);
            this.btnXembaocao.Name = "btnXembaocao";
            this.btnXembaocao.Size = new System.Drawing.Size(114, 31);
            this.btnXembaocao.TabIndex = 14;
            this.btnXembaocao.Text = "Xuất báo cáo";
            this.btnXembaocao.UseVisualStyleBackColor = true;
            this.btnXembaocao.Click += new System.EventHandler(this.btnXembaocao_Click);
            // 
            // DEdenngay
            // 
            this.DEdenngay.EditValue = null;
            this.DEdenngay.Location = new System.Drawing.Point(633, 76);
            this.DEdenngay.Margin = new System.Windows.Forms.Padding(2);
            this.DEdenngay.Name = "DEdenngay";
            this.DEdenngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEdenngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEdenngay.Size = new System.Drawing.Size(96, 20);
            this.DEdenngay.TabIndex = 13;
            this.DEdenngay.EditValueChanged += new System.EventHandler(this.DEdenngay_EditValueChanged);
            // 
            // DEtungay
            // 
            this.DEtungay.EditValue = null;
            this.DEtungay.Location = new System.Drawing.Point(633, 24);
            this.DEtungay.Margin = new System.Windows.Forms.Padding(2);
            this.DEtungay.Name = "DEtungay";
            this.DEtungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEtungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEtungay.Size = new System.Drawing.Size(96, 20);
            this.DEtungay.TabIndex = 11;
            this.DEtungay.EditValueChanged += new System.EventHandler(this.DEtungay_EditValueChanged);
            // 
            // dSTK
            // 
            this.dSTK.DataSetName = "DSTK";
            this.dSTK.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsTK
            // 
            this.bdsTK.DataMember = "TAIKHOAN";
            this.bdsTK.DataSource = this.dSTK;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHINHANHTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = this.tAIKHOANTableAdapter;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSTKTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tAIKHOANTableAdapter
            // 
            this.tAIKHOANTableAdapter.ClearBeforeFill = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barHeaderItem1,
            this.maNV_login,
            this.hoTen_login,
            this.nhom_login});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem1)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barHeaderItem1.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
            this.barHeaderItem1.Appearance.Options.UseFont = true;
            this.barHeaderItem1.Appearance.Options.UseForeColor = true;
            this.barHeaderItem1.Caption = "REPORT";
            this.barHeaderItem1.Id = 0;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.maNV_login),
            new DevExpress.XtraBars.LinkPersistInfo(this.hoTen_login),
            new DevExpress.XtraBars.LinkPersistInfo(this.nhom_login)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // maNV_login
            // 
            this.maNV_login.Caption = "barButtonItem1";
            this.maNV_login.Id = 1;
            this.maNV_login.Name = "maNV_login";
            // 
            // hoTen_login
            // 
            this.hoTen_login.Caption = "barButtonItem2";
            this.hoTen_login.Id = 2;
            this.hoTen_login.Name = "hoTen_login";
            // 
            // nhom_login
            // 
            this.nhom_login.Caption = "barButtonItem3";
            this.nhom_login.Id = 3;
            this.nhom_login.Name = "nhom_login";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(1121, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 567);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1121, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 526);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1121, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 526);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXemDuLieu);
            this.panel2.Controls.Add(this.cbChiNhanh);
            this.panel2.Controls.Add(nGAYMOTKLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DEtungay);
            this.panel2.Controls.Add(this.btnXembaocao);
            this.panel2.Controls.Add(this.DEdenngay);
            this.panel2.Controls.Add(label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1121, 259);
            this.panel2.TabIndex = 17;
            // 
            // btnXemDuLieu
            // 
            this.btnXemDuLieu.Location = new System.Drawing.Point(524, 178);
            this.btnXemDuLieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnXemDuLieu.Name = "btnXemDuLieu";
            this.btnXemDuLieu.Size = new System.Drawing.Size(114, 31);
            this.btnXemDuLieu.TabIndex = 17;
            this.btnXemDuLieu.Text = "Xem dữ liệu";
            this.btnXemDuLieu.UseVisualStyleBackColor = true;
            this.btnXemDuLieu.Click += new System.EventHandler(this.btnXemDuLieu_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tAIKHOANGridControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 319);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1121, 248);
            this.panel3.TabIndex = 18;
            // 
            // tAIKHOANGridControl
            // 
            this.tAIKHOANGridControl.DataSource = this.bdsTK;
            this.tAIKHOANGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tAIKHOANGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.tAIKHOANGridControl.Location = new System.Drawing.Point(0, 0);
            this.tAIKHOANGridControl.MainView = this.gridView1;
            this.tAIKHOANGridControl.Margin = new System.Windows.Forms.Padding(2);
            this.tAIKHOANGridControl.MenuManager = this.barManager1;
            this.tAIKHOANGridControl.Name = "tAIKHOANGridControl";
            this.tAIKHOANGridControl.Size = new System.Drawing.Size(1121, 248);
            this.tAIKHOANGridControl.TabIndex = 0;
            this.tAIKHOANGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.tAIKHOANGridControl.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSOTK,
            this.colCMND,
            this.colSODU,
            this.colNGAYMOTK,
            this.colMACN});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.tAIKHOANGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 600;
            // 
            // colSOTK
            // 
            this.colSOTK.Caption = "SOTK";
            this.colSOTK.FieldName = "SOTK";
            this.colSOTK.MinWidth = 19;
            this.colSOTK.Name = "colSOTK";
            this.colSOTK.Visible = true;
            this.colSOTK.VisibleIndex = 0;
            this.colSOTK.Width = 70;
            // 
            // colCMND
            // 
            this.colCMND.Caption = "CMND";
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 19;
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 1;
            this.colCMND.Width = 70;
            // 
            // colSODU
            // 
            this.colSODU.Caption = "SODU";
            this.colSODU.FieldName = "SODU";
            this.colSODU.MinWidth = 19;
            this.colSODU.Name = "colSODU";
            this.colSODU.Visible = true;
            this.colSODU.VisibleIndex = 2;
            this.colSODU.Width = 70;
            // 
            // colNGAYMOTK
            // 
            this.colNGAYMOTK.Caption = "NGAYMOTK";
            this.colNGAYMOTK.FieldName = "NGAYMOTK";
            this.colNGAYMOTK.MinWidth = 19;
            this.colNGAYMOTK.Name = "colNGAYMOTK";
            this.colNGAYMOTK.Visible = true;
            this.colNGAYMOTK.VisibleIndex = 3;
            this.colNGAYMOTK.Width = 70;
            // 
            // colMACN
            // 
            this.colMACN.Caption = "MACN";
            this.colMACN.FieldName = "MACN";
            this.colMACN.MinWidth = 19;
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 4;
            this.colMACN.Width = 70;
            // 
            // Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 589);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian";
            this.Text = "Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian";
            this.Load += new System.EventHandler(this.Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DEdenngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEdenngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEtungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEtungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tAIKHOANGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXembaocao;
        public DevExpress.XtraEditors.DateEdit DEdenngay;
        public DevExpress.XtraEditors.DateEdit DEtungay;
        private System.Windows.Forms.Label label1;
        private DSTK dSTK;
        private System.Windows.Forms.BindingSource bdsTK;
        private DSTKTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTKTableAdapters.TAIKHOANTableAdapter tAIKHOANTableAdapter;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarButtonItem maNV_login;
        private DevExpress.XtraBars.BarButtonItem hoTen_login;
        private DevExpress.XtraBars.BarButtonItem nhom_login;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnXemDuLieu;
        public DevExpress.XtraGrid.GridControl tAIKHOANGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colSODU;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYMOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
    }
}