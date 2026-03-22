using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.BL.Services;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Model;

namespace SimpleCRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly ILogger<UserRoleController> _logger;
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(ILogger<UserRoleController> logger, IUserRoleService userRoleService)
        {
            _logger = logger;
            _userRoleService = userRoleService;
        }

        [HttpGet("GetAllUserRoles")]
        public async Task<ActionResult<List<UserRole>>> GetAllUserRoles()
        {
            var userRoles = await _userRoleService.GetAllUserRoles();

            if (userRoles != null)
            {
                return Ok(userRoles);
            }
            else
            {
                return NotFound($"UserRoles could not be found.");
            }
        }

        [HttpGet("GetUserRoleByRoleID/{userID}")]
        public async Task<ActionResult<UserRole>> GetUserRoleByRoleID(Guid userID)
        {
            var userRoles = await _userRoleService.GetUserRoleByRoleID(userID);

            if (userRoles != null)
            {
                return Ok(userRoles);
            }
            else
            {
                return NotFound($"UserRole with UserID {userID} could not be found.");
            }
        }

        [HttpGet("GetUserRoleByRoleName/{roleName}")]
        public async Task<ActionResult<UserRole>> GetUserRoleByRoleName(string roleName)
        {
            var userRoles = await _userRoleService.GetUserRoleByRoleName(roleName);

            if (userRoles != null)
            {
                return Ok(userRoles);
            }
            else
            {
                return NotFound($"UserRole with RoleName {roleName} could not be found.");
            }
        }

        [HttpPost("InsertRole")]
        public async Task<ActionResult<UserRole>> InsertRole([FromBody] InsertRoleRequest insertRoleRequest)
        {
            if (insertRoleRequest == null)
            {
                return BadRequest("Role is null");
            }

            if (string.IsNullOrWhiteSpace(insertRoleRequest.RoleName))
            {
                return BadRequest("RoleName cannot be null or empty.");
            }

            var role = new UserRole
            {
                RoleId = new Guid(),
                RoleName = insertRoleRequest.RoleName,
                Description = insertRoleRequest.Description
            };

            var createdRole = await _userRoleService.InsertUserRole(role);

            return Ok(createdRole);
        }
    }
}
