using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Real_App.Dtos;
using Real_App.Interfaces;
using Real_App.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Real_App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

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
            loginRes.Username = loginReq.Username;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(LoginReqDto loginReq)
        {
            if (await _uow.UserRepository.UserAlreadyExists(loginReq.Username))
                return BadRequest("User already exists, please try something else");

            _uow.UserRepository.Register(loginReq.Username, loginReq.Password);
            await _uow.SaveAsync();

            return StatusCode(201);
        }

        private string CreateJWT(User user)
        {
            // Tạo khóa đối xứng
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Key").Value));

            //PAYLOAD
            var claims = new Claim[]
            {
                // Mỗi Claim là một cặp key-value
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // Xác định phương pháp ký cho JWT
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // Mô tả cấu hình và nội dung của Token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
