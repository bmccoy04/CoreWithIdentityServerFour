using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace CoreWithIdentityServerFour.Console
{
    class Runner{
        public async static Task Run(){
            System.Console.WriteLine("test");
            
            var disco = await DiscoveryClient.GetAsync("http://localhost:5050");


            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if(tokenResponse.IsError){
                System.Console.WriteLine(tokenResponse.Error);
                return;
            };

            System.Console.WriteLine(tokenResponse.Json);

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
            var response = await client.GetAsync("http://localhost:5000/api/identity");
            if(!response.IsSuccessStatusCode){
                System.Console.WriteLine(response.StatusCode);                
            } else {
                var content = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(content);
            }
        }
    }
}