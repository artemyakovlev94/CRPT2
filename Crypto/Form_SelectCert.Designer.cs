namespace Crypto
{
    partial class Form_SelectCert
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_certs = new System.Windows.Forms.ComboBox();
            this.rtb_data_cert = new System.Windows.Forms.RichTextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cb_certs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtb_data_cert, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_OK, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_Cancel, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 330);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cb_certs
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cb_certs, 2);
            this.cb_certs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_certs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_certs.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_certs.FormattingEnabled = true;
            this.cb_certs.Location = new System.Drawing.Point(20, 20);
            this.cb_certs.Margin = new System.Windows.Forms.Padding(20);
            this.cb_certs.Name = "cb_certs";
            this.cb_certs.Size = new System.Drawing.Size(605, 31);
            this.cb_certs.TabIndex = 0;
            this.cb_certs.SelectedIndexChanged += new System.EventHandler(this.cb_certs_SelectedIndexChanged);
            // 
            // rtb_data_cert
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtb_data_cert, 2);
            this.rtb_data_cert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_data_cert.Location = new System.Drawing.Point(100, 100);
            this.rtb_data_cert.Margin = new System.Windows.Forms.Padding(100, 20, 100, 20);
            this.rtb_data_cert.Name = "rtb_data_cert";
            this.rtb_data_cert.Size = new System.Drawing.Size(445, 130);
            this.rtb_data_cert.TabIndex = 1;
            this.rtb_data_cert.Text = "";
            // 
            // btn_OK
            // 
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_OK.Location = new System.Drawing.Point(150, 253);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(150, 3, 50, 30);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(122, 47);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Cancel.Location = new System.Drawing.Point(372, 253);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(50, 3, 150, 30);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(123, 47);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_SelectCert
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(645, 330);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_SelectCert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SelectCert";
            this.Load += new System.EventHandler(this.Form_SelectCert_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cb_certs;
        private System.Windows.Forms.RichTextBox rtb_data_cert;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}