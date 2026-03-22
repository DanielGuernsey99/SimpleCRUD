using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.UI.Models;

namespace SimpleCRUD.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var model = new TableViewModel
            {
                Title = "Users",
                Headers = new List<string> { "User ID", "First Name", "Last Name" },
                Rows = new List<List<string>>
                {
                    new() { "1", "Jane", "Smith" },
                    new() { "2", "John", "Doe" }
                }
            };

            return View(model);
        }
    }
}