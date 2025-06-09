using APIProjeKampi.WebUI.Dtos.UIMessageDtos;
using APIProjeKampi.WebUI.Dtos.UINotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarNotificationAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarNotificationAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var message = await httpClient.GetAsync("https://localhost:7086/api/Notification");

            if (message.IsSuccessStatusCode)
            {
                var readAsStringAsync = await message.Content.ReadAsStringAsync();
                var deserializeObject = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(readAsStringAsync);
                return View(deserializeObject);
            }

            return View();
        }
    }
}