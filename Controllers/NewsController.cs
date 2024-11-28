using BatDongSan.Models; 
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatDongSan.Controllers
{
    public class NewsController : Controller
    {
        private readonly MenuService _menuService;
        private readonly NewsService _newsService;
        private readonly MyDbContext _context;

        public NewsController(MenuService menuService, NewsService newsService, MyDbContext context)
        {
            _menuService = menuService;
            _newsService = newsService;
            _context = context;
        }

        // GET: News/Create
        [HttpGet]
        public IActionResult News()
        {
            // Kiểm tra nếu MenuItems tồn tại trong TempData
            if (TempData["MenuItems"] != null)
            {
                var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuItem>>(TempData["MenuItems"].ToString());
                ViewBag.MenuItems = menuItems;
            }
            else
            {
                // Nếu không có menu trong TempData, lấy từ dịch vụ
                var menuItems = _menuService.GetMenuItems();
                ViewBag.MenuItems = menuItems;
            }
            return View(); // Return the view to create a new news entry
        }

        // GET: News/Index
        public async Task<IActionResult> Index()
        {
            if (TempData["MenuItems"] != null)
            {
                var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuItem>>(TempData["MenuItems"].ToString());
                ViewBag.MenuItems = menuItems;
            }
            else
            {
                var menuItems = _menuService.GetMenuItems();
                ViewBag.MenuItems = menuItems;
            }

            var newsList = await _context.News.ToListAsync(); // Lấy danh sách bài viết từ database
            return View("news"); // Truyền danh sách bài viết sang View
        }
    }
}