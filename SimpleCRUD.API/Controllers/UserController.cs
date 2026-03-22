using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.BL.Services;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Model;

namespace SimpleCRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound("Users could not be found.");
            }
        }

        [HttpGet("GetUserByUserID/{userID}")]
        public async Task<ActionResult<User>> GetUserByUserID(Guid userID)
        {
            var users = await _userService.GetUserByUserID(userID);

            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound($"User with UserID {userID} could not be found.");
            }
        }

        [HttpPost("InsertUser")]
        public async Task<ActionResult<User>> InsertUser([FromBody] InsertUserRequest insertUserRequest)
        {
            if (insertUserRequest == null)
            {
                return BadRequest("User is null");
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = insertUserRequest.FirstName,
                LastName = insertUserRequest.LastName
            };

            var createdUser = await _userService.InsertUser(user);

            return Ok(createdUser);
        }
    }
}
