using APIProjeKampi.WebUI.Dtos.UICategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7086/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonResponse);
                return View(categories);
            }
            return View();
        }
    }
}
