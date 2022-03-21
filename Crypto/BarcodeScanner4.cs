using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class BarcodeScanner4
    {
        public event EventHandler<RecievedDataEventArgs> DataRecieved;



        private const string PORT_NAME_HID = "HID";

        private SerialPort _serialPort = new SerialPort();

        private LowLevelKeyboardListener _keyboardListener = new LowLevelKeyboardListener();

        private List<Character> characters = new List<Character>();
        private bool upperCase { get; set; }


        public BarcodeScannerParametres Parametres { get; set; }


        

        public BarcodeScanner4() : this(new BarcodeScannerParametres()) { }
        public BarcodeScanner4(BarcodeScannerParametres paremetres)
        {
            Parametres = paremetres;
        }

        public void OpenConnection()
        {
            if (Parametres.Port == PORT_NAME_HID)
            {
                _keyboardListener.OnKeyPressed += DataAcquisition;
                _keyboardListener.HookKeyboard();
            }
            else
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.PortName = Parametres.Port;
                _serialPort.BaudRate = Parametres.BaudRate;
                _serialPort.DataBits = 8;
                _serialPort.Encoding = Encoding.ASCII;
                _serialPort.DataReceived += DataAcquisition;
                _serialPort.Open();
            }
        }

        public void CloseConnection()
        {
            if (Parametres.Port == PORT_NAME_HID)
            {
                _keyboardListener.HookKeyboard();
                _keyboardListener.OnKeyPressed -= DataAcquisition;
            }
            else
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.DataReceived -= DataAcquisition;
            }
        }

        private void DataAcquisition(object sender, EventArgs e)
        {
            if (Parametres.Port == PORT_NAME_HID)
            {
                KeyPressedArgs keyPressedArgs = e as KeyPressedArgs;

                
                if (keyPressedArgs.KeyPressed == System.Windows.Input.Key.LeftCtrl || keyPressedArgs.KeyPressed == System.Windows.Input.Key.RightCtrl ||
                    keyPressedArgs.KeyPressed == System.Windows.Input.Key.LeftAlt || keyPressedArgs.KeyPressed == System.Windows.Input.Key.RightAlt)
                {
                    return;
                }

                if (keyPressedArgs.KeyPressed == System.Windows.Input.Key.LeftShift || keyPressedArgs.KeyPressed == System.Windows.Input.Key.RightShift)
                {
                    upperCase = true;
                    return;
                }

                characters.Add(new Character(keyPressedArgs.KeyCode, upperCase, (char)keyPressedArgs.KeyCode));

                if (keyPressedArgs.KeyCode == Parametres.LineBreakSymbol)
                {
                    OnDataRecieved();
                }

                upperCase = false;
            }
            else
            {
                SerialDataReceivedEventArgs serialDataReceivedEventArgs = e as SerialDataReceivedEventArgs;

                char[] readExistingChars = _serialPort.ReadExisting().ToArray();

                foreach (var ch in readExistingChars)
                    characters.Add(new Character(ch, char.IsUpper(ch), ch));

                OnDataRecieved();
            }
        }

        private void OnDataRecieved()
        {
            
            
            if (DataRecieved != null)
                DataRecieved.Invoke(this, new RecievedDataEventArgs(characters, Parametres.LineBreakSymbol, Parametres.GS1Symbol));

            characters.Clear();
            upperCase = false;
        }










        //*************************************************************
        public class Character
        {
            public int Code { get; set; }
            public bool IsUpper { get; set; }
            public bool IsLower { get; set; }
            public char Value { get; set; }
            public Character() : this(0) {}
            public Character(int code) : this(code, false) { }
            public Character(int code, bool isUpper) : this(code, isUpper, (char)0) { }
            public Character(int code, bool isUpper, char ch)
            {
                Code = code;
                IsUpper = isUpper;
                IsLower = !isUpper;
                Value = ch;
            }
        }

        public class RecievedDataEventArgs : EventArgs
        {
            public List<Character> Characters { get; set; }
            public string Value { get; set; }
            public List<string> GS1Groups { get; set; }

            public RecievedDataEventArgs(List<Character> characters) : this(characters, 13) { }
            public RecievedDataEventArgs(List<Character> characters, int lineBreakChar) : this(characters, lineBreakChar, 119) { }
            public RecievedDataEventArgs(List<Character> characters, int lineBreakChar, int gs1Char)
            {
                Characters = characters;

                GS1Groups = new List<string>();

                string gs1_group = string.Empty;
                
                Characters.ForEach(ch =>
                {
                    if (ch.Code == gs1Char)
                    {
                        if (!string.IsNullOrWhiteSpace(gs1_group))
                            GS1Groups.Add(gs1_group);

                        gs1_group = string.Empty;
                    }

                    if (!char.IsControl(ch.Value) && !char.IsWhiteSpace(ch.Value) && ch.Value != gs1Char)
                    {
                        Value += ch.IsLower ? char.ToLower(ch.Value) : char.ToUpper(ch.Value);
                        gs1_group += ch.IsLower ? char.ToLower(ch.Value) : char.ToUpper(ch.Value);
                    }
                });

                if (!string.IsNullOrWhiteSpace(gs1_group))
                    GS1Groups.Add(gs1_group);
            }

            public override string ToString()
            {
                string gs1_string = string.Empty;

                if (GS1Groups.Count == 0)
                    return Value;

                for (int i = 0; i < GS1Groups.Count; i++)
                {
                    gs1_string += GS1Groups[i];
                    gs1_string += i < GS1Groups.Count - 1 ? " (GS) " : string.Empty;
                }

                return gs1_string;
            }
        }

        public class BarcodeScannerParametres
        {
            internal string Port { get; set; }
            internal int BaudRate { get; set; }
            internal int LineBreakSymbol { get; set; }
            internal int GS1Symbol { get; set; }
            public BarcodeScannerParametres() : this(PORT_NAME_HID) { }
            public BarcodeScannerParametres(string port) : this(port, 9600) { }
            public BarcodeScannerParametres(string port, int baudRate) : this(port, baudRate, 13) { }
            public BarcodeScannerParametres(string port, int baudRate, int lineBreakSymbol) : this(port, baudRate, lineBreakSymbol, 119) { }
            public BarcodeScannerParametres(string port, int baudRate, int lineBreakSymbol, int gs1Symbol)
            {
                Port = port;
                BaudRate = baudRate;
                LineBreakSymbol = lineBreakSymbol;
                GS1Symbol = Port == PORT_NAME_HID ? gs1Symbol : 29;
            }
        }

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


    }
}
