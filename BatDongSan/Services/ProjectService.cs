using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
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

        public List<Project> GetAllProject()
        {
            return _context.Projects
                .Where(m => !m.Hide)
                .OrderBy(m => m.Order)
                .ToList();
        }
        public List<Project> GetTop5()
        {
            return _context.Projects
                .Where(m => !m.Hide)
                .OrderBy(m => m.DateUp)
                .Take(5)
                .ToList();
        }
        public List<Project> GetRentPro()
        {
            return _context.Projects
                .Where(m => !m.Hide && m.Type == 0) 
                .OrderBy(m => m.Order)
                .ToList();
        }
        public List<Project> GetSalePro()
        {
            return _context.Projects
                .Where(m => !m.Hide && m.Type == 1) 
                .OrderBy(m => m.Order)
                .ToList();
        }
        public Project find(int id)
        {
            return _context.Projects
				.FirstOrDefault(m => m.Id == id);
		}
    }
}