using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
