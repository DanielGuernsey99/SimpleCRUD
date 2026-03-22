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
    public class ApplicationUserRoleController : ControllerBase
    {
        private readonly ILogger<ApplicationUserRoleController> _logger;
        private readonly IApplicationUserRoleService _applicationUserRoleService;

        public ApplicationUserRoleController(ILogger<ApplicationUserRoleController> logger, IApplicationUserRoleService applicationUserRoleService)
        {
            _logger = logger;
            _applicationUserRoleService = applicationUserRoleService;
        }

        [HttpGet("GetAllApplicationUserRoles")]
        public async Task<ActionResult<List<ApplicationUserRole>>> GetAllApplicationUserRoles()
        {
            var applicationUserRoles = await _applicationUserRoleService.GetAllApplicationUserRoles();

            if (applicationUserRoles != null)
            {
                return Ok(applicationUserRoles);
            }
            else
            {
                return NotFound("ApplicationUserRoles were not found.");
            }
        }

        [HttpGet("GetApplicationUserRoleByApplicationRoleID/{applicationRoleID}")]
        public async Task<ActionResult<List<ApplicationUserRole>>> GetApplicationUserRoleByApplicationRoleID(Guid applicationRoleID)
        {
            var applicationUserRoles = await _applicationUserRoleService.GetApplicationUserRolesByApplicationRoleID(applicationRoleID);

            if (applicationUserRoles != null)
            {
                return Ok(applicationUserRoles);
            }
            else
            {
                return NotFound($"ApplicationUserRoles with ApplicationRoleID {applicationRoleID} was not found.");
            }
        }

        [HttpGet("GetApplicationUserRoleByApplicationUserID/{applicationUserID}")]
        public async Task<ActionResult<List<ApplicationUserRole>>> GetApplicationUserRoleByApplicationUserID(Guid applicationUserID)
        {
            var applicationUserRoles = await _applicationUserRoleService.GetApplicationUserRolesByApplicationUserID(applicationUserID);

            if (applicationUserRoles != null)
            {
                return Ok(applicationUserRoles);
            }
            else
            {
                return NotFound($"ApplicationUserRoles with ApplicationUserID {applicationUserID} was not found.");
            }
        }

        [HttpGet("GetApplicationUserRoleByApplicationUserRoleID/{applicationUserRoleID}")]
        public async Task<ActionResult<List<ApplicationUserRole>>> GetApplicationUserRoleByApplicationUserRoleID(Guid applicationUserRoleID)
        {
            var applicationUserRoles = await _applicationUserRoleService.GetApplicationUserRoleByApplicationUserRoleID(applicationUserRoleID);

            if (applicationUserRoles != null)
            {
                return Ok(applicationUserRoles);
            }
            else
            {
                return BadRequest($"ApplicationUserRoles with ApplicationUserRoleID {applicationUserRoleID} was not found.");
            }
        }

        [HttpGet("GetApplicationUserRoleByApplicationID/{applicationID}")]
        public async Task<ActionResult<List<ApplicationUserRole>>> GetApplicationUserRoleByApplicationID(Guid applicationID)
        {
            var applicationUserRoles = await _applicationUserRoleService.GetApplicationUserRolesByApplicationID(applicationID);

            if (applicationUserRoles != null)
            {
                return Ok(applicationUserRoles);
            }
            else
            {
                return NotFound($"ApplicationUserRoles with ApplicationID {applicationID} was not found.");
            }
        }

        [HttpPost("InsertApplicationUserRole")]
        public async Task<ActionResult<ApplicationUserRole>> InsertApplicationUserRole([FromBody] InsertApplicationUserRoleRequest insertApplicationUserRoleRequest)
        {
            if (insertApplicationUserRoleRequest == null)
            {
                return BadRequest("ApplicationUserRole is null");
            }

            if (insertApplicationUserRoleRequest.ApplicationRoleID.ToString().IsNullOrEmpty())
            {
                return BadRequest("ApplicationUserRole ApplicationRoleID is null");
            }

            if (insertApplicationUserRoleRequest.ApplicationUserID.ToString().IsNullOrEmpty())
            {
                return BadRequest("ApplicationUserRole ApplicationUserID is null");
            }

            var applicationUserRole = new ApplicationUserRole
            {
                ApplicationUserRolesId = new Guid(),
                ApplicationId = insertApplicationUserRoleRequest.ApplicationID,
                ApplicationRoleId = insertApplicationUserRoleRequest.ApplicationRoleID,
                ApplicationUserId = insertApplicationUserRoleRequest.ApplicationUserID
            };

            var createdApplicationUserRole = await _applicationUserRoleService.InsertApplicationUserRole(applicationUserRole);

            return Ok(createdApplicationUserRole);
        }
    }
}
