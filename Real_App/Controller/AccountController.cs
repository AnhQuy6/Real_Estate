using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_App.Dtos;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        //api/account/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await _uow.UserRepository.Authenticate(loginReq.Username, loginReq.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var loginRes = new LoginResDto();
            loginRes.Username = user.Username;
            loginRes.Token = "Token to be generated";
            return Ok(loginRes);
        }
    }
}
