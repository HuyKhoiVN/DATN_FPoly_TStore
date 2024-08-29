using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppMVC.Controllers
{
    public class ProducerController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProducerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Producer
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7182/api/Producer");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var producers = JsonConvert.DeserializeObject<List<Producer>>(responseBody);

            return View(producers);
        }

        // GET: Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7182/api/Producer", producer);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(producer);
        }

        // GET: Producer/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Producer/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var producer = JsonConvert.DeserializeObject<Producer>(responseBody);

            return View(producer);
        }

        // POST: Producer/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Producer producer)
        {
            if (id != producer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7182/api/Producer/{id}", producer);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(producer);
        }

        // GET: Producer/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Producer/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var producer = JsonConvert.DeserializeObject<Producer>(responseBody);

            return View(producer);
        }

        // POST: Producer/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7182/api/Producer/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
