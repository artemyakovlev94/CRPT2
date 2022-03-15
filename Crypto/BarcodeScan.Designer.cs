namespace Crypto
{
    partial class BarcodeScan
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
            this.cb_barcodeScanerPort = new System.Windows.Forms.ComboBox();
            this.serialPortBarcodeScaner = new System.IO.Ports.SerialPort(this.components);
            this.tb_SymbolNewLine = new System.Windows.Forms.TextBox();
            this.label_barcodeScaner = new System.Windows.Forms.Label();
            this.label_symbolNewLine = new System.Windows.Forms.Label();
            this.label_symbolGSForHID = new System.Windows.Forms.Label();
            this.tb_symbolGSForHID = new System.Windows.Forms.TextBox();
            this.tb_scanData = new System.Windows.Forms.TextBox();
            this.rtb_scanData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cb_barcodeScanerPort
            // 
            this.cb_barcodeScanerPort.FormattingEnabled = true;
            this.cb_barcodeScanerPort.Location = new System.Drawing.Point(101, 12);
            this.cb_barcodeScanerPort.Name = "cb_barcodeScanerPort";
            this.cb_barcodeScanerPort.Size = new System.Drawing.Size(121, 21);
            this.cb_barcodeScanerPort.TabIndex = 0;
            this.cb_barcodeScanerPort.SelectedIndexChanged += new System.EventHandler(this.cb_barcodeScanerPort_SelectedIndexChanged);
            // 
            // serialPortBarcodeScaner
            // 
            this.serialPortBarcodeScaner.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tb_SymbolNewLine
            // 
            this.tb_SymbolNewLine.Location = new System.Drawing.Point(372, 12);
            this.tb_SymbolNewLine.Name = "tb_SymbolNewLine";
            this.tb_SymbolNewLine.Size = new System.Drawing.Size(100, 20);
            this.tb_SymbolNewLine.TabIndex = 1;
            this.tb_SymbolNewLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_SymbolNewLine_KeyDown);
            // 
            // label_barcodeScaner
            // 
            this.label_barcodeScaner.AutoSize = true;
            this.label_barcodeScaner.Location = new System.Drawing.Point(10, 15);
            this.label_barcodeScaner.Name = "label_barcodeScaner";
            this.label_barcodeScaner.Size = new System.Drawing.Size(85, 13);
            this.label_barcodeScaner.TabIndex = 2;
            this.label_barcodeScaner.Text = "Barcode scaner:";
            // 
            // label_symbolNewLine
            // 
            this.label_symbolNewLine.AutoSize = true;
            this.label_symbolNewLine.Location = new System.Drawing.Point(228, 15);
            this.label_symbolNewLine.Name = "label_symbolNewLine";
            this.label_symbolNewLine.Size = new System.Drawing.Size(138, 13);
            this.label_symbolNewLine.TabIndex = 3;
            this.label_symbolNewLine.Text = "Символ переноса строки:";
            // 
            // label_symbolGSForHID
            // 
            this.label_symbolGSForHID.AutoSize = true;
            this.label_symbolGSForHID.Location = new System.Drawing.Point(478, 15);
            this.label_symbolGSForHID.Name = "label_symbolGSForHID";
            this.label_symbolGSForHID.Size = new System.Drawing.Size(116, 13);
            this.label_symbolGSForHID.TabIndex = 4;
            this.label_symbolGSForHID.Text = "Символ GS (для HID):";
            // 
            // tb_symbolGSForHID
            // 
            this.tb_symbolGSForHID.Location = new System.Drawing.Point(600, 13);
            this.tb_symbolGSForHID.Name = "tb_symbolGSForHID";
            this.tb_symbolGSForHID.Size = new System.Drawing.Size(100, 20);
            this.tb_symbolGSForHID.TabIndex = 5;
            this.tb_symbolGSForHID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_symbolGSForHID_KeyDown);
            // 
            // tb_scanData
            // 
            this.tb_scanData.Location = new System.Drawing.Point(13, 49);
            this.tb_scanData.Name = "tb_scanData";
            this.tb_scanData.Size = new System.Drawing.Size(687, 20);
            this.tb_scanData.TabIndex = 6;
            // 
            // rtb_scanData
            // 
            this.rtb_scanData.Location = new System.Drawing.Point(13, 87);
            this.rtb_scanData.Name = "rtb_scanData";
            this.rtb_scanData.Size = new System.Drawing.Size(687, 351);
            this.rtb_scanData.TabIndex = 7;
            this.rtb_scanData.Text = "";
            // 
            // BarcodeScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 450);
            this.Controls.Add(this.rtb_scanData);
            this.Controls.Add(this.tb_scanData);
            this.Controls.Add(this.tb_symbolGSForHID);
            this.Controls.Add(this.label_symbolGSForHID);
            this.Controls.Add(this.label_symbolNewLine);
            this.Controls.Add(this.label_barcodeScaner);
            this.Controls.Add(this.tb_SymbolNewLine);
            this.Controls.Add(this.cb_barcodeScanerPort);
            this.Name = "BarcodeScan";
            this.Text = "BarcodeScan";
            this.Load += new System.EventHandler(this.BarcodeScan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_barcodeScanerPort;
        private System.IO.Ports.SerialPort serialPortBarcodeScaner;
        private System.Windows.Forms.TextBox tb_SymbolNewLine;
        private System.Windows.Forms.Label label_barcodeScaner;
        private System.Windows.Forms.Label label_symbolNewLine;
        private System.Windows.Forms.Label label_symbolGSForHID;
        private System.Windows.Forms.TextBox tb_symbolGSForHID;
        private System.Windows.Forms.TextBox tb_scanData;
        private System.Windows.Forms.RichTextBox rtb_scanData;
    }
}