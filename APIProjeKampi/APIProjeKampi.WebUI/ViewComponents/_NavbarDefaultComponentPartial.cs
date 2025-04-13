using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
