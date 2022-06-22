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
    public class RewardCompositionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RewardCompositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RewardCompositions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardComposition = await _context.RewardCompositions
                .FirstOrDefaultAsync(m => m.RewardCompositionId == id);
            if (rewardComposition == null)
            {
                return NotFound();
            }

            return View(rewardComposition);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RewardCompositionId,RewardComponents")] RewardComposition rewardComposition)
        {
            if (ModelState.IsValid)
            {
                rewardComposition.RewardCompositionId = await _context.RewardCompositions.CountAsync() + 100;
                _context.Add(rewardComposition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewardComposition);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardComposition = await _context.RewardCompositions.FindAsync(id);
            if (rewardComposition == null)
            {
                return NotFound();
            }
            return View(rewardComposition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RewardCompositionId,RewardComponents")] RewardComposition rewardComposition)
        {
            if (id != rewardComposition.RewardCompositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardComposition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardCompositionExists(rewardComposition.RewardCompositionId))
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
            return View(rewardComposition);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardComposition = await _context.RewardCompositions
                .FirstOrDefaultAsync(m => m.RewardCompositionId == id);
            if (rewardComposition == null)
            {
                return NotFound();
            }

            return View(rewardComposition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rewardComposition = await _context.RewardCompositions.FindAsync(id);
            _context.RewardCompositions.Remove(rewardComposition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardCompositionExists(int id)
        {
            return _context.RewardCompositions.Any(e => e.RewardCompositionId == id);
        }
    }
}
