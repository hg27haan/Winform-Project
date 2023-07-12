namespace NewDoAn
{
    partial class FormGiaoDienBanDau
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
            this.ptBKhachHang = new System.Windows.Forms.PictureBox();
            this.ptbNhanVien = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptBKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // ptBKhachHang
            // 
            this.ptBKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptBKhachHang.Image = global::NewDoAn.Properties.Resources.KhachHang;
            this.ptBKhachHang.Location = new System.Drawing.Point(6, 180);
            this.ptBKhachHang.Name = "ptBKhachHang";
            this.ptBKhachHang.Size = new System.Drawing.Size(301, 92);
            this.ptBKhachHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBKhachHang.TabIndex = 3;
            this.ptBKhachHang.TabStop = false;
            this.ptBKhachHang.Click += new System.EventHandler(this.ptBKhachHang_Click);
            // 
            // ptbNhanVien
            // 
            this.ptbNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbNhanVien.Image = global::NewDoAn.Properties.Resources.NhanVien;
            this.ptbNhanVien.Location = new System.Drawing.Point(6, 80);
            this.ptbNhanVien.Name = "ptbNhanVien";
            this.ptbNhanVien.Size = new System.Drawing.Size(301, 94);
            this.ptbNhanVien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbNhanVien.TabIndex = 2;
            this.ptbNhanVien.TabStop = false;
            this.ptbNhanVien.Click += new System.EventHandler(this.ptbNhanVien_Click);
            // 
            // FormGiaoDienBanDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(314, 283);
            this.Controls.Add(this.ptBKhachHang);
            this.Controls.Add(this.ptbNhanVien);
            this.MaximizeBox = false;
            this.Name = "FormGiaoDienBanDau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BẠN LÀ ?";
            ((System.ComponentModel.ISupportInitialize)(this.ptBKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ptbNhanVien;
        private System.Windows.Forms.PictureBox ptBKhachHang;
    }
}