using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Data.Model
{
    public class InsertApplicationRequest
    {
        public string? ApplicationName { get; set; }
        public string? ApplicationDescription { get; set; }
    }
}
