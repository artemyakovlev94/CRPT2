namespace Crypto
{
    partial class Form_Main
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
            this.tc_sign_data = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tlp_sign_data = new System.Windows.Forms.TableLayoutPanel();
            this.tb_data = new System.Windows.Forms.TextBox();
            this.rtb_sign_data = new System.Windows.Forms.RichTextBox();
            this.btn_sign_data = new System.Windows.Forms.Button();
            this.tb_shielding = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_string_for_shielding = new System.Windows.Forms.TextBox();
            this.rtb_data_shielding = new System.Windows.Forms.RichTextBox();
            this.radio_btn_URL = new System.Windows.Forms.RadioButton();
            this.radio_btn_JSON = new System.Windows.Forms.RadioButton();
            this.radio_btn_XML = new System.Windows.Forms.RadioButton();
            this.tc_sign_data.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tlp_sign_data.SuspendLayout();
            this.tb_shielding.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_sign_data
            // 
            this.tc_sign_data.Controls.Add(this.tabPage1);
            this.tc_sign_data.Controls.Add(this.tb_shielding);
            this.tc_sign_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_sign_data.Location = new System.Drawing.Point(0, 0);
            this.tc_sign_data.Name = "tc_sign_data";
            this.tc_sign_data.SelectedIndex = 0;
            this.tc_sign_data.Size = new System.Drawing.Size(800, 450);
            this.tc_sign_data.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tlp_sign_data);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sign string";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tlp_sign_data
            // 
            this.tlp_sign_data.ColumnCount = 2;
            this.tlp_sign_data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_sign_data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_sign_data.Controls.Add(this.tb_data, 0, 0);
            this.tlp_sign_data.Controls.Add(this.rtb_sign_data, 0, 1);
            this.tlp_sign_data.Controls.Add(this.btn_sign_data, 1, 0);
            this.tlp_sign_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_sign_data.Location = new System.Drawing.Point(3, 3);
            this.tlp_sign_data.Name = "tlp_sign_data";
            this.tlp_sign_data.RowCount = 2;
            this.tlp_sign_data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_sign_data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_sign_data.Size = new System.Drawing.Size(786, 418);
            this.tlp_sign_data.TabIndex = 0;
            // 
            // tb_data
            // 
            this.tb_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_data.Location = new System.Drawing.Point(3, 3);
            this.tb_data.Name = "tb_data";
            this.tb_data.Size = new System.Drawing.Size(730, 20);
            this.tb_data.TabIndex = 0;
            // 
            // rtb_sign_data
            // 
            this.tlp_sign_data.SetColumnSpan(this.rtb_sign_data, 2);
            this.rtb_sign_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_sign_data.Location = new System.Drawing.Point(3, 33);
            this.rtb_sign_data.Name = "rtb_sign_data";
            this.rtb_sign_data.Size = new System.Drawing.Size(780, 382);
            this.rtb_sign_data.TabIndex = 1;
            this.rtb_sign_data.Text = "";
            // 
            // btn_sign_data
            // 
            this.btn_sign_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_sign_data.Location = new System.Drawing.Point(739, 3);
            this.btn_sign_data.Name = "btn_sign_data";
            this.btn_sign_data.Size = new System.Drawing.Size(44, 24);
            this.btn_sign_data.TabIndex = 2;
            this.btn_sign_data.Text = "Sign";
            this.btn_sign_data.UseVisualStyleBackColor = true;
            this.btn_sign_data.Click += new System.EventHandler(this.btn_sign_data_Click);
            // 
            // tb_shielding
            // 
            this.tb_shielding.Controls.Add(this.tableLayoutPanel1);
            this.tb_shielding.Location = new System.Drawing.Point(4, 22);
            this.tb_shielding.Name = "tb_shielding";
            this.tb_shielding.Padding = new System.Windows.Forms.Padding(3);
            this.tb_shielding.Size = new System.Drawing.Size(792, 424);
            this.tb_shielding.TabIndex = 1;
            this.tb_shielding.Text = "Shielding";
            this.tb_shielding.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.tb_string_for_shielding, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtb_data_shielding, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radio_btn_URL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radio_btn_JSON, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radio_btn_XML, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 418);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tb_string_for_shielding
            // 
            this.tb_string_for_shielding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_string_for_shielding.Location = new System.Drawing.Point(3, 3);
            this.tb_string_for_shielding.Name = "tb_string_for_shielding";
            this.tb_string_for_shielding.Size = new System.Drawing.Size(540, 20);
            this.tb_string_for_shielding.TabIndex = 0;
            this.tb_string_for_shielding.TextChanged += new System.EventHandler(this.tb_string_for_shielding_TextChanged);
            // 
            // rtb_data_shielding
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtb_data_shielding, 4);
            this.rtb_data_shielding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_data_shielding.Location = new System.Drawing.Point(3, 33);
            this.rtb_data_shielding.Name = "rtb_data_shielding";
            this.rtb_data_shielding.Size = new System.Drawing.Size(780, 382);
            this.rtb_data_shielding.TabIndex = 1;
            this.rtb_data_shielding.Text = "";
            // 
            // radio_btn_URL
            // 
            this.radio_btn_URL.AutoSize = true;
            this.radio_btn_URL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radio_btn_URL.Location = new System.Drawing.Point(549, 3);
            this.radio_btn_URL.Name = "radio_btn_URL";
            this.radio_btn_URL.Size = new System.Drawing.Size(74, 24);
            this.radio_btn_URL.TabIndex = 2;
            this.radio_btn_URL.TabStop = true;
            this.radio_btn_URL.Text = "URL";
            this.radio_btn_URL.UseVisualStyleBackColor = true;
            this.radio_btn_URL.CheckedChanged += new System.EventHandler(this.radio_btn_URL_CheckedChanged);
            // 
            // radio_btn_JSON
            // 
            this.radio_btn_JSON.AutoSize = true;
            this.radio_btn_JSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radio_btn_JSON.Location = new System.Drawing.Point(629, 3);
            this.radio_btn_JSON.Name = "radio_btn_JSON";
            this.radio_btn_JSON.Size = new System.Drawing.Size(74, 24);
            this.radio_btn_JSON.TabIndex = 3;
            this.radio_btn_JSON.TabStop = true;
            this.radio_btn_JSON.Text = "JSON";
            this.radio_btn_JSON.UseVisualStyleBackColor = true;
            this.radio_btn_JSON.CheckedChanged += new System.EventHandler(this.radio_btn_JSON_CheckedChanged);
            // 
            // radio_btn_XML
            // 
            this.radio_btn_XML.AutoSize = true;
            this.radio_btn_XML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radio_btn_XML.Location = new System.Drawing.Point(709, 3);
            this.radio_btn_XML.Name = "radio_btn_XML";
            this.radio_btn_XML.Size = new System.Drawing.Size(74, 24);
            this.radio_btn_XML.TabIndex = 4;
            this.radio_btn_XML.TabStop = true;
            this.radio_btn_XML.Text = "XML";
            this.radio_btn_XML.UseVisualStyleBackColor = true;
            this.radio_btn_XML.CheckedChanged += new System.EventHandler(this.radio_btn_XML_CheckedChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tc_sign_data);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Activated += new System.EventHandler(this.Form_Main_Activated);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tc_sign_data.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tlp_sign_data.ResumeLayout(false);
            this.tlp_sign_data.PerformLayout();
            this.tb_shielding.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_sign_data;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tlp_sign_data;
        private System.Windows.Forms.TextBox tb_data;
        private System.Windows.Forms.RichTextBox rtb_sign_data;
        private System.Windows.Forms.Button btn_sign_data;
        private System.Windows.Forms.TabPage tb_shielding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tb_string_for_shielding;
        private System.Windows.Forms.RichTextBox rtb_data_shielding;
        private System.Windows.Forms.RadioButton radio_btn_URL;
        private System.Windows.Forms.RadioButton radio_btn_JSON;
        private System.Windows.Forms.RadioButton radio_btn_XML;
    }
}