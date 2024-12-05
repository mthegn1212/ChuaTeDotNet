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
        private readonly ProjectService _projectService;

        public NewsController(MenuService menuService, NewsService newsService, MyDbContext context, ProjectService projectService, NewsService newService)
        {
            _menuService = menuService;
            _newsService = newsService;
            _context = context;
            _projectService = projectService;
        }

        // GET: News/Create
        // GET: News/Details
        [Route("Home/news/{id}")]
        [HttpGet]
        public async Task<IActionResult> News(int id)
        {
            // Fetch news details by ID
            var news = await _context.News
                .Include(n => n.ImagePath) // Include related entities, if any
                .FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
            {
                return NotFound(); // Return a 404 error if the news is not found
            }

            // Populate menu items for the view
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

            ViewBag.NewsDetails = news;
            return View("news"); // Render the news view
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
            return View("news", newsList); // Truyền danh sách bài viết sang View
        }
        public IActionResult Detail(int id)
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;
            var news = _newsService.GetTop4();
            ViewBag.News = news;

            return View();
        }

        
    }
}