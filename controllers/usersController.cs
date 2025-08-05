using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_userService.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            return user == null ? NotFound(new { error = "User not found" }) : Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
                return BadRequest(new { error = "Invalid user data" });

            return Ok(_userService.Create(user));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            var updated = _userService.Update(id, user);
            return updated == null ? NotFound(new { error = "User not found" }) : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _userService.Delete(id);
            return success ? NoContent() : NotFound(new { error = "User not found" });
        }
    }
}
