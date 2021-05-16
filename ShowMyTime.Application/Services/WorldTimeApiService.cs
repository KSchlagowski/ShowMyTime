using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShowMyTime.Application.Interfaces;
using ShowMyTime.Domain.Enums;

namespace ShowMyTime.Application.Services
{
    public class WorldTimeApiService : IWorldTimeApiService
    {
        private readonly HttpClient _client;

        public WorldTimeApiService()
        {
            _client = new HttpClient();
        }

        private void Configure()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public async Task<string> GetJsonFromAPI(string exactApiPath)
        {
            string msg = "";

            Configure();
            
            try
            {
                var stringTask = _client.GetStringAsync(exactApiPath);
                msg = await stringTask;
            } 
            catch(HttpRequestException e)
            {
                System.Console.WriteLine(e.StatusCode);
                
                if (e.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    msg = "503";
                }
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    msg = "404";
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
            }
            
            return msg;
        }
    }
}
