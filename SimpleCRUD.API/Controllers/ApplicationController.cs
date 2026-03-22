using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.BL.Services;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Model;

namespace SimpleCRUD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationService _applicationService;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        [HttpGet("GetAllApplications")]
        public async Task<ActionResult<List<Application>>> GetAllApplications()
        {
            var applications = await _applicationService.GetAllApplications();

            if (applications != null)
            {
                return Ok(applications);
            }
            else
            {
                return BadRequest("Applications is null.");
            }
        }

        [HttpGet("GetApplicationByApplicationName/{applicationName}")]
        public async Task<ActionResult<List<Application>>> GetApplicationByApplicationName(string applicationName)
        {
            var applications = await _applicationService.GetApplicationByApplicationName(applicationName);

            if (applications != null)
            {
                return Ok(applications);
            }
            else
            {
                return NotFound($"Application with '{applicationName}' was not found.");
            }
        }

        [HttpGet("GetApplicationByApplicationID/{applicationID}")]
        public async Task<ActionResult<List<Application>>> GetApplicationByApplicationID(Guid applicationID)
        {
            var applications = await _applicationService.GetApplicationByApplicationID(applicationID);

            if (applications != null)
            {
                return Ok(applications);
            }
            else
            {
                return NotFound($"Application with {applicationID} was not found.");
            }
        }

        [HttpPost("InsertApplication")]
        public async Task<ActionResult<Application>> InsertApplication([FromBody] InsertApplicationRequest insertApplicationRequest)
        {
            if (insertApplicationRequest == null)
            {
                return BadRequest("Application is null");
            }

            if (string.IsNullOrWhiteSpace(insertApplicationRequest.ApplicationName))
            {
                return BadRequest("ApplicationName cannot be null or empty.");
            }

            var application = new Application
            {
                ApplicationId = new Guid(),
                ApplicationName = insertApplicationRequest.ApplicationName,
                ApplicationDescription = insertApplicationRequest.ApplicationDescription
            };

            var createdApplication = await _applicationService.InsertApplication(application);

            return Ok(createdApplication);
        }
    }
}
