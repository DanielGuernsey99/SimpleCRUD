using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.BL.Services;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Model;

namespace SimpleCRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<Roles>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();

            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound($"Roles could not be found.");
            }
        }

        [HttpGet("GetRoleByRoleID/{userID}")]
        public async Task<ActionResult<Roles>> GetRoleByRoleID(Guid userID)
        {
            var roles = await _roleService.GetRoleByRoleID(userID);

            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound($"Role with UserID {userID} could not be found.");
            }
        }

        [HttpGet("GetRoleByRoleName/{roleName}")]
        public async Task<ActionResult<Roles>> GetRoleByRoleName(string roleName)
        {
            var roles = await _roleService.GetRoleByRoleName(roleName);

            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound($"Role with RoleName {roleName} could not be found.");
            }
        }

        [HttpPost("InsertRole")]
        public async Task<ActionResult<Roles>> InsertRole([FromBody] InsertRoleRequest insertRoleRequest)
        {
            if (insertRoleRequest == null)
            {
                return BadRequest("Role is null");
            }

            if (string.IsNullOrWhiteSpace(insertRoleRequest.RoleName))
            {
                return BadRequest("RoleName cannot be null or empty.");
            }

            var role = new Roles
            {
                RoleId = new Guid(),
                RoleName = insertRoleRequest.RoleName,
                Description = insertRoleRequest.Description
            };

            var createdRole = await _roleService.InsertRole(role);

            return Ok(createdRole);
        }
    }
}
