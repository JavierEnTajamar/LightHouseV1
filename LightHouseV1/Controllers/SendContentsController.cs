using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightHouseV1.Models;
using LightHouseV1.ViewModels;

namespace LightHouseV1.Controllers
{
    public class SendContentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendContentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SendContents.Include(x => x.Send).Include(x => x.Reward).Include(x => x.Reward.Castaway).Include(x => x.Reward.RewardType).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendContent = await _context.SendContents
                .FirstOrDefaultAsync(m => m.SendContentId == id);
            if (sendContent == null)
            {
                return NotFound();
            }

            return View(sendContent);
        }

        public async Task<IActionResult> Create()
        {
            var sendDisplay = await _context.Sends.Select(x => new
            {
                Id = x.SendId,
                Value = x.SendName
            }).ToListAsync();
            var rewardDisplay = await _context.Rewards.Include(x => x.Castaway).Include(x => x.RewardType).Select(x => new
            {
                Id = x.RewardId,
                Value = x.Castaway.CastawayTwitchName + " " + x.RewardType.RewardTypeName
            }).ToListAsync();

            AddSendContent vm = new AddSendContent();

            vm.SendList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(sendDisplay, "Id", "Value");
            vm.RewardList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardDisplay, "Id", "Value");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSendContent vm)
        {
            if (ModelState.IsValid)
            {
                //var rewardComposition = await _context.RewardCompositions.SingleOrDefaultAsync(i => i.RewardCompositionId == vm.RewardComposition.RewardCompositionId);
                //var rewardStatus = await _context.RewardStatuses.SingleOrDefaultAsync(i => i.RewardStatusId == vm.RewardStatus.RewardStatusId);
                //vm.Reward.RewardType = rewardType;
                //vm.Reward.Castaway = castaway;
                SendContent objectToAdd = new SendContent();

                var sendInContent = await _context.Sends.SingleOrDefaultAsync(i => i.SendId == vm.Send.SendId);
                var rewardInContent = await _context.Rewards.Include(x => x.Castaway).SingleOrDefaultAsync(i => i.RewardId == vm.Reward.RewardId);
                objectToAdd.Send = sendInContent;
                objectToAdd.Reward = rewardInContent;

                
                objectToAdd.SendContentId = await _context.SendContents.CountAsync() + 100;
                _context.SendContents.Add(objectToAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendContent = await _context.SendContents.FindAsync(id);
            if (sendContent == null)
            {
                return NotFound();
            }
            return View(sendContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendTypeId")] SendContent sendContent)
        {
            if (id != sendContent.SendContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendContentExists(sendContent.SendContentId))
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
            return View(sendContent);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendContent = await _context.SendContents
                .FirstOrDefaultAsync(m => m.SendContentId == id);
            if (sendContent == null)
            {
                return NotFound();
            }

            return View(sendContent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendContent = await _context.SendContents.FindAsync(id);
            _context.SendContents.Remove(sendContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendContentExists(int id)
        {
            return _context.SendContents.Any(e => e.SendContentId == id);
        }
    }
}
