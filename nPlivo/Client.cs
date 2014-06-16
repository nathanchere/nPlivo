using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;

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

        private IRestResponse<T> _request<T>(string http_method, string resource, Dictionary<string,string> data)
         where T : new()
        {
            var request = new RestRequest() { Resource = resource, RequestFormat = DataFormat.Json };

            // add the parameters to the request
            foreach (KeyValuePair<string, string> kvp in data)
                request.AddParameter(kvp.Key, HtmlEntity.Convert(kvp.Value));

            //set the HTTP method for this request
            switch (http_method.ToUpper())
            {
                case "GET": request.Method = Method.GET;
                    break;
                case "POST": request.Method = Method.POST;
                    request.Parameters.Clear();
                    request.AddParameter("application/json", request.JsonSerializer.Serialize(data), ParameterType.RequestBody);
                    break;
                case "DELETE": request.Method = Method.DELETE;
                    break;
                default: request.Method = Method.GET;
                    break;
            };
            restClient.AddHandler("application/json", new JsonDeserializer());
            IRestResponse<T> response = restClient.Execute<T>(request);
            return response;
        }

        public IRestResponse<MessageResponse> SendSms(SmsMessage message)
        {
            IRestResponse<MessageResponse> resp = _request<MessageResponse>("POST", "/Message/", new Dictionary<string, string>()
            {
                {"src", fromNumber},
                {"dst", toNumber},
                {"text", body},
                //{"url", "http://some.domain/receivestatus/"},
                //{"method", "GET"}
            });
            return resp;
            //if (resp.Data != null)
            //{
            //    PropertyInfo[] proplist = resp.Data.GetType().GetProperties();
            //    foreach (PropertyInfo property in proplist)
            //        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(resp.Data, null));
            //}
            //else
            //    Console.WriteLine(resp.ErrorMessage);
        }
    }

    public IRestResponse<MessageResponse> SendSms(string fromNumber, string toNumber, string body)
        {
            IRestResponse<MessageResponse> resp = _request<MessageResponse>("POST", "/Message/", new Dictionary<string, string>()
            {
                {"src", fromNumber},
                {"dst", toNumber},
                {"text", body},
                //{"url", "http://some.domain/receivestatus/"},
                //{"method", "GET"}
            });
            return resp;
            //if (resp.Data != null)
            //{
            //    PropertyInfo[] proplist = resp.Data.GetType().GetProperties();
            //    foreach (PropertyInfo property in proplist)
            //        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(resp.Data, null));
            //}
            //else
            //    Console.WriteLine(resp.ErrorMessage);
        }
    }

    class HtmlEntity
    {
        public static string Convert(string inputText)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in inputText)
            {
                if ((int)c > 127)
                {
                    builder.Append("&#");
                    builder.Append((int)c);
                    builder.Append(";");
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }
    public class MessageResponse
    {
        public string message { get; set; }
        public List<string> message_uuid { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }


}
