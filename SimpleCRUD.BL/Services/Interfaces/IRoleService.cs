using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Roles>> GetAllRoles();

        Task<Roles?> GetRoleByRoleID(Guid RoleID);

        Task<Roles?> GetRoleByRoleName(string RoleName);

        Task<Roles> InsertRole(Roles role);
    }
}
