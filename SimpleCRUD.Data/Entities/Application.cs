using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

public partial class Application
{
    [Key]
    [Column("ApplicationID")]
    public Guid ApplicationId { get; set; }

    public string ApplicationName { get; set; } = null!;
    public string ApplicationDescription { get; set; } = null!;

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        = new List<ApplicationUser>();

    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        = new List<ApplicationUserRole>();
}
