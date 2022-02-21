using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Crypto : Form
    {
        public X509Certificate2 certificate2 = null;

        public Crypto()
        {
            InitializeComponent();

            List<CryptoClass.UserCert> userCerts = CryptoClass.GetCertificates();

            if (userCerts.Count > 0)
            {
                foreach (CryptoClass.UserCert cert in userCerts)
                    comboBox1.Items.Add(cert);

                comboBox1.SelectedIndex = 0;

                CryptoClass.UserCert selectedCert = (CryptoClass.UserCert)comboBox1.Items[comboBox1.SelectedIndex];

                certificate2 = selectedCert.certificate;
            }
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;

            if (string.IsNullOrEmpty(textBox1.Text) && certificate2 == null)
                return;

            try
            {
                Encoding encoding = Encoding.Unicode;

                byte[] encodedSignature = CryptoClass.SingMsg(encoding.GetBytes(textBox1.Text), certificate2, false);

                richTextBox1.Text = Convert.ToBase64String(encodedSignature);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_get_CRPT_token_Click(object sender, EventArgs e)
        {
            richTextBox_CRPT_Token.Text = String.Empty;

            if (certificate2 == null)
                return;

            richTextBox_CRPT_Token.Text = CRPT.GetAuthenticationToken(certificate2).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CryptoClass.UserCert selectedCert = (CryptoClass.UserCert)comboBox1.Items[comboBox1.SelectedIndex];

            certificate2 = selectedCert.certificate;
        }
    }
}
