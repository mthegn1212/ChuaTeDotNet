using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BatDongSan.Services
{
    public class MenuService
    {
        private readonly MyDbContext _context;

        public MenuService(MyDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _context.MenuItem
				.Include(m => m.ChildMenus)
				.Where(m => m.Hide == false)
                .OrderBy(m => m.Order)
                .ToList();
        }
    }
}