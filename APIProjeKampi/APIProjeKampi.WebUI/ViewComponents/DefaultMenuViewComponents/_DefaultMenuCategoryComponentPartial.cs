using APIProjeKampi.WebUI.Dtos.UICategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultMenuCategoryComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var _client = _clientFactory.CreateClient();
            var response = await _client.GetAsync("https://localhost:7086/api/Categories/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject(jsonData);

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
