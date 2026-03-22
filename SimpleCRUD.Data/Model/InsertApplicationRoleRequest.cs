using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Data.Model
{
    public class InsertApplicationRoleRequest
    {
        public Guid RoleId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
