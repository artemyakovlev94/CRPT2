using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crypto.Crypto;

namespace Crypto
{
    public partial class Form_SelectCert : Form
    {
        CryptoClass cryptoClass = new CryptoClass();

        public Form_SelectCert()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

        }

        private void Form_SelectCert_Load(object sender, EventArgs e)
        {
            List<SignerCertData> signerCerts = cryptoClass.GetSignerCerts();

            foreach (var signerCert in signerCerts)
                cb_certs.Items.Add(signerCert);

            btn_OK.Enabled = cb_certs.SelectedItem != null;
        }

        private void cb_certs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_certs.SelectedItem == null)
            {
                rtb_data_cert.Text = string.Empty;
            }
            else
            {
                SignerCertData signerCertSelected = (SignerCertData)cb_certs.SelectedItem;

                rtb_data_cert.Text = string.Format("Владелец: {1}{0}ИНН: {2}{0}{3}{0}Адрес: {4}",
                    Environment.NewLine,
                    signerCertSelected.subject.IndividualName,
                    signerCertSelected.subject.INN,
                    signerCertSelected.subject.INN.Length == 10 ? $"ОГРН: {signerCertSelected.subject.OGRN}" : $"ОГРНИП: {signerCertSelected.subject.OGRN}",
                    signerCertSelected.subject.Address
                );
            }

            btn_OK.Enabled = cb_certs.SelectedItem != null;
        }
    }
}
