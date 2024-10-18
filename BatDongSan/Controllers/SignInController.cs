using BatDongSan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using BatDongSan.Services;
using Microsoft.EntityFrameworkCore;

namespace BatDongSan.Controllers
{

    public class SignInController : Controller
    {
        private readonly MenuService _menuService;
        public SignInController(MenuService menuService)
        {
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            var menuItem = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItem;
            return View("signIn");
        }
        public IActionResult SignUp()
        {
            var menuItem = _menuService.GetMenuItems();
            ViewBag.MenuItems = menuItem;
            return View("signUp");
        }
    }
}
