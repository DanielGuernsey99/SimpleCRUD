using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleCRUD.BL.Services;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Model;
using System;

namespace SimpleCRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationRoleController : ControllerBase
    {
        private readonly ILogger<ApplicationRoleController> _logger;
        private readonly IApplicationRoleService _applicationRoleService;

        public ApplicationRoleController(ILogger<ApplicationRoleController> logger, IApplicationRoleService applicationRoleService)
        {
            _logger = logger;
            _applicationRoleService = applicationRoleService;
        }

        [HttpGet("GetAllApplicationRoles")]
        public async Task<ActionResult<List<ApplicationRole>>> GetAllApplicationRoles()
        {
            var applicationRoles = await _applicationRoleService.GetAllApplicationRoles();

            if (applicationRoles != null)
            {
                return Ok(applicationRoles);
            }
            else
            {
                return NotFound($"Application Roles not found.");
            }
        }

        [HttpGet("GetApplicationRoleByApplicationRoleID/{applicationRoleID}")]
        public async Task<ActionResult<ApplicationRole>> GetApplicationRoleByApplicationRoleID(Guid applicationRoleID)
        {
            var applicationRoles = await _applicationRoleService.GetApplicationRoleByApplicationRoleID(applicationRoleID);

            if (applicationRoles != null)
            {
                return Ok(applicationRoles);
            }
            else
            {
                return NotFound($"ApplicationRole with ApplicationRoleID {applicationRoleID} was not found.");
            }
        }

        [HttpGet("GetApplicationRoleByApplicationID/{applicationID}")]
        public async Task<ActionResult<List<ApplicationRole>>> GetApplicationRoleByApplicationID(Guid applicationID)
        {
            var applicationRoles = await _applicationRoleService.GetApplicationRolesByApplicationID(applicationID);

            if (applicationRoles != null)
            {
                return Ok(applicationRoles);
            }
            else
            {
                return NotFound($"ApplicationsRoles with ApplicationID {applicationID} was not found.");
            }
        }


        [HttpGet("GetApplicationRoleByRoleID/{RoleID}")]
        public async Task<ActionResult<List<ApplicationRole>>> GetApplicationRoleByRoleID(Guid roleID)
        {
            var applicationRoles = await _applicationRoleService.GetApplicationRolesByRoleID(roleID);

            if (applicationRoles != null)
            {
                return Ok(applicationRoles);
            }
            else
            {
                return NotFound($"ApplicationRoles with RoleID {roleID} was not found.");
            }
        }

        [HttpPost("InsertApplicationRole")]
        public async Task<ActionResult<ApplicationRole>> InsertApplicationRole([FromBody] InsertApplicationRoleRequest insertApplicationRoleRequest)
        {
            if (insertApplicationRoleRequest == null)
            {
                return BadRequest("Application Role is null");
            }

            if (insertApplicationRoleRequest.RoleId.ToString().IsNullOrEmpty())
            {
                return BadRequest("Application Role RoleID is null");
            }

            if (insertApplicationRoleRequest.ApplicationId.ToString().IsNullOrEmpty())
            {
                return BadRequest("Application Role ApplicationID is null");
            }

            var applicationRole = new ApplicationRole
            {
                ApplicationRoleId = new Guid(),
                ApplicationId = insertApplicationRoleRequest.ApplicationId,
                RoleId = insertApplicationRoleRequest.RoleId
            };

            var createdApplicationRole = await _applicationRoleService.InsertApplicationRole(applicationRole);

            return Ok(createdApplicationRole);
        }
    }
}
