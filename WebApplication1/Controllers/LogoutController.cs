using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Index()
        {
            var token = Request.Cookies["token"];
            HttpContext.Response.Cookies.Delete("token");
            return RedirectToAction("Index", "Home");
        }
    }
}
