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
        internal int baudRate { get; set; } = 9600;
        internal int timeout { get; set; } = 1000;
        internal Encoding encoding { get; set; } = Encoding.ASCII;
        internal int lineBreakSymbolValue { get; set; } = 13;
        internal int gs1SymbolValue { get; set; } = 119;
        private static bool upperCase { get; set; } = false;

        internal BarcodeScanner2()
        {
            port = portNameHID;
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
    }
}
