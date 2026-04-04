using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

[Table("ApplicationUser")]
public partial class ApplicationUsers
{
    [Key]
    [Column("ApplicationUserID")]
    public Guid ApplicationUserId { get; set; }

    [Column("ApplicationID")]
    public Guid ApplicationId { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    public virtual Applications Application { get; set; } = null!;
    public virtual Users User { get; set; } = null!;

    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        = new List<ApplicationUserRole>();
}
