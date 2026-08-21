using Microsoft.AspNetCore.Mvc;
using ServiceCenterManagementMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServiceCenterManagementMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient client;

        public CustomerController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();

            client.BaseAddress =
                new Uri("http://localhost:5243/");
        }

        // GET: Customer
        public IActionResult Index()
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync("api/Customer").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Customer>());
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            List<Customer> customers =
                JsonSerializer.Deserialize<List<Customer>>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(customers);
        }

        // GET: Customer/Details/5
        public IActionResult Details(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Customer/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Customer customer =
                JsonSerializer.Deserialize<Customer>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(customer);
        }

        // GET: Customer/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(customer);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    "api/Customer",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(customer);
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Customer/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Customer customer =
                JsonSerializer.Deserialize<Customer>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(customer);
        }

        // POST: Customer/Edit
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            SetToken();

            string json =
                JsonSerializer.Serialize(customer);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PutAsync(
                    "api/Customer",
                    content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View(customer);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.GetAsync($"api/Customer/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string data =
                response.Content.ReadAsStringAsync().Result;

            Customer customer =
                JsonSerializer.Deserialize<Customer>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            SetToken();

            HttpResponseMessage response =
                client.DeleteAsync($"api/Customer/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            string error =
                response.Content.ReadAsStringAsync().Result;

            ModelState.AddModelError("", error);

            return View();
        }

        // Add JWT token to request
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