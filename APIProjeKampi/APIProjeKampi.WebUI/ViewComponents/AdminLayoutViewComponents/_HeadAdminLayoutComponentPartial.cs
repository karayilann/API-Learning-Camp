using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _HeadAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
