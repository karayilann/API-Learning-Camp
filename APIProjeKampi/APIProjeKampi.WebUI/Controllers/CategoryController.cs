using Microsoft.AspNetCore.Mvc;

namespace APIProjeKampi.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryList()
        {
            return View();
        }
    }
}
