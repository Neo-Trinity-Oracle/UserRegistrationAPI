using Microsoft.AspNetCore.Mvc;
using UserRegistrationApi.Models;
using UserRegistrationApi.Services;

namespace UserRegistrationApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var user = await _userService.Register(request);
            if (user == null)
                return Unauthorized("Failed to Register");

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.Login(request);
            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(user);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateRequest request)
        {
            var user = await _userService.Update(request);
            if (user == null)
                return Unauthorized("Failed to update User");

            return Ok(user);
        }
    }
}
