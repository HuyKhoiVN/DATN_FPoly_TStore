using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductDetailController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7182/api/Product/productDetail/{id}";

            var response = await _httpClient.GetStringAsync(url);
            var productDetail = JsonConvert.DeserializeObject<ProductDetailDto>(response);

            return View(productDetail);
        }
    }
}
