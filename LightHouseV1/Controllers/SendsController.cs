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
    public class SendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sends.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var send = await _context.Sends
                .FirstOrDefaultAsync(m => m.SendId == id);
            if (send == null)
            {
                return NotFound();
            }

            return View(send);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendId, Deliver, TrackingCode, SendName,SendType,SendPrice,SendDay,ReceptionDay")] Send send)
        {
            if (ModelState.IsValid)
            {
                send.SendId = await _context.Sends.CountAsync() + 100;

                _context.Add(send);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(send);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var send = await _context.Sends.FindAsync(id);
            if (send == null)
            {
                return NotFound();
            }
            return View(send);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendId, Deliver, TrackingCode, SendName,SendType,SendPrice,SendDay,ReceptionDay")] Send send)
        {
            if (id != send.SendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(send);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendExists(send.SendId))
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
            return View(send);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var send = await _context.Sends
                .FirstOrDefaultAsync(m => m.SendId == id);
            if (send == null)
            {
                return NotFound();
            }

            return View(send);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var send = await _context.Sends.FindAsync(id);
            _context.Sends.Remove(send);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendExists(int id)
        {
            return _context.Sends.Any(e => e.SendId == id);
        }
    }
}
