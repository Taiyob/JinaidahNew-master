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
    public class TaxRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaxRates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaxRate.Include(t => t.HoldingCategory).Include(t => t.HoldingType).Include(t => t.TaxItemSetting);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaxRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRate
                .Include(t => t.HoldingCategory)
                .Include(t => t.HoldingType)
                .Include(t => t.TaxItemSetting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            return View(taxRate);
        }

        // GET: TaxRates/Create
        public IActionResult Create()
        {
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName");
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName");
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName");
            return View();
        }

        // POST: TaxRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaxItemSettingId,HoldingTypeId,HoldingCategoryId,Rate")] TaxRate taxRate)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(taxRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName", taxRate.HoldingCategoryId);
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", taxRate.HoldingTypeId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName", taxRate.TaxItemSettingId);
            return View(taxRate);
        }

        // GET: TaxRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRate.FindAsync(id);
            if (taxRate == null)
            {
                return NotFound();
            }
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName", taxRate.HoldingCategoryId);
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", taxRate.HoldingTypeId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName", taxRate.TaxItemSettingId);
            return View(taxRate);
        }

        // POST: TaxRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaxItemSettingId,HoldingTypeId,HoldingCategoryId,Rate")] TaxRate taxRate)
        {
            if (id != taxRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxRateExists(taxRate.Id))
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
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName", taxRate.HoldingCategoryId);
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", taxRate.HoldingTypeId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName", taxRate.TaxItemSettingId);
            return View(taxRate);
        }

        // GET: TaxRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRate = await _context.TaxRate
                .Include(t => t.HoldingCategory)
                .Include(t => t.HoldingType)
                .Include(t => t.TaxItemSetting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            return View(taxRate);
        }

        // POST: TaxRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxRate = await _context.TaxRate.FindAsync(id);
            _context.TaxRate.Remove(taxRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxRateExists(int id)
        {
            return _context.TaxRate.Any(e => e.Id == id);
        }
    }
}
