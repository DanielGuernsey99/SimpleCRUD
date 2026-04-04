using Microsoft.AspNetCore.Mvc;

namespace SimpleCRUD.UI.Controllers.User
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}