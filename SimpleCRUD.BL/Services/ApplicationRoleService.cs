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
    public class ApplicationRoleService : IApplicationRoleService
    {
        private readonly SimpleCrudDbContext _dbContext;

        public ApplicationRoleService(SimpleCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all ApplicationRoles in the Application Roles table
        /// </summary>
        /// <returns>List of ApplicationRoles</returns>
        public async Task<List<ApplicationRoles>> GetAllApplicationRoles()
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves the ApplicationRole by the ApplicationRoleID
        /// </summary>
        /// <param name="ApplicationRoleID">Id of the ApplicationRole</param>
        /// <returns>A single Application Role</returns>
        public async Task<ApplicationRoles?> GetApplicationRoleByApplicationRoleID(Guid ApplicationRoleID)
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().FirstOrDefaultAsync(ar => ar.ApplicationRoleId == ApplicationRoleID);
        }

        /// <summary>
        /// Retrieves all ApplicationRoles by RoleID
        /// </summary>
        /// <param name="RoleID">Id of the Role</param>
        /// <returns>List of ApplicationRoles</returns>
        public async Task<List<ApplicationRoles>> GetApplicationRolesByRoleID(Guid RoleID)
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().Where(ar => ar.RoleId == RoleID).ToListAsync();
        }

        /// <summary>
        /// Retrieves ApplicationRoles by the ApplicationID
        /// </summary>
        /// <param name="ApplicationID">ID of the Application</param>
        /// <returns>List of ApplicationRoles</returns>
        public async Task<List<ApplicationRoles>> GetApplicationRolesByApplicationID(Guid ApplicationID)
        {
            return await _dbContext.ApplicationRoles.AsNoTracking().Where(ar => ar.ApplicationId == ApplicationID).ToListAsync();
        }

        /// <summary>
        /// Adds an ApplicationRole to the ApplicationRole table
        /// </summary>
        /// <param name="applicationRole">ApplicationRole to be inserted</param>
        /// <returns>The ApplicationRole inserted</returns>
        public async Task<ApplicationRoles> InsertApplicationRole(ApplicationRoles applicationRole)
        {
            applicationRole.ApplicationRoleId = Guid.NewGuid();

            _dbContext.ApplicationRoles.Add(applicationRole);

            await _dbContext.SaveChangesAsync();

            return applicationRole;
        }
    }
}
