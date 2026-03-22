using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

public partial class UserRole
{
    [StringLength(250)]
    [Unicode(false)]
    public string? RoleName { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Key]
    [Column("RoleID")]
    public Guid RoleId { get; set; }
}
