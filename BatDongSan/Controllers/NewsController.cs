using BatDongSan.Models; // Nhớ thêm namespace của model
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

public class NewsController : Controller
{
    private readonly MenuService _menuService; // Thêm MenuService để lấy menu items
    private readonly NewsService _newsService;

    public NewsController(MenuService menuService, NewsService newsService)
    {
        _menuService = menuService; // Khởi tạo MenuService
        _newsService = newsService; // Khởi tạo NewsService
    }

    public IActionResult Index()
    {
        var menuItems = _menuService.GetMenuItems(); // Lấy menu items từ MenuService
        ViewBag.MenuItems = menuItems; // Truyền vào ViewBag

        var blogEntries = _newsService.GetAllNews(); // Sử dụng phương thức để lấy tin tức
        return View("news", blogEntries); // Trả về view news.cshtml với blogEntries
    }
}
