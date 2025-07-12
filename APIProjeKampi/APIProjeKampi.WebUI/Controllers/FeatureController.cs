using System.Text;
using APIProjeKampi.WebUI.Dtos.UIFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7086/api/Features");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonResponse);
                return View(features);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var message = await client.PostAsync("https://localhost:7086/api/Features", content);
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }

            return View();
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7086/api/Features?id={id}");
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7086/api/Features/GetFeature?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var feature = JsonConvert.DeserializeObject<GetFeatureByIdDto>(jsonResponse);
                return View(feature);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var message = await client.PutAsync("https://localhost:7086/api/Features", content);
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }

            return View();


        }
    }
}
