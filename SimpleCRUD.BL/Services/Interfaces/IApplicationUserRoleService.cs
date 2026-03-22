using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IApplicationUserRoleService
    {
        Task<List<ApplicationUserRole>> GetAllApplicationUserRoles();

        Task<ApplicationUserRole?> GetApplicationUserRoleByApplicationUserRoleID(Guid ApplicationUserRoleID);

        Task<List<ApplicationUserRole>> GetApplicationUserRolesByApplicationID(Guid ApplicationID);

        Task<List<ApplicationUserRole>> GetApplicationUserRolesByApplicationUserID(Guid ApplicationUserID);

        Task<List<ApplicationUserRole>> GetApplicationUserRolesByApplicationRoleID(Guid ApplicationRoleID);

        Task<ApplicationUserRole> InsertApplicationUserRole(ApplicationUserRole applicationUserRole);

        
    }
}
