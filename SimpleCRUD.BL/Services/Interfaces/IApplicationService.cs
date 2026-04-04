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
        Task<List<Applications>> GetAllApplications();

        Task<Applications?> GetApplicationByApplicationID(Guid ApplicationID);

        Task<Applications?> GetApplicationByApplicationName(string ApplicationName);

        Task<Applications> InsertApplication(Applications application);

    }
}
