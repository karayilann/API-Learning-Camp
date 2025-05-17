using APIProjeKampi.WebUI.Dtos.UIChefDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _ChefsDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _ChefsDefaultComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7086/api/Chefs/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ResultChefDto>>(content);

                return View(list);
            }

            return View();
        }


    }
}
