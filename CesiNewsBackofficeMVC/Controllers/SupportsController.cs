using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CesiNewsModel.Context;
using CesiNewsModel.Entities;

namespace CesiNewsBackofficeMVC.Controllers
{
    public class SupportsController : Controller
    {
        private readonly NewsDbContext _context;

        public SupportsController(NewsDbContext context)
        {
            _context = context;
        }

        // GET: Supports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supports.ToListAsync());
        }

        // GET: Supports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support = await _context.Supports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (support == null)
            {
                return NotFound();
            }

            return View(support);
        }

        // GET: Supports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support = await _context.Supports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (support == null)
            {
                return NotFound();
            }

            return View(support);
        }

        // POST: Supports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var support = await _context.Supports.FindAsync(id);
            if (support != null)
            {
                _context.Supports.Remove(support);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportExists(int id)
        {
            return _context.Supports.Any(e => e.Id == id);
        }
    }
}
