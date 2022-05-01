using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;
using ShoppingListAPI.Services.UserService;
using ShoppingListAPI.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, IRepository<User> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Password = request.Password,
                Roles = UserRole.User
            };

            _repository.Add(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var users = _repository.GetAll(u => u.Name == request.Name);
            if (!users.Any())
                return BadRequest("User not found.");

            var user = users.FirstOrDefault(u => u.Password == request.Password);
            if (user == null)
                return BadRequest("Wrong password.");

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Roles.GetDescription())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
