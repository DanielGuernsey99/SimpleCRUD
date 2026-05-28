using Microsoft.EntityFrameworkCore;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.DataContext;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.BL.Services
{
    public class RoleService : IRoleService
    {
        private readonly SimpleCrudDbContext _dbContext;

        public RoleService(SimpleCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all Roles in the Roles table
        /// </summary>
        /// <returns>List of Roles</returns>
        public async Task<List<Roles>> GetAllRoles()
        {
            return await _dbContext.Roles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves a Role by its RoleID
        /// </summary>
        /// <param name="roleID">ID of the Role</param>
        /// <returns>A single Role</returns>
        public async Task<Roles?> GetRoleByRoleID(Guid roleID)
        {
            return await _dbContext.Roles.AsNoTracking().FirstOrDefaultAsync(ur => ur.RoleId == roleID);
        }

        /// <summary>
        /// Retrieves a Roles by its RoleName
        /// </summary>
        /// <param name="roleName">Name of the Role</param>
        /// <returns>A single Roles</returns>
        public async Task<Roles?> GetRoleByRoleName(string roleName)
        {
            return await _dbContext.Roles.AsNoTracking().FirstOrDefaultAsync(ur => ur.RoleName == roleName);
        }

        /// <summary>
        /// Inserts a Roles into the Role table
        /// </summary>
        /// <param name="role">Role to be inserted</param>
        /// <returns>The inserted Role</returns>
        public async Task<Roles> InsertRole(Roles role)
        {
            role.RoleId = Guid.NewGuid();

            _dbContext.Roles.Add(role);

            await _dbContext.SaveChangesAsync();

            return role;
        }
    }
}
