using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PharmacyChain.Contract;
using PharmacyChain.DTOs;
using PharmacyChain.Models;
using PharmacyChain.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyChain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController:ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly JWTSettings _jwtSettings;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IOptions<JWTSettings> jwtSettings,IMapper mapper)
        {
            _repository = repository;
            _jwtSettings = jwtSettings.Value;
            _mapper = mapper;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] User user)
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
        public async Task<IActionResult> Register (User user)
        {
            var newUser = await _repository.Create(user);
            return Ok(newUser);
        }


    }
}
