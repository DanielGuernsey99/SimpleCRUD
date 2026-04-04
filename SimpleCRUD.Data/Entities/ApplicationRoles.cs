using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD.Data.Entities;

public partial class ApplicationRoles
{
    [Key]
    [Column("ApplicationRoleID")]
    public Guid ApplicationRoleId { get; set; }

    [Column("ApplicationId")]
    public Guid ApplicationId { get; set; }

    [Column("RoleId")]
    public Guid RoleId { get; set; }

    [InverseProperty("ApplicationRole")]
    public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = new List<ApplicationUserRole>();
}
