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
        public DbSet<News> News { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Users> Users { get; set; }
		public DbSet<ChildMenus> ChildMenus { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			SeedData.Seed(modelBuilder);
		}
	}
}
