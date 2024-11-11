using Azure;
using Microsoft.AspNetCore.Mvc;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Application.Interfaces;

namespace WifiSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        // GET: api/user/{id}
        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _userRepository.GetUserByIdAsync(id);
            return Ok(response);
        }

        // GET: api/user
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            var response = await _userRepository.AddUserAsync(userDto);
            return Ok();
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            var result = await _userRepository.LoginUser(login);
            return Ok();
        }

        // Put api/user/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UserDto userDto) 
        {
            var response = await _userRepository.UpdateUserAsync(userDto);
            return Ok();
        }

        //Delete api/user/delete
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(UserDto userDto) 
        {
            var response = await _userRepository.DeleteUserAsync(userDto);
            return Ok();
        }

    }
}
