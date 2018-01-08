using System;
using System.Net.Http;
using System.Threading.Tasks;
using X.Interfaces;
using X.Models;
using X.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(RestClient))]
namespace X.Services
{
    public class RestClient : IRestClient
    {        
        private static HttpClient _client;

        public RestClient()
        {
            if (_client == null)
            {
                _client = new HttpClient();
            }
        }

        public async Task<string> GetJokeAsync()
        {
           
            try
            {
                var req = new HttpRequestMessage();
                req.RequestUri = new Uri("https://icanhazdadjoke.com/");
                req.Method = HttpMethod.Get;
                req.Headers.Add("Accept", "text/plain");

                var response = await _client.SendAsync(req);

                var data = await response.Content.ReadAsStringAsync();

                return data;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<QuoteData> GetQuoteAsync()
        {

            try
            {
                var req = new HttpRequestMessage();
                req.RequestUri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/");
                req.Method = HttpMethod.Get;
                req.Headers.Add("Accept", "application/json");
                req.Headers.Add("X-Mashape-Key", "e3KEFNy1YRmsh6Wti0MevOKMb9tSp1OKzIrjsnEjeAOGsgQmYC");

              
                var response = await _client.SendAsync(req);

                var data = await response.Content.ReadAsStringAsync();

                var responseParsed = JsonConvert.DeserializeObject<QuoteData>(data);

                return responseParsed;
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }




}
