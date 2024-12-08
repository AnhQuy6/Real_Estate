using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Real_App.Interfaces;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PropertyController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        [Route("Properties")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesAsync()
        {
            var properties = await _uow.PropertyRepository.GetPropertiesAsync();
            return Ok(properties);
        }
    }
}
