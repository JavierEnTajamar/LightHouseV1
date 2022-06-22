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
    public class RewardStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RewardStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RewardStatuses.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardStatus = await _context.RewardStatuses
                .FirstOrDefaultAsync(m => m.RewardStatusId == id);
            if (rewardStatus == null)
            {
                return NotFound();
            }

            return View(rewardStatus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RewardStatusId,RewardStatusType")] RewardStatus rewardStatus)
        {
            if (ModelState.IsValid)
            {
                rewardStatus.RewardStatusId = await _context.RewardStatuses.CountAsync() + 100;

                _context.Add(rewardStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewardStatus);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardStatus = await _context.RewardStatuses.FindAsync(id);
            if (rewardStatus == null)
            {
                return NotFound();
            }
            return View(rewardStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RewardStatusId,RewardStatusType")] RewardStatus rewardStatus)
        {
            if (id != rewardStatus.RewardStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardStatusExists(rewardStatus.RewardStatusId))
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
            return View(rewardStatus);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardStatus = await _context.RewardStatuses
                .FirstOrDefaultAsync(m => m.RewardStatusId == id);
            if (rewardStatus == null)
            {
                return NotFound();
            }

            return View(rewardStatus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rewardStatus = await _context.RewardStatuses.FindAsync(id);
            _context.RewardStatuses.Remove(rewardStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardStatusExists(int id)
        {
            return _context.RewardStatuses.Any(e => e.RewardStatusId == id);
        }
    }
}
