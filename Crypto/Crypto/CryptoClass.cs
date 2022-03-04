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
        // Хранилище сертификатов: Личное
        private const StoreName storeName = StoreName.My;
        // Расположение хранилища сертификатов: Текущий пользователь
        private const StoreLocation storeLocation = StoreLocation.CurrentUser;
        // Список данных сертификатов
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

        /// <summary>
        /// Получить список данных сертификатов электронных подписей установленных в хранилище личное текущего пользователя операционной системы
        /// </summary>
        /// <returns>Список данных сертификатов электронных подписей</returns>
        public List<SignerCertData> GetSignerCerts()
        {
            return certificates;
        }

        /// <summary>
        /// Получить данные сертификата электронной подписи по отпечатку
        /// </summary>
        /// <param name="thumbprint">Отпечаток сертификата электронной подписи</param>
        /// <returns>Данные сертификата электронной подписи</returns>
        internal SignerCertData GetSignerCertByThumbprint(string thumbprint)
        {
            return certificates.Find(x => x.thumbprint.Contains(thumbprint));
        }

        /// <summary>
        /// Получить данные сертификата электронной подписи по серийному номеру
        /// </summary>
        /// <param name="serialNumber">Серийный номер сертификата электронной подписи</param>
        /// <returns>Данные сертификата электронной подписи</returns>
        internal SignerCertData GetSignerCertBySerialNumber(string serialNumber)
        {
            return certificates.Find(x => x.serial_number.Contains(serialNumber));
        }

        /// <summary>
        /// Подписать данные
        /// </summary>
        /// <param name="signatureData">Данные для подписания</param>
        /// <param name="signedData">Подписанные данные</param>
        /// <param name="signingCertificate">Сертификат электронной подписи</param>
        /// <returns>Подписанные данные</returns>
        internal byte[] SignData(byte[] signatureData, out byte[] signedData, X509Certificate2 signingCertificate, bool detached = false) 
        {
            try
            {
                ContentInfo contentInfo = new ContentInfo(signatureData);
                SignedCms signedCms = new SignedCms(contentInfo, detached);
                CmsSigner cmsSigner = new CmsSigner(signingCertificate);

                signedCms.ComputeSignature(cmsSigner);

                signedCms.CheckSignature(false);

                signedData = signedCms.Encode();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                signedData = null;
            }

            return signedData;
        }

        /// <summary>
        /// Снять подпись с данных
        /// </summary>
        /// <param name="signatureRemovalData">Подписанные данные</param>
        /// <param name="unsignedData">Данные без подписи</param>
        /// <param name="signingCertificate">Сертификат электронной подписи</param>
        /// <returns>Данные без подписи</returns>
        internal byte[] UnsignData(byte[] signatureRemovalData, out byte[] unsignedData, X509Certificate2 signingCertificate = null, bool detached = false)
        {
            try
            {
                ContentInfo contentInfo = new ContentInfo(signatureRemovalData);
                SignedCms signedCms = new SignedCms(contentInfo);

                if (signingCertificate != null)
                {
                    CmsSigner cmsSigner = new CmsSigner(signingCertificate);

                    signedCms.ComputeSignature(cmsSigner);

                    signedCms.CheckSignature(false);
                }

                signedCms.Decode(signatureRemovalData);

                unsignedData = signedCms.ContentInfo.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                unsignedData = null;
            }

            return unsignedData;
        }
    }
}
