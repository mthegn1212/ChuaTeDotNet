using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BatDongSan.Models;

namespace BatDongSan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly MyDbContext _context;

        public NewsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: Admin/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Admin/News/Create
        public IActionResult Create()
        {
            var news = new News
            {
                DateUp = DateTime.Now // Gán giá trị ngày hiện tại cho DateUp
            };
    
            return View(news);
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Admin/News/Create
        // POST: Admin/News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                // Gán giá trị DateUp là ngày hiện tại khi tạo mới
                news.DateUp = DateTime.Now;

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Quay lại danh sách
            }

            // Trả về lại view "Details" nhưng với đối tượng news đầy đủ
            return View(news); // Truyền đối tượng news vào view
        }

        // GET: Admin/News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Detail,ImagePath,Link,Meta,Hide,Order")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Cập nhật giá trị DateUp nếu cần thiết
                    news.DateUp = DateTime.Now;

                    // Cập nhật thông tin bản tin
                    _context.Update(news);
                    await _context.SaveChangesAsync();

                    // Sau khi cập nhật thành công, chuyển hướng đến trang Details
                    return RedirectToAction("Details", new { id = news.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            // Trả về view Edit nếu có lỗi xác thực
            return View(news);
        }

        // GET: Admin/News/Delete/5
        // POST: Admin/News/Delete/5
        // POST: Admin/News/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }

            // Return a JSON response indicating success
            return Json(new { success = true });
        }
        
        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
