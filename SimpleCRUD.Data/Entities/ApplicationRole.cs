using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

public partial class ApplicationRole
{
    [Key]
    [Column("ApplicationRoleID")]
    public Guid ApplicationRoleId { get; set; }

    [Column("RoleId")]
    public Guid RoleId { get; set; }

    [Column("ApplicationId")]
    public Guid ApplicationId { get; set; }

    [InverseProperty("ApplicationRole")]
    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = new List<ApplicationUserRole>();
}
