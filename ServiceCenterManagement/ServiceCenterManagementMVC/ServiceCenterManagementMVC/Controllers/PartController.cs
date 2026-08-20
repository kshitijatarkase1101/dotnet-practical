using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class PartController : Controller
    {
        private readonly HttpClient client;

        public PartController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();

            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        // GET: Part
        public IActionResult Index()
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync("api/Part").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Part>());
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            List<Part> parts =
                JsonSerializer.Deserialize<List<Part>>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(parts);
        }

        // GET: Part/Details/5
        public IActionResult Details(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Part/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Part part =
                JsonSerializer.Deserialize<Part>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(part);
        }

        // GET: Part/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Part/Create
        [HttpPost]
        public IActionResult Create(Part part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(part);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    "api/Part",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(part);
        }

        // GET: Part/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Part/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Part part =
                JsonSerializer.Deserialize<Part>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(part);
        }

        // POST: Part/Edit
        [HttpPost]
        public IActionResult Edit(Part part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(part);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PutAsync(
                    "api/Part",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(part);
        }

        // GET: Part/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Part/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Part part =
                JsonSerializer.Deserialize<Part>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(part);
        }

        // POST: Part/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.DeleteAsync(
                    $"api/Part/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        private void SetToken()
        {
            string token =
                HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }
    }
}