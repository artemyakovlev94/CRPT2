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
        bool TestConnection = false;

        private LowLevelKeyboardListener _listener;

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

            rtb_Test.Visible = TestConnection;

            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
        }

        private void BarcodeSannerSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPortBarcodeScaner.IsOpen)
                serialPortBarcodeScaner.Close();
            else
                _listener.UnHookKeyboard();
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

            AccessibilityFormElements();
        }

        private void cb_BaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerBaudRate = (int)cb_BaudRate.SelectedItem;
            Properties.Settings.Default.Save();
        }

        private void tb_lineBreakCharacter_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerLineBreakCharacter = e.KeyData.ToString();
            Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue = e.KeyValue;
            Properties.Settings.Default.Save();

            tb_lineBreakCharacter.Text = e.KeyData.ToString();
        }

        private void tb_GS1Symbol_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.BarcodeScannerGS1Character = e.KeyData.ToString();
            Properties.Settings.Default.BarcodeScannerGS1CharacterValue = e.KeyValue;
            Properties.Settings.Default.Save();

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
                    //_listener.HookKeyboard();
                    rtb_Test.Focus();
                }
                else
                {
                    //_listener.UnHookKeyboard();
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


        private List<KeyPressedArgs> keyPressedArgs = new List<KeyPressedArgs>();
        private void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            keyPressedArgs.Add(e);

            //rtb_Test.Text += string.Format("{0}", ConvertKey(e));
        }

        private string ConvertKey(KeyPressedArgs e)
        {
            string ch = string.Empty;

            switch (e.KeyPressed)
            {
                case Key.D0:
                    ch = "0";
                    break;
                case Key.D1:
                    ch = "1";
                    break;
                case Key.D2:
                    ch = "2";
                    break;
                case Key.D3:
                    ch = "3";
                    break;
                case Key.D4:
                    ch = "4";
                    break;
                case Key.D5:
                    ch = "5";
                    break;
                case Key.D6:
                    ch = "6";
                    break;
                case Key.D7:
                    ch = "7";
                    break;
                case Key.D8:
                    ch = "8";
                    break;
                case Key.D9:
                    ch = "9";
                    break;
                case Key.OemMinus:
                    ch = "-";
                    break;
                default:
                    ch = e.KeyPressed.ToString();
                    break;
            }

            return ch;
        }

        bool upper_case;
        private void BarcodeSannerSettings_KeyUp(object sender, KeyEventArgs e)
        {
            if (!TestConnection || cb_Ports.SelectedItem.ToString() != "HID")
                return;


            rtb_Test.Text += e.KeyData;
            rtb_Test.Text += Environment.NewLine;
        }

        private string ConverKeyToString(KeyEventArgs e)
        {
            //if (e == null)
            //    return key_string;
            string key_string = string.Empty;
            upper_case = e.Modifiers == Keys.Shift;

            //string value;

            //if (dictonary_keys.TryGetValue(e.KeyCode, out value))
            //{
            //    key_string += value;
            //}

            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    key_string += "0";
                    break;
                case Keys.NumPad1:
                    key_string += "1";
                    break;
                case Keys.NumPad2:
                    key_string += "2";
                    break;
                case Keys.NumPad3:
                    key_string += "3";
                    break;
                case Keys.NumPad4:
                    key_string += "4";
                    break;
                case Keys.NumPad5:
                    key_string += "5";
                    break;
                case Keys.NumPad6:
                    key_string += "6";
                    break;
                case Keys.NumPad7:
                    key_string += "7";
                    break;
                case Keys.NumPad8:
                    key_string += "8";
                    break;
                case Keys.NumPad9:
                    key_string += "9";
                    break;
                case Keys.D0:
                    key_string += (upper_case ? ")" : "0");
                    break;
                case Keys.D1:
                    key_string += (upper_case ? "!" : "1");
                    break;
                case Keys.D2:
                    key_string += (upper_case ? "@" : "2");
                    break;
                case Keys.D3:
                    key_string += (upper_case ? "#" : "3");
                    break;
                case Keys.D4:
                    key_string += (upper_case ? "$" : "4");
                    break;
                case Keys.D5:
                    key_string += (upper_case ? "%" : "5");
                    break;
                case Keys.D6:
                    key_string += (upper_case ? "^" : "6");
                    break;
                case Keys.D7:
                    key_string += (upper_case ? "&" : "7");
                    break;
                case Keys.D8:
                    key_string += (upper_case ? "*" : "8");
                    break;
                case Keys.D9:
                    key_string += (upper_case ? "(" : "9");
                    break;
                case Keys.Q:
                    key_string += (upper_case ? "Q" : "q");
                    break;
                case Keys.W:
                    key_string += (upper_case ? "W" : "w");
                    break;
                case Keys.E:
                    key_string += (upper_case ? "E" : "e");
                    break;
                case Keys.R:
                    key_string += (upper_case ? "R" : "r");
                    break;
                case Keys.T:
                    key_string += (upper_case ? "T" : "t");
                    break;
                case Keys.Y:
                    key_string += (upper_case ? "Y" : "y");
                    break;
                case Keys.U:
                    key_string += (upper_case ? "U" : "u");
                    break;
                case Keys.I:
                    key_string += (upper_case ? "I" : "i");
                    break;
                case Keys.O:
                    key_string += (upper_case ? "O" : "o");
                    break;
                case Keys.P:
                    key_string += (upper_case ? "P" : "p");
                    break;
                case Keys.A:
                    key_string += (upper_case ? "A" : "a");
                    break;
                case Keys.S:
                    key_string += (upper_case ? "S" : "s");
                    break;
                case Keys.D:
                    key_string += (upper_case ? "D" : "d");
                    break;
                case Keys.F:
                    key_string += (upper_case ? "F" : "f");
                    break;
                case Keys.G:
                    key_string += (upper_case ? "G" : "g");
                    break;
                case Keys.H:
                    key_string += (upper_case ? "H" : "h");
                    break;
                case Keys.J:
                    key_string += (upper_case ? "J" : "j");
                    break;
                case Keys.K:
                    key_string += (upper_case ? "K" : "k");
                    break;
                case Keys.L:
                    key_string += (upper_case ? "L" : "l");
                    break;
                case Keys.Z:
                    key_string += (upper_case ? "Z" : "z");
                    break;
                case Keys.X:
                    key_string += (upper_case ? "X" : "x");
                    break;
                case Keys.C:
                    key_string += (upper_case ? "C" : "c");
                    break;
                case Keys.V:
                    key_string += (upper_case ? "V" : "v");
                    break;
                case Keys.B:
                    key_string += (upper_case ? "B" : "b");
                    break;
                case Keys.N:
                    key_string += (upper_case ? "N" : "n");
                    break;
                case Keys.M:
                    key_string += (upper_case ? "M" : "m");
                    break;
                // Символ GS
                case Keys.Oem6:
                    key_string += "<GS>";
                    break;
                default:
                    break;
            }

            return key_string;
        }

        private void BarcodeSannerSettings_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void BarcodeSannerSettings_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void rtb_Test_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
    }
}
