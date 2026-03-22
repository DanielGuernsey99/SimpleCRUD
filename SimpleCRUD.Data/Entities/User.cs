using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Data.Entities;

public partial class User
{
    [Key]
    [Column("UserID")]
    public Guid UserId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        = new List<ApplicationUser>();
}
