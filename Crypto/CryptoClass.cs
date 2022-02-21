using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Crypto
{
    internal class CryptoClass
    {
        public class UserCert
        {
            public string Name { get; set; }
            public string SerialNumber { get; set; }
            public string Thumbprint { get; set; }
            public X509Certificate2 certificate { get; set; }
            public override string ToString()
            {
                return string.Format("{0} ({1})", this.Name, this.SerialNumber);
            }
        }

        public static List<UserCert> GetCertificates()
        {
            var certificates = new List<UserCert>();

            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            foreach (var c in store.Certificates)
            {
                if (c.SubjectName.Name == null) continue;

                var sIndex = c.SubjectName.Name.IndexOf("CN=", 0, StringComparison.InvariantCulture);

                if (sIndex == -1)
                    continue;

                sIndex += 3;

                var fIndex = c.SubjectName.Name.IndexOf(",", sIndex, StringComparison.InvariantCulture);

                if (fIndex == -1)
                    fIndex = c.SubjectName.Name.Length;

                certificates.Add(new UserCert()
                {
                    Name = c.SubjectName.Name.Substring(sIndex, fIndex - sIndex),
                    Thumbprint = c.Thumbprint,
                    SerialNumber = c.SerialNumber,
                    certificate = c
                });
            }

            store.Close();

            return certificates;
        }

        public static byte[] SingMsg(Byte[] msg, X509Certificate2 singleCert, bool detached)
        {
            try
            {
                ContentInfo contentInfo = new ContentInfo(msg);
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

        public static X509Certificate2 GetSignerCertByThumbprint(string thumbprint)
        {
            X509Certificate2 x509Certificate2 = null;

            X509Store storeMy = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            storeMy.Open(OpenFlags.ReadOnly);

            if (storeMy.Certificates.Count > 0)
            {
                X509Certificate2Collection certColl = storeMy.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

                if (certColl.Count > 0)
                    x509Certificate2 = certColl[0];
            }

            storeMy.Close();

            return x509Certificate2;
        }

        public static X509Certificate2 GetSignerCertBySerialNumber(string serial_number)
        {
            X509Certificate2 x509Certificate2 = null;

            X509Store storeMy = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            storeMy.Open(OpenFlags.ReadOnly);

            if (storeMy.Certificates.Count > 0)
            {
                X509Certificate2Collection certColl = storeMy.Certificates.Find(X509FindType.FindBySerialNumber, serial_number, false);

                if (certColl.Count > 0)
                    x509Certificate2 = certColl[0];
            }

            storeMy.Close();

            return x509Certificate2;
        }
    }
}
