using Microsoft.AspNetCore.Mvc;
using BatDongSan.Models;
using BatDongSan.Helpers;
using BatDongSan.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace BatDongSan.Controllers
{
    public class SignInController : Controller
    {
        private readonly MenuService _menuService;
        private readonly MyDbContext _context;

        public SignInController(MenuService menuService, MyDbContext context)
        {
            _menuService = menuService;
            _context = context;
        }
        
        // Hiển thị trang đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            var menuItem = _menuService.GetMenuItems();
            ViewBag.MenuItems = _menuService.GetMenuItems() ?? new List<MenuItem>();
            return View("SignIn");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SignIn");
            }

            // Tìm kiếm người dùng theo email
            var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                // Không tìm thấy email trong cơ sở dữ liệu
                ModelState.AddModelError(string.Empty, "Email không tồn tại.");
                return View("SignIn");
            }

            if (!PasswordHelper.VerifyPassword(model.Password, user.Password))
            {
                // Sai mật khẩu
                ModelState.AddModelError(string.Empty, "Mật khẩu không chính xác.");
                return View("SignIn");
            }

            // Đăng nhập thành công, lưu thông tin người dùng vào Session
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("UserId", user.Id);

            // Lưu menu items vào TempData
            var menuItems = _menuService.GetMenuItems();
            TempData["MenuItems"] = JsonConvert.SerializeObject(menuItems, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return RedirectToAction("Index", "Home");
        }

        // Hiển thị trang đăng ký
        [HttpGet]
        public IActionResult SignUp()
        {
            var menuItem = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItem;
            return View("SignUp");
        }

        // Xử lý đăng ký người dùng mới
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp"); // Trả lại view với thông báo lỗi
            }

            // Kiểm tra email đã tồn tại hay chưa
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError(string.Empty, "Email này đã được đăng ký.");
                return View("SignUp");
            }

            // Tạo người dùng mới
            var hashedPassword = PasswordHelper.HashPassword(model.Password);

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = hashedPassword, // Lưu mật khẩu đã mã hóa
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Sau khi đăng ký thành công, đăng nhập người dùng
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chính
        }

        // Xử lý đăng xuất
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa tất cả session
            return RedirectToAction("Index", "Home");
        }
    }
}
