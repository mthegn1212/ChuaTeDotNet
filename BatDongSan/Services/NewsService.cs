using BatDongSan.Models;

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
            .Where(n => !n.Hide) // Lọc những tin tức không bị ẩn
            .OrderBy(n => n.Order) // Sắp xếp theo thứ tự
            .ToList(); // Chuyển đổi thành danh sách
    }
    public List<News> GetTop4()
    {
        return _context.News
            .Where(n => !n.Hide) // Lọc những tin tức không bị ẩn
            .OrderBy(n => n.Order)
            .Take(4)// Sắp xếp theo thứ tự
            .ToList(); // Chuyển đổi thành danh sách
    }
}
