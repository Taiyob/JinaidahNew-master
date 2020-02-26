using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jinaidah.Data;
using Jinaidah.Models;

namespace Jinaidah.Controllers
{
    public class WaterConnectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaterConnectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WaterConnections
        public async Task<IActionResult> Index(string usrtext,string msg="")
        {
            ViewBag.msg = msg;
            var applicationDbContext = _context.WaterConnection.Include(w => w.HoldingInfo);
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.HoldingInfo.HoldingNo.ToLower().Contains(usrtext.ToLower()));
                                     

                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WaterConnections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterConnection = await _context.WaterConnection
                .Include(w => w.HoldingInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterConnection == null)
            {
                return NotFound();
            }

            return View(waterConnection);
        }

        // GET: WaterConnections/Create
        public IActionResult Create()
        {
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo");
            return View();
        }

        // POST: WaterConnections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoldingInfoId,ConnectionDia,ConnectionDate,FloorNos,IsActive")] WaterConnection waterConnection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", waterConnection.HoldingInfoId);
            return View(waterConnection);
        }

        // GET: WaterConnections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterConnection = await _context.WaterConnection.FindAsync(id);
            if (waterConnection == null)
            {
                return NotFound();
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", waterConnection.HoldingInfoId);
            return View(waterConnection);
        }

        // POST: WaterConnections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoldingInfoId,ConnectionDia,ConnectionDate,FloorNos,IsActive")] WaterConnection waterConnection)
        {
            if (id != waterConnection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterConnectionExists(waterConnection.Id))
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
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", waterConnection.HoldingInfoId);
            return View(waterConnection);
        }

        // GET: WaterConnections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterConnection = await _context.WaterConnection
                .Include(w => w.HoldingInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterConnection == null)
            {
                return NotFound();
            }
            var wtr = await _context.WaterRate.FirstOrDefaultAsync(x => x.WaterConnectionId == id);
            if(wtr!=null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("index", new { msg = msg1 });
            }

            return View(waterConnection);
        }

        // POST: WaterConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterConnection = await _context.WaterConnection.FindAsync(id);
            _context.WaterConnection.Remove(waterConnection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterConnectionExists(int id)
        {
            return _context.WaterConnection.Any(e => e.Id == id);
        }
    }
}
