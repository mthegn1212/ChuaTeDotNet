using Microsoft.EntityFrameworkCore;
using BatDongSan.Services;
using BatDongSan.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container.
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<NewsService>(); // Đăng ký NewsService
builder.Services.AddScoped<ProjectService>(); // Đăng ký NewsService
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Cấu hình pipeline yêu cầu HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Thêm routing cho listing
app.MapControllerRoute(
    name: "listing",
    pattern: "listing",
    defaults: new { controller = "Listing", action = "Index" });

// Thêm routing cho about
app.MapControllerRoute(
    name: "PostNew",
    pattern: "PostNew",
    defaults: new { controller = "Listing", action = "PostNew" });

// Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Route cho tin tức
app.MapControllerRoute(
    name: "news",
    pattern: "news",
    defaults: new { controller = "News", action = "Index" });

app.MapControllerRoute(
    name: "signIn",
    pattern: "signIn",
    defaults: new { controller = "SignIn", action = "Index" });

app.Run();
