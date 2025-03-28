namespace ApiProjeKampi.WebUI.ViewComponent
{
    using Microsoft.AspNetCore.Mvc;

    public class _HeadDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
