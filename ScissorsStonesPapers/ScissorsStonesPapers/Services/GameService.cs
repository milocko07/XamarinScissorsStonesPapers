using Newtonsoft.Json;
using ScissorsStonesPapers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScissorsStonesPapers.Services
{
    public class GameService
    {
        private HttpClient _client;
        private static GameService _instance;

        public GameService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            _client.MaxResponseContentBufferSize = 256000;
        }

        public static GameService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameService();
                }

                return _instance;
            }
        }

        public async Task<List<Scores>> GetItems()
        {
            var items = new List<Scores>();
            var uri = new Uri(string.Format("{0}/tables/scores", GlobalSettings.GameEndpoint));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
              
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Scores>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return items;
        }

        public async Task InsertScore(Scores score)
        {
            var uri = new Uri(string.Format("{0}/tables/scores", GlobalSettings.GameEndpoint));

            var values = string.Format(" \"scoreGamer\": \"{0}\",  \"scoreMachine\": \"{1}\"", score.scoreGamer, score.scoreMachine);

            values = "{" + values + "}";

            StringContent stringContent = new StringContent
            (
             values,
               UnicodeEncoding.UTF8,
               "application/json"
            );

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                //dynamic content = JsonConvert.DeserializeObject(
                //    response.Content.ReadAsStringAsync()
                //    .Result);

                //// Access variables from the returned JSON object
                //var appHref = content.links.applications.href;
            }
        }
    }
}
