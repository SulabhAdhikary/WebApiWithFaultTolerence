using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataContext.EntityModels;

namespace DataContext
{
    public static class DataContextExtension
    {
        public static void EnsureSeedData(this DataContext context)
        {
            SeedData(context);

        }
        /// <summary>
        /// This method will insert sample data in the Database
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(DataContext context)
        {
            bool doesDatabaseExist =  context.Database.EnsureCreated();
            if (context.WeatherInfos.Any())
            {
                return;
            }

            var weatherInfos = new WeatherInfo[]
            {
                new WeatherInfo{InfoDate = DateTime.Parse("2018-06-24"),TemperatureC=32, Summary="Scorching"},
                new WeatherInfo{InfoDate = DateTime.Parse("2018-06-25"),TemperatureC=45, Summary="Mild"},
                new WeatherInfo{InfoDate = DateTime.Parse("2018-06-26"),TemperatureC=-4, Summary="Mild"},
                new WeatherInfo{InfoDate = DateTime.Parse("2018-06-27"),TemperatureC=16, Summary="Balmy"},
                new WeatherInfo{InfoDate = DateTime.Parse("2018-06-28"),TemperatureC=53, Summary="Hot"}
            };
            foreach (WeatherInfo wi in weatherInfos)
            {
                context.WeatherInfos.Add(wi);
            }
            context.SaveChanges();
        }
    }
}
