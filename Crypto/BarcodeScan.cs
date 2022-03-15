using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class BarcodeScan : Form
    {
        public BarcodeScan()
        {
            InitializeComponent();
        }

        private void BarcodeScan_Load(object sender, EventArgs e)
        {
            cb_barcodeScanerPort.Items.Add("HID");

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                cb_barcodeScanerPort.Items.Add(port);

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.BarcodeScannerPort))
            {
                if (cb_barcodeScanerPort.Items.Count > 0)
                    cb_barcodeScanerPort.SelectedIndex = 0;
            }
            else
            {
                cb_barcodeScanerPort.SelectedIndex = cb_barcodeScanerPort.Items.IndexOf(Properties.Settings.Default.BarcodeScannerPort);
            }

            tb_SymbolNewLine.Text = Properties.Settings.Default.BarcodeScannerLineBreakCharacter;
            tb_symbolGSForHID.Text = Properties.Settings.Default.BarcodeScannerGS1Character;
        }

        private void tb_SymbolNewLine_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerLineBreakCharacter = e.KeyData.ToString();
            Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue = e.KeyValue;
            Properties.Settings.Default.Save();

            tb_SymbolNewLine.Text = e.KeyData.ToString();
        }

        private void tb_symbolGSForHID_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerGS1Character = e.KeyData.ToString();
            Properties.Settings.Default.BarcodeScannerGS1CharacterValue = e.KeyValue;
            Properties.Settings.Default.Save();

            tb_symbolGSForHID.Text = e.KeyData.ToString();
        }

        private void cb_barcodeScanerPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerPort = cb_barcodeScanerPort.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            tb_symbolGSForHID.Enabled = cb_barcodeScanerPort.SelectedItem.ToString() == "HID";

            if (cb_barcodeScanerPort.SelectedItem.ToString() == "HID")
            {
                if (serialPortBarcodeScaner.IsOpen)
                    serialPortBarcodeScaner.Close();
            }
            else
            {
                if (serialPortBarcodeScaner.IsOpen)
                    serialPortBarcodeScaner.Close();

                serialPortBarcodeScaner.PortName = cb_barcodeScanerPort.SelectedItem.ToString();
                serialPortBarcodeScaner.BaudRate = 9600;
                serialPortBarcodeScaner.DataBits = 8;
                serialPortBarcodeScaner.Encoding = Encoding.ASCII;
                serialPortBarcodeScaner.Open();
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate));
        }

        private void DoUpdate(object s, EventArgs e)
        {
            char[] chars = serialPortBarcodeScaner.ReadExisting().ToArray();

            tb_scanData.Text = string.Empty;

            foreach (var ch in chars)
            {
                if (ch == (char)Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue || ch == (char)29)
                    break;

                tb_scanData.Text += ch;
            }

            rtb_scanData.Text += tb_scanData.Text;
            rtb_scanData.Text += Environment.NewLine;
        }
    }
}
