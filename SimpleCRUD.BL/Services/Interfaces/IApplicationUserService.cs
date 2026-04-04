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
        Task<List<ApplicationUsers>> GetAllApplicationUsers();

        Task<ApplicationUsers?> GetApplicationUserByApplicationUserID(Guid ApplicationUserID);

        Task<List<ApplicationUsers>> GetApplicationUsersByUserID(Guid UserID);

        Task<ApplicationUsers> InsertApplicationUser(ApplicationUsers applicationUser);
    }
}
