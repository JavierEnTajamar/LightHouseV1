using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightHouseV1.Models;

namespace LightHouseV1.Controllers
{
    public class ClaimedBiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimedBiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaimedBys.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimedBy = await _context.ClaimedBys
                .FirstOrDefaultAsync(m => m.ClaimedById == id);
            if (claimedBy == null)
            {
                return NotFound();
            }

            return View(claimedBy);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimedById,ClaimedByType")] ClaimedBy claimedBy)
        {
            if (ModelState.IsValid)
            {
                claimedBy.ClaimedById = await _context.ClaimedBys.CountAsync() + 100;

                _context.Add(claimedBy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claimedBy);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimedBy = await _context.ClaimedBys.FindAsync(id);
            if (claimedBy == null)
            {
                return NotFound();
            }
            return View(claimedBy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimedById,ClaimedByType")] ClaimedBy claimedBy)
        {
            if (id != claimedBy.ClaimedById)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimedBy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimedByExists(claimedBy.ClaimedById))
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
            return View(claimedBy);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimedBy = await _context.ClaimedBys
                .FirstOrDefaultAsync(m => m.ClaimedById == id);
            if (claimedBy == null)
            {
                return NotFound();
            }

            return View(claimedBy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claimedBy = await _context.ClaimedBys.FindAsync(id);
            _context.ClaimedBys.Remove(claimedBy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimedByExists(int id)
        {
            return _context.ClaimedBys.Any(e => e.ClaimedById == id);
        }
    }
}
