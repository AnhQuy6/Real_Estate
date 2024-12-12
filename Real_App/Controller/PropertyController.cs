using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_App.Dtos;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PropertyController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Type/{sellRent}")]
        
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesAsync(int sellRent)
        {
            var properties = await _uow.PropertyRepository.GetPropertiesAsync(sellRent);
            var propertyListDto = _mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertyListDto);
        }

        [HttpGet]
        [Route("detail/{id}")]
        public async Task<IActionResult> GetPropertyDetailAsync(int id)
        {
            var property = await _uow.PropertyRepository.GetPropertyDetailAsync(id);
            var propertyDto = _mapper.Map<PropertyDetailDto>(property);
            return Ok(propertyDto);
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            var userId = GetUserId();
            property.PostedBy = userId;
            property.LastUpdatedBy = userId;
            _uow.PropertyRepository.AddProperty(property);
            await _uow.SaveAsync();
            return StatusCode(201);
        }
    }
}
