using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _FooterDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
