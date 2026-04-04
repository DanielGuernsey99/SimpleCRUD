using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IApplicationRoleService
    {
        Task<List<ApplicationRoles>> GetAllApplicationRoles();

        Task<ApplicationRoles?> GetApplicationRoleByApplicationRoleID(Guid ApplicationRoleID);

        Task<List<ApplicationRoles>> GetApplicationRolesByRoleID(Guid RoleID);

        Task<List<ApplicationRoles>> GetApplicationRolesByApplicationID(Guid ApplicationID);

        Task<ApplicationRoles> InsertApplicationRole(ApplicationRoles applicationRole);
    }
}
