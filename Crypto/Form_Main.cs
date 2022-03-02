using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.token))
            {
                Hide();
                Form_Auth form_auth = new Form_Auth();
                form_auth.ShowDialog();
                return;
            }
        }

        private void Form_Main_Activated(object sender, EventArgs e)
        {
            //Test();

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.token))
            {
                using (StreamWriter writer = new StreamWriter("token.txt", true, Encoding.Default))
                {
                    writer.WriteLine(Properties.Settings.Default.token);
                }
            }
            
        }

        private void Test()
        {
            

            //MessageBox.Show(Properties.Settings.Default.token);
        }
    }
}
