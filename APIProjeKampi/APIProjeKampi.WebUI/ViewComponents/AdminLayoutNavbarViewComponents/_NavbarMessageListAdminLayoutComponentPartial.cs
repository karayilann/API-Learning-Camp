using APIProjeKampi.WebUI.Dtos.UIMessageDtos;
using APIProjeKampi.WebUI.Dtos.UITestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponentPartial : ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var message = await httpClient.GetAsync("https://localhost:7086/api/Messages/GetUnreadMessages/");

            if (message.IsSuccessStatusCode)
            {
                var readAsStringAsync = await message.Content.ReadAsStringAsync();
                var deserializeObject = JsonConvert.DeserializeObject<List<ResultMessageUnreadDto>>(readAsStringAsync);
                return View(deserializeObject);
            }

            return View();
        }
    }
}
