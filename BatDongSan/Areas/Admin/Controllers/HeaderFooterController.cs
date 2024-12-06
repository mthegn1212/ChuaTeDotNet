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
    public class HeaderFooterController : Controller
    {
        private readonly MyDbContext _context;

        public HeaderFooterController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HeaderFooter
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeaderFooter.ToListAsync());
        }

        // GET: Admin/HeaderFooter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerFooter = await _context.HeaderFooter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headerFooter == null)
            {
                return NotFound();
            }

            return View(headerFooter);
        }

        // GET: Admin/HeaderFooter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HeaderFooter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsVisible,Content,DateCreate")] HeaderFooter headerFooter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headerFooter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headerFooter);
        }

        // GET: Admin/HeaderFooter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerFooter = await _context.HeaderFooter.FindAsync(id);
            if (headerFooter == null)
            {
                return NotFound();
            }
            return View(headerFooter);
        }

        // POST: Admin/HeaderFooter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsVisible,Content,DateCreate")] HeaderFooter headerFooter)
        {
            if (id != headerFooter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headerFooter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeaderFooterExists(headerFooter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(headerFooter);
        }

        // GET: Admin/HeaderFooter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerFooter = await _context.HeaderFooter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headerFooter == null)
            {
                return NotFound();
            }

            return View(headerFooter);
        }

        // POST: Admin/HeaderFooter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headerFooter = await _context.HeaderFooter.FindAsync(id);
            if (headerFooter != null)
            {
                _context.HeaderFooter.Remove(headerFooter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeaderFooterExists(int id)
        {
            return _context.HeaderFooter.Any(e => e.Id == id);
        }
    }
}
