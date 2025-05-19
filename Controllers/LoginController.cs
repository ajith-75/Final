using Microsoft.AspNetCore.Mvc;

namespace KalyanamApp.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Login(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Error = "தயவுசெய்து உங்கள் பெயரை எழுதுங்கள்!";
                return View();
            }

            HttpContext.Session.SetString("UserName", name);
            return RedirectToAction("Invite");
        }
        [HttpGet]
        public IActionResult Invite()
        {
            var name = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(name)) return RedirectToAction("Login");

            ViewBag.UserName = name;
            return View();
        }
    }
}
