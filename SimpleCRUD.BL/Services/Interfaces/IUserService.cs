using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();

        Task<Users?> GetUserByUserID(Guid UserID);

        Task<Users> InsertUser(Users user);
    }
}
