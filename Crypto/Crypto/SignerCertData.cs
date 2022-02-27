using System;
using System.Security.Cryptography.X509Certificates;

namespace Crypto.Crypto
{
    internal class SignerCertData
    {
        internal class Subject
        {
            internal string Name { get; private set; }
            internal string IndividualName { get; private set; }
            internal string Address { get; private set; }
            internal string Email { get; private set; }
            internal string INN { get; private set; }
            internal string OGRN { get; private set; }

            internal Subject(string SubjectName)
            {
                Name = GetValueFromStringByKey(SubjectName, "CN=");

                string SN = GetValueFromStringByKey(SubjectName, "SN=");
                string G = GetValueFromStringByKey(SubjectName, "G=");
                IndividualName = string.IsNullOrWhiteSpace(SN) ? string.Empty : string.IsNullOrWhiteSpace(G) ? SN : $"{SN} {G}";

                string C = GetValueFromStringByKey(SubjectName, "C=");
                string S = GetValueFromStringByKey(SubjectName, "S=");
                string L = GetValueFromStringByKey(SubjectName, "L=");
                string street_separator = SubjectName.IndexOf("STREET=\"", 0, StringComparison.InvariantCulture) == -1 ? "," : "\",";
                string street = GetValueFromStringByKey(SubjectName, "STREET=", street_separator);
                street = string.IsNullOrWhiteSpace(street) ? street : street.Replace("\\", string.Empty).Replace("\"", string.Empty);

                Address = string.IsNullOrWhiteSpace(C) ? string.Empty : string.IsNullOrWhiteSpace(S)
                    ? C : string.IsNullOrWhiteSpace(L)
                    ? $"{C}, {S}" : string.IsNullOrWhiteSpace(street)
                    ? $"{C}, {S}, {L}" : $"{C}, {S}, {L}, {street}";

                Email = GetValueFromStringByKey(SubjectName, "E=");

                INN = GetValueFromStringByKey(SubjectName, "ИНН=");
                INN = string.IsNullOrWhiteSpace(INN) ? GetValueFromStringByKey(SubjectName, "ИНН ЮЛ=") : INN;

                OGRN = GetValueFromStringByKey(SubjectName, "ОГРН=");
                OGRN = string.IsNullOrWhiteSpace(OGRN) ? GetValueFromStringByKey(SubjectName, "ОГРНИП=") : OGRN;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        internal class Issuer
        {
            internal string Name { get; private set; }
            internal string Organization { get; private set; }
            internal string Address { get; private set; }
            internal string Email { get; private set; }
            internal string INN { get; private set; }
            internal string OGRN { get; private set; }

            internal Issuer(string IssuerName)
            {
                Name = GetValueFromStringByKey(IssuerName, "CN=");
                Organization = GetValueFromStringByKey(IssuerName, "O=");

                string C = GetValueFromStringByKey(IssuerName, "C=");
                string S = GetValueFromStringByKey(IssuerName, "S=");
                string L = GetValueFromStringByKey(IssuerName, "L=");
                string street_separator = IssuerName.IndexOf("STREET=\"", 0, StringComparison.InvariantCulture) == -1 ? "," : "\",";
                string street = GetValueFromStringByKey(IssuerName, "STREET=", street_separator);
                street = string.IsNullOrWhiteSpace(street) ? street : street.Replace("\\", string.Empty).Replace("\"", string.Empty);

                Address = string.IsNullOrWhiteSpace(C) ? string.Empty : string.IsNullOrWhiteSpace(S)
                    ? C : string.IsNullOrWhiteSpace(L)
                    ? $"{C}, {S}" : string.IsNullOrWhiteSpace(street)
                    ? $"{C}, {S}, {L}" : $"{C}, {S}, {L}, {street}";

                Email = GetValueFromStringByKey(IssuerName, "E=");

                INN = GetValueFromStringByKey(IssuerName, "ИНН ЮЛ=");

                OGRN = GetValueFromStringByKey(IssuerName, "ОГРН=");
            }

            public override string ToString()
            {
                return Name;
            }
        }
        internal X509Certificate2 certificate { get; private set; }
        internal Subject subject { get; private set; }
        internal Issuer issuer { get; private set; }
        internal DateTime not_before { get; private set; }
        internal DateTime not_after { get; private set; }
        internal string serial_number { get; private set; }
        internal string thumbprint { get; private set; }
        
        internal SignerCertData(X509Certificate2 certificate)
        {
            if (string.IsNullOrEmpty(certificate.SubjectName.Name) || string.IsNullOrEmpty(certificate.IssuerName.Name))
                return;

            this.certificate = certificate;

            subject = new Subject(certificate.SubjectName.Name);

            issuer = new Issuer(certificate.IssuerName.Name);

            not_before = certificate.NotBefore;

            not_after = certificate.NotAfter;

            serial_number = certificate.GetSerialNumberString();

            thumbprint = certificate.Thumbprint;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} - {2})", subject.ToString(), not_before.ToString("yyyy.MM.dd"), not_after.ToString("yyyy.MM.dd"));
        }

        internal static string GetValueFromStringByKey(string str, string key, string separator = ",")
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
    }

    
}
