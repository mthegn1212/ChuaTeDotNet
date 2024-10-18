using Microsoft.EntityFrameworkCore;
using BatDongSan.Models;

namespace BatDongSan.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<News> News { get; set; } // Thêm DbSet cho News
        public DbSet<Project> Projects { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
