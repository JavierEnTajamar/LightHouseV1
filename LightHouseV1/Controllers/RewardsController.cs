using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightHouseV1.Models;
using LightHouseV1.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LightHouseV1.Controllers
{
    [Authorize(Roles = "Castaway, Lightkeeper")]
    public class RewardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RewardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Rewards.Include(x => x.RewardType).Include(x => x.Castaway).Include(x => x.ClaimedBy)
                .Include(x => x.RewardComposition).Include(x => x.Template).Include(x => x.RewardStatus).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reward = await _context.Rewards
                .FirstOrDefaultAsync(m => m.RewardId == id);
            if (reward == null)
            {
                return NotFound();
            }

            return View(reward);
        }

        public async Task<IActionResult> Create()
        {
            var rewardTypeDisplay = await _context.RewardTypes.Select(x => new
            {
                Id = x.RewardTypeId,
                Value = x.RewardTypeName
            }).ToListAsync();

            var castawayDisplay = await _context.Castaways.Select(x => new
            {
                Id = x.CastawayId,
                Value = x.CastawayTwitchName
            }).ToListAsync();

            var claimedByDisplay = await _context.ClaimedBys.Select(x => new
            {
                Id = x.ClaimedById,
                Value = x.ClaimedByType
            }).ToListAsync();

            var templateDisplay = await _context.Templates.Select(x => new
            {
                Id = x.TemplateId,
                Value = x.TemplateName
            }).ToListAsync();
            var rewardCompositionDisplay = await _context.RewardCompositions.Select(x => new
            {
                Id = x.RewardCompositionId,
                Value = x.RewardComponents
            }).ToListAsync();
            var rewardStatusDisplay = await _context.RewardStatuses.Select(x => new
            {
                Id = x.RewardStatusId,
                Value = x.RewardStatusType
            }).ToListAsync();

            AddRewardSettingsViewModel vm = new AddRewardSettingsViewModel();

            vm.RewardTypeList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardTypeDisplay, "Id", "Value");
            vm.CastawayList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(castawayDisplay, "Id", "Value");
            vm.ClaimedByList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(claimedByDisplay, "Id", "Value");
            vm.TemplateList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(templateDisplay, "Id", "Value");
            vm.RewardCompositionList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardCompositionDisplay, "Id", "Value");
            vm.RewardStatusList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardStatusDisplay, "Id", "Value");

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddRewardSettingsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var rewardType = await _context.RewardTypes.SingleOrDefaultAsync(i => i.RewardTypeId == vm.RewardType.RewardTypeId);
                var castaway = await _context.Castaways.SingleOrDefaultAsync(i => i.CastawayId == vm.Castaway.CastawayId);
                var claimedBy = await _context.ClaimedBys.SingleOrDefaultAsync(i => i.ClaimedById == vm.ClaimedBy.ClaimedById);
                var template = await _context.Templates.SingleOrDefaultAsync(i => i.TemplateId == vm.Template.TemplateId);
                var rewardComposition = await _context.RewardCompositions.SingleOrDefaultAsync(i => i.RewardCompositionId == vm.RewardComposition.RewardCompositionId);
                var rewardStatus = await _context.RewardStatuses.SingleOrDefaultAsync(i => i.RewardStatusId == vm.RewardStatus.RewardStatusId);
                vm.Reward.RewardType = rewardType;
                vm.Reward.Castaway = castaway;
                vm.Reward.ClaimedBy = claimedBy;
                vm.Reward.Template = template;
                vm.Reward.RewardComposition = rewardComposition;
                vm.Reward.RewardStatus = rewardStatus;
                vm.Reward.RewardId = await _context.Rewards.CountAsync() + 100;
                _context.Add(vm.Reward);
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

            var reward = await _context.Rewards.Where(x => x.RewardId == id).Include(x => x.RewardType).Include(x => x.Castaway).Include(x => x.ClaimedBy)
                .Include(x => x.RewardComposition).Include(x => x.Template).Include(x => x.RewardStatus).FirstOrDefaultAsync();
            if (reward == null)
            {
                return NotFound();
            }
            var rewardTypeDisplay = await _context.RewardTypes.Select(x => new
            {
                Id = x.RewardTypeId,
                Value = x.RewardTypeName
            }).ToListAsync();

            var castawayDisplay = await _context.Castaways.Select(x => new
            {
                Id = x.CastawayId,
                Value = x.CastawayTwitchName
            }).ToListAsync();

            var claimedByDisplay = await _context.ClaimedBys.Select(x => new
            {
                Id = x.ClaimedById,
                Value = x.ClaimedByType
            }).ToListAsync();

            var templateDisplay = await _context.Templates.Select(x => new
            {
                Id = x.TemplateId,
                Value = x.TemplateName
            }).ToListAsync();
            var rewardCompositionDisplay = await _context.RewardCompositions.Select(x => new
            {
                Id = x.RewardCompositionId,
                Value = x.RewardComponents
            }).ToListAsync();
            var rewardStatusDisplay = await _context.RewardStatuses.Select(x => new
            {
                Id = x.RewardStatusId,
                Value = x.RewardStatusType
            }).ToListAsync();

            AddRewardSettingsViewModel vm = new AddRewardSettingsViewModel();

            vm.RewardTypeList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardTypeDisplay, "Id", "Value");
            vm.CastawayList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(castawayDisplay, "Id", "Value");
            vm.ClaimedByList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(claimedByDisplay, "Id", "Value");
            vm.TemplateList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(templateDisplay, "Id", "Value");
            vm.RewardCompositionList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardCompositionDisplay, "Id", "Value");
            vm.RewardStatusList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(rewardStatusDisplay, "Id", "Value");


            vm.Reward = reward;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddRewardSettingsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var rewardType = await _context.RewardTypes.SingleOrDefaultAsync(i => i.RewardTypeId == vm.Reward.RewardType.RewardTypeId);
                var castaway = await _context.Castaways.SingleOrDefaultAsync(i => i.CastawayId == vm.Reward.Castaway.CastawayId);
                var claimedBy = await _context.ClaimedBys.SingleOrDefaultAsync(i => i.ClaimedById == vm.Reward.ClaimedBy.ClaimedById);
                var template = await _context.Templates.SingleOrDefaultAsync(i => i.TemplateId == vm.Reward.Template.TemplateId);
                var rewardComposition = await _context.RewardCompositions.SingleOrDefaultAsync(i => i.RewardCompositionId == vm.Reward.RewardComposition.RewardCompositionId);
                var rewardStatus = await _context.RewardStatuses.SingleOrDefaultAsync(i => i.RewardStatusId == vm.Reward.RewardStatus.RewardStatusId);
                vm.Reward.RewardType = rewardType;
                vm.Reward.Castaway = castaway;
                vm.Reward.ClaimedBy = claimedBy;
                vm.Reward.Template = template;
                vm.Reward.RewardComposition = rewardComposition;
                vm.Reward.RewardStatus = rewardStatus;

                var editedReward = vm.Reward;

                _context.Rewards.Update(editedReward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reward = await _context.Rewards
                .FirstOrDefaultAsync(m => m.RewardId == id);
            if (reward == null)
            {
                return NotFound();
            }

            return View(reward);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reward = await _context.Rewards.FindAsync(id);

            SendContent sendContentToDelete = _context.SendContents.Where(x => x.Reward == reward).FirstOrDefault();

            if (sendContentToDelete != null)
            {
                _context.SendContents.Remove(sendContentToDelete);
            }

            _context.Rewards.Remove(reward);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardExists(int id)
        {
            return _context.Rewards.Any(e => e.RewardId == id);
        }
        [Authorize(Roles = "Castaway, Lightkeeper")]
        public async Task<IActionResult> Certified(int? id)
        {
            var reward = await _context.Rewards.Include(x => x.RewardType)
                .Include(x => x.Template).Include(x => x.Castaway).Include(x => x.ClaimedBy)
                .Include(x => x.RewardComposition).Include(x => x.RewardStatus)
                .Where(x => x.RewardId == id).SingleOrDefaultAsync();            
            var pepe = await _context.Rewards.Where(x => x.RewardType == reward.RewardType).ToListAsync();
            ViewBag.orderNumber = pepe.IndexOf(reward) +1;
            return View(reward);
        }
    }
}
