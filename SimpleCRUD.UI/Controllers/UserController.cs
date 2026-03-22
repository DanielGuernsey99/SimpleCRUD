using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.UI.DTOs;
using SimpleCRUD.UI.ViewModels;
using SimpleCRUD.UI.Models.User;

namespace SimpleCRUD.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var tableModel = new TableViewModel
            {
                Title = "Users",
                Headers = new List<string> { "User ID", "First Name", "Last Name" },
                Rows = new List<List<string>>()
            };

            try
            {
                var client = _httpClientFactory.CreateClient("SimpleCrudApi");

                var users = await client.GetFromJsonAsync<List<UserDto>>("User/GetAllUsers");

                if (users != null)
                {
                    tableModel.Rows = users.Select(user => new List<string>
                    {
                        user.UserId.ToString(),
                        user.FirstName ?? string.Empty,
                        user.LastName ?? string.Empty
                    }).ToList();
                }
            }
            catch
            {
                tableModel.Rows = new List<List<string>>();
            }

            return View(tableModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateUserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var client = _httpClientFactory.CreateClient("SimpleCrudApi");

                var request = new CreateUserDTO
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var response = await client.PostAsJsonAsync("User/InsertUser", request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Unable to create user.");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View(model);
        }
    }
}