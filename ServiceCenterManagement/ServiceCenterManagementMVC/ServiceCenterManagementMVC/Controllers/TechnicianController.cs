using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class TechnicianController : Controller
    {
        private readonly HttpClient client;

        public TechnicianController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();
            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        // GET: Technician
        public IActionResult Index()
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync("api/Technician").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Technician>());
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            List<Technician> technicians =
                JsonSerializer.Deserialize<List<Technician>>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(technicians);
        }

        // GET: Technician/Details/5
        public IActionResult Details(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Technician/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Technician technician =
                JsonSerializer.Deserialize<Technician>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(technician);
        }

        // GET: Technician/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technician/Create
        [HttpPost]
        public IActionResult Create(Technician technician)
        {
            if (!ModelState.IsValid)
            {
                return View(technician);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(technician);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    "api/Technician",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(technician);
        }

        // GET: Technician/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Technician/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Technician technician =
                JsonSerializer.Deserialize<Technician>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(technician);
        }

        // POST: Technician/Edit
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (!ModelState.IsValid)
            {
                return View(technician);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(technician);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PutAsync(
                    "api/Technician",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(technician);
        }

        // GET: Technician/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Technician/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Technician technician =
                JsonSerializer.Deserialize<Technician>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(technician);
        }

        // POST: Technician/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.DeleteAsync(
                    $"api/Technician/{id}").Result;

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

