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
    [AllowAnonymous]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var PropertyTypes = await _uow.PropertyTypeRepository.GetPropertyTypesAsync();
            var PropertyTypeDto = _mapper.Map<IEnumerable<KeyValuePairDto>>(PropertyTypes);
            return Ok(PropertyTypeDto);
        }
    }
}
