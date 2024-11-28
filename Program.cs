using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BatDongSan.Services;
using BatDongSan.Models;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container.
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<ProjectService>();

// Thêm DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();

// Thêm Razor Pages (nếu sử dụng)
builder.Services.AddRazorPages();

// Thêm session và distributed memory cache
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set thời gian hết hạn session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Thêm MVC controllers và views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline yêu cầu HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

// Thêm middleware authentication và authorization
app.UseAuthentication();
app.UseAuthorization();

// Định nghĩa routing
// Route cho Areas
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");

// Route cho các chức năng cụ thể
app.MapControllerRoute(
    name: "listing",
    pattern: "listing",
    defaults: new { controller = "Listing", action = "Index" });

app.MapControllerRoute(
    name: "postNew",
    pattern: "postNew",
    defaults: new { controller = "Listing", action = "PostNew" });

app.MapControllerRoute(
    name: "news",
    pattern: "news",
    defaults: new { controller = "News", action = "Index" });

app.MapControllerRoute(
    name: "signIn",
    pattern: "signIn",
    defaults: new { controller = "SignIn", action = "Login" });

// Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages (nếu có sử dụng)
app.MapRazorPages();

app.Run();
