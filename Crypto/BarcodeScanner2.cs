using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    internal class BarcodeScanner2 : BarcodeData
    {        
        internal delegate void BarcodeScannerHandler(BarcodeData barcodeData);

        internal event BarcodeScannerHandler NotifyReceivedData;

        private const string portNameHID = "HID";

        internal string port { get; set; }
        internal int baudRate { get; set; }
        internal int lineBreakSymbolValue { get; set; }
        internal int gs1SymbolValue { get; set; }
        internal int timeout { get; set; }
        internal Encoding encoding { get; set; }
        private static bool upperCase { get; set; }

        internal BarcodeScanner2()
        {
            port = portNameHID;
            baudRate = 9600;
            lineBreakSymbolValue = 13;
            gs1SymbolValue = 119;
            timeout = 2000;
            encoding = Encoding.ASCII;
            upperCase = false;
        }

        internal BarcodeScanner2(string port, int baudRate, int lineBreakSymbol, int gs1Symbol)
        {
            this.port = port;
            this.baudRate = baudRate;
            this.lineBreakSymbolValue = lineBreakSymbol;
            this.gs1SymbolValue = gs1Symbol;
            timeout = 2000;
            encoding = Encoding.ASCII;
            upperCase = false;
        }

        internal BarcodeScanner2(string port, int baudRate, int lineBreakSymbol, int gs1Symbol, int timeout, Encoding encoding)
        {
            this.port = port;
            this.baudRate = baudRate;
            this.lineBreakSymbolValue = lineBreakSymbol;
            this.gs1SymbolValue = gs1Symbol;
            this.timeout = timeout;
            this.encoding = encoding;
            upperCase = false;
        }

        internal void SetPort(string port)
        {
            this.port = port;
        }

        internal void SetBaudRate(int baudRate)
        {
            this.baudRate = baudRate;
        }

        internal void SetLineBreakSymbol(int lineBreakSymbolValue)
        {
            this.lineBreakSymbolValue = lineBreakSymbolValue;
        }

        internal void SetGS1Symbol(int gs1SymbolValue)
        {
            this.gs1SymbolValue = gs1SymbolValue;
        }

        internal void SetTimeout(int timeout)
        {
            this.timeout = timeout;
        }

        internal void SetEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        internal void ReceivedDataEvent(KeyEventArgs e)
        {
            if (port != portNameHID || e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey || 
                e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.Alt)
                return;

            if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                upperCase = true;
                return;
            }

            charCodes.Add(new CharCode()
            {
                UpperCase = upperCase,
                Code = (int)e.KeyCode
            });

            if (e.KeyValue == (char)lineBreakSymbolValue)
            {
                ParseReceivedData(lineBreakSymbolValue, gs1SymbolValue);

                NotifyReceivedData?.Invoke(this);

                ResetReceivedData();
            }

            upperCase = false;
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            ReceivedDataEvent(e);
        }

        private void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            MessageBox.Show(String.Format("{0} = {1} ({2})", (int)e.KeyPressed, e.KeyPressed, e));
        }

        private LowLevelKeyboardListener _listener = new LowLevelKeyboardListener();
        public void Open()
        {
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
        }

        public void Close()
        {
            _listener.UnHookKeyboard();
        }
    }
}
