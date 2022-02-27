using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Crypto.Crypto;
using DevExpress.XtraSplashScreen;

namespace Crypto
{
    public partial class Form_Auth : Form
    {
        CryptoClass cryptoClass = new CryptoClass();

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

            SignerCertData signerCertSelected = (SignerCertData)cb_certificates.SelectedItem;

            Properties.Settings.Default.cert_sn = signerCertSelected.serial_number;

            CRPT.Authentication authentication = new CRPT.Authentication();

            IOverlaySplashScreenHandle ShowProgressPanel()
            {
                return SplashScreenManager.ShowOverlayForm(this);
            }
            void CloseProgressPanel(IOverlaySplashScreenHandle handlew)
            {
                if (handlew != null)
                    SplashScreenManager.CloseOverlayForm(handlew);
            }

            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = ShowProgressPanel();
                // Launch a long-running operation while
                // the Overlay Form overlaps the current form.

                CRPT cRPT = new CRPT();
                authentication = cRPT.GetAuthenticationToken(signerCertSelected.certificate);
                
            }
            finally
            {
                CloseProgressPanel(handle);
                MessageBox.Show(authentication.ToString());
            }
        }

        private void Form_Auth_Load(object sender, EventArgs e)
        {
            List<SignerCertData> signerCerts = cryptoClass.GetSignerCerts();

            foreach (var signerCert in signerCerts)
                cb_certificates.Items.Add(signerCert);

            btn_sign_in.Enabled = cb_certificates.SelectedItem != null;
        }

        private void cb_certificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_certificates.SelectedItem == null)
            {
                rtb_cert_data.Text = string.Empty;
            }
            else
            {
                SignerCertData signerCertSelected = (SignerCertData)cb_certificates.SelectedItem;

                rtb_cert_data.Text = string.Format("Владелец: {1}{0}ИНН: {2}{0}{3}{0}Адрес: {4}",
                    Environment.NewLine,
                    signerCertSelected.subject.IndividualName,
                    signerCertSelected.subject.INN,
                    signerCertSelected.subject.INN.Length == 10 ? $"ОГРН: {signerCertSelected.subject.OGRN}" : $"ОГРНИП: {signerCertSelected.subject.OGRN}",
                    signerCertSelected.subject.Address
                );
            }

            btn_sign_in.Enabled = cb_certificates.SelectedItem != null;
        }
    }
}
