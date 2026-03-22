using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.DataContext;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.BL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly SimpleCrudDbContext _dbContext;
        private readonly ILogger<ApplicationUserService> _logger;

        public ApplicationUserService(SimpleCrudDbContext dbContext, ILogger<ApplicationUserService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all ApplicationUsers in the ApplicationUsers table
        /// </summary>
        /// <returns>List of ApplicationUsers</returns>
        public async Task<List<ApplicationUser>> GetAllApplicationUsers()
        {
            return await _dbContext.ApplicationUsers.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an ApplicationUser by its ApplicationUserID
        /// </summary>
        /// <param name="applicationUserID">ID of the ApplicationUser</param>
        /// <returns>A single ApplicationUser</returns>
        public async Task<ApplicationUser?> GetApplicationUserByApplicationUserID(Guid applicationUserID)
        {
            return await _dbContext.ApplicationUsers.AsNoTracking().FirstOrDefaultAsync(au => au.ApplicationUserId == applicationUserID);
        }

        /// <summary>
        /// Retrieves ApplicationUsers by the UserID
        /// </summary>
        /// <param name="userID">ID of the User</param>
        /// <returns>List of ApplicationUsers</returns>
        public async Task<List<ApplicationUser>> GetApplicationUsersByUserID(Guid userID)
        {
            return await _dbContext.ApplicationUsers.AsNoTracking().Where(au => au.UserId == userID).ToListAsync();
        }


        /// <summary>
        /// Inserts an ApplicationUser into the ApplicationUsers table
        /// </summary>
        /// <param name="applicationUser">ApplicationUser to be inserted</param>
        /// <returns>The inserted ApplicationUser</returns>
        public async Task<ApplicationUser> InsertApplicationUser(ApplicationUser applicationUser)
        {
            try
            {
                applicationUser.ApplicationUserId = Guid.NewGuid();

                _dbContext.ApplicationUsers.Add(applicationUser);

                await _dbContext.SaveChangesAsync();

                return applicationUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting ApplicationUser | InsertApplicationUser.");
                throw;
            }
        }
    }
}
