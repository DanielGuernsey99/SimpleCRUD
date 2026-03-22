using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<List<UserRole>> GetAllUserRoles();

        Task<UserRole?> GetUserRoleByRoleID(Guid RoleID);

        Task<UserRole?> GetUserRoleByRoleName(string RoleName);

        Task<UserRole> InsertUserRole(UserRole role);
    }
}
