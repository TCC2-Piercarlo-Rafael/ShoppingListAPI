using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;
using ShoppingListAPI.Utils;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration, IRepository<User> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> Update(User request)
        {
            var user = await _repository.GetById(request.Id);

            if (user == null)
                return BadRequest("User not found");

            user.Name = request.Name;
            user.Password = request.Password;
            user.Roles = request.Roles;

            _repository.Update(user);

            return Ok(_repository.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> Delete(Guid id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
                return BadRequest("User not found");

            _repository.Delete(user);

            return Ok(_repository.GetAll());
        }
    }
}
