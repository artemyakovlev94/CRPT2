using System.Collections.Generic;
using System.Windows.Forms;

namespace Crypto
{
    public class BarcodeData
    {
        // https://docs.microsoft.com/ru-ru/dotnet/api/system.windows.forms.keys?view=windowsdesktop-6.0

        /// <summary>
        /// Словарь символов верхнего регистра (клавиша символа = символ)
        /// </summary>
        private readonly Dictionary<Keys, string> uppercaseSymbolByKey = new Dictionary<Keys, string>()
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

        /// <summary>
        /// Словарь символов нижнего регистра (клавиша символа = символ)
        /// </summary>
        private readonly Dictionary<Keys, string> lowercaseSymbolByKey = new Dictionary<Keys, string>()
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

        /// <summary>
        /// Словарь символов верхнего регистра (код символа = символ)
        /// </summary>
        private readonly Dictionary<int, string> uppercaseSymbolByKeyCode = new Dictionary<int, string>()
        {
            { 111, "/" },
            { 106, "*" },
            { 109, "-" },
            { 107, "+" },
            { 110, "." },
            { 96, "0" },
            { 97, "1" },
            { 98, "2" },
            { 99, "3" },
            { 100, "4" },
            { 101, "5" },
            { 102, "6" },
            { 103, "7" },
            { 104, "8" },
            { 105, "9" },
            { 48, ")" },
            { 49, "!" },
            { 50, "@" },
            { 51, "#" },
            { 52, "$" },
            { 53, "%" },
            { 54, "^" },
            { 55, "&" },
            { 56, "*" },
            { 57, "(" },
            { 192, "~" },
            { 189, "_" },
            { 187, "+" },
            { 219, "{" },
            { 221, "}" },
            { 186, ":" },
            { 222, "\"" },
            { 220, "|" },
            { 188, "<" },
            { 190, ">" },
            { 191, "?" },
            { 65, "A" },
            { 66, "B" },
            { 67, "C" },
            { 68, "D" },
            { 69, "E" },
            { 70, "F" },
            { 71, "G" },
            { 72, "H" },
            { 73, "I" },
            { 74, "J" },
            { 75, "K" },
            { 76, "L" },
            { 77, "M" },
            { 78, "N" },
            { 79, "O" },
            { 80, "P" },
            { 81, "Q" },
            { 82, "R" },
            { 83, "S" },
            { 84, "T" },
            { 85, "U" },
            { 86, "V" },
            { 87, "W" },
            { 88, "X" },
            { 89, "Y" },
            { 90, "Z" },
        };

        /// <summary>
        /// Словарь символов нижнего регистра (код символа = символ)
        /// </summary>
        private readonly Dictionary<int, string> lowercaseSymbolByKeyCode = new Dictionary<int, string>()
        {
            { 111, "/" },
            { 106, "*" },
            { 109, "-" },
            { 107, "+" },
            { 110, "." },
            { 96, "0" },
            { 97, "1" },
            { 98, "2" },
            { 99, "3" },
            { 100, "4" },
            { 101, "5" },
            { 102, "6" },
            { 103, "7" },
            { 104, "8" },
            { 105, "9" },
            { 48, "0" },
            { 49, "1" },
            { 50, "2" },
            { 51, "3" },
            { 52, "4" },
            { 53, "5" },
            { 54, "6" },
            { 55, "7" },
            { 56, "8" },
            { 57, "9" },
            { 192, "`" },
            { 189, "-" },
            { 187, "=" },
            { 219, "[" },
            { 221, "]" },
            { 186, ";" },
            { 222, "'" },
            { 220, "\\" },
            { 188, "," },
            { 190, "." },
            { 191, "/" },
            { 65, "a" },
            { 66, "b" },
            { 67, "c" },
            { 68, "d" },
            { 69, "e" },
            { 70, "f" },
            { 71, "g" },
            { 72, "h" },
            { 73, "i" },
            { 74, "j" },
            { 75, "k" },
            { 76, "l" },
            { 77, "m" },
            { 78, "n" },
            { 79, "o" },
            { 80, "p" },
            { 81, "q" },
            { 82, "r" },
            { 83, "s" },
            { 84, "t" },
            { 85, "u" },
            { 86, "v" },
            { 87, "w" },
            { 88, "x" },
            { 89, "y" },
            { 90, "z" },
        };

        /// <summary>
        /// Код символа с указанием регистра клавиатуры
        /// </summary>
        public class CharCode
        {
            public bool UpperCase { get; set; } = false;
            public int Code { get; set; } = 0;
        }

        /// <summary>
        /// Коды символов с указанием регистра клавиатуры
        /// </summary>
        public List<CharCode> charCodes { get; set; } = new List<CharCode>();

        /// <summary>
        /// Символы строкой
        /// </summary>
        public string value { get; private protected set; } = string.Empty;

        /// <summary>
        /// Символы
        /// </summary>
        public List<string> characters { get; private protected set; } = new List<string>();

        /// <summary>
        /// Массив блоков штрихкода формата GS1 DataMatrix
        /// </summary>
        public List<string> gs1Blocks { get; private protected set; } = new List<string>();

        /// <summary>
        /// Разобрать полученные данные от сканера штрихкода
        /// </summary>
        /// <param name="lineBreakSymbolCode">Код символа переноса строки</param>
        /// <param name="gs1SymbolCode">Код символа GS1 DataMatrix</param>
        public void ParseReceivedData(int lineBreakSymbolCode = 13, int gs1SymbolCode = 29)
        {
            value = string.Empty;
            characters.Clear();
            gs1Blocks.Clear();

            if (charCodes.Count == 0)
                return;

            string gs1Block = string.Empty;

            foreach (CharCode charCode in charCodes)
            {
                if (charCode.Code == lineBreakSymbolCode)
                {
                    if (!string.IsNullOrWhiteSpace(gs1Block))
                        gs1Blocks.Add(gs1Block);

                    gs1Block = string.Empty;
                    break;
                }

                string ch;

                if (charCode.UpperCase)
                    uppercaseSymbolByKeyCode.TryGetValue(charCode.Code, out ch);
                else
                    lowercaseSymbolByKeyCode.TryGetValue(charCode.Code, out ch);

                if (charCode.Code == gs1SymbolCode)
                {
                    if (!string.IsNullOrWhiteSpace(gs1Block))
                        gs1Blocks.Add(gs1Block);

                    gs1Block = string.Empty;
                }
                else
                {
                    characters.Add(ch);
                    value += ch;
                    gs1Block += ch;
                }
            }
        }

        /// <summary>
        /// Сбросить полученные данные от сканера штрихкода
        /// </summary>
        public void ResetReceivedData()
        {
            value = string.Empty;
            charCodes.Clear();
            characters.Clear();
            gs1Blocks.Clear();
        }

        /// <summary>
        /// Возвращает строку, представляющую полученные данные от сканера штрихкода
        /// </summary>
        /// <returns>Строка, представляющая полученные данные от сканера штрихкода</returns>
        public override string ToString()
        {
            string representation = string.Empty;

            if (gs1Blocks.Count > 1)
            {
                for (int i = 0; i < gs1Blocks.Count; i++)
                {
                    representation += gs1Blocks[i];
                    representation += i < gs1Blocks.Count-1 ? " (GS1) " : string.Empty;
                }
            }
            else
            {
                representation = value;
            }

            return representation;
        }
    }
}
