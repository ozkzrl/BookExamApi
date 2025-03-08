using Microsoft.AspNetCore.Mvc;
using BookExam.Application.Interfaces;
using BookExam.Application.DTOs.User;

namespace BookExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            var result = await _userService.RegisterUserAsync(registerUserDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            var token = await _userService.LoginUserAsync(loginUserDto);
            if (token == null)
                return Unauthorized();
            return Ok(new { token });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
