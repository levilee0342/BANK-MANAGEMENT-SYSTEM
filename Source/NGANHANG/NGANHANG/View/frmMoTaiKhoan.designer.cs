
namespace NGANHANG.View
{
    partial class frmMoTaiKhoan
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
            System.Windows.Forms.Label sODULabel;
            System.Windows.Forms.Label sOTKLabel;
            System.Windows.Forms.Label mACNLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label sODTLabel;
            System.Windows.Forms.Label nGAYCAPLabel;
            System.Windows.Forms.Label pHAILabel;
            System.Windows.Forms.Label tENLabel;
            System.Windows.Forms.Label hOLabel;
            System.Windows.Forms.Label cMNDLabel;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btKT = new System.Windows.Forms.Button();
            this.txtNhapCMND = new DevExpress.XtraEditors.TextEdit();
            this.nhapCMND = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPHAI = new System.Windows.Forms.ComboBox();
            this.dteNGAYCAP = new DevExpress.XtraEditors.DateEdit();
            this.txtSODT = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN = new DevExpress.XtraEditors.TextEdit();
            this.txtMACN = new DevExpress.XtraEditors.TextEdit();
            this.txtDIACHI = new DevExpress.XtraEditors.TextEdit();
            this.txtHO = new DevExpress.XtraEditors.TextEdit();
            this.txtCMND = new DevExpress.XtraEditors.TextEdit();
            this.btHuy = new System.Windows.Forms.Button();
            this.btXN = new System.Windows.Forms.Button();
            this.txtSODU = new DevExpress.XtraEditors.TextEdit();
            this.txtSOTK = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            this.dSTK = new NGANHANG.DSTK();
            this.bdsTK = new System.Windows.Forms.BindingSource(this.components);
            this.tAIKHOANTableAdapter = new NGANHANG.DSTKTableAdapters.TAIKHOANTableAdapter();
            this.tableAdapterManager = new NGANHANG.DSTKTableAdapters.TableAdapterManager();
            this.bdsKH = new System.Windows.Forms.BindingSource(this.components);
            this.kHACHHANGTableAdapter = new NGANHANG.DSTKTableAdapters.KHACHHANGTableAdapter();

