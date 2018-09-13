using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSpa.Helper;
using WebSpa.Services;
using WebSpa.ViewModel;

namespace WebSpa.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private IWeatherDataService _weatherDataService;
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public  SampleDataController(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> WeatherForecasts()
        {
            try
            {
                var resfromWebapi = await _weatherDataService.GetWeatherForcastData();
                return StatusCode(200, resfromWebapi);
            }catch(MicroServiceCallException ex)
            {
                return StatusCode(503, Json("Could get data from microservices"));
            }
          
        }

       
    }
}
