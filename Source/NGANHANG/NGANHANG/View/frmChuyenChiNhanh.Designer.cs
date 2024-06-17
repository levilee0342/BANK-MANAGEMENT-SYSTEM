
namespace NGANHANG.View
{
    partial class frmChuyenChiNhanh
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.t = new DevExpress.XtraEditors.LabelControl();
            this.x = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtMaNV);
            this.groupControl1.Controls.Add(this.cbChiNhanh);
            this.groupControl1.Controls.Add(this.t);
            this.groupControl1.Controls.Add(this.x);
            this.groupControl1.Location = new System.Drawing.Point(179, 47);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(619, 198);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Chuyển chi nhánh";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(236, 125);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(302, 23);
            this.txtMaNV.TabIndex = 9;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(236, 69);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(302, 24);
            this.cbChiNhanh.TabIndex = 8;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            this.cbChiNhanh.Click += new System.EventHandler(this.cbChiNhanh_Click);
            this.cbChiNhanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbChiNhanh_KeyPress);
            // 
            // t
            // 
            this.t.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.t.Appearance.Options.UseFont = true;
            this.t.Location = new System.Drawing.Point(56, 70);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(64, 18);
            this.t.TabIndex = 4;
            this.t.Text = "Chi nhánh";
            // 
            // x
            // 
            this.x.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.x.Appearance.Options.UseFont = true;
            this.x.Location = new System.Drawing.Point(56, 125);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(116, 18);
            this.x.TabIndex = 0;
            this.x.Text = "Mã nhân viên mới";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(525, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(364, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 29);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ChuyenChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 390);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "ChuyenChiNhanh";
            this.Text = "ChuyenChiNhanh";
            this.Load += new System.EventHandler(this.ChuyenChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.ComboBox cbChiNhanh;
        private DevExpress.XtraEditors.LabelControl t;
        private DevExpress.XtraEditors.LabelControl x;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}