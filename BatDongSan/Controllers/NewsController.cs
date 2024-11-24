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
            return View(); // Return the view to create a new news entry
        }

        // GET: News/Index
        public async Task<IActionResult> Index()
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;

            var blogEntries = _newsService.GetAllNews();
            var newsList = await _context.News.ToListAsync();
            return View("news");
        }

        // Phương thức lưu file vào thư mục wwwroot
        private async Task<string> SaveFileAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder); // Tạo thư mục nếu chưa tồn tại
            }

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return "/uploads/" + uniqueFileName; // Trả về đường dẫn tương đối để lưu vào database
        }

        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostNews(News news)
        {
            if (ModelState.IsValid)
            {
                // Handle file uploads and save news data
                if (news.FeaturedImage != null)
                {
                    string imgPath = await SaveFileAsync(news.FeaturedImage);
                    news.FeaturedImagePath = imgPath;
                }

                if (news.UploadedImages != null && news.UploadedImages.Any())
                {
                    news.UploadedImagePaths = new List<string>();
                    foreach (var file in news.UploadedImages)
                    {
                        string imgPath = await SaveFileAsync(file);
                        news.UploadedImagePaths.Add(imgPath);
                    }
                }

                news.DateUp = DateTime.Now;
                _context.News.Add(news);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "News"); // Redirect after creating the news item
            }
            return View("News"); // Return to the Create view with the model if there is a validation error
        }
    }
}