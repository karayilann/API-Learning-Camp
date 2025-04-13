using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
