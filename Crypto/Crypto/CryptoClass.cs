using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crypto.Crypto
{
    internal class CryptoClass
    {
        private const StoreName storeName = StoreName.My;
        private const StoreLocation storeLocation = StoreLocation.CurrentUser;

        internal List<SignerCertData> certificates = new List<SignerCertData>();

        internal CryptoClass()
        {
            X509Store store = new X509Store(storeName, storeLocation);

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 certificate in store.Certificates)
            {
                if (!certificate.Verify() || certificate.NotBefore > DateTime.Now || certificate.NotAfter < DateTime.Now)
                    continue;

                SignerCertData certificate_data = new SignerCertData(certificate);

                if (string.IsNullOrWhiteSpace(certificate_data.serial_number) || string.IsNullOrWhiteSpace(certificate_data.subject.INN) || string.IsNullOrWhiteSpace(certificate_data.issuer.INN))
                    continue;

                certificates.Add(new SignerCertData(certificate));
            }

            store.Close();
        }

        public List<SignerCertData> GetSignerCerts()
        {
            return certificates;
        }

        internal SignerCertData GetSignerCertByThumbprint(string thumbprint)
        {
            return certificates.Find(x => x.thumbprint.Contains(thumbprint));
        }

        internal SignerCertData GetSignerCertBySerialNumber(string serialNumber)
        {
            return certificates.Find(x => x.serial_number.Contains(serialNumber));
        }

        internal byte[] SingData(byte[] data, X509Certificate2 singleCert, bool detached)
        {
            try
            {
                ContentInfo contentInfo = new ContentInfo(data);
                SignedCms signedCms = new SignedCms(contentInfo, detached);
                CmsSigner cmsSigner = new CmsSigner(singleCert);

                signedCms.ComputeSignature(cmsSigner);

                return signedCms.Encode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
