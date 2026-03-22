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
    public class ApplicationUserRoleService : IApplicationUserRoleService
    {
        private readonly SimpleCrudDbContext _dbContext;
        private readonly ILogger<ApplicationUserRoleService> _logger;

        public ApplicationUserRoleService(SimpleCrudDbContext dbContext, ILogger<ApplicationUserRoleService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all ApplicationUserRoles in the ApplicationUserRoles table
        /// </summary>
        /// <returns>List of ApplicationUserRoles</returns>
        public async Task<List<ApplicationUserRole>> GetAllApplicationUserRoles()
        {
            return await _dbContext.ApplicationUserRoles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an ApplicationUserRole by its ApplicationUserRoleID
        /// </summary>
        /// <param name="applicationUserRoleID">ID of the ApplicationUserRole</param>
        /// <returns>A single ApplicationUserRole</returns>
        public async Task<ApplicationUserRole?> GetApplicationUserRoleByApplicationUserRoleID(Guid applicationUserRoleID)
        {
            return await _dbContext.ApplicationUserRoles.AsNoTracking().FirstOrDefaultAsync(aur => aur.ApplicationUserRolesId == applicationUserRoleID);
        }

        /// <summary>
        /// Retrieves ApplicationUserRoles by ApplicationID
        /// </summary>
        /// <param name="applicationID">ID of the Application</param>
        /// <returns>List of ApplicationUserRoles</returns>
        public async Task<List<ApplicationUserRole>> GetApplicationUserRolesByApplicationID(Guid applicationID)
        {
            return await _dbContext.ApplicationUserRoles.AsNoTracking().Where(aur => aur.ApplicationId == applicationID).ToListAsync();
        }

        /// <summary>
        /// Retrieves ApplicationUserRoles by ApplicationUserID
        /// </summary>
        /// <param name="applicationUserID">ID of the ApplicationUser</param>
        /// <returns>List of ApplicationUserRoles</returns>
        public async Task<List<ApplicationUserRole>> GetApplicationUserRolesByApplicationUserID(Guid applicationUserID)
        {
            return await _dbContext.ApplicationUserRoles.AsNoTracking().Where(aur => aur.ApplicationUserId == applicationUserID).ToListAsync();
        }

        /// <summary>
        /// Retrieves ApplicationUserRoles by ApplicationRoleID
        /// </summary>
        /// <param name="applicationRoleID">ID of the ApplicationRole</param>
        /// <returns>List of ApplicationUserRoles</returns>
        public async Task<List<ApplicationUserRole>> GetApplicationUserRolesByApplicationRoleID(Guid applicationRoleID)
        {
            return await _dbContext.ApplicationUserRoles.AsNoTracking().Where(aur => aur.ApplicationRoleId == applicationRoleID).ToListAsync();
        }

        /// <summary>
        /// Inserts an ApplicationUserRole into the ApplicationUserRoles table
        /// </summary>
        /// <param name="applicationUserRole">ApplicationUserRole to be inserted</param>
        /// <returns>The inserted ApplicationUserRole</returns>
        public async Task<ApplicationUserRole> InsertApplicationUserRole(ApplicationUserRole applicationUserRole)
        {
            try
            {
                applicationUserRole.ApplicationUserRolesId = Guid.NewGuid();

                _dbContext.ApplicationUserRoles.Add(applicationUserRole);

                await _dbContext.SaveChangesAsync();

                return applicationUserRole;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inserting ApplicationUserRole | InsertApplicationUserRole");
                throw;
            }
        }
    }
}
