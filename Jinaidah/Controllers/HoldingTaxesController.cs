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
    public class HoldingTaxesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoldingTaxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoldingTaxes
        public async Task<IActionResult> Index(string usrtext)
        {
            var applicationDbContext = _context.HoldingTax.Include(h => h.HoldingInfo).Include(h => h.HoldingType).Include(h => h.TaxItemSetting);
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.HoldingInfo.HoldingNo.ToLower().Contains(usrtext.ToLower())
                                        || e.HoldingType.TypeName.ToLower().Contains(usrtext.ToLower()));

                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoldingTaxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingTax = await _context.HoldingTax
                .Include(h => h.HoldingInfo)
                .Include(h => h.HoldingType)
                .Include(h => h.TaxItemSetting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingTax == null)
            {
                return NotFound();
            }

            return View(holdingTax);
        }

        // GET: HoldingTaxes/Create
        public IActionResult Create()
        {
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo");
            ViewData["HoldingTypeId"] = new SelectList(_context.Set<HoldingType>(), "Id", "TypeName");
            ViewData["TaxItemSettingId"] = new SelectList(_context.Set<TaxItemSetting>(), "Id", "ItemName");
            return View();
        }

        // POST: HoldingTaxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoldingInfoId,HoldingTypeId,TaxItemSettingId,Rate,TaxAmount,Remark")] HoldingTax holdingTax)
        {
            bool IsHoldingTaxExist = _context.HoldingTax.Any
   (x => x.HoldingInfoId == holdingTax.HoldingInfoId && x.Id != holdingTax.Id);
            if (IsHoldingTaxExist == true)
            {
                ModelState.AddModelError("DivisonName", "Client Id Already exit");
            }
            if (ModelState.IsValid)
            {
                holdingTax.InsertDate = DateTime.Now;
               // holdingTax.InsertBy=
                _context.Add(holdingTax);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", holdingTax.HoldingInfoId);
            ViewData["HoldingTypeId"] = new SelectList(_context.Set<HoldingType>(), "Id", "TypeName", holdingTax.HoldingTypeId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.Set<TaxItemSetting>(), "Id", "ItemName", holdingTax.TaxItemSettingId);
            return View(holdingTax);
        }

        // GET: HoldingTaxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingTax = await _context.HoldingTax.FindAsync(id);
            if (holdingTax == null)
            {
                return NotFound();
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", holdingTax.HoldingInfoId);
            ViewData["HoldingTypeId"] = new SelectList(_context.Set<HoldingType>(), "Id", "TypeName", holdingTax.HoldingTypeId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.Set<TaxItemSetting>(), "Id", "ItemName", holdingTax.TaxItemSettingId);
            return View(holdingTax);
        }

        // POST: HoldingTaxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoldingInfoId,HoldingTypeId,TaxItemSettingId,Rate,TaxAmount,Remark")] HoldingTax holdingTax)
        {
            if (id != holdingTax.Id)
            {
                return NotFound();
            }
            bool IsHoldingTaxExist = _context.HoldingTax.Any
  (x => x.HoldingInfoId == holdingTax.HoldingInfoId && x.Id != holdingTax.Id);
            if (IsHoldingTaxExist == true)
            {
                ModelState.AddModelError("HoldingInfoId", "Holding Id Already exit");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    holdingTax.UpdateDate = DateTime.Now;
                   // holdingTax.UpdatedBy=
                    _context.Update(holdingTax);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingTaxExists(holdingTax.Id))
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
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", holdingTax.HoldingInfoId);
            ViewData["HoldingTypeId"] = new SelectList(_context.Set<HoldingType>(), "Id", "TypeName", holdingTax.HoldingTypeId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.Set<TaxItemSetting>(), "Id", "ItemName", holdingTax.TaxItemSettingId);
            return View(holdingTax);
        }

        // GET: HoldingTaxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingTax = await _context.HoldingTax
                .Include(h => h.HoldingInfo)
                .Include(h => h.HoldingType)
                .Include(h => h.TaxItemSetting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingTax == null)
            {
                return NotFound();
            }

            return View(holdingTax);
        }

        // POST: HoldingTaxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holdingTax = await _context.HoldingTax.FindAsync(id);
            _context.HoldingTax.Remove(holdingTax);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingTaxExists(int id)
        {
            return _context.HoldingTax.Any(e => e.Id == id);
        }
    }
}
