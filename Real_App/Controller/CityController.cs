using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_App.Data;
using Real_App.Data.Repository;
using Real_App.Model;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    
    {
        private readonly ICityRepository _repo;
        public CityController(ICityRepository repo)
        {
            _repo = repo;
        }
        
        //Get api/city/all
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<City>>> GetCitiesAsync()
        {
            var cities = await _repo.GetCitiesAsync();
            return Ok(cities);
        }

        
        // api/city/add
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<City>> AddCity(City city)
        {
            _repo.AddCity(city);
            await _repo.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<int>> DeleteCity(int id)
        {
            _repo.DeleteCity(id);
            await _repo.SaveAsync();
            return Ok(id);
        }
        
    }
}
