using APIProjeKampi.WebUI.Dtos.UITestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _TestimonialDefaultComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _TestimonialDefaultComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var message = await client.GetAsync("https://localhost:7086/api/Testimonials/");

            if (message.IsSuccessStatusCode)
            {
                var readAsStringAsync = await message.Content.ReadAsStringAsync();
                var deserializeObject = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(readAsStringAsync);
                return View(deserializeObject);
            }

            return View();
        }

    }
}
