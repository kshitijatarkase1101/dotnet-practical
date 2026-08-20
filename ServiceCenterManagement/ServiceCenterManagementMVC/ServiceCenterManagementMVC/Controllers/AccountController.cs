using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient client;

        public AccountController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();

            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string url =
                $"api/Auth/login?username={Uri.EscapeDataString(model.Username)}&password={Uri.EscapeDataString(model.Password)}";

            HttpResponseMessage response =
                client.PostAsync(url, null).Result;

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid username or password");

                return View(model);
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            LoginResponse result =
                JsonSerializer.Deserialize<LoginResponse>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            HttpContext.Session.SetString(
                "Token",
                result.Token);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}