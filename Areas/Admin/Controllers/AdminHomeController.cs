using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Xử lý đăng xuất
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Login", "SignIn", new { area = "" }); // Explicitly specify no area
        }

    }
}
