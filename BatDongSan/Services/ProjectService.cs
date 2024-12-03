using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BatDongSan.Services
{
    public class ProjectService
    {
        private readonly MyDbContext _context;

        public ProjectService(MyDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả các dự án không bị ẩn
        public List<Projects> GetAllProject()
        {
            return _context.Projects
                .Where(m => !m.Hide)
                .OrderBy(m => m.Order)
                .ToList();
        }

        // Lấy 5 dự án mới nhất
        public List<Projects> GetTop5()
        {
            return _context.Projects
                .Where(m => !m.Hide)
                .OrderBy(m => m.DateUp)
                .Take(5)
                .ToList();
        }

        // Lấy các dự án cho thuê (Type = 0)
        public List<Projects> GetRentPro()
        {
            return _context.Projects    
                .Where(m => !m.Hide && m.Type == 0) 
                .OrderBy(m => m.Order)
                .ToList();
        }

        // Lấy các dự án bán (Type = 1)
        public List<Projects> GetSalePro()
        {
            return _context.Projects
                .Where(m => !m.Hide && m.Type == 1) 
                .OrderBy(m => m.Order)
                .ToList();
        }

        // Tìm kiếm một dự án theo ID
        public Projects? Find(int id)
        {
            return _context.Projects
                .FirstOrDefault(m => m.Id == id && !m.Hide);
        }

        // Lấy chi tiết dự án bao gồm các hình ảnh
        public Projects? GetProjectDetail(int id)
        {
            return _context.Projects
                .Where(m => m.Id == id && !m.Hide)
                .FirstOrDefault();
        }
    }
}