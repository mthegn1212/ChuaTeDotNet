using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.EntityFrameworkCore;

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

        // GET: PostNew (Page for posting a new project)
        public IActionResult PostNew()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để truy cập trang này.";
                return RedirectToAction("Login", "SignIn");
            }

            var model = new Projects();

            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;

            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;

            var news = _newService.GetTop4();
            ViewBag.News = news;

            return View("PostNew", model); // Pass the model to the view
        }

        // POST: Upload images from CKEditor
        [HttpPost]
        public IActionResult Upload(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", upload.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    upload.CopyTo(fileStream);
                }
                return Json(new { uploaded = true, url = "/uploads/" + upload.FileName });
            }
            return Json(new { uploaded = false, error = "Failed to upload the file." });
        }

        [HttpPost]
        public async Task<IActionResult> UpProject(Projects projects, List<IFormFile> uploadedImages)
        {
            // 1. Initialize the ProjectImages list if it's null
            projects.ProjectImages = projects.ProjectImages ?? new List<ProjectImages>();

            // 2. Extract image URLs from the Description field (from CKEditor)
            var extractedImageUrls = ExtractImageUrls(projects.Description);
            foreach (var url in extractedImageUrls)
            {
                projects.ProjectImages.Add(new ProjectImages { ImageUrl = url });
            }

            // 3. Save uploaded images from the form to the server and add them to ProjectImages
            if (uploadedImages != null && uploadedImages.Any())
            {
                foreach (var file in uploadedImages)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    projects.ProjectImages.Add(new ProjectImages { ImageUrl = "/uploads/" + fileName });
                }
            }

            // 4. Clean the Description (remove image tags if necessary)
            projects.Description = Regex.Replace(projects.Description, @"<img [^>]*src=""([^""]+)""[^>]*>", "");

            // 5. Save the project to the database
            _context.Projects.Add(projects);
            await _context.SaveChangesAsync();

            // 6. Save ProjectImage entries
            foreach (var projectImage in projects.ProjectImages)
            {
                projectImage.ProjectId = projects.Id; // Make sure the ProjectId is set
                _context.ProjectImages.Add(projectImage); // Do NOT set the 'Id' here
            }
            await _context.SaveChangesAsync(); // This will insert the images with auto-generated IDs

            // 7. Redirect to the Details page for the newly created project
            return RedirectToAction("Details", new { id = projects.Id });
        }

        // GET: Details of a project
        public ActionResult Details(int id)
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;

            var project = _projectService.GetProjectDetail(id);
            return View("Index");
        }

        // Extract image URLs from HTML content
        private List<string> ExtractImageUrls(string htmlContent)
        {
            var urls = new List<string>();
            var matchCollection = Regex.Matches(htmlContent, @"<img [^>]*src=""([^""]+)""[^>]*>");
            foreach (Match match in matchCollection)
            {
                if (match.Groups.Count > 1)
                {
                    urls.Add(match.Groups[1].Value);
                }
            }
            return urls;
        }
    }
}
