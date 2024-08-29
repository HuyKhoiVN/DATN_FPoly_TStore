using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppMVC.Controllers
{
    public class SizeController : Controller
    {
        private readonly HttpClient _httpClient;

        public SizeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Size
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7182/api/Size");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var sizes = JsonConvert.DeserializeObject<List<Size>>(responseBody);

            return View(sizes);
        }

        // GET: Size/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Size/Create
        [HttpPost]
        public async Task<IActionResult> Create(string sizeName)
        {
            var size = new Size
            {
                SizeName = sizeName
                // Các thuộc tính khác có thể được đặt ở đây nếu cần
            };

            var json = JsonConvert.SerializeObject(size);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7182/api/Size", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(size);
        }

        // GET: Size/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Size/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var size = JsonConvert.DeserializeObject<Size>(responseBody);

            return View(size);
        }

        // POST: Size/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, string sizeName)
        {
            var size = new Size
            {
                Id = id,
                SizeName = sizeName
                // Các thuộc tính khác có thể được đặt ở đây nếu cần
            };

            var json = JsonConvert.SerializeObject(size);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7182/api/Size/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(size);
        }

        // POST: Size/Delete
        [HttpPost] 
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7182/api/Size/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            // Nếu xóa thất bại, có thể xử lý ở đây
            return RedirectToAction(nameof(Index));
        }
    }
}
