using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly HttpClient client;

        public ServiceRequestController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();

            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        // GET: ServiceRequest
        public IActionResult Index()
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync("api/ServiceRequest").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ServiceRequest>());
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            List<ServiceRequest> requests =
                JsonSerializer.Deserialize<List<ServiceRequest>>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(requests);
        }

        // GET: ServiceRequest/Details/5
        public IActionResult Details(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/ServiceRequest/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            ServiceRequest request =
                JsonSerializer.Deserialize<ServiceRequest>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(request);
        }

        // GET: ServiceRequest/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceRequest/Create
        [HttpPost]
        public IActionResult Create(ServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(request);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    "api/ServiceRequest",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(request);
        }

        // GET: ServiceRequest/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/ServiceRequest/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            ServiceRequest request =
                JsonSerializer.Deserialize<ServiceRequest>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(request);
        }

        // POST: ServiceRequest/Edit
        [HttpPost]
        public IActionResult Edit(ServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(request);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PutAsync(
                    "api/ServiceRequest",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(request);
        }

        // GET: ServiceRequest/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/ServiceRequest/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            ServiceRequest request =
                JsonSerializer.Deserialize<ServiceRequest>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(request);
        }

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.DeleteAsync(
                    $"api/ServiceRequest/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // JWT Token
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

