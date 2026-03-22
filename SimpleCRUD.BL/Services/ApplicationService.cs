using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.DataContext;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.BL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly SimpleCrudDbContext _dbContext;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(SimpleCrudDbContext dbContext, ILogger<ApplicationService> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Applications in the Applications table
        /// </summary>
        /// <returns>List of Applications</returns>
        public async Task<List<Application>> GetAllApplications()
        {
            return await _dbContext.Applications.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an Application by its ApplicationID
        /// </summary>
        /// <param name="applicationID">ID of the Application</param>
        /// <returns>A single Application</returns>
        public async Task<Application?> GetApplicationByApplicationID(Guid applicationID)
        {
            return await _dbContext.Applications.AsNoTracking().FirstOrDefaultAsync(a => a.ApplicationId == applicationID);
        }

        /// <summary>
        /// Retrieves an Application by its ApplicationName
        /// </summary>
        /// <param name="applicationName">Name of the Application</param>
        /// <returns>A single Application</returns>
        public async Task<Application?> GetApplicationByApplicationName(string applicationName)
        {
            return await _dbContext.Applications.AsNoTracking().FirstOrDefaultAsync(a => a.ApplicationName == applicationName);
        }

        /// <summary>
        /// Inserts an Application into the Applications table
        /// </summary>
        /// <param name="application">Application to be inserted</param>
        /// <returns>The inserted Application</returns>
        public async Task<Application> InsertApplication(Application application)
        {
            try
            {
                application.ApplicationId = Guid.NewGuid();

                _dbContext.Applications.Add(application);

                await _dbContext.SaveChangesAsync();

                return application;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting Application | InsertApplication.");
                throw;
            }
        }
    }
}
