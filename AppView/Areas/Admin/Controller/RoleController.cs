using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoleController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Producer
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7182/api/Role");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var Roles = JsonConvert.DeserializeObject<List<Role>>(responseBody);

            return View(Roles);
        }

        // GET: Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        public async Task<IActionResult> Create(Role roles)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7182/api/Role", roles);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(roles);
        }

        // GET: Producer/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Role/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<Role>(responseBody);

            return View(roles);
        }

        // POST: Producer/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Role roles)
        {
            if (id != roles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7182/api/Role/{id}", roles);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(roles);
        }

        // GET: Producer/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Role/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<Role>(responseBody);

            return View(roles);
        }

        // POST: Producer/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7182/api/Role/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
