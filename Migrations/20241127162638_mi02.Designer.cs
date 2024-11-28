﻿// <auto-generated />
using System;
using BatDongSan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BatDongSan.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241127162638_mi02")]
    partial class mi02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BatDongSan.Models.ChildMenus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Hide")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("ChildMenus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateBegin = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(969),
                            Hide = false,
                            Link = "/RentListing",
                            MenuItemId = 2,
                            Meta = "rentlisting",
                            Name = "RentListing",
                            Order = 1
                        },
                        new
                        {
                            Id = 2,
                            DateBegin = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(971),
                            Hide = false,
                            Link = "/SaleListing",
                            MenuItemId = 2,
                            Meta = "salelisting",
                            Name = "SaleListing",
                            Order = 2
                        });
                });

            modelBuilder.Entity("BatDongSan.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Hide")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MenuItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateBegin = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(872),
                            Hide = false,
                            Link = "/",
                            Meta = "home",
                            Name = "Home",
                            Order = 1
                        },
                        new
                        {
                            Id = 2,
                            DateBegin = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(887),
                            Hide = false,
                            Link = "/listing",
                            Meta = "listing",
                            Name = "Listing",
                            Order = 2
                        },
                        new
                        {
                            Id = 3,
                            DateBegin = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(889),
                            Hide = false,
                            Link = "/news",
                            Meta = "news",
                            Name = "News",
                            Order = 3
                        },
                        new
                        {
                            Id = 4,
                            DateBegin = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(890),
                            Hide = false,
                            Link = "/PostNew",
                            Meta = "Post-New",
                            Name = "PostNew",
                            Order = 4
                        });
                });

            modelBuilder.Entity("BatDongSan.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateUp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Hide")
                        .HasColumnType("bit");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Celebrate the grand opening of Lạc Long Quân Tower, the new landmark in Hà Nội.",
                            DateUp = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(991),
                            Detail = "Lạc Long Quân Tower offers luxury apartments with premium amenities for a modern lifestyle.",
                            Hide = false,
                            ImagePath = "/images/news/laclongquan-tower.jpg",
                            Link = "/news/laclongquan-tower-opening",
                            Meta = "-1",
                            Order = 1,
                            Title = "Grand Opening of Lạc Long Quân Tower"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Discover the perfect blend of nature and modern living at Green Home Hà Nội.",
                            DateUp = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(995),
                            Detail = "Green Home Hà Nội features lush gardens, eco-friendly designs, and convenient facilities.",
                            Hide = false,
                            ImagePath = "/images/news/green-home.jpg",
                            Link = "/news/green-home-hanoi",
                            Meta = "-2",
                            Order = 2,
                            Title = "Green Living in the Heart of Hà Nội"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Experience unparalleled luxury at the newly launched apartments in the city center.",
                            DateUp = new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(997),
                            Detail = "Our new apartments redefine elegance with state-of-the-art designs and facilities.",
                            Hide = true,
                            ImagePath = "/images/news/luxury-apartments.jpg",
                            Link = "/news/luxury-apartments",
                            Meta = "-3",
                            Order = 3,
                            Title = "Luxury Apartments Now Available"
                        });
                });

            modelBuilder.Entity("BatDongSan.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hide")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UploadedImagePaths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("upById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BatDongSan.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 11, 27, 23, 26, 37, 825, DateTimeKind.Local).AddTicks(3288),
                            Email = "admin@gmail.com",
                            Password = "d0nWdZT7RBzOZ3n40yMqiA==:um9ZgiBEaF6lLJksPSKf47XZWs8cxEkubL9R1PabImA=",
                            Role = "admin",
                            UserName = "Minh Thắng"
                        });
                });

            modelBuilder.Entity("BatDongSan.Models.ChildMenus", b =>
                {
                    b.HasOne("BatDongSan.Models.MenuItem", "MenuItem")
                        .WithMany("ChildMenus")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("BatDongSan.Models.MenuItem", b =>
                {
                    b.Navigation("ChildMenus");
                });
#pragma warning restore 612, 618
        }
    }
}
