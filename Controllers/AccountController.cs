using Microsoft.AspNetCore.Mvc;

namespace mvcproj.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
