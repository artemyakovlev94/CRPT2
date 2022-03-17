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
using System.Windows.Input;

namespace Crypto
{
    public partial class BarcodeSannerSettings : Form
    {
        BarcodeScanner2 barcodeScanner2 = new BarcodeScanner2();

        bool TestConnection = false;

        public BarcodeSannerSettings()
        {
            InitializeComponent();
        }

        private void BarcodeSannerSettings_Load(object sender, EventArgs e)
        {
            cb_Ports.Items.Add("HID");

            cb_BaudRate.Items.Add(1200);
            cb_BaudRate.Items.Add(9600);

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                cb_Ports.Items.Add(port);

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.BarcodeScannerPort))
            {
                Properties.Settings.Default.BarcodeScannerPort = cb_Ports.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.BarcodeScannerBaudRate <= 0)
            {
                Properties.Settings.Default.BarcodeScannerBaudRate = 9600;
                Properties.Settings.Default.Save();
            }

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.BarcodeScannerLineBreakCharacter) ||
                Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue <= 0)
            {
                Properties.Settings.Default.BarcodeScannerLineBreakCharacter = "Return";
                Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue = 13;
                Properties.Settings.Default.Save();
            }

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.BarcodeScannerGS1Character) ||
                Properties.Settings.Default.BarcodeScannerGS1CharacterValue <= 0)
            {
                Properties.Settings.Default.BarcodeScannerGS1Character = "F8";
                Properties.Settings.Default.BarcodeScannerGS1CharacterValue = 119;
                Properties.Settings.Default.Save();
            }

            cb_Ports.SelectedIndex = cb_Ports.Items.IndexOf(Properties.Settings.Default.BarcodeScannerPort);
            cb_BaudRate.SelectedIndex = cb_BaudRate.Items.IndexOf(Properties.Settings.Default.BarcodeScannerBaudRate);
            tb_lineBreakCharacter.Text = Properties.Settings.Default.BarcodeScannerLineBreakCharacter;
            tb_GS1Symbol.Text = Properties.Settings.Default.BarcodeScannerGS1Character;

            barcodeScanner2.SetPort(Properties.Settings.Default.BarcodeScannerPort);
            barcodeScanner2.SetBaudRate(Properties.Settings.Default.BarcodeScannerBaudRate);
            barcodeScanner2.SetLineBreakSymbol(Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue);
            barcodeScanner2.SetGS1Symbol(Properties.Settings.Default.BarcodeScannerGS1CharacterValue);

            rtb_Test.Visible = TestConnection;
        }

        private void BarcodeSannerSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPortBarcodeScaner.IsOpen)
                serialPortBarcodeScaner.Close();
        }

        private void AccessibilityFormElements()
        {
            btn_Test.Text = TestConnection ? "Прервать" : "Проверка связи";

            cb_Ports.Enabled = !TestConnection;
            cb_BaudRate.Enabled = TestConnection ? false : cb_Ports.SelectedItem.ToString() != "HID";
            tb_lineBreakCharacter.Enabled = !TestConnection;
            tb_GS1Symbol.Enabled = TestConnection ? false : cb_Ports.SelectedItem.ToString() == "HID";

            rtb_Test.Visible = TestConnection;
        }

        private void cb_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerPort = cb_Ports.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            barcodeScanner2.SetPort(Properties.Settings.Default.BarcodeScannerPort);

            AccessibilityFormElements();
        }

        private void cb_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerBaudRate = (int)cb_BaudRate.SelectedItem;
            Properties.Settings.Default.Save();

            barcodeScanner2.SetBaudRate(Properties.Settings.Default.BarcodeScannerBaudRate);
        }

        private void tb_lineBreakCharacter_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerLineBreakCharacter = e.KeyData.ToString();
            Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue = e.KeyValue;
            Properties.Settings.Default.Save();

            barcodeScanner2.SetLineBreakSymbol(Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue);

            tb_lineBreakCharacter.Text = e.KeyData.ToString();
        }

        private void tb_GS1Symbol_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerGS1Character = e.KeyData.ToString();
            Properties.Settings.Default.BarcodeScannerGS1CharacterValue = e.KeyValue;
            Properties.Settings.Default.Save();

            barcodeScanner2.SetGS1Symbol(Properties.Settings.Default.BarcodeScannerGS1CharacterValue);

            tb_GS1Symbol.Text = e.KeyData.ToString();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            rtb_Test.Text = string.Empty;

            TestConnection = !TestConnection;

            AccessibilityFormElements();

            if (cb_Ports.SelectedItem.ToString() == "HID")
            {
                if (TestConnection)
                {
                    rtb_Test.Focus();
                    barcodeScanner2.NotifyReceivedData += NotifyReceivedData;
                }
                else
                {
                    barcodeScanner2.NotifyReceivedData -= NotifyReceivedData;
                }   
            }
            else
            {
                if (TestConnection)
                {
                    if (serialPortBarcodeScaner.IsOpen)
                        serialPortBarcodeScaner.Close();

                    serialPortBarcodeScaner.PortName = cb_Ports.SelectedItem.ToString();
                    serialPortBarcodeScaner.BaudRate = (int)cb_BaudRate.SelectedItem;
                    serialPortBarcodeScaner.DataBits = 8;
                    serialPortBarcodeScaner.Encoding = Encoding.ASCII;
                    serialPortBarcodeScaner.Open();
                }
                else
                {
                    if (serialPortBarcodeScaner.IsOpen)
                        serialPortBarcodeScaner.Close();
                }
            }
        }

        #region COMScanner
        private void serialPortBarcodeScaner_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Invoke(new EventHandler(DoUpdate));
        }

        private void DoUpdate(object s, EventArgs e)
        {
            if (!TestConnection)
                return;

            char[] chars = serialPortBarcodeScaner.ReadExisting().ToArray();

            string strScanData = string.Empty;
            
            foreach (var ch in chars)
            {
                if (ch == (char)Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue || ch == (char)29)
                    break;

                strScanData += ch;
            }

            rtb_Test.Text += string.Format("{0}{1}", strScanData, Environment.NewLine);
        }
        #endregion

        private void BarcodeSannerSettings_KeyUp(object sender, KeyEventArgs e)
        {
            if (TestConnection && cb_Ports.SelectedItem.ToString() == "HID")
                barcodeScanner2.ReceivedDataEvent(e);
        }

        private void NotifyReceivedData(BarcodeData barcodeData)
        {
            rtb_Test.Text += string.Format("{0}{1}", barcodeData.ToString(), Environment.NewLine);
        }
    }
}
