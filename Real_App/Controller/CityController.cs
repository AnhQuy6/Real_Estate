using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_App.Interfaces;
using Real_App.Model;
using Real_App.Repository;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public CityController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        // api/city/all
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<City>>> GetCitiesAsync()
        {
            var cities = await _uow.CityRepository.GetCitiesAsync();
            return Ok(cities);
        }
        
        // api/city/add
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<City>> AddCity(City city)
        {
            _uow.CityRepository.AddCity(city);
            await _uow.SaveAsync();
            return StatusCode(201);
        }
        
        // api/city/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<int>> DeleteCity(int id)
        {
            _uow.CityRepository.DeleteCity(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
 