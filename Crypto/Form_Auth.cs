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
    public partial class Form_Auth : Form
    {
        public Form_Auth()
        {
            InitializeComponent();
        }

        private void Form_Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_sign_in_Click(object sender, EventArgs e)
        {
            if (cb_certificates.SelectedItem == null)
                return;

            MessageBox.Show(cb_certificates.SelectedItem.ToString());
        }

        private void Form_Auth_Load(object sender, EventArgs e)
        {
            List<CryptoClass.Certificate> userCerts = CryptoClass.GetCertificates();

            if (userCerts.Count > 0)
            {
                foreach (CryptoClass.Certificate cert in userCerts)
                    cb_certificates.Items.Add(cert);
            }
        }
    }
}
