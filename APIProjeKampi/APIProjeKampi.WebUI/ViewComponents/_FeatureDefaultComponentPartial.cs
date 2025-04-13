using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
