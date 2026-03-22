using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Data.Model
{
    public class InsertApplicationUserRoleRequest
    {
        public Guid ApplicationID { get; set; }
        public Guid ApplicationUserID { get; set; }
        public Guid ApplicationRoleID { get; set; }
    }
}
