using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestX1Dummy.GoRestPackage.DTOS.PostUser;

namespace ApiTestingX1.GoRestPackage.Utils.RequestUtils
{
    class RestUtils
    {
        public static T CallService<T>(string url, Method operation, string requestBodyObject = "default")
        {
            var client = new RestClient(url)
            {
                Timeout = 500000
            };

            var request = new RestRequest(operation);

            if (!requestBodyObject.Equals("default"))
            {
                var token = "3af11215926713cae085c0451f6ce3d532b242d326beee830af03673e2caf9aa"; // this is the goRest token
                   
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("RequestBody", requestBodyObject, ParameterType.RequestBody);

            }
            else
            {
                client.Authenticator = new SimpleAuthenticator("username", "3af11215926713cae085c0451f6ce3d532b242d326beee830af03673e2caf9aa", "password", "null");
            }

            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() != "OK")
            {
                var res = JObject.Parse(response.Content);

                throw new Exception("The service call failed. Status code [" + response.StatusCode + "] Message [" + res["error"] + "]");
            }

            if (response == null)
            {
                return default(T);
            }

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(response.Content, settings);
        }

    }
}
