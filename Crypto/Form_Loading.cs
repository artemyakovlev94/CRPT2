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
            label_loading_text.Text = "И затем создается таймер. Данная перегрузка конструктора таймера принимает четыре параметра:";

            if (string.IsNullOrEmpty(Properties.Settings.Default.cert_sn) || string.IsNullOrEmpty(Properties.Settings.Default.token))
            {
                Hide();
                new Form_Auth().ShowDialog();
                Show();
            }
            else
            {
                Hide();
                new Crypto().ShowDialog();
                Show();
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
