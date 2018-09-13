using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSpa.ViewModel;
using static WebSpa.Controllers.SampleDataController;

namespace WebSpa.Services
{
    public interface IWeatherDataService
    {
        Task<List<WeatherForecast>> GetWeatherForcastData();
    }
}
