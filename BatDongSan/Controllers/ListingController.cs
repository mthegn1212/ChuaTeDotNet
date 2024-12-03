using Microsoft.AspNetCore.Mvc;
using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace BatDongSan.Controllers
{
    public class ListingController : Controller
    {
        private readonly MenuService _menuService;
        private readonly ProjectService _projectService;
        private readonly NewsService _newService;
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ListingController(MenuService menuService, ProjectService projectService, NewsService newService, MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _menuService = menuService;
            _webHostEnvironment = webHostEnvironment;

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
        
        public IActionResult Listing()
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;
            var news = _newService.GetTop4();
            ViewBag.News = news;

            return View();
        }

        // GET: PostNew (Page for posting a new project)
        public IActionResult PostProject()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để truy cập trang này.";
                return RedirectToAction("Login", "SignIn");
            }
            string filePath1 = Path.Combine(_webHostEnvironment.WebRootPath, "data", "quan_huyen.json");
                        Console.WriteLine(filePath1);

            var model = new Projects();

            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;

            var salePro = _projectService.GetSalePro();
            ViewBag.SalePro = salePro;

            var news = _newService.GetTop4();
            ViewBag.News = news;

            return View("PostProject", model); // Pass the model to the view
        }
        
        // GET: ManageProject
        public IActionResult ProjectManagement()
        {
            // Get the user ID from session
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
            {
                // If the user is not logged in or session is invalid, redirect to login
                return RedirectToAction("Login", "SignIn");
            }
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            // Fetch all projects where UpById matches the UserId
            var userProjects = _context.Projects.Where(p => p.upById == userId).ToList();

            // Pass the projects to the view
            return View(userProjects);
        }

        
        // GET: ManageProject/Edit/5
        public async Task<IActionResult> EditProjects(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            return View(projects);
        }

        // POST: ManageProject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProjects(int id, [Bind("Id,Name,Description,Link,Meta,Hide,Order,Type,Locate,Price,Area,DateUp,upById,Image1,Image2,Image3,Image4,Image5")] Projects projects, IFormFile Image1, IFormFile Image2, IFormFile Image3, IFormFile Image4, IFormFile Image5)
        {
            if (id != projects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Handle image upload and deletion if images are updated
                    string[] imageProperties = { "Image1", "Image2", "Image3", "Image4", "Image5" };
                    var imageFiles = new[] { Image1, Image2, Image3, Image4, Image5 };

                    for (int i = 0; i < imageProperties.Length; i++)
                    {
                        var imageProperty = imageProperties[i];
                        var imageFile = imageFiles[i];

                        // If the image is not null (i.e., user uploaded a new image)
                        if (imageFile != null)
                        {
                            // Delete the old image if it exists
                            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", (string)typeof(Projects).GetProperty(imageProperty).GetValue(projects));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }

                            // Save the new image
                            var filePath = Path.Combine("wwwroot/uploads", Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName));

                            using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), filePath), FileMode.Create))
                            {
                                await imageFile.CopyToAsync(stream);
                            }

                            // Update the project object with the new image path
                            typeof(Projects).GetProperty(imageProperty).SetValue(projects, filePath.Replace("wwwroot", ""));
                        }
                    }

                    _context.Update(projects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projects);
        }

        // POST: ManageProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            if (projects != null)
            {
                // Delete images from wwwroot/uploads/ folder
                var imageProperties = new[] { "Image1", "Image2", "Image3", "Image4", "Image5" };
                foreach (var imageProperty in imageProperties)
                {
                    var imagePath = (string)typeof(Projects).GetProperty(imageProperty).GetValue(projects);
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                }

                _context.Projects.Remove(projects);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

        // POST: Upload images from CKEditor
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile upload)
        {
            if (upload.Length > 0)
            {
                // Lấy đường dẫn thư mục "wwwroot/uploads"
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Tạo tên file an toàn
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(upload.FileName)}";

                // Tạo đường dẫn lưu file
                var fileSavePath = Path.Combine(uploadsFolder, fileName);

                // Lưu file
                await using (var fileStream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream); // Chờ quá trình lưu hoàn tất
                }

                // Tạo URL tương đối để trả về
                var fileUrl = $"/uploads/{fileName}";

                return Json(new { uploaded = true, url = fileUrl });
            }

            // Trường hợp không có file được upload
            return Json(new { uploaded = false, error = "No file selected or file is empty." });
        }
        
        [HttpPost]
        public async Task<IActionResult> UpProject(Projects project, List<IFormFile> uploadedImages)
        {
            if (ModelState.IsValid)
            {
                // Gộp giá trị địa chỉ thành 1 chuỗi
                string location = Request.Form["Province"] + ", " + Request.Form["District"] + ", " + Request.Form["Ward"] + ", " + Request.Form["Street"];
                project.Locate = location;
                project.upById = HttpContext.Session.GetInt32("UserId") ?? 0;
                project.Meta = RemoveVietnameseTone(project.Name).Trim().ToLower().Replace(" ", "-");

                // Lưu dữ liệu ban đầu để có giá trị Id
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                // Gán giá trị Link sau khi có Id
                project.Link = "/id=" + project.Id + "&name=" + project.Meta;

                // Cập nhật lại dự án với giá trị Link
                _context.Projects.Update(project);

                // Handle image uploads
                if (uploadedImages.Count > 0)
                {
                    for (int i = 0; i < uploadedImages.Count && i < 5; i++)
                    {
                        var file = uploadedImages[i];
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                        // Save image to the server
                        await using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Assign the image path to the corresponding property in the project
                        switch (i)
                        {
                            case 0:
                                project.Image1 = fileName;
                                break;
                            case 1:
                                project.Image2 = fileName;
                                break;
                            case 2:
                                project.Image3 = fileName;
                                break;
                            case 3:
                                project.Image4 = fileName;
                                break;
                            case 4:
                                project.Image5 = fileName;
                                break;
                        }
                    }
                }

                // Lưu lại dữ liệu cuối cùng (bao gồm cả hình ảnh)
                await _context.SaveChangesAsync();

                // Redirect to the project detail page after saving
                return View("Detail", new { id = project.Id });
            }

            // Return to form with errors if model is invalid
            return View("PostProject", model: new Projects());
        }

        public IActionResult Detail(int id)
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var project = _projectService.GetProjectDetail(id); // Replace with your actual data-fetching method.

            var top5Projects = _projectService.GetTop5(); // Replace with actual logic.
            ViewBag.Top5Pro = top5Projects;
            ViewBag.ProjectById = project;

            return View(project);
        }

        private string RemoveVietnameseTone(string str)
        {
            // Chuyển đổi dấu tiếng Việt thành không dấu
            string formD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in formD)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
