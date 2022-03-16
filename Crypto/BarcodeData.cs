using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class BarcodeData
    {
        // https://docs.microsoft.com/ru-ru/dotnet/api/system.windows.forms.keys?view=windowsdesktop-6.0

        private readonly Dictionary<int, string> uppercaseKeySymbol = new Dictionary<int, string>()
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

        private readonly Dictionary<int, string> lowercaseKeySymbol = new Dictionary<int, string>()
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

        public class CharCode
        {
            public bool UpperCase { get; set; } = false;
            public int Code { get; set; } = 0;
        }

        public List<CharCode> charCodes { get; set; } = new List<CharCode>();

        public string value { get; private protected set; } = string.Empty;
        public string valueRepresentation { get; protected set; } = string.Empty;
        public List<string> characters { get; private protected set; } = new List<string>();
        public List<int> characterСodes { get; private protected set; } = new List<int>();
        public List<string> gs1Blocks { get; private protected set; } = new List<string>();

        public void processCharacters(int lineBreakSymbolCode = 13, int gs1SymbolCode = 29)
        {
            value = string.Empty;
            valueRepresentation = string.Empty;
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
                    uppercaseKeySymbol.TryGetValue(charCode.Code, out ch);
                else
                    lowercaseKeySymbol.TryGetValue(charCode.Code, out ch);

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

        //public void Deconstruct(out string value)
        //{
        //    value = this.value;
        //}

        //public void Deconstruct(out string value, out string valueRepresentation)
        //{
        //    value = this.value;
        //    valueRepresentation = this.valueRepresentation;
        //}

        //public void Deconstruct(out string value, out string valueRepresentation, out List<string> characters)
        //{
        //    value = this.value;
        //    valueRepresentation = this.valueRepresentation;
        //    characters = this.characters;
        //}

        //public void Deconstruct(out string value, out string valueRepresentation, out List<string> characters, out List<int> characterСodes)
        //{
        //    value = this.value;
        //    valueRepresentation = this.valueRepresentation;
        //    characters = this.characters;
        //    characterСodes = this.characterСodes;
        //}

        //public void Deconstruct(out string value, out string valueRepresentation, out List<string> characters, out List<int> characterСodes, out List<string> gs1Blocks)
        //{
        //    value = this.value;
        //    valueRepresentation = this.valueRepresentation;
        //    characters = this.characters;
        //    characterСodes = this.characterСodes;
        //    gs1Blocks = this.gs1Blocks;
        //}

        public override string ToString()
        {
            return valueRepresentation;
        }
    }
}
