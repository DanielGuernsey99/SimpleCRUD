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

    [Column("ApplicationID")]
    public Guid ApplicationId { get; set; }

    [Column("ApplicationUserID")]
    public Guid ApplicationUserId { get; set; }

    [Column("ApplicationRoleID")]
    public Guid ApplicationRoleId { get; set; }

    [ForeignKey("ApplicationId")]
    [InverseProperty("ApplicationUserRoles")]
    public virtual Application Application { get; set; } = null!;

    [ForeignKey("ApplicationRoleId")]
    [InverseProperty("ApplicationUserRoles")]
    public virtual ApplicationRole ApplicationRole { get; set; } = null!;

    [ForeignKey("ApplicationUserId")]
    [InverseProperty("ApplicationUserRoles")]
    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
