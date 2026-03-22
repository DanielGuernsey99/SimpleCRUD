using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUser>> GetAllApplicationUsers();

        Task<ApplicationUser?> GetApplicationUserByApplicationUserID(Guid ApplicationUserID);

        Task<List<ApplicationUser>> GetApplicationUsersByUserID(Guid UserID);

        Task<ApplicationUser> InsertApplicationUser(ApplicationUser applicationUser);
    }
}
