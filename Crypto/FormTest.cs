using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class FormTest : Form
    {
        ForFormTest forformTest = new ForFormTest();

        private bool TestConn = false;

        public FormTest()
        {
            InitializeComponent();

            button1.Text = TestConn ? "Прервать" : "Тест";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestConn = !TestConn;

            button1.Text = TestConn ? "Прервать" : "Тест";

            richTextBox1.Focus();

            if (TestConn)
            {
                forformTest.Notify += DisplayMessage;
            }
            else
            {
                forformTest.Notify -= DisplayMessage;
            }
        }

        private void DisplayMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void FormTest_KeyUp(object sender, KeyEventArgs e)
        {
            forformTest.InputData(e);
        }
    }
}
