using BatDongSan.Models; 
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

public class NewsController : Controller
{
    private readonly MenuService _menuService; 
    private readonly NewsService _newsService;

    public NewsController(MenuService menuService, NewsService newsService)
    {
        _menuService = menuService; 
        _newsService = newsService; 
    }

    public IActionResult Index()
    {
        var menuItems = _menuService.GetMenuItems(); 
        ViewBag.MenuItems = menuItems; 

        var blogEntries = _newsService.GetAllNews();
        return View("news", blogEntries); 
    }
}
