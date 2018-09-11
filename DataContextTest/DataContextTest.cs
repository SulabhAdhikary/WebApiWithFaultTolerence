using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using DataContext.EntityModels;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;



namespace DataContextTest
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void CheckGetWeatherInfos()
        {
            var students = new List<WeatherInfo>
            {
                  new WeatherInfo{Id=1, InfoDate = DateTime.Parse("2018-06-24"),TemperatureC=32, Summary="Scorching"},
                  new WeatherInfo{Id =2, InfoDate = DateTime.Parse("2018-06-25"),TemperatureC=45, Summary="Mild"},

            }.AsQueryable<WeatherInfo>();
            var mockSet = new Mock<DbSet<WeatherInfo>>();
            mockSet.As<IQueryable<WeatherInfo>>().Setup(m => m.Provider).Returns(students.Provider);
            mockSet.As<IQueryable<WeatherInfo>>().Setup(m => m.Expression).Returns(students.Expression);
            mockSet.As<IQueryable<WeatherInfo>>().Setup(m => m.ElementType).Returns(students.ElementType);
            mockSet.As<IQueryable<WeatherInfo>>().Setup(m => m.GetEnumerator()).Returns(() => students.GetEnumerator());
            var mockContext = new Mock<DataContext.DataContext>();
            mockContext.Setup(c => c.Set<WeatherInfo>()).Returns(mockSet.Object);
            DataContext.RepositoryImplementation.Repository obj = new DataContext.RepositoryImplementation.Repository(mockContext.Object);

            var allInfos = obj.GetAll<WeatherInfo>();
            List<WeatherInfo> lstAllStudents = allInfos.ToList();
            Assert.AreEqual(2, lstAllStudents.Count);
        }

    }
}
