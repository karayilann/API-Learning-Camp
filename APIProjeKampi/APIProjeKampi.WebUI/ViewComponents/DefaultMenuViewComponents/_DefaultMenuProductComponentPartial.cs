using APIProjeKampi.WebUI.Dtos.UIProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMenuProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7086/api/Products/");

            if (response.IsSuccessStatusCode)
            {
                var readAsStringAsync = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ResultProductDto>>(readAsStringAsync);
                return View(list);
            }

            return View();
        }    
    }
}
