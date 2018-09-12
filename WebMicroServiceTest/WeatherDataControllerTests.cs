using DataContext.EntityModels;
using DataContext.RepositoryContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMicroServiceFetchWeatherData.Controllers;
using WebMicroServiceFetchWeatherData.Services.Interface;

namespace WebMicroServiceTest
{
    [TestClass]
    public class WeatherDataControllerTests
    {
        [TestMethod]
        public void TestMethodGetSuccess()
        {
            var rep = new Mock<IRepositoryBase>();
            var randGenerator = new Mock<IFaultyServiceSimulator>();
            randGenerator.Setup(m => m.CheckIfServiceIsFaulty()).Returns(false);

            var students = new List<WeatherInfo>
            {
                new WeatherInfo{Id=1, InfoDate = DateTime.Parse("2018-06-24"),TemperatureC=32, Summary="Scorching"},
                new WeatherInfo{Id =2, InfoDate = DateTime.Parse("2018-06-25"),TemperatureC=45, Summary="Mild"},
            }.AsQueryable<WeatherInfo>();

            WeatherDataController objWeatherDataController = new WeatherDataController(rep.Object, randGenerator.Object);
            var result = objWeatherDataController.Get();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [TestMethod]
        public void TestMethodGetFailied()
        {
            var rep = new Mock<IRepositoryBase>();
            var randGenerator = new Mock<IFaultyServiceSimulator>();
            randGenerator.Setup(m => m.CheckIfServiceIsFaulty()).Returns(true);

            var students = new List<WeatherInfo>
            {
                new WeatherInfo{Id=1, InfoDate = DateTime.Parse("2018-06-24"),TemperatureC=32, Summary="Scorching"},
                new WeatherInfo{Id =2, InfoDate = DateTime.Parse("2018-06-25"),TemperatureC=45, Summary="Mild"},
            }.AsQueryable<WeatherInfo>();

            WeatherDataController objWeatherDataController = new WeatherDataController(rep.Object, randGenerator.Object);
            var result = objWeatherDataController.Get();
            var statuscode = (Microsoft.AspNetCore.Mvc.StatusCodeResult)result;
            Assert.AreEqual(500, statuscode.StatusCode);
        }
    }
}