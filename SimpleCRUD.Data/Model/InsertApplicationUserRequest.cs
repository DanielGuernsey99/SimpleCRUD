using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Data.Model
{
    public class InsertApplicationUserRequest
    {
        public Guid UserID { get; set; }
        public Guid ApplicationID { get; set; }
    }
}
