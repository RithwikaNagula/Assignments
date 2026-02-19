using Microsoft.AspNetCore.Mvc;

namespace JWTRoles.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
