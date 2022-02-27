namespace Crypto
{
    partial class Form_Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Auth));
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_sign_in = new System.Windows.Forms.Button();
            this.cb_certificates = new System.Windows.Forms.ComboBox();
            this.label_certificate = new System.Windows.Forms.Label();
            this.rtb_cert_data = new System.Windows.Forms.RichTextBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Close.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btn_Close.Location = new System.Drawing.Point(363, 349);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(129, 37);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "ЗАКРЫТЬ";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_sign_in
            // 
            this.btn_sign_in.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_sign_in.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sign_in.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btn_sign_in.Location = new System.Drawing.Point(211, 349);
            this.btn_sign_in.Name = "btn_sign_in";
            this.btn_sign_in.Size = new System.Drawing.Size(129, 37);
            this.btn_sign_in.TabIndex = 1;
            this.btn_sign_in.Text = "ВОЙТИ";
            this.btn_sign_in.UseVisualStyleBackColor = true;
            this.btn_sign_in.Click += new System.EventHandler(this.btn_sign_in_Click);
            // 
            // cb_certificates
            // 
            this.cb_certificates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(11)))));
            this.cb_certificates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_certificates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_certificates.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold);
            this.cb_certificates.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cb_certificates.FormattingEnabled = true;
            this.cb_certificates.Location = new System.Drawing.Point(31, 176);
            this.cb_certificates.Name = "cb_certificates";
            this.cb_certificates.Size = new System.Drawing.Size(641, 32);
            this.cb_certificates.Sorted = true;
            this.cb_certificates.TabIndex = 0;
            this.cb_certificates.SelectedIndexChanged += new System.EventHandler(this.cb_certificates_SelectedIndexChanged);
            // 
            // label_certificate
            // 
            this.label_certificate.AutoSize = true;
            this.label_certificate.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_certificate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_certificate.Location = new System.Drawing.Point(27, 149);
            this.label_certificate.Name = "label_certificate";
            this.label_certificate.Size = new System.Drawing.Size(219, 24);
            this.label_certificate.TabIndex = 3;
            this.label_certificate.Text = "Выберите сертификат:";
            // 
            // rtb_cert_data
            // 
            this.rtb_cert_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(11)))));
            this.rtb_cert_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_cert_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_cert_data.Location = new System.Drawing.Point(163, 227);
            this.rtb_cert_data.Name = "rtb_cert_data";
            this.rtb_cert_data.ReadOnly = true;
            this.rtb_cert_data.Size = new System.Drawing.Size(376, 98);
            this.rtb_cert_data.TabIndex = 4;
            this.rtb_cert_data.TabStop = false;
            this.rtb_cert_data.Text = "";
            // 
            // pb_logo
            // 
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(261, 24);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(180, 119);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 5;
            this.pb_logo.TabStop = false;
            // 
            // Form_Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(702, 419);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.rtb_cert_data);
            this.Controls.Add(this.label_certificate);
            this.Controls.Add(this.cb_certificates);
            this.Controls.Add(this.btn_sign_in);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Auth_FormClosed);
            this.Load += new System.EventHandler(this.Form_Auth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_sign_in;
        private System.Windows.Forms.ComboBox cb_certificates;
        private System.Windows.Forms.Label label_certificate;
        private System.Windows.Forms.RichTextBox rtb_cert_data;
        private System.Windows.Forms.PictureBox pb_logo;
    }
}