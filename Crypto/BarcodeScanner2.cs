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

        internal event BarcodeScannerHandler Notify;

        private string port { get; set; } = "HID";
        private int baudRate { get; set; } = 9600;
        private int lineBreakSymbolValue { get; set; } = 13;
        private int gs1SymbolValue { get; set; } = 119;
        private static bool upperCase { get; set; } = false;

        private readonly Dictionary<Keys, string> uppercaseKeySymbol = new Dictionary<Keys, string>()
        {
            { Keys.Divide,          "/" },
            { Keys.Multiply,        "*" },
            { Keys.Subtract,        "-" },
            { Keys.Add,             "+" },
            { Keys.Decimal,         "." },
            { Keys.NumPad1,         "1" },
            { Keys.NumPad2,         "2" },
            { Keys.NumPad3,         "3" },
            { Keys.NumPad4,         "4" },
            { Keys.NumPad5,         "5" },
            { Keys.NumPad6,         "6" },
            { Keys.NumPad7,         "7" },
            { Keys.NumPad8,         "8" },
            { Keys.NumPad9,         "9" },
            { Keys.NumPad0,         "0" },
            { Keys.D1,              "!" },
            { Keys.D2,              "@" },
            { Keys.D3,              "#" },
            { Keys.D4,              "$" },
            { Keys.D5,              "%" },
            { Keys.D6,              "^" },
            { Keys.D7,              "&" },
            { Keys.D8,              "*" },
            { Keys.D9,              "(" },
            { Keys.D0,              ")" },
            { Keys.Oemtilde,        "~" },
            { Keys.OemMinus,        "_" },
            { Keys.Oemplus,         "+" },
            { Keys.OemOpenBrackets, "{" },
            { Keys.Oem6,            "}" },
            { Keys.Oem1,            ":" },
            { Keys.Oem7,            "\"" },
            { Keys.Oem5,            "|" },
            { Keys.Oemcomma,        "<" },
            { Keys.OemPeriod,       ">" },
            { Keys.OemQuestion,     "?" },
            { Keys.A,               "A" },
            { Keys.B,               "B" },
            { Keys.C,               "C" },
            { Keys.D,               "D" },
            { Keys.E,               "E" },
            { Keys.F,               "F" },
            { Keys.G,               "G" },
            { Keys.H,               "H" },
            { Keys.I,               "I" },
            { Keys.J,               "J" },
            { Keys.K,               "K" },
            { Keys.L,               "L" },
            { Keys.M,               "M" },
            { Keys.N,               "N" },
            { Keys.O,               "O" },
            { Keys.P,               "P" },
            { Keys.Q,               "Q" },
            { Keys.R,               "R" },
            { Keys.S,               "S" },
            { Keys.T,               "T" },
            { Keys.U,               "U" },
            { Keys.V,               "V" },
            { Keys.W,               "W" },
            { Keys.X,               "X" },
            { Keys.Y,               "Y" },
            { Keys.Z,               "Z" },
        };

        private readonly Dictionary<Keys, string> lowercaseKeySymbol = new Dictionary<Keys, string>()
        {
            { Keys.Divide,          "/" },
            { Keys.Multiply,        "*" },
            { Keys.Subtract,        "-" },
            { Keys.Add,             "+" },
            { Keys.Decimal,         "." },
            { Keys.NumPad1,         "1" },
            { Keys.NumPad2,         "2" },
            { Keys.NumPad3,         "3" },
            { Keys.NumPad4,         "4" },
            { Keys.NumPad5,         "5" },
            { Keys.NumPad6,         "6" },
            { Keys.NumPad7,         "7" },
            { Keys.NumPad8,         "8" },
            { Keys.NumPad9,         "9" },
            { Keys.NumPad0,         "0" },
            { Keys.D1,              "1" },
            { Keys.D2,              "2" },
            { Keys.D3,              "3" },
            { Keys.D4,              "4" },
            { Keys.D5,              "5" },
            { Keys.D6,              "6" },
            { Keys.D7,              "7" },
            { Keys.D8,              "8" },
            { Keys.D9,              "9" },
            { Keys.D0,              "0" },
            { Keys.Oemtilde,        "`" },
            { Keys.OemMinus,        "-" },
            { Keys.Oemplus,         "=" },
            { Keys.OemOpenBrackets, "[" },
            { Keys.Oem6,            "]" },
            { Keys.Oem1,            ";" },
            { Keys.Oem7,            "'" },
            { Keys.Oem5,            "\\" },
            { Keys.Oemcomma,        "," },
            { Keys.OemPeriod,       "." },
            { Keys.OemQuestion,     "/" },
            { Keys.A,               "a" },
            { Keys.B,               "b" },
            { Keys.C,               "c" },
            { Keys.D,               "d" },
            { Keys.E,               "e" },
            { Keys.F,               "f" },
            { Keys.G,               "g" },
            { Keys.H,               "h" },
            { Keys.I,               "i" },
            { Keys.J,               "j" },
            { Keys.K,               "k" },
            { Keys.L,               "l" },
            { Keys.M,               "m" },
            { Keys.N,               "n" },
            { Keys.O,               "o" },
            { Keys.P,               "p" },
            { Keys.Q,               "q" },
            { Keys.R,               "r" },
            { Keys.S,               "s" },
            { Keys.T,               "t" },
            { Keys.U,               "u" },
            { Keys.V,               "v" },
            { Keys.W,               "w" },
            { Keys.X,               "x" },
            { Keys.Y,               "y" },
            { Keys.Z,               "z" },
        };


        internal BarcodeScanner2()
        {
        }

        internal BarcodeScanner2(string port)
        {
            this.port = port;

            if (port != "HID")
                gs1SymbolValue = 29;
        }

        internal BarcodeScanner2(string port, int baudRate)
        {
            this.port = port;
            this.baudRate = baudRate;

            if (port != "HID")
                gs1SymbolValue = 29;
        }

        internal BarcodeScanner2(string port, int baudRate, int lineBreakSymbolValue)
        {
            this.port = port;
            this.baudRate = baudRate;
            this.lineBreakSymbolValue = lineBreakSymbolValue;

            if (port != "HID")
                gs1SymbolValue = 29;
        }

        internal BarcodeScanner2(string port, int baudRate, int lineBreakSymbolValue, int gs1SymbolValue)
        {
            this.port = port;
            this.baudRate = baudRate;
            this.lineBreakSymbolValue = lineBreakSymbolValue;
            this.gs1SymbolValue = port == "HID" ? gs1SymbolValue : 29;
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

        string gs1Block = string.Empty;
        internal void KeyEvent(KeyEventArgs e)
        {
            if (port != "HID")
                return;

            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.Alt)
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

            characterСodes.Add((int)e.KeyCode);

            if (e.KeyValue == (char)lineBreakSymbolValue)
            {
                processCharacters(lineBreakSymbolValue, gs1SymbolValue);
                Notify?.Invoke(this);
            }

            upperCase = false;

            //if (e.KeyValue == (char)lineBreakSymbolValue)
            //{
            //    if (!string.IsNullOrWhiteSpace(gs1Block))
            //        gs1Blocks.Add(gs1Block);

            //    upperCase = false;
            //    gs1Block = string.Empty;

            //    Notify?.Invoke(this);

            //    value = string.Empty;

            //    characters.Clear();
            //    characterСodes.Clear();
            //    gs1Blocks.Clear();

            //    return;
            //}

            //if (e.KeyValue == (char)gs1SymbolValue)
            //{
            //    upperCase = false;

            //    if (!string.IsNullOrWhiteSpace(gs1Block))
            //        gs1Blocks.Add(gs1Block);

            //    gs1Block = string.Empty;

            //    return;
            //}

            //string ch;
            //if (upperCase)
            //    uppercaseKeySymbol.TryGetValue(e.KeyCode, out ch);
            //else
            //    lowercaseKeySymbol.TryGetValue(e.KeyCode, out ch);

            //value += ch;
            //gs1Block += ch;

            //characters.Add(ch);

            //upperCase = false;
        }
    }
}
