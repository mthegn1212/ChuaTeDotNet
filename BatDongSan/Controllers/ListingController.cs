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

            // SEO tags
            ViewData["Title"] = "Rent Properties - Bat Dong San";
            ViewData["Description"] = "Browse rental properties available for rent in your area.";
            ViewData["Keywords"] = "rental properties, apartments for rent, houses for rent";

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

            // SEO tags
            ViewData["Title"] = "Sale Properties - Bat Dong San";
            ViewData["Description"] = "Find properties available for sale at Bat Dong San. Discover homes, apartments, and land for sale.";
            ViewData["Keywords"] = "sale properties, real estate for sale, houses for sale";

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

            return View("PostProject", model); 
        }

        public IActionResult ProjectManagement()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
            {
                return RedirectToAction("Login", "SignIn");
            }
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var userProjects = _context.Projects.Where(p => p.upById == userId).ToList();
            return View(userProjects);
        }

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

            // Cập nhật ViewData cho SEO
            ViewData["Title"] = "Chỉnh sửa dự án - " + projects.Name;
            ViewData["Description"] = "Chỉnh sửa dự án " + projects.Name + " với các thông tin như tên, diện tích, giá và mô tả.";

            ViewBag.ProjectById = projects;
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
    
            return View(projects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProjects(int id, Projects updatedProject, List<IFormFile> uploadedImages)
        {
            if (id != updatedProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                    if (existingProject == null)
                    {
                        return NotFound();
                    }

                    // Update fields
                    existingProject.Name = updatedProject.Name ?? existingProject.Name;
                    existingProject.Description = updatedProject.Description ?? existingProject.Description;
                    existingProject.Hide = updatedProject.Hide;
                    existingProject.Order = updatedProject.Order;
                    existingProject.Type = updatedProject.Type;
                    existingProject.Price = updatedProject.Price ?? existingProject.Price;
                    existingProject.Area = updatedProject.Area ?? existingProject.Area;
                    existingProject.DateUp = updatedProject.DateUp;

                    // Update address
                    var province = Request.Form["Province"];
                    var district = Request.Form["District"];
                    var ward = Request.Form["Ward"];
                    var street = Request.Form["Street"];
                    if (!string.IsNullOrEmpty(province) || !string.IsNullOrEmpty(district) || !string.IsNullOrEmpty(ward) || !string.IsNullOrEmpty(street))
                    {
                        existingProject.Locate = $"{province}, {district}, {ward}, {street}".Trim(',', ' ');
                    }

                    // Handle images
                    var imageProperties = new[] { "Image1", "Image2", "Image3", "Image4", "Image5" };
                    var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    for (int i = 0; i < imageProperties.Length; i++)
                    {
                        var imageProperty = imageProperties[i];
                        var existingImage = existingProject.GetType().GetProperty(imageProperty)?.GetValue(existingProject)?.ToString();
                        var uploadedImage = uploadedImages.ElementAtOrDefault(i);

                        if (uploadedImage != null)
                        {
                            // Delete old image
                            if (!string.IsNullOrEmpty(existingImage))
                            {
                                var oldImagePath = Path.Combine(uploadDir, existingImage);
                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }
                            }

                            // Save new image
                            var newFileName = Guid.NewGuid() + Path.GetExtension(uploadedImage.FileName);
                            var newImagePath = Path.Combine(uploadDir, newFileName);
                            await using (var stream = new FileStream(newImagePath, FileMode.Create))
                            {
                                await uploadedImage.CopyToAsync(stream);
                            }

                            // Update project image property
                            existingProject.GetType().GetProperty(imageProperty)?.SetValue(existingProject, newFileName);
                        }
                    }

                    // Save changes
                    _context.Projects.Update(existingProject);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Detail", new { id = existingProject.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Projects.Any(p => p.Id == id))
                    {
                        return NotFound();
                    }

                    throw;
                }
            }

            return View(updatedProject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            if (projects != null)
            {
                var imageProperties = new[] { "Image1", "Image2", "Image3", "Image4", "Image5" };

                foreach (var imageProperty in imageProperties)
                {
                    var imagePath = (string)typeof(Projects).GetProperty(imageProperty)?.GetValue(projects);
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", imagePath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                }

                _context.Projects.Remove(projects);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ProjectManagement));
        }

        public IActionResult Detail(int id)
        {
            var menuItems = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItems;
            var project = _projectService.GetProjectDetail(id); // Replace with your actual data-fetching method.
            if (project == null)
            {
                return NotFound(); // Handle the case when no project is found.
            }
            var top5Projects = _projectService.GetTop5(); // Replace with actual logic.
            ViewBag.Top5Pro = top5Projects;
            ViewBag.ProjectById = project;

            return View();
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
                return RedirectToAction("Detail", new { id = project.Id });
            }

            // Return to form with errors if model is invalid
            return View("PostProject", model: new Projects());
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
