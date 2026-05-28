using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.DataContext;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.BL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly SimpleCrudDbContext _dbContext;

        public ApplicationService(SimpleCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all Applications in the Applications table
        /// </summary>
        /// <returns>List of Applications</returns>
        public async Task<List<Applications>> GetAllApplications()
        {
            return await _dbContext.Applications.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an Application by its ApplicationID
        /// </summary>
        /// <param name="applicationID">ID of the Application</param>
        /// <returns>A single Application</returns>
        public async Task<Applications?> GetApplicationByApplicationID(Guid applicationID)
        {
            return await _dbContext.Applications.AsNoTracking().FirstOrDefaultAsync(a => a.ApplicationId == applicationID);
        }

        /// <summary>
        /// Retrieves an Application by its ApplicationName
        /// </summary>
        /// <param name="applicationName">Name of the Application</param>
        /// <returns>A single Application</returns>
        public async Task<Applications?> GetApplicationByApplicationName(string applicationName)
        {
            return await _dbContext.Applications.AsNoTracking().FirstOrDefaultAsync(a => a.ApplicationName == applicationName);
        }

        /// <summary>
        /// Inserts an Application into the Applications table
        /// </summary>
        /// <param name="application">Application to be inserted</param>
        /// <returns>The inserted Application</returns>
        public async Task<Applications> InsertApplication(Applications application)
        {
            application.ApplicationId = Guid.NewGuid();

            _dbContext.Applications.Add(application);

            await _dbContext.SaveChangesAsync();

            return application;
        }
    }
}
