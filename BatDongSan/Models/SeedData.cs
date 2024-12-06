using Microsoft.EntityFrameworkCore;
using System;
using BatDongSan.Helpers;

namespace BatDongSan.Models
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1, Name = "Home", Link = "/", Meta = "home", Hide = false, Order = 1, DateBegin = DateTime.Now
                },
                new MenuItem
                {
                    Id = 2, Name = "Listing", Link = "/listing", Meta = "listing", Hide = false, Order = 2,
                    DateBegin = DateTime.Now
                },
                new MenuItem
                {
                    Id = 3, Name = "News", Link = "/news", Meta = "news", Hide = false, Order = 3,
                    DateBegin = DateTime.Now
                },
                new MenuItem
                {
                    Id = 4, Name = "PostProject", Link = "/PostProject", Meta = "post-project", Hide = false, Order = 4,
                    DateBegin = DateTime.Now
                },
                new MenuItem
                {
                    Id = 5, Name = "Project Management", Link = "/ProjectManagement", Meta = "project-management",
                    Hide = false, Order = 5, DateBegin = DateTime.Now
                }
            );

            modelBuilder.Entity<ChildMenus>().HasData(
                new ChildMenus
                {
                    Id = 1, Name = "RentListing", Link = "/RentListing", Meta = "rentlisting", Hide = false, Order = 1,
                    DateBegin = DateTime.Now, MenuItemId = 2
                },
                new ChildMenus
                {
                    Id = 2, Name = "SaleListing", Link = "/SaleListing", Meta = "salelisting", Hide = false, Order = 2,
                    DateBegin = DateTime.Now, MenuItemId = 2
                }
            );

            modelBuilder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Title = "Grand Opening of Lạc Long Quân Tower",
                    Content = "Celebrate the grand opening of Lạc Long Quân Tower, the new landmark in Hà Nội.",
                    Detail =
                        "Lạc Long Quân Tower offers luxury apartments with premium amenities for a modern lifestyle.",
                    Link = "/news/laclongquan-tower-opening",
                    Meta = "-1",
                    Hide = false,
                    Order = 1,
                    ImagePath = "/images/news/laclongquan-tower.jpg",
                    DateUp = DateTime.Now
                },
                new News
                {
                    Id = 2,
                    Title = "Green Living in the Heart of Hà Nội",
                    Content = "Discover the perfect blend of nature and modern living at Green Home Hà Nội.",
                    Detail =
                        "Green Home Hà Nội features lush gardens, eco-friendly designs, and convenient facilities.",
                    Link = "/news/green-home-hanoi",
                    Meta = "-2",
                    Hide = false,
                    Order = 2,
                    ImagePath = "/images/news/green-home.jpg",
                    DateUp = DateTime.Now
                },
                new News
                {
                    Id = 3,
                    Title = "Luxury Apartments Now Available",
                    Content = "Experience unparalleled luxury at the newly launched apartments in the city center.",
                    Detail = "Our new apartments redefine elegance with state-of-the-art designs and facilities.",
                    Link = "/news/luxury-apartments",
                    Meta = "-3",
                    Hide = true,
                    Order = 3,
                    ImagePath = "/images/news/luxury-apartments.jpg",
                    DateUp = DateTime.Now
                }
            );

            // Sửa lại phần thêm Users vào đúng Entity
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    UserName = "Minh Thắng",
                    Email = "admin@gmail.com",
                    Password = PasswordHelper.HashPassword("Thang123"), // Kiểm tra phương thức HashPassword
                    Role = "admin",
                    CreatedAt = DateTime.Now
                }
            );
            // Thêm dữ liệu cho HeaderFooter
            modelBuilder.Entity<HeaderFooter>().HasData(
                new HeaderFooter
                {
                    Id = 1,
                    IsVisible = true,
                    Content = "GoodLands",
                    DateCreate = DateTime.Now
                },
                new HeaderFooter
                {
                    Id = 2,
                    IsVisible = true,
                    Content = "0942 824 505",
                    DateCreate = DateTime.Now
                },
                new HeaderFooter
                {
                    Id = 3,
                    IsVisible = true,
                    Content = "GoodLands@gmail.com",
                    DateCreate = DateTime.Now
                },
                new HeaderFooter
                {
                    Id = 4,
                    IsVisible = true,
                    Content = "Far far away, behind the word mountains, far from the countries.",
                    DateCreate = DateTime.Now
                },
                new HeaderFooter
                {
                    Id = 5,
                    IsVisible = true,
                    Content = "Welcome, ",
                    DateCreate = DateTime.Now
                }
            );
        }
    }
}