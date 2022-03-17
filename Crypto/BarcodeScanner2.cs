using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Crypto
{
    internal class BarcodeScanner2 : BarcodeData
    {
        private LowLevelKeyboardListener _keyboardListener = new LowLevelKeyboardListener();

        internal delegate void BarcodeScannerHandler(BarcodeData barcodeData);

        internal event BarcodeScannerHandler NotifyReceivedData;

        private const string portNameHID = "HID";

        internal string port { get; set; }
        internal int baudRate { get; set; }
        internal int lineBreakSymbolValue { get; set; }
        internal int gs1SymbolValue { get; set; }
        internal Encoding encoding { get; set; }
        private static bool upperCase { get; set; }

        internal BarcodeScanner2()
        {
            port = portNameHID;
            baudRate = 9600;
            lineBreakSymbolValue = 13;
            gs1SymbolValue = 119;
            encoding = Encoding.ASCII;
            upperCase = false;
        }

        internal BarcodeScanner2(string port, int baudRate, int lineBreakSymbol, int gs1Symbol)
        {
            this.port = port;
            this.baudRate = baudRate;
            this.lineBreakSymbolValue = lineBreakSymbol;
            this.gs1SymbolValue = gs1Symbol;
            encoding = Encoding.ASCII;
            upperCase = false;
        }

        internal BarcodeScanner2(string port, int baudRate, int lineBreakSymbol, int gs1Symbol, int timeout, Encoding encoding)
        {
            this.port = port;
            this.baudRate = baudRate;
            this.lineBreakSymbolValue = lineBreakSymbol;
            this.gs1SymbolValue = gs1Symbol;
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

        internal void SetEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        private void _keyboardListener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if (e.KeyPressed == System.Windows.Input.Key.LeftCtrl || e.KeyPressed == System.Windows.Input.Key.RightCtrl || 
                e.KeyPressed == System.Windows.Input.Key.LeftAlt || e.KeyPressed == System.Windows.Input.Key.RightAlt)
            {
                return;
            }

            if (e.KeyPressed == System.Windows.Input.Key.LeftShift || e.KeyPressed == System.Windows.Input.Key.RightShift)
            {
                upperCase = true;
                return;
            }

            charCodes.Add(new CharCode()
            {
                UpperCase = upperCase,
                Code = e.KeyCode
            });

            if (e.KeyCode == lineBreakSymbolValue)
            {
                EndReceivedData();
            }

            upperCase = false;
        }

        private void EndReceivedData()
        {
            ParseReceivedData(lineBreakSymbolValue, gs1SymbolValue);

            NotifyReceivedData?.Invoke(this);

            ResetReceivedData();
        }

        public void OpenConnection()
        {
            if (port == portNameHID)
            {
                _keyboardListener.OnKeyPressed += _keyboardListener_OnKeyPressed;
                _keyboardListener.HookKeyboard();
            }
            else
            {
                // COM ports
            }
        }

        public void CloseConnection()
        {
            if (port == portNameHID)
            {
                _keyboardListener.UnHookKeyboard();
                _keyboardListener.OnKeyPressed -= _keyboardListener_OnKeyPressed;
            }
            else
            {
                // COM ports
            }
        }
    }
}
