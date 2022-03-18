using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crypto
{
    internal class BarcodeScanner3
    {
        public event EventHandler<EventBarcodeDataEventArgs> CounterChanged;

        private Thread my_thread;

        private const string portNameHID = "HID";

        private SerialPort _serialPort = new SerialPort();

        internal string port { get; set; }
        internal int baudRate { get; set; }
        internal int lineBreakSymbolValue { get; set; }
        internal int gs1SymbolValue { get; set; }
        internal Encoding encoding { get; set; }
        private static bool upperCase { get; set; }

        internal BarcodeScanner3()
        {
            port = portNameHID;
            baudRate = 9600;
            lineBreakSymbolValue = 13;
            gs1SymbolValue = 119;
            encoding = Encoding.ASCII;
            upperCase = false;
        }

        List<int> charCodes = new List<int>();
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            char[] chars = _serialPort.ReadExisting().ToArray();

            foreach (var ch in chars)
            {
                if ((int)ch == lineBreakSymbolValue)
                    break;

                charCodes.Add(ch);
            }

            OnCounterChanged(charCodes);
        }

        public void OpenConnection()
        {
            new Thread(new ThreadStart(() =>
            {
                _serialPort.PortName = port;
                _serialPort.BaudRate = baudRate;
                _serialPort.DataBits = 8;
                _serialPort.Encoding = Encoding.ASCII;
                _serialPort.DataReceived += _serialPort_DataReceived;
                _serialPort.Open();
            })).Start();
        }

        void OnCounterChanged(List<int> data)
        {
            if (CounterChanged != null)
                CounterChanged.Invoke(this, new EventBarcodeDataEventArgs(data));
        }

        public class EventBarcodeDataEventArgs : EventArgs
        {
            public List<int> Data { get; set; }
            public EventBarcodeDataEventArgs(List<int> data)
            {
                Data = data;
            }
        }
    }
}
