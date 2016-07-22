using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerodhaClientSharp.Client;
using ZerodhaClientSharp.DomainTypes;

namespace ZerodhaClientSharp.LoginData
{
    public class Login
    {
        string api_key = "aw230frvr95ajkzx";
        string api_secret = "s9xnvmit7stynvej93a2qd17vxyxi3cn";
        public string Token_Request { get; set; }
        public string CheckSum { get; set; }

        public string SiteLogin()
        {
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
          
            var request = new  RestRequest("connect/login?api_key=" + api_key, Method.GET);
            // adds to POST or URL querystring based on Method
            // replaces matching token in request.Resource

            // easily add HTTP Headers
            // request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = ZerodhaClient.GetClient().Client.Execute(request);
            return response.ResponseUri.ToString();
            //            var content = response.Content; // raw content as string

            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;

            //// easy async support
            //client.ExecuteAsync(request, response =>
            //{
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response =>
            //{
            //    Console.WriteLine(response.Data.Name);
            //});
        }

        private string GetCheckSum(string token_id)
        {

            string password = api_key + token_id + api_secret;
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();

        }

        public SessionWrapper GetSession(string token_id)
        {   // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("session/token", Method.POST);
            request.AddParameter("api_key", api_key);
            request.AddParameter("request_token", token_id);
            request.AddParameter("checksum", GetCheckSum(token_id));// adds to POST or URL querystring based on Method
            // replaces matching token in request.Resource

            // easily add HTTP Headers
            // request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse<SessionWrapper> response = ZerodhaClient.GetClient().Client.Execute<SessionWrapper>(request);
            return response.Data;
            //var content = response.Content; // raw content as string

        }

        public string GetUserToken(string token_id)
        {
            string userToken;
            var sessionData = GetSession(token_id);
            userToken = sessionData.data.access_token;
            return userToken;
        }
    }
}
