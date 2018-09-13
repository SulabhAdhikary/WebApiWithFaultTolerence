using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMicroServiceFetchWeatherData.Services.Interface;

namespace WebMicroServiceFetchWeatherData.Services
{
    public class FaultyServiceSimulator : IFaultyServiceSimulator
    {
        public bool CheckIfServiceIsFaulty()
        {
            var rng = new Random();
            var number = Math.Round((decimal)rng.Next(0, 100), 0);
            return !(number % 2 == 0);
           
        }
    }
}
