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
    public class WaterRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaterRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WaterRates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WaterRate.Include(w => w.HoldingType).Include(w => w.WaterConnection);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WaterRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var waterRate = await _context.WaterRate
                .Include(w => w.HoldingType)
                .Include(w => w.WaterConnection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterRate == null)
            {
                return NotFound();
            }

            return View(waterRate);
        }

        // GET: WaterRates/Create
        public IActionResult Create()
        {
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName");
            ViewData["WaterConnectionId"] = new SelectList(_context.WaterConnection, "Id", "Id");
            return View();
        }

        // POST: WaterRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoldingTypeId,WaterConnectionId,Rate,FloorNos,FloorRate,FineRate,IsActive,Remark")] WaterRate waterRate)
        {
           
            if (ModelState.IsValid)
            {
                waterRate.InsertDate = DateTime.Now;
                // clientInfo.InsertBy=
                _context.Add(waterRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", waterRate.HoldingTypeId);
            ViewData["WaterConnectionId"] = new SelectList(_context.WaterConnection, "Id", "Id", waterRate.WaterConnectionId);
            return View(waterRate);
        }

        // GET: WaterRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterRate = await _context.WaterRate.FindAsync(id);
            if (waterRate == null)
            {
                return NotFound();
            }
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", waterRate.HoldingTypeId);
            ViewData["WaterConnectionId"] = new SelectList(_context.WaterConnection, "Id", "Id", waterRate.WaterConnectionId);
            return View(waterRate);
        }

        // POST: WaterRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoldingTypeId,WaterConnectionId,Rate,FloorNos,FloorRate,FineRate,IsActive,Remark")] WaterRate waterRate)
        {
            if (id != waterRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    waterRate.UpdateDate = DateTime.Now;
                    //waterRate.UpdatedBy =;
                    _context.Update(waterRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterRateExists(waterRate.Id))
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
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", waterRate.HoldingTypeId);
            ViewData["WaterConnectionId"] = new SelectList(_context.WaterConnection, "Id", "Id", waterRate.WaterConnectionId);
            return View(waterRate);
        }

        // GET: WaterRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterRate = await _context.WaterRate
                .Include(w => w.HoldingType)
                .Include(w => w.WaterConnection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterRate == null)
            {
                return NotFound();
            }

            return View(waterRate);
        }

        // POST: WaterRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterRate = await _context.WaterRate.FindAsync(id);
            _context.WaterRate.Remove(waterRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterRateExists(int id)
        {
            return _context.WaterRate.Any(e => e.Id == id);
        }
    }
}
