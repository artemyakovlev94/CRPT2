using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Crypto
{
    internal class CRPT
    {
        public class Authentication
        {
            public string token { get; set; }
            public string code { get; set; }
            public string error_message { get; set; }
            public string description { get; set; }

            public override string ToString()
            {
                if (code == null)
                    return token;
                else
                    return error_message;
            }
        }

        public class AuthenticationData
        {
            public string uuid { get; set; }
            public string data { get; set; }

            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }

            public static void Get()
            {
                var client = new RestClient(BaseURL);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.Resource = "/auth/cert/key";
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = null;

                try
                {
                    response = client.Execute(request);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(response.ErrorMessage);
                    return;
                }

                try
                {
                    authenticationData = JsonSerializer.Deserialize<AuthenticationData>(response.Content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        
        private static string BaseURL = "https://shoes.sandbox.crpt.tech/api/v3";
        private static AuthenticationData authenticationData = new AuthenticationData();
        private static Authentication authentication = new Authentication();
        public static X509Certificate2 certificate = null;

        public static Authentication GetAuthenticationToken(X509Certificate2 cert = null)
        {
            if (cert != null)
                certificate = cert;

            if (certificate == null)
                return authentication;

            GetAuthenticationData();

            try
            {
                Encoding encoding = Encoding.Unicode;

                byte[] encodedSignature = CryptoClass.SingMsg(encoding.GetBytes(authenticationData.data), certificate, false);

                if (encodedSignature == null)
                    return authentication;

                authenticationData.data = Convert.ToBase64String(encodedSignature);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
                return authentication;
            }

            var client = new RestClient(BaseURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.Resource = "/auth/cert/";
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            var body = authenticationData.ToString();
            request.AddParameter("application/json;charset=UTF-8", body, ParameterType.RequestBody);

            IRestResponse response = null;

            try
            {
                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return authentication;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(response.ErrorMessage);
                return authentication;
            }

            try
            {
                authentication = JsonSerializer.Deserialize<Authentication>(response.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return authentication;
        }

        private static void GetAuthenticationData()
        {
            var client = new RestClient(BaseURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.Resource = "/auth/cert/key";
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = null;

            try
            {
                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(response.ErrorMessage);
                return;
            }

            try
            {
                authenticationData = JsonSerializer.Deserialize<AuthenticationData>(response.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
