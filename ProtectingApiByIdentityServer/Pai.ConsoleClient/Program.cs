using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pai.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // discover endpoints from metadata
            var disco = DiscoveryClient.GetAsync("http://localhost:5300").Result;

            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ConsoleClient", "ConsoleSecret");
            var tokenResponse =  tokenClient.RequestClientCredentialsAsync("MyTest").Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("==============================");

            //设置token 访问API
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

           // var response = client.GetAsync("http://localhost:5301/api/values").Result;

            var response = client.GetAsync("http://localhost:5301/api/myapi1").Result;

            string content = "";
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JArray.Parse(content));
            }

            Console.ReadKey();


        }
    }
}
