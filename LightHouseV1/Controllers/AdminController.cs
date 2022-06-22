using LightHouseV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Lightkeeper")]

        public async Task<IActionResult> Main()
        {
            var gastoRewards = await _context.Rewards.SumAsync(x => x.BuyPrice);
            ViewBag.GastosRewards = gastoRewards / 100;
            var gastoSends = await _context.Sends.SumAsync(x => x.SendPrice);
            ViewBag.GastosSends = gastoSends / 100;
            ViewBag.GastosTotales = (gastoRewards + gastoSends) / 100;
            return View();
        }
    }
}
