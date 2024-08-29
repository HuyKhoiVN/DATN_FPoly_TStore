using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Areas.Admin.Controllers
{
    public class VoucherController : Controller
    {
        private readonly HttpClient _httpClient;

        public VoucherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Voucher
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7182/api/Voucher");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var vouchers = JsonConvert.DeserializeObject<List<Voucher>>(responseBody);

            return View(vouchers);
        }

        // GET: Voucher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voucher/Create
        [HttpPost]
        public async Task<IActionResult> Create(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7182/api/Voucher", voucher);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(voucher);
        }

        // GET: Voucher/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Voucher/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var voucher = JsonConvert.DeserializeObject<Voucher>(responseBody);

            return View(voucher);
        }

        // POST: Voucher/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Voucher voucher)
        {
            if (id != voucher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7182/api/Voucher/{id}", voucher);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(voucher);
        }

        // GET: Voucher/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Voucher/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var voucher = JsonConvert.DeserializeObject<Voucher>(responseBody);

            return View(voucher);
        }

        // POST: Voucher/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7182/api/Voucher/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
