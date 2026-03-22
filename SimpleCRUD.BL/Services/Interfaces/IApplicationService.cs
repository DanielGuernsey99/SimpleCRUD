using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.BL.Services.Interfaces
{
    public interface IApplicationService
    {
        Task <List<Application>> GetAllApplications();

        Task<Application?> GetApplicationByApplicationID(Guid ApplicationID);

        Task<Application?> GetApplicationByApplicationName(string ApplicationName);

        Task<Application> InsertApplication(Application application);

    }
}
