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
    public class ApplicationRoleService : IApplicationRoleService
    {
        private readonly SimpleCrudDbContext _dbContext;
        private readonly ILogger<ApplicationRoleService> _logger;

        public ApplicationRoleService(SimpleCrudDbContext dbContext, ILogger<ApplicationRoleService> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all ApplicationRoles in the Application Roles table
        /// </summary>
        /// <returns>List of ApplicationRoles</returns>
        public async Task<List<ApplicationRole>> GetAllApplicationRoles()
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves the ApplicationRole by the ApplicationRoleID
        /// </summary>
        /// <param name="ApplicationRoleID">Id of the ApplicationRole</param>
        /// <returns>A single Application Role</returns>
        public async Task<ApplicationRole?> GetApplicationRoleByApplicationRoleID(Guid ApplicationRoleID)
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().FirstOrDefaultAsync(ar => ar.ApplicationRoleId == ApplicationRoleID);
        }

        /// <summary>
        /// Retrieves all ApplicationRoles by RoleID
        /// </summary>
        /// <param name="RoleID">Id of the Role</param>
        /// <returns>List of ApplicationRoles</returns>
        public async Task<List<ApplicationRole>> GetApplicationRolesByRoleID(Guid RoleID)
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().Where(ar => ar.RoleId == RoleID).ToListAsync();
        }

        /// <summary>
        /// Retrieves ApplicationRoles by the ApplicationID
        /// </summary>
        /// <param name="ApplicationID">ID of the Application</param>
        /// <returns>List of ApplicationRoles</returns>
        public async Task<List<ApplicationRole>> GetApplicationRolesByApplicationID(Guid ApplicationID)
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().Where(ar => ar.ApplicationId == ApplicationID).ToListAsync();
        }

        /// <summary>
        /// Adds an ApplicationRole to the ApplicationRole table
        /// </summary>
        /// <param name="applicationRole">ApplicationRole to be inserted</param>
        /// <returns>The ApplicationRole inserted</returns>
        public async Task<ApplicationRole> InsertApplicationRole(ApplicationRole applicationRole)
        {
            try
            {
                applicationRole.ApplicationRoleId = Guid.NewGuid();

                _dbContext.ApplicationRoles.Add(applicationRole);

                await _dbContext.SaveChangesAsync();

                return applicationRole;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting Application | InsertApplication.");
                throw;
            }
        }
    }
}
