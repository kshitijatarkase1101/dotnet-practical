using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly HttpClient client;

        public VehicleController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();

            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        // GET: Vehicle
        public IActionResult Index()
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync("api/Vehicle").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Vehicle>());
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            List<Vehicle> vehicles =
                JsonSerializer.Deserialize<List<Vehicle>>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(vehicles);
        }

        // GET: Vehicle/Details/5
        public IActionResult Details(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Vehicle/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Vehicle vehicle =
                JsonSerializer.Deserialize<Vehicle>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(vehicle);
        }

        // GET: Vehicle/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicle);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(vehicle);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    "api/Vehicle",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Vehicle/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Vehicle vehicle =
                JsonSerializer.Deserialize<Vehicle>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(vehicle);
        }

        // POST: Vehicle/Edit
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicle);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(vehicle);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PutAsync(
                    "api/Vehicle",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Vehicle/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Vehicle vehicle =
                JsonSerializer.Deserialize<Vehicle>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.DeleteAsync(
                    $"api/Vehicle/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // Add JWT token
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

