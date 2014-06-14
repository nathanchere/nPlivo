using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace nPlivo
{
    public class Client
    {       
        private const string BASE_URL = "https://api.plivo.com";
        private readonly RestClient restClient;

        public Client(string authId, string authToken)
        {           
            restClient = new RestClient
            {
                Authenticator = new HttpBasicAuthenticator(authId, authToken),
                UserAgent = "nPlivo",
                BaseUrl = String.Format("{0}/v1/Account/{1}", BASE_URL, authId)
            };
        }
    }


}
