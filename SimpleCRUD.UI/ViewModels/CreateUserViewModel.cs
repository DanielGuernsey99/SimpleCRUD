using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD.UI.Models.User
{
    public class CreateUserViewModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
    }
}