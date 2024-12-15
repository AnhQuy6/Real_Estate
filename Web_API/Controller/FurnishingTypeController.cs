using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_App.Data;
using Real_App.Dtos;
using Real_App.Interfaces;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnishingTypeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FurnishingTypeController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("fff")]
        public async Task<IActionResult> GetFurnishingTypesAsync()
        {
            var FurnishingType = await _uow.FurnishingTypeRepository.GetFurnishingTypesAsync();
            var FurnishingTypeDto = _mapper.Map<IEnumerable<KeyValuePairDto>>(FurnishingType);
            return Ok(FurnishingTypeDto);
        }
    }
}
