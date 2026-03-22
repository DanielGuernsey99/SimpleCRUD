using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.DataContext;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.BL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly SimpleCrudDbContext _dbContext;
        private readonly ILogger<UserRoleService> _logger;

        public UserRoleService(SimpleCrudDbContext dbContext, ILogger<UserRoleService> logger) 
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all UserRoles in the UserRoles table
        /// </summary>
        /// <returns>List of UserRoles</returns>
        public async Task<List<UserRole>> GetAllUserRoles()
        {
            return await _dbContext.UserRoles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves a UserRole by its RoleID
        /// </summary>
        /// <param name="roleID">ID of the Role</param>
        /// <returns>A single UserRole</returns>
        public async Task<UserRole?> GetUserRoleByRoleID(Guid roleID)
        {
            return await _dbContext.UserRoles.AsNoTracking().FirstOrDefaultAsync(ur => ur.RoleId == roleID);
        }

        /// <summary>
        /// Retrieves a UserRole by its RoleName
        /// </summary>
        /// <param name="roleName">Name of the Role</param>
        /// <returns>A single UserRole</returns>
        public async Task<UserRole?> GetUserRoleByRoleName(string roleName)
        {
            return await _dbContext.UserRoles.AsNoTracking().FirstOrDefaultAsync(ur => ur.RoleName == roleName);
        }

        /// <summary>
        /// Inserts a UserRole into the UserRoles table
        /// </summary>
        /// <param name="userRole">UserRole to be inserted</param>
        /// <returns>The inserted UserRole</returns>
        public async Task<UserRole> InsertUserRole(UserRole userRole)
        {
            try
            {
                userRole.RoleId = Guid.NewGuid();

                _dbContext.UserRoles.Add(userRole);

                await _dbContext.SaveChangesAsync();

                return userRole;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting UserRole | InsertRole.");
                throw;
            }
        }
    }
}
