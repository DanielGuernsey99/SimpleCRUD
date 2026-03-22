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
        Task<List<User>> GetAllUsers();

        Task<User?> GetUserByUserID(Guid UserID);

        Task<User> InsertUser(User user);
    }
}
