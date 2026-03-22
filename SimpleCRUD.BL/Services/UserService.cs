using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.DataContext;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.BL.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly SimpleCrudDbContext _dbContext;
        public UserService(SimpleCrudDbContext dbContext, ILogger<UserService> logger) 
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all users in the Users table
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves a user by their UserID
        /// </summary>
        /// <param name="UserID">UserID of the user</param>
        /// <returns>A single user</returns>
        public async Task<User?> GetUserByUserID(Guid UserID)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == UserID);
        }

        /// <summary>
        /// Inserts a user into the user table
        /// </summary>
        /// <param name="user">User to be inserted</param>
        /// <returns>The inserted user</returns>
        public async Task<User> InsertUser(User user)
        {
            try
            {
                user.UserId = Guid.NewGuid();

                _dbContext.Users.Add(user);

                await _dbContext.SaveChangesAsync();

                return user;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error inserting user | InsertUser.");
                throw;
            }
        }
    }
}
