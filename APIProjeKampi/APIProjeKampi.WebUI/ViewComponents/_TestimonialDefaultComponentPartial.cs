using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _TestimonialDefaultComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _TestimonialDefaultComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            client.GetAsync("https://localhost:7086/api/Testimonials/");
        }


    }
}
