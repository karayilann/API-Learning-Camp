using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.ViewComponents
{
    public class _HeadDefaultComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
