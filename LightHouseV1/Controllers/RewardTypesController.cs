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
    public class RewardTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RewardTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RewardTypes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardType = await _context.RewardTypes
                .FirstOrDefaultAsync(m => m.RewardTypeId == id);
            if (rewardType == null)
            {
                return NotFound();
            }

            return View(rewardType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RewardTypeId,RewardTypeName")] RewardType rewardType)
        {
            if (ModelState.IsValid)
            {
                rewardType.RewardTypeId = await _context.RewardTypes.CountAsync() + 100;

                _context.Add(rewardType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewardType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardType = await _context.RewardTypes.FindAsync(id);
            if (rewardType == null)
            {
                return NotFound();
            }
            return View(rewardType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RewardTypeId,RewardTypeName")] RewardType rewardType)
        {
            if (id != rewardType.RewardTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardTypeExists(rewardType.RewardTypeId))
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
            return View(rewardType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardType = await _context.RewardTypes
                .FirstOrDefaultAsync(m => m.RewardTypeId == id);
            if (rewardType == null)
            {
                return NotFound();
            }

            return View(rewardType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rewardType = await _context.RewardTypes.FindAsync(id);
            _context.RewardTypes.Remove(rewardType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardTypeExists(int id)
        {
            return _context.RewardTypes.Any(e => e.RewardTypeId == id);
        }
    }
}
