using Microsoft.AspNetCore.Mvc;

namespace UserApp.PL.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
