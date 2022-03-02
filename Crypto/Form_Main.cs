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
using Crypto.Crypto;

namespace Crypto
{
    public partial class Form_Main : Form
    {
        CryptoClass cryptoClass = new CryptoClass();

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(Properties.Settings.Default.token))
            //{
            //    Hide();
            //    Form_Auth form_auth = new Form_Auth();
            //    form_auth.ShowDialog();
            //    return;
            //}
            radio_btn_URL.Checked = true;
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

        private void btn_sign_data_Click(object sender, EventArgs e)
        {
            Form_SelectCert form_SelectCert = new Form_SelectCert();
            form_SelectCert.ShowDialog();

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.cert_sn) || string.IsNullOrWhiteSpace(tb_data.Text))
                return;

            SignerCertData signerCert = cryptoClass.GetSignerCertBySerialNumber(Properties.Settings.Default.cert_sn);

            Encoding encoding = Encoding.Unicode;

            byte[] encodedSignature = cryptoClass.SingData(encoding.GetBytes(tb_data.Text), signerCert.certificate, false);

            if(encodedSignature == null)
                return;

            rtb_sign_data.Text = Convert.ToBase64String(encodedSignature);
        }

        private void tb_string_for_shielding_TextChanged(object sender, EventArgs e)
        {
            Sheilding();
        }

        private void radio_btn_URL_CheckedChanged(object sender, EventArgs e)
        {
            Sheilding();
        }

        private void radio_btn_JSON_CheckedChanged(object sender, EventArgs e)
        {
            Sheilding();
        }

        private void radio_btn_XML_CheckedChanged(object sender, EventArgs e)
        {
            Sheilding();
        }

        private void Sheilding()
        {
            rtb_data_shielding.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(tb_string_for_shielding.Text))
                return;

            char[] chars = tb_string_for_shielding.Text.ToCharArray();
            string new_string = string.Empty;
            foreach (char ch in chars)
            {
                string test = string.Empty;

                if (radio_btn_URL.Checked)
                    charSheildURL.TryGetValue(ch, out test);

                new_string += string.IsNullOrWhiteSpace(test) ? ch.ToString() : test;
            }

            rtb_data_shielding.Text = new_string;
        }

        private Dictionary<char, string> charSheildURL = new Dictionary<char, string>()
        {
            { '!', "%21" },
            { '\\', "%5C" },
            { '\"', "%22" },
            { '%', "%25" },
            { '&', "%26" },
            { '\'', "%27" },
            { '*', "%2A" },
            { '+', "%2B" },
            { '-', "%2D" },
            { '.', "%2E" },
            { '/', "%2F" },
            { '_', "%5F" },
            { ',', "%2C" },
            { ':', "%3A" },
            { ';', "%3B" },
            { '=', "%3D" },
            { '<', "%3C" },
            { '>', "%3E" },
            { '?', "%3F" },
            { '(', "%28" },
            { ')', "%29" }
        };
    }
}
