using DataContext.EntityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebSpa.Helper;
using WebSpa.ViewModel;

namespace WebSpa.Services
{
    public class WeatherDataService : IWeatherDataService
    {
      
        private HttpClient _client;      
        readonly ILogger<WeatherDataService> _log;
       

        public WeatherDataService(HttpClient client,IConfiguration Configuration, ILogger<WeatherDataService> log)
        {
            _client = client;
            _client.BaseAddress = new Uri(Configuration["microserviceUrl"]);
            _log = log;
     
        }

        public async Task<List<WeatherForecast>> GetWeatherForcastData()
        {  
                var  requestEndpoint = new Uri($"api/WeatherData", UriKind.Relative);
                HttpResponseMessage httpResponse = await _client.GetAsync(requestEndpoint); 
                string data = await httpResponse.Content.ReadAsStringAsync();
               if (string.IsNullOrEmpty(data))
               {
                    _log.LogInformation("Failed to get data from api/WeatherData");
                    throw new MicroServiceCallException("Error While calling webservice");
               }
               List<WeatherInfo> retFromWebService = JsonConvert.DeserializeObject<List<WeatherInfo>>(data);
               var result = retFromWebService.Select(t =>
               new WeatherForecast { DateFormatted = t.InfoDate.ToString("d"), Summary = t.Summary, TemperatureC = t.TemperatureC });
               return result.ToList();
        }
       
    }
}