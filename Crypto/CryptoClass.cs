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
        public class Certificate
        {
            public string SubjectName { get; set; }
            public string SubjectIndividualName { get; set; }
            public string SubjectAddress { get; set; }
            public string SubjectEmail { get; set; }
            public string SubjectINN { get; set; }
            public string SubjectOGRN { get; set; }
            public string SubjectOGRNIP { get; set; }
            public X509Certificate2 certificate { get; set; }
            public override string ToString()
            {
                return string.Format("{0} ({1} - {2})", this.SubjectName, this.certificate.NotBefore.ToString("yyyy.MM.dd"), this.certificate.NotAfter.ToString("yyyy.MM.dd"));
            }
        }

        public static List<Certificate> GetCertificates()
        {
            var certificates = new List<Certificate>();

            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            foreach (var c in store.Certificates)
            {
                if (string.IsNullOrEmpty(c.SubjectName.Name))
                    continue;

                // Наименование из сертификата
                string subject_name = GetValueIndexOfString(c.SubjectName.Name, "CN=");
                // Наименование физического лица из сертификата
                string subject_individual_name = string.Format("{0} {1}", GetValueIndexOfString(c.SubjectName.Name, "SN="), GetValueIndexOfString(c.SubjectName.Name, "G="));
                // E-Mail из сертификате
                string subject_email = GetValueIndexOfString(c.SubjectName.Name, "E=", ",");
                // Улица из сертификате
                string subject_street = GetValueIndexOfString(c.SubjectName.Name, "STREET=", "\",");
                // Адрес из сертификата
                string subject_address = string.Format("{0}, {1}, {2}, {3}",
                    GetValueIndexOfString(c.SubjectName.Name, "C="),
                    GetValueIndexOfString(c.SubjectName.Name, "S="),
                    GetValueIndexOfString(c.SubjectName.Name, "L="),
                    (string.IsNullOrEmpty(subject_street) ? "" : subject_street.Replace("\\", string.Empty).Replace("\"", string.Empty)));
                // ОГРН из сертификата
                string subject_OGRN = GetValueIndexOfString(c.SubjectName.Name, "ОГРН=");
                // ОГРНИП из сертификата
                string subject_OGRNIP = GetValueIndexOfString(c.SubjectName.Name, "ОГРНИП=");
                // ИНН из сертификата
                string subject_INN = (string.IsNullOrEmpty(subject_OGRN) ? GetValueIndexOfString(c.SubjectName.Name, "ИНН=") : GetValueIndexOfString(c.SubjectName.Name, "ИНН ЮЛ="));

                if (string.IsNullOrEmpty(subject_name) || (string.IsNullOrEmpty(subject_OGRN) && string.IsNullOrEmpty(subject_OGRNIP)) ||
                    string.IsNullOrEmpty(subject_INN) || c.NotBefore > DateTime.Now || c.NotAfter < DateTime.Now)
                    continue;

                certificates.Add(new Certificate
                {
                    certificate = c,
                    SubjectName = subject_name,
                    SubjectIndividualName = subject_individual_name,
                    SubjectAddress = subject_address,
                    SubjectEmail = subject_email,
                    SubjectINN = subject_INN,
                    SubjectOGRN = subject_OGRN,
                    SubjectOGRNIP = subject_OGRNIP
                });
            }

            store.Close();

            return certificates;
        }

        private static string GetValueIndexOfString(string str, string key, string separator = ",")
        {
            if (str == null)
                return null;

            var i = str.IndexOf(key, 0, StringComparison.InvariantCulture);

            if (i == -1)
                return null;

            i += key.Length;

            var e = str.IndexOf(separator, i, StringComparison.InvariantCulture);

            if (e == -1)
                e = str.Length;

            string val = str.Substring(i, e - i);

            return val;
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
