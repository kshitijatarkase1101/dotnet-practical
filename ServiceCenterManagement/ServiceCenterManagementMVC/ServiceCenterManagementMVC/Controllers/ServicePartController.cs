using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class ServicePartController : Controller
    {
        private readonly HttpClient client;

        public ServicePartController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();

            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        // GET: ServicePart
        public IActionResult Index()
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync("api/ServicePart").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ServicePart>());
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            List<ServicePart> serviceParts =
                JsonSerializer.Deserialize<List<ServicePart>>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(serviceParts);
        }

        // GET: ServicePart/Details/5
        public IActionResult Details(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/ServicePart/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            ServicePart servicePart =
                JsonSerializer.Deserialize<ServicePart>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(servicePart);
        }

        // GET: ServicePart/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicePart/Create
        [HttpPost]
        public IActionResult Create(ServicePart servicePart)
        {
            if (!ModelState.IsValid)
            {
                return View(servicePart);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(servicePart);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    "api/ServicePart",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(servicePart);
        }

        // GET: ServicePart/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/ServicePart/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            ServicePart servicePart =
                JsonSerializer.Deserialize<ServicePart>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(servicePart);
        }

        // POST: ServicePart/Edit
        [HttpPost]
        public IActionResult Edit(ServicePart servicePart)
        {
            if (!ModelState.IsValid)
            {
                return View(servicePart);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(servicePart);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PutAsync(
                    "api/ServicePart",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(servicePart);
        }

        // GET: ServicePart/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/ServicePart/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            ServicePart servicePart =
                JsonSerializer.Deserialize<ServicePart>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(servicePart);
        }

        // POST: ServicePart/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.DeleteAsync(
                    $"api/ServicePart/{id}").Result;

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

