using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

public partial class ApplicationUserRole
{
    [Key]
    [Column("ApplicationUserRolesID")]
    public Guid ApplicationUserRolesId { get; set; }

    [Column("ApplicationUserID")]
    public Guid ApplicationUserId { get; set; }

    [Column("ApplicationRoleID")]
    public Guid ApplicationRoleId { get; set; }

    [ForeignKey("ApplicationRoleId")]
    [InverseProperty("ApplicationUserRoles")]
    public virtual ApplicationRoles ApplicationRole { get; set; } = null!;

    [ForeignKey("ApplicationUserId")]
    [InverseProperty("ApplicationUserRoles")]
    public virtual ApplicationUsers ApplicationUser { get; set; } = null!;
}
