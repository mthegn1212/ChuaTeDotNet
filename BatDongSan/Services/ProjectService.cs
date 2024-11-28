using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;

namespace BatDongSan.Services
{
    public class ProjectService
    {
        private readonly MyDbContext _context;

        public ProjectService(MyDbContext context)
        {
            _context = context;
        }

        public List<Projects> GetAllProject()
        {
            return _context.Projects
                .Where(m => !m.Hide)
                .OrderBy(m => m.Order)
                .ToList();
        }

        public List<Projects> GetTop5()
        {
            return _context.Projects
                .Where(m => !m.Hide)
                .OrderBy(m => m.DateUp)
                .Take(5)
                .ToList();
        }

        public List<Projects> GetRentPro()
        {
            return _context.Projects    
                .Where(m => !m.Hide && m.Type == 0) 
                .OrderBy(m => m.Order)
                .ToList();
        }

        public List<Projects> GetSalePro()
        {
            return _context.Projects
                .Where(m => !m.Hide && m.Type == 1) 
                .OrderBy(m => m.Order)
                .ToList();
        }

        public Projects? Find(int id)
        {
            return _context.Projects
                .FirstOrDefault(m => m.Id == id && !m.Hide);
        }

        // Get project detail including images
        public Projects? GetProjectDetail(int id)
        {
            return _context.Projects
                .Where(m => m.Id == id && !m.Hide)
                .Include(p => p.ProjectImages)  // Include related ProjectImages
                .FirstOrDefault();
        }
    }
}