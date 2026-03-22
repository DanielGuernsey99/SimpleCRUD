using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleCRUD.BL.Services;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Model;

namespace SimpleCRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ILogger<ApplicationUserController> _logger;
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(ILogger<ApplicationUserController> logger, IApplicationUserService applicationUserService)
        {
            _logger = logger;
            _applicationUserService = applicationUserService;
        }

        [HttpGet("GetAllApplicationUsers")]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllApplicationUsers()
        {
            var applicationUsers = await _applicationUserService.GetAllApplicationUsers();

            if (applicationUsers != null)
            {
                return Ok(applicationUsers);
            }
            else
            {
                return NotFound("ApplicationUsers were not found.");
            }
        }

        [HttpGet("GetApplicationUserByApplicationUserID/{applicationUserID}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUserByApplicationUserID(Guid applicationUserID)
        {
            var applicationUsers = await _applicationUserService.GetApplicationUserByApplicationUserID(applicationUserID);

            if (applicationUsers != null)
            {
                return Ok(applicationUsers);
            }
            else
            {
                return NotFound($"ApplicationUser with ApplicationUserID {applicationUserID} was not found.");
            }
        }

        [HttpGet("GetApplicationUserByUserID/{userID}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUserByUserID(Guid userID)
        {
            var applicationUsers = await _applicationUserService.GetApplicationUsersByUserID(userID);

            if (applicationUsers != null)
            {
                return Ok(applicationUsers);
            }
            else
            {
                return NotFound($"ApplicationUsers with UserID {userID} was not found.");
            }
        }

        [HttpPost("InsertApplicationUser")]
        public async Task<ActionResult<ApplicationUser>> InsertApplicationUser([FromBody] InsertApplicationUserRequest insertApplicationUserRequest)
        {
            if (insertApplicationUserRequest == null)
            {
                return BadRequest("Application User is null");
            }

            if (insertApplicationUserRequest.UserID.ToString().IsNullOrEmpty())
            {
                return BadRequest("Application User UserID is null");
            }

            if (insertApplicationUserRequest.ApplicationID.ToString().IsNullOrEmpty())
            {
                return BadRequest("Application User is null");
            }

            var applicationUser = new ApplicationUser
            {
                ApplicationUserId = new Guid(),
                ApplicationId = insertApplicationUserRequest.ApplicationID,
                UserId = insertApplicationUserRequest.UserID
            };

            var createdApplication = await _applicationUserService.InsertApplicationUser(applicationUser);

            return Ok(createdApplication);
        }
    }
}
