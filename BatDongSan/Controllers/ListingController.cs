﻿using Microsoft.AspNetCore.Mvc;
using BatDongSan.Services;
using BatDongSan.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BatDongSan.Controllers
{
    public class ListingController : Controller
    {
        private readonly MenuService _menuService;
        private readonly ProjectService _projectService;
        private readonly NewsService _newService;
        private readonly MyDbContext _context;

        public ListingController(MenuService menuService, ProjectService projectService, NewsService newService, MyDbContext context)
        {
            _menuService = menuService;
            _projectService = projectService;
            _newService = newService;
            _context = context;
        }

        public IActionResult Index()
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var top5Pro = _projectService.GetTop5();
            ViewBag.Top5Pro = top5Pro;
            var rentPro = _projectService.GetRentPro();
            ViewBag.RentPro = rentPro;
            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;
            var projects = _projectService.GetAllProject();
            ViewBag.Projects = projects;

            return View("listing", top5Pro);
        }
        public ActionResult Details(int id)
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var project = _projectService.find(id);
            ViewBag.ProjectById = project;
            var top5Pro = _projectService.GetTop5();
            ViewBag.Top5Pro = top5Pro;

            return View("Detail");
        }
        public IActionResult RentListing()
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var rentPro = _projectService.GetRentPro();
            ViewBag.RentPro = rentPro;
            var news = _newService.GetTop4();
            ViewBag.News = news;

            return View("RentListing");
        }
        public IActionResult SaleListing()
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;
            var news = _newService.GetTop4();
            ViewBag.News = news;

            return View("SaleListing");
        }
        public IActionResult PostNew()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để truy cập trang này.";
                return RedirectToAction("Login", "SignIn");
            }

            var model = new Project();

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

            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;
            var news = _newService.GetTop4();
            ViewBag.News = news;

            return View("PostNew", model); // Truyền model vào view
        }

        // Phương thức lưu file vào thư mục wwwroot
        private async Task<string> SaveFileAsync(IFormFile file)
        {
            try
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return "~/uploads/" + uniqueFileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}"); // Thêm log lỗi chi tiết
                throw new Exception("There was an error uploading the file.", ex); // Đảm bảo ném lỗi để biết nguyên nhân
            }

        }


        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UpProject([Bind("Name,Description,Hide,Order,Type,Price,Area")] Project project)
        {
            if (ModelState.IsValid)
            {
                //foreach ( var img in imgs)
                //{
                //	string nameimg = await SaveFileAsync(img);
                //	project.UploadedImagePaths.Add(nameimg);
                //}
                project.upById = HttpContext.Session.GetInt32("Id") ?? 0;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState
                    .Where(ms => ms.Value.Errors.Any())
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    );
                return BadRequest(errors);
            }
        }
    }
}