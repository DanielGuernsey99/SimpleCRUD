using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

[Table("ApplicationUser")]
public partial class ApplicationUser
{
    [Key]
    [Column("ApplicationUserID")]
    public Guid ApplicationUserId { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    [Column("ApplicationID")]
    public Guid ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;
    public virtual User User { get; set; } = null!;

    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        = new List<ApplicationUserRole>();
}
