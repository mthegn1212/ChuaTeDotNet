using BatDongSan.Models;

namespace BatDongSan.Services
{
    public class NewsService
    {
        private readonly MyDbContext _context;

        public NewsService(MyDbContext context)
        {
            _context = context;
        }

        public List<News> GetAllNews()
        {
            return _context.News
                .Where(n => n.Hide != true) // Filters out 'null' and 'true' values
                .OrderBy(n => n.Order) // Sắp xếp theo thứ tự
                .ToList(); // Chuyển đổi thành danh sách
        }

        public List<News> GetTop4()
        {
            return _context.News
                .Where(n => n.Hide != true) // Filters out 'null' and 'true' values
                .OrderBy(n => n.Order)
                .Take(4) // Sắp xếp theo thứ tự
                .ToList(); // Chuyển đổi thành danh sách
        }

    }
}