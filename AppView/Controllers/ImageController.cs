using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppMVC.Controllers
{
    public class ImageController : Controller
    {
        private readonly HttpClient _httpClient;

        public ImageController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7182/api/Image");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var images = JsonConvert.DeserializeObject<List<Image>>(responseBody);

            return View(images);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        public async Task<IActionResult> Create(Image image)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7182/api/Image", image);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(image);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Image/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var image = JsonConvert.DeserializeObject<Image>(responseBody);

            return View(image);
        }

        // POST: Image/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7182/api/Image/{id}", image);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(image);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7182/api/Image/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var image = JsonConvert.DeserializeObject<Image>(responseBody);

            return View(image);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7182/api/Image/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
