using Microsoft.AspNetCore.Mvc;

namespace SimpleCRUD.UI.Controllers.Application
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
