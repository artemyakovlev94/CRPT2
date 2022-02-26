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

            CryptoClass.Certificate cert = (CryptoClass.Certificate)cb_certificates.SelectedItem;

            Properties.Settings.Default.cert_sn = cert.certificate.GetSerialNumberString();

            Hide();
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

        private void cb_certificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_certificates.SelectedItem == null)
            {
                rtb_cert_data.Text = String.Empty;
            }
            else
            {
                CryptoClass.Certificate certificate = (CryptoClass.Certificate)cb_certificates.SelectedItem;

                rtb_cert_data.Text = String.Format("Владелец: {1}{0}ИНН: {2}{0}{3}{0}Адрес: {4}", 
                    Environment.NewLine,
                    certificate.SubjectIndividualName,
                    certificate.SubjectINN,
                    (string.IsNullOrEmpty(certificate.SubjectOGRNIP) ? $"ОГРН: {certificate.SubjectOGRN}" : $"ОГРНИП: {certificate.SubjectOGRNIP}"),
                    certificate.SubjectAddress
                );
            }
        }
    }
}
