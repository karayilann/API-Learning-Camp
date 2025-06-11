using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _SidebarAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
