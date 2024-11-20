using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BatDongSan.Services;
using BatDongSan.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container.
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<NewsService>(); // Đăng ký NewsService
builder.Services.AddScoped<ProjectService>(); // Đăng ký ProjectService

// Thêm DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();

// Add Razor Pages service (fix for the error)
builder.Services.AddRazorPages(); // This is necessary for Razor Pages to work

// Add session and distributed memory cache for session management
builder.Services.AddDistributedMemoryCache(); // For session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add MVC controllers and views
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
app.UseSession(); // Important for session state

app.UseRouting();

// Add authentication and authorization middleware
app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();  // Add authorization middleware

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
    pattern: "SignIn",
    defaults: new { controller = "SignIn", action = "Login" });

// Ensure Razor Pages service is added
app.MapRazorPages(); // This will map Razor Pages if you're using them

app.Run();

