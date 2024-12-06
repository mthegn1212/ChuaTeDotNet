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
        public async Task<IActionResult> Detail(int id)
        {
            // Fetch the news details by ID
            var news = await _context.News.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound(); // Return 404 if the news is not found
            }

            // Get related news (example logic, adjust based on your structure)
            var relatedNews = await _context.News
                .Where(n => n.Id != id) // Exclude the current news
                .OrderByDescending(n => n.DateUp) // Sort by date
                .Take(4) // Limit to 4 related news
                .ToListAsync();

            // Populate the ViewBag with related news
            ViewBag.RelatedNews = relatedNews;

            // Return the view with the news model
            return View(news);
        }
    }
}