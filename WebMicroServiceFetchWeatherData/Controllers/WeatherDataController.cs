using DataContext.EntityModels;
using DataContext.RepositoryContracts;
using Microsoft.AspNetCore.Mvc;
using WebMicroServiceFetchWeatherData.Services.Interface;

namespace WebMicroServiceFetchWeatherData.Controllers
{
    [Route("api/[controller]")]
    public class WeatherDataController : Controller
    {
        private IRepositoryBase _repository { get; set; }
        private IFaultyServiceSimulator _faultyService { get; set; }

        public WeatherDataController(IRepositoryBase repository, IFaultyServiceSimulator faultyService)
        {
            _repository = repository;
            _faultyService = faultyService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            if (!_faultyService.CheckIfServiceIsFaulty())
            {
                var lstAllWeatherInfo = _repository.GetAll<WeatherInfo>();
                return Ok(lstAllWeatherInfo);
            }
            return StatusCode(500);
        }
    }
}