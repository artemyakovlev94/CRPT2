using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Barcode : Form
    {
        public Barcode()
        {
            InitializeComponent();
        }

        private void Barcode_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cb_com_ports.Items.Add(port);
            }

            if (cb_com_ports.Items.Count > 0)
            {
                cb_com_ports.SelectedIndex = 0;

                serialPort1.PortName = cb_com_ports.SelectedItem.ToString(); //Указываем наш порт - в данном случае COM1.
                serialPort1.BaudRate = 9600; //указываем скорость.
                serialPort1.DataBits = 8;
                serialPort1.Encoding = Encoding.ASCII;
                serialPort1.Open(); //Открываем порт.
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_com_ports.SelectedIndex == -1)
                return;

            serialPort1.PortName = cb_com_ports.SelectedItem.ToString(); //Указываем наш порт - в данном случае COM1.
            serialPort1.BaudRate = 9600; //указываем скорость.
            serialPort1.DataBits = 8;
            serialPort1.Encoding = Encoding.ASCII;
            serialPort1.Open(); //Открываем порт.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate));
        }

        private void Barcode_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }

        public class BarcodeData
        {
            public string GTIN { get; set; }
            public string serialNumber { get; set; }
            public string keyCheck { get; set; }
            public string codeCheck { get; set; }

        }

        private void DoUpdate(object s, EventArgs e)
        { 
            char[] chars = serialPort1.ReadExisting().ToArray();

            foreach (var ch in chars)
            {
                if (ch == (char)29 || ch == (char)13)
                    break;

                richTextBox1.Text += ch;
            }

            richTextBox1.Text += Environment.NewLine;
        }
    }
}
