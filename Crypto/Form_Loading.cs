using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form_Loading : Form
    {
        public Form_Loading()
        {
            InitializeComponent();
            label_loading_text.Text = String.Empty;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Loading_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.cert_sn))
            {
                Hide();
                new Form_Auth().ShowDialog();
                Show();
            }

            label_loading_text.Text = Properties.Settings.Default.cert_sn;

            if (string.IsNullOrEmpty(Properties.Settings.Default.token))
            {
                // Получить токен
            }
        }
    }
}
