using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Atlanta", "New York" };
        }
    }
}
