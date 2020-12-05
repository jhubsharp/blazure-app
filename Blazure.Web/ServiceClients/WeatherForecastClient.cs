using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static Blazure.Web.Pages.FetchData;

namespace Blazure.Web.ServiceClients
{
    public class WeatherForecastClient
    {
        private HttpClient _client;

        public WeatherForecastClient(HttpClient client, IOptions<WeatherForecastOptions> options)
        {
            _client = client;
            _client.BaseAddress = new Uri(options.Value.BaseAddress);
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return await _client.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
        }
    }

    public class WeatherForecastOptions
    {
        public const string WeatherForecastConfig = "api:weatherForecast";
        
        public string BaseAddress { get; set; }
    }
}
