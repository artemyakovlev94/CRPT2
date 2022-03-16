using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    internal class ForFormTest
    {
        internal delegate void ForFormTestHandler(string message);
        internal event ForFormTestHandler Notify;

        private bool upper_case = false;

        private string strData = string.Empty;

        internal void Test()
        {
            Notify?.Invoke($"На счет поступило: 0");
        }

        internal void InputData(KeyEventArgs e)
        {
            if (e.KeyValue == (char)Properties.Settings.Default.BarcodeScannerLineBreakCharacterValue)
            {
                Notify?.Invoke(strData);
                strData = "";
                return;
            }

            if (e.KeyValue == (char)Properties.Settings.Default.BarcodeScannerGS1CharacterValue)
            {
                strData += "<GS1>";
                return;
            }

            if (e.KeyCode == Keys.Shift || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                upper_case = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    strData += "0";
                    break;
                case Keys.NumPad1:
                    strData += "1";
                    break;
                case Keys.NumPad2:
                    strData += "2";
                    break;
                case Keys.NumPad3:
                    strData += "3";
                    break;
                case Keys.NumPad4:
                    strData += "4";
                    break;
                case Keys.NumPad5:
                    strData += "5";
                    break;
                case Keys.NumPad6:
                    strData += "6";
                    break;
                case Keys.NumPad7:
                    strData += "7";
                    break;
                case Keys.NumPad8:
                    strData += "8";
                    break;
                case Keys.NumPad9:
                    strData += "9";
                    break;
                case Keys.D0:
                    strData += (upper_case ? ")" : "0");
                    break;
                case Keys.D1:
                    strData += (upper_case ? "!" : "1");
                    break;
                case Keys.D2:
                    strData += (upper_case ? "@" : "2");
                    break;
                case Keys.D3:
                    strData += (upper_case ? "#" : "3");
                    break;
                case Keys.D4:
                    strData += (upper_case ? "$" : "4");
                    break;
                case Keys.D5:
                    strData += (upper_case ? "%" : "5");
                    break;
                case Keys.D6:
                    strData += (upper_case ? "^" : "6");
                    break;
                case Keys.D7:
                    strData += (upper_case ? "&" : "7");
                    break;
                case Keys.D8:
                    strData += (upper_case ? "*" : "8");
                    break;
                case Keys.D9:
                    strData += (upper_case ? "(" : "9");
                    break;
                case Keys.Q:
                    strData += (upper_case ? "Q" : "q");
                    break;
                case Keys.W:
                    strData += (upper_case ? "W" : "w");
                    break;
                case Keys.E:
                    strData += (upper_case ? "E" : "e");
                    break;
                case Keys.R:
                    strData += (upper_case ? "R" : "r");
                    break;
                case Keys.T:
                    strData += (upper_case ? "T" : "t");
                    break;
                case Keys.Y:
                    strData += (upper_case ? "Y" : "y");
                    break;
                case Keys.U:
                    strData += (upper_case ? "U" : "u");
                    break;
                case Keys.I:
                    strData += (upper_case ? "I" : "i");
                    break;
                case Keys.O:
                    strData += (upper_case ? "O" : "o");
                    break;
                case Keys.P:
                    strData += (upper_case ? "P" : "p");
                    break;
                case Keys.A:
                    strData += (upper_case ? "A" : "a");
                    break;
                case Keys.S:
                    strData += (upper_case ? "S" : "s");
                    break;
                case Keys.D:
                    strData += (upper_case ? "D" : "d");
                    break;
                case Keys.F:
                    strData += (upper_case ? "F" : "f");
                    break;
                case Keys.G:
                    strData += (upper_case ? "G" : "g");
                    break;
                case Keys.H:
                    strData += (upper_case ? "H" : "h");
                    break;
                case Keys.J:
                    strData += (upper_case ? "J" : "j");
                    break;
                case Keys.K:
                    strData += (upper_case ? "K" : "k");
                    break;
                case Keys.L:
                    strData += (upper_case ? "L" : "l");
                    break;
                case Keys.Z:
                    strData += (upper_case ? "Z" : "z");
                    break;
                case Keys.X:
                    strData += (upper_case ? "X" : "x");
                    break;
                case Keys.C:
                    strData += (upper_case ? "C" : "c");
                    break;
                case Keys.V:
                    strData += (upper_case ? "V" : "v");
                    break;
                case Keys.B:
                    strData += (upper_case ? "B" : "b");
                    break;
                case Keys.N:
                    strData += (upper_case ? "N" : "n");
                    break;
                case Keys.M:
                    strData += (upper_case ? "M" : "m");
                    break;
                case Keys.Oemtilde:
                    strData += (upper_case ? "~" : "`");
                    break;
                case Keys.OemMinus:
                    strData += (upper_case ? "_" : "-");
                    break;
                case Keys.Oemplus:
                    strData += (upper_case ? "+" : "=");
                    break;
                case Keys.OemOpenBrackets:
                    strData += (upper_case ? "{" : "[");
                    break;
                case Keys.Oem6:
                    strData += (upper_case ? "}" : "]");
                    break;
                case Keys.Oem1:
                    strData += (upper_case ? ":" : ";");
                    break;
                case Keys.Oem7:
                    strData += (upper_case ? "\"" : "'");
                    break;
                case Keys.Oem5:
                    strData += (upper_case ? "|" : "\\");
                    break;
                case Keys.Oemcomma:
                    strData += (upper_case ? "<" : ",");
                    break;
                case Keys.OemPeriod:
                    strData += (upper_case ? ">" : ".");
                    break;
                case Keys.OemQuestion:
                    strData += (upper_case ? "?" : "/");
                    break;
                case Keys.Divide:
                    strData += "/";
                    break;
                case Keys.Multiply:
                    strData += "*";
                    break;
                case Keys.Subtract:
                    strData += "-";
                    break;
                case Keys.Add:
                    strData += "+";
                    break;
                case Keys.Decimal:
                    strData += ".";
                    break;
                default:
                    break;
            }

            upper_case = false;
        }
    }
}
