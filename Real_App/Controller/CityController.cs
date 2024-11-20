using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Real_App.Dtos;
using Real_App.Interfaces;
using Real_App.Migrations;
using Real_App.Model;
using Real_App.Repository;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        // api/city/all
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCitiesAsync()
        {
            var cities = await _uow.CityRepository.GetCitiesAsync();
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }
        
        // api/city/add
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CityDto>> AddCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            city.LastUpdatedOn = DateTime.Now;
            city.LastUpdatedBy = 1;
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

        // api/city/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<City>> UpdateCity(int id, CityDto cityDto)
        {
            var cityFromDb = await _uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedOn = DateTime.Now;
            cityFromDb.LastUpdatedBy = 1;
            _mapper.Map(cityDto, cityFromDb);
            await _uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpPatch]
        [Route("update/{id}")]
        public async Task<ActionResult<City>> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch) 
        {
            var cityFromDb = await _uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedOn = DateTime.Now;
            cityFromDb.LastUpdatedBy = 1;

            cityToPatch.ApplyTo(cityFromDb, ModelState);
            await _uow.SaveAsync();
            return StatusCode(200);
        }
    }
}
 