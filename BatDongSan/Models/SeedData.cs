using Microsoft.EntityFrameworkCore;
using System;

namespace BatDongSan.Models
{
	public static class SeedData
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MenuItem>().HasData(
				new MenuItem { Id = 1, Name = "Home", Link = "/", Meta = "home", Hide = false, Order = 1, DateBegin = DateTime.Now },
				new MenuItem { Id = 2, Name = "Listing", Link = "/listing", Meta = "listing", Hide = false, Order = 2, DateBegin = DateTime.Now },
				new MenuItem { Id = 3, Name = "News", Link = "/news", Meta = "news", Hide = false, Order = 3, DateBegin = DateTime.Now },
				new MenuItem { Id = 4, Name = "PostNew", Link = "/PostNew", Meta = "Post-New", Hide = false, Order = 4, DateBegin = DateTime.Now }
			);

			modelBuilder.Entity<ChildMenus>().HasData(
				new ChildMenus { Id = 1, Name = "RentListing", Link = "/RentListing", Meta = "rentlisting", Hide = false, Order = 1, DateBegin = DateTime.Now, MenuItemId = 2 },
				new ChildMenus { Id = 2, Name = "SaleListing", Link = "/SaleListing", Meta = "salelisting", Hide = false, Order = 2, DateBegin = DateTime.Now, MenuItemId = 2 }
			);

			modelBuilder.Entity<Project>().HasData(
				new Project 
				{ 
					Id = 1, 
					Name = "hú Gia Hưng ApartmentP", 
					Description = "A modern apartment complex", 
					Link = "/project/phugia", 
					Meta = "phugia", 
					Img = "/images/phugia.jpg", 
					Hide = false, 
					Order = 1, 
					Type = 1, 
					Locate = "Hồ Chí Minh", 
					Price = 1000000000, 
					Area = "80m²", 
					DateUp = DateTime.Now
				},
				new Project 
				{ 
					Id = 2, 
					Name = "Lạc Long Quân Tower", 
					Description = "A luxury residential tower", 
					Link = "/project/laclongquan", 
					Meta = "laclongquan", 
					Img = "/images/laclongquan.jpg", 
					Hide = false, 
					Order = 2, 
					Type = 2, 
					Locate = "Hà Nội", 
					Price = 2000000000, 
					Area = "100m²", 
					DateUp = DateTime.Now
				}
			);
		}
	}
}
