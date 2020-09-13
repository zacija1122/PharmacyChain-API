using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PharmacyChain.Contract;
using PharmacyChain.Models;
using PharmacyChain.Services;

namespace PharmacyChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
        private readonly JWTSettings _jwtSettings;
        public EmployeeController(IEmployeeRepo repository, IOptions<JWTSettings> jwtSettings)
        {
            _repository = repository;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] AuthTest user)
        {
            user = await _repository.GetByEmailAndPassworkd(user);

            UserWithToken userWithToken = new UserWithToken(user);
            if (userWithToken == null)
                return NotFound();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.AccessToken = tokenHandler.WriteToken(token);

            return userWithToken;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] AuthTest user)

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfEmployees = await _repository.GetAll();
            if (listOfEmployees == null)
                return NotFound();
            return Ok(listOfEmployees);
        }

    }
}