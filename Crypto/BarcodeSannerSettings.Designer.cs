namespace Crypto
{
    partial class BarcodeSannerSettings
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
            this.cb_Ports = new System.Windows.Forms.ComboBox();
            this.tb_lineBreakCharacter = new System.Windows.Forms.TextBox();
            this.tb_GS1Symbol = new System.Windows.Forms.TextBox();
            this.cb_BaudRate = new System.Windows.Forms.ComboBox();
            this.label_ports = new System.Windows.Forms.Label();
            this.label_BaudRate = new System.Windows.Forms.Label();
            this.label_lineBreakCharacter = new System.Windows.Forms.Label();
            this.label_GS1Symbol = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Test = new System.Windows.Forms.Button();
            this.rtb_Test = new System.Windows.Forms.RichTextBox();
            this.serialPortBarcodeScaner = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_Ports
            // 
            this.cb_Ports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Ports.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_Ports.FormattingEnabled = true;
            this.cb_Ports.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_Ports.Location = new System.Drawing.Point(197, 3);
            this.cb_Ports.Name = "cb_Ports";
            this.cb_Ports.Size = new System.Drawing.Size(189, 24);
            this.cb_Ports.TabIndex = 0;
            this.cb_Ports.SelectedIndexChanged += new System.EventHandler(this.cb_Ports_SelectedIndexChanged);
            // 
            // tb_lineBreakCharacter
            // 
            this.tb_lineBreakCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_lineBreakCharacter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_lineBreakCharacter.Location = new System.Drawing.Point(197, 63);
            this.tb_lineBreakCharacter.Name = "tb_lineBreakCharacter";
            this.tb_lineBreakCharacter.ReadOnly = true;
            this.tb_lineBreakCharacter.Size = new System.Drawing.Size(189, 23);
            this.tb_lineBreakCharacter.TabIndex = 1;
            this.tb_lineBreakCharacter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_lineBreakCharacter_KeyDown);
            // 
            // tb_GS1Symbol
            // 
            this.tb_GS1Symbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_GS1Symbol.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_GS1Symbol.Location = new System.Drawing.Point(197, 92);
            this.tb_GS1Symbol.Name = "tb_GS1Symbol";
            this.tb_GS1Symbol.ReadOnly = true;
            this.tb_GS1Symbol.Size = new System.Drawing.Size(189, 23);
            this.tb_GS1Symbol.TabIndex = 2;
            this.tb_GS1Symbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_GS1Symbol_KeyDown);
            // 
            // cb_BaudRate
            // 
            this.cb_BaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_BaudRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_BaudRate.FormattingEnabled = true;
            this.cb_BaudRate.Location = new System.Drawing.Point(197, 33);
            this.cb_BaudRate.Name = "cb_BaudRate";
            this.cb_BaudRate.Size = new System.Drawing.Size(189, 24);
            this.cb_BaudRate.TabIndex = 3;
            this.cb_BaudRate.SelectedIndexChanged += new System.EventHandler(this.cb_BaudRate_SelectedIndexChanged);
            // 
            // label_ports
            // 
            this.label_ports.AutoSize = true;
            this.label_ports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ports.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ports.Location = new System.Drawing.Point(3, 5);
            this.label_ports.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label_ports.Name = "label_ports";
            this.label_ports.Size = new System.Drawing.Size(188, 25);
            this.label_ports.TabIndex = 4;
            this.label_ports.Text = "Порт:";
            this.label_ports.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_BaudRate
            // 
            this.label_BaudRate.AutoSize = true;
            this.label_BaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_BaudRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_BaudRate.Location = new System.Drawing.Point(3, 35);
            this.label_BaudRate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label_BaudRate.Name = "label_BaudRate";
            this.label_BaudRate.Size = new System.Drawing.Size(188, 25);
            this.label_BaudRate.TabIndex = 5;
            this.label_BaudRate.Text = "Скорость передачи:";
            this.label_BaudRate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_lineBreakCharacter
            // 
            this.label_lineBreakCharacter.AutoSize = true;
            this.label_lineBreakCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_lineBreakCharacter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_lineBreakCharacter.Location = new System.Drawing.Point(3, 65);
            this.label_lineBreakCharacter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label_lineBreakCharacter.Name = "label_lineBreakCharacter";
            this.label_lineBreakCharacter.Size = new System.Drawing.Size(188, 24);
            this.label_lineBreakCharacter.TabIndex = 6;
            this.label_lineBreakCharacter.Text = "Символ переноса строки:";
            this.label_lineBreakCharacter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_GS1Symbol
            // 
            this.label_GS1Symbol.AutoSize = true;
            this.label_GS1Symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_GS1Symbol.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_GS1Symbol.Location = new System.Drawing.Point(3, 94);
            this.label_GS1Symbol.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label_GS1Symbol.Name = "label_GS1Symbol";
            this.label_GS1Symbol.Size = new System.Drawing.Size(188, 24);
            this.label_GS1Symbol.TabIndex = 7;
            this.label_GS1Symbol.Text = "Символ GS1 (для HID):";
            this.label_GS1Symbol.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cb_Ports, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Test, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_GS1Symbol, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cb_BaudRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_lineBreakCharacter, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_lineBreakCharacter, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_BaudRate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_GS1Symbol, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_ports, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 156);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btn_Test
            // 
            this.btn_Test.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Test.Location = new System.Drawing.Point(197, 121);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(189, 23);
            this.btn_Test.TabIndex = 9;
            this.btn_Test.Text = "Проверка связи";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // rtb_Test
            // 
            this.rtb_Test.Location = new System.Drawing.Point(12, 174);
            this.rtb_Test.Name = "rtb_Test";
            this.rtb_Test.ReadOnly = true;
            this.rtb_Test.Size = new System.Drawing.Size(386, 96);
            this.rtb_Test.TabIndex = 10;
            this.rtb_Test.Text = "";
            this.rtb_Test.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.rtb_Test_PreviewKeyDown);
            // 
            // serialPortBarcodeScaner
            // 
            this.serialPortBarcodeScaner.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortBarcodeScaner_DataReceived);
            // 
            // BarcodeSannerSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(417, 280);
            this.Controls.Add(this.rtb_Test);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeSannerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка сканера штрихкода";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BarcodeSannerSettings_FormClosed);
            this.Load += new System.EventHandler(this.BarcodeSannerSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarcodeSannerSettings_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BarcodeSannerSettings_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BarcodeSannerSettings_PreviewKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Ports;
        private System.Windows.Forms.TextBox tb_lineBreakCharacter;
        private System.Windows.Forms.TextBox tb_GS1Symbol;
        private System.Windows.Forms.ComboBox cb_BaudRate;
        private System.Windows.Forms.Label label_ports;
        private System.Windows.Forms.Label label_BaudRate;
        private System.Windows.Forms.Label label_lineBreakCharacter;
        private System.Windows.Forms.Label label_GS1Symbol;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.RichTextBox rtb_Test;
        private System.IO.Ports.SerialPort serialPortBarcodeScaner;
    }
}