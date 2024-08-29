using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppMVC.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductCategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: ProductCategory
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7182/api/ProductCategory");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ProductCatergory>>(responseBody);

            return View(categories);
        }

        // GET: ProductCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductCatergory category)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7182/api/ProductCategory", category);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
        }

        // GET: ProductCategory/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/ProductCategory/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<ProductCatergory>(responseBody);

            return View(category);
        }

        // POST: ProductCategory/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProductCatergory category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7182/api/ProductCategory/{id}", category);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
        }

        // POST: Size/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7182/api/ProductCategory/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            // Có thể thêm thông báo lỗi hoặc xử lý khác nếu cần
            return RedirectToAction(nameof(Index));
        }
    }
}