            sODULabel = new System.Windows.Forms.Label();
            sOTKLabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            sODTLabel = new System.Windows.Forms.Label();
            nGAYCAPLabel = new System.Windows.Forms.Label();
            pHAILabel = new System.Windows.Forms.Label();
            tENLabel = new System.Windows.Forms.Label();
            hOLabel = new System.Windows.Forms.Label();
            cMNDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapCMND.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYCAP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYCAP.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSODT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMACN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIACHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMND.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSODU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKH)).BeginInit();

            this.SuspendLayout();
            // 
            // sODULabel
            // 
            sODULabel.AutoSize = true;
            sODULabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            sODULabel.Location = new System.Drawing.Point(816, 165);
            sODULabel.Name = "sODULabel";
            sODULabel.Size = new System.Drawing.Size(45, 16);
            sODULabel.TabIndex = 69;
            sODULabel.Text = "Số dư:";
            // 
            // sOTKLabel
            // 
            sOTKLabel.AutoSize = true;
            sOTKLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            sOTKLabel.Location = new System.Drawing.Point(816, 103);
            sOTKLabel.Name = "sOTKLabel";
            sOTKLabel.Size = new System.Drawing.Size(48, 16);
            sOTKLabel.TabIndex = 62;
            sOTKLabel.Text = "Số TK:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            mACNLabel.Location = new System.Drawing.Point(60, 343);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(68, 16);
            mACNLabel.TabIndex = 60;
            mACNLabel.Text = "Chi nhánh:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dIACHILabel.Location = new System.Drawing.Point(60, 281);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(51, 16);
            dIACHILabel.TabIndex = 58;
            dIACHILabel.Text = "Địa chỉ:";
            // 
            // sODTLabel
            // 
            sODTLabel.AutoSize = true;
            sODTLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            sODTLabel.Location = new System.Drawing.Point(401, 219);
            sODTLabel.Name = "sODTLabel";
            sODTLabel.Size = new System.Drawing.Size(48, 16);
            sODTLabel.TabIndex = 56;
            sODTLabel.Text = "Số ĐT:";
            // 
            // nGAYCAPLabel
            // 
            nGAYCAPLabel.AutoSize = true;
            nGAYCAPLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            nGAYCAPLabel.Location = new System.Drawing.Point(401, 99);
            nGAYCAPLabel.Name = "nGAYCAPLabel";
            nGAYCAPLabel.Size = new System.Drawing.Size(65, 16);
            nGAYCAPLabel.TabIndex = 54;
            nGAYCAPLabel.Text = "Ngày cấp:";
            // 
            // pHAILabel
            // 
            pHAILabel.AutoSize = true;
            pHAILabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            pHAILabel.Location = new System.Drawing.Point(60, 217);
            pHAILabel.Name = "pHAILabel";
            pHAILabel.Size = new System.Drawing.Size(60, 16);
            pHAILabel.TabIndex = 52;
            pHAILabel.Text = "Giới tính:";
            // 
            // tENLabel
            // 
            tENLabel.AutoSize = true;
            tENLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            tENLabel.Location = new System.Drawing.Point(401, 157);
            tENLabel.Name = "tENLabel";
            tENLabel.Size = new System.Drawing.Size(33, 16);
            tENLabel.TabIndex = 50;
            tENLabel.Text = "Tên:";
            // 
            // hOLabel
            // 
            hOLabel.AutoSize = true;
            hOLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            hOLabel.Location = new System.Drawing.Point(60, 157);
            hOLabel.Name = "hOLabel";
            hOLabel.Size = new System.Drawing.Size(27, 16);
            hOLabel.TabIndex = 48;
            hOLabel.Text = "Họ:";
            // 
            // cMNDLabel
            // 
            cMNDLabel.AutoSize = true;
            cMNDLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            cMNDLabel.Location = new System.Drawing.Point(60, 99);
            cMNDLabel.Name = "cMNDLabel";
            cMNDLabel.Size = new System.Drawing.Size(52, 16);
            cMNDLabel.TabIndex = 46;
            cMNDLabel.Text = "CMND:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btKT);
            this.panelControl1.Controls.Add(this.txtNhapCMND);
            this.panelControl1.Controls.Add(this.nhapCMND);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1208, 71);
            this.panelControl1.TabIndex = 13;
            // 
            // btKT
            // 
            this.btKT.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btKT.Location = new System.Drawing.Point(793, 18);
            this.btKT.Name = "btKT";
            this.btKT.Size = new System.Drawing.Size(90, 34);
            this.btKT.TabIndex = 2;
            this.btKT.Text = "Kiểm tra";
            this.btKT.UseVisualStyleBackColor = true;
            this.btKT.Click += new System.EventHandler(this.btKT_Click);
            // 
            // txtNhapCMND
            // 
            this.txtNhapCMND.Location = new System.Drawing.Point(348, 24);
            this.txtNhapCMND.Name = "txtNhapCMND";
            this.txtNhapCMND.Size = new System.Drawing.Size(406, 22);
            this.txtNhapCMND.TabIndex = 1;
            // 
            // nhapCMND
            // 
            this.nhapCMND.AutoSize = true;
            this.nhapCMND.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nhapCMND.Location = new System.Drawing.Point(209, 27);
            this.nhapCMND.Name = "nhapCMND";
            this.nhapCMND.Size = new System.Drawing.Size(106, 17);
            this.nhapCMND.TabIndex = 0;
            this.nhapCMND.Text = "Nhập số CMND:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPHAI);
            this.groupBox1.Controls.Add(this.dteNGAYCAP);
            this.groupBox1.Controls.Add(this.txtSODT);
            this.groupBox1.Controls.Add(this.txtTEN);
            this.groupBox1.Controls.Add(this.txtMACN);
            this.groupBox1.Controls.Add(this.txtDIACHI);
            this.groupBox1.Controls.Add(this.txtHO);
            this.groupBox1.Controls.Add(this.txtCMND);
            this.groupBox1.Controls.Add(this.btHuy);
            this.groupBox1.Controls.Add(this.btXN);
            this.groupBox1.Controls.Add(sODULabel);
            this.groupBox1.Controls.Add(this.txtSODU);
            this.groupBox1.Controls.Add(sOTKLabel);
            this.groupBox1.Controls.Add(this.txtSOTK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(mACNLabel);
            this.groupBox1.Controls.Add(dIACHILabel);
            this.groupBox1.Controls.Add(sODTLabel);
            this.groupBox1.Controls.Add(nGAYCAPLabel);
            this.groupBox1.Controls.Add(pHAILabel);
            this.groupBox1.Controls.Add(tENLabel);
            this.groupBox1.Controls.Add(hOLabel);
            this.groupBox1.Controls.Add(cMNDLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1208, 441);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản ";
            // 
            // cmbPHAI
            // 

            this.cmbPHAI.FormattingEnabled = true;
            this.cmbPHAI.Location = new System.Drawing.Point(164, 213);
            this.cmbPHAI.Name = "cmbPHAI";
            this.cmbPHAI.Size = new System.Drawing.Size(133, 24);
            this.cmbPHAI.TabIndex = 80;
            // 
            // dteNGAYCAP
            // 
            this.dteNGAYCAP.EditValue = null;
            this.dteNGAYCAP.Location = new System.Drawing.Point(527, 95);
            this.dteNGAYCAP.Name = "dteNGAYCAP";
            this.dteNGAYCAP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAYCAP.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAYCAP.Size = new System.Drawing.Size(133, 22);
            this.dteNGAYCAP.TabIndex = 79;
            // 
            // txtSODT
            // 
            this.txtSODT.Location = new System.Drawing.Point(527, 213);
            this.txtSODT.Name = "txtSODT";
            this.txtSODT.Size = new System.Drawing.Size(133, 22);
            this.txtSODT.TabIndex = 78;
            // 
            // txtTEN
            // 
            this.txtTEN.Location = new System.Drawing.Point(527, 153);
            this.txtTEN.Name = "txtTEN";
            this.txtTEN.Size = new System.Drawing.Size(133, 22);
            this.txtTEN.TabIndex = 77;
            // 
            // txtMACN
            // 
            this.txtMACN.Location = new System.Drawing.Point(164, 343);
            this.txtMACN.Name = "txtMACN";
            this.txtMACN.Size = new System.Drawing.Size(133, 22);
            this.txtMACN.TabIndex = 76;
            // 
            // txtDIACHI
            // 
            this.txtDIACHI.Location = new System.Drawing.Point(164, 277);
            this.txtDIACHI.Name = "txtDIACHI";
            this.txtDIACHI.Size = new System.Drawing.Size(496, 22);
            this.txtDIACHI.TabIndex = 75;
            // 
            // txtHO
            // 
            this.txtHO.Location = new System.Drawing.Point(164, 153);
            this.txtHO.Name = "txtHO";
            this.txtHO.Size = new System.Drawing.Size(133, 22);
            this.txtHO.TabIndex = 74;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(164, 99);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(133, 22);
            this.txtCMND.TabIndex = 73;
            // 
            // btHuy
            // 
            this.btHuy.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btHuy.Location = new System.Drawing.Point(962, 224);

            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(75, 36);
            this.btHuy.TabIndex = 72;
            this.btHuy.Text = "Hủy";
            this.btHuy.UseVisualStyleBackColor = true;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // btXN
            // 
            this.btXN.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btXN.Location = new System.Drawing.Point(819, 224);
            this.btXN.Name = "btXN";
            this.btXN.Size = new System.Drawing.Size(81, 36);
            this.btXN.TabIndex = 71;
            this.btXN.Text = "Xác nhận";
            this.btXN.UseVisualStyleBackColor = true;
            this.btXN.Click += new System.EventHandler(this.btXN_Click);
            // 
            // txtSODU
            // 
            this.txtSODU.Location = new System.Drawing.Point(912, 162);
            this.txtSODU.Name = "txtSODU";
            this.txtSODU.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSODU.Properties.Appearance.Options.UseFont = true;
            this.txtSODU.Properties.DisplayFormat.FormatString = "n0";
            this.txtSODU.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSODU.Properties.EditFormat.FormatString = "n0";
            this.txtSODU.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSODU.Size = new System.Drawing.Size(125, 22);
            this.txtSODU.TabIndex = 70;
            // 
            // txtSOTK
            // 

            this.txtSOTK.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dSTK, "SOTK", true));
            this.txtSOTK.Location = new System.Drawing.Point(912, 100);
            this.txtSOTK.Name = "txtSOTK";
            this.txtSOTK.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSOTK.Properties.Appearance.Options.UseFont = true;
            this.txtSOTK.Size = new System.Drawing.Size(125, 22);
            this.txtSOTK.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(820, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 26);
            this.label2.TabIndex = 63;
            this.label2.Text = "TẠO TÀI KHOẢN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(207, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 26);
            this.label1.TabIndex = 45;
            this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
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
            // tAIKHOANTableAdapter
            // 
            this.tAIKHOANTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHINHANHTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = this.kHACHHANGTableAdapter;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = this.tAIKHOANTableAdapter;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSTKTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdsKH
            // 
            this.bdsKH.DataMember = "KHACHHANG";
            this.bdsKH.DataSource = this.dSTK;
            // 
            // kHACHHANGTableAdapter
            // 
            this.kHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // frmMoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 512);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmMoTaiKhoan";
            this.Text = "MoTaiKhoan";
            this.Load += new System.EventHandler(this.MoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapCMND.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYCAP.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYCAP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSODT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMACN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIACHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMND.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSODU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btKT;
        private DevExpress.XtraEditors.TextEdit txtNhapCMND;
        private System.Windows.Forms.Label nhapCMND;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btHuy;
        private System.Windows.Forms.Button btXN;
        private DevExpress.XtraEditors.TextEdit txtSODU;
        private DevExpress.XtraEditors.TextEdit txtSOTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPHAI;
        private DevExpress.XtraEditors.DateEdit dteNGAYCAP;
        private DevExpress.XtraEditors.TextEdit txtSODT;
        private DevExpress.XtraEditors.TextEdit txtTEN;
        private DevExpress.XtraEditors.TextEdit txtMACN;
        private DevExpress.XtraEditors.TextEdit txtDIACHI;
        private DevExpress.XtraEditors.TextEdit txtHO;
        private DevExpress.XtraEditors.TextEdit txtCMND;
        private DSTK dSTK;
        private System.Windows.Forms.BindingSource bdsTK;
        private DSTKTableAdapters.TAIKHOANTableAdapter tAIKHOANTableAdapter;
        private DSTKTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTKTableAdapters.KHACHHANGTableAdapter kHACHHANGTableAdapter;
        private System.Windows.Forms.BindingSource bdsKH;
    }
}