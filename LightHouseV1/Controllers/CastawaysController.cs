using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightHouseV1.Models;
using Microsoft.AspNetCore.Identity;

namespace LightHouseV1.Controllers
{
    public class CastawaysController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        public CastawaysController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Castaways.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castaway = await _context.Castaways
                .FirstOrDefaultAsync(m => m.CastawayId == id);
            if (castaway == null)
            {
                return NotFound();
            }

            return View(castaway);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CastawayId,CastawayTwitchName,CastawayName,CastawayLastName,CastawaySecondLastName,CastawayTelephone,CityName,CastawayPostalCode,CastawayRoadType,CastawayRoadName,CastawayHomeNumber,CastawayHomePortal,CastawayHomeFloor,CastawayHomeDoor")] Castaway castaway)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(castaway);
                castaway.CastawayId = await _context.Castaways.CountAsync() + 100;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Castaways");
            }
            return View(castaway);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castaway = await _context.Castaways.FindAsync(id);
            if (castaway == null)
            {
                return NotFound();
            }
            return View(castaway);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CastawayId,CastawayTwitchName,CastawayName,CastawayLastName,CastawaySecondLastName,CastawayTelephone,CityName,CastawayPostalCode,CastawayRoadType,CastawayRoadName,CastawayHomeNumber,CastawayHomePortal,CastawayHomeFloor,CastawayHomeDoor")] Castaway castaway)
        {
            if (id != castaway.CastawayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(castaway);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(castaway);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castaway = await _context.Castaways
                .FirstOrDefaultAsync(m => m.CastawayId == id);
            if (castaway == null)
            {
                return NotFound();
            }

            return View(castaway);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var castaway = await _context.Castaways.FindAsync(id);
            _context.Castaways.Remove(castaway);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastawayExists(int id)
        {
            return _context.Castaways.Any(e => e.CastawayId == id);
        }
    }
}
