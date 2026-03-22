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
        Task<List<ApplicationRole>> GetAllApplicationRoles();

        Task<ApplicationRole?> GetApplicationRoleByApplicationRoleID(Guid ApplicationRoleID);

        Task<List<ApplicationRole>> GetApplicationRolesByRoleID(Guid RoleID);

        Task<List<ApplicationRole>> GetApplicationRolesByApplicationID(Guid ApplicationID);

        Task<ApplicationRole> InsertApplicationRole(ApplicationRole applicationRole);
    }
}
