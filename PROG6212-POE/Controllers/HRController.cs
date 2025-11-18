using Microsoft.AspNetCore.Mvc;

namespace PROG6212_POE.Controllers
{
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
