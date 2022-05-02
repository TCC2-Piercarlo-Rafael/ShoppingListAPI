using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(_userService.Get());
        }

        [HttpPut]
        public ActionResult<List<User>> Update(User request)
        {
            var user = _userService.GetById(request.Id);

            if (user == null)
                return BadRequest("User not found");

            user.Name = request.Name;
            user.Password = request.Password;
            user.Roles = request.Roles;

            _userService.Update(user);

            return Ok(_userService.Get());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Category>> Delete(Guid id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return BadRequest("User not found");

            _userService.Delete(user);

            return Ok(_userService.Get());
        }
    }
}
