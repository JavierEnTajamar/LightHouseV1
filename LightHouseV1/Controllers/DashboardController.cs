using LightHouseV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LightHouseV1.Controllers
{
    [Authorize(Roles = "Castaway, Lightkeeper")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var loggedUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(await _db.Castaways.Where(x => x.User.Id == loggedUser).SingleOrDefaultAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Profile(int id, [Bind("CastawayId,CastawayTwitchName,CastawayName,CastawayLastName,CastawaySecondLastName,CastawayTelephone,CityName,CastawayPostalCode,CastawayRoadType,CastawayRoadName,CastawayHomeNumber,CastawayHomePortal,CastawayHomeFloor,CastawayHomeDoor")] Castaway castaway)
        {
            if (id != castaway.CastawayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                    
                    _db.Update(castaway);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastawayExists(castaway.CastawayId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Profile));
            }
            return View(castaway);                
        }
        [HttpGet]
        public async Task<IActionResult> Main()
        {
            var loggedUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Castaway castaway = await _db.Castaways.Where(x => x.User.Id == loggedUser).SingleOrDefaultAsync();
            var castawayRewards = await _db.Rewards.Where(x => x.Castaway.User.Id == loggedUser).Include(x => x.RewardType).Include(x => x.Castaway).Include(x => x.ClaimedBy)
                .Include(x => x.RewardComposition).Include(x => x.Template).Include(x => x.RewardStatus).ToListAsync();

            ViewBag.Rewards = castawayRewards;
            ViewBag.TotalRewards = castawayRewards.Count();
            ViewBag.DiferentRewards = castawayRewards.GroupBy(x => x.RewardType).Select(x => x.First()).ToList().Count();
            return View(castaway);
        }

        private bool CastawayExists(int id)
        {
            return _db.Castaways.Any(e => e.CastawayId == id);
        }
    }
}
