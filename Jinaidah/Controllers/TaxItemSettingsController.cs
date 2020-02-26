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
    public class TaxItemSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxItemSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaxItemSettings
        public async Task<IActionResult> Index(string msg="")
        {
            ViewBag.msg = msg;
            return View(await _context.TaxItemSetting.ToListAsync());
        }

        // GET: TaxItemSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxItemSetting = await _context.TaxItemSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxItemSetting == null)
            {
                return NotFound();
            }

            return View(taxItemSetting);
        }

        // GET: TaxItemSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxItemSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,Remark")] TaxItemSetting taxItemSetting)
        {
            bool IsTaxItemSettingExist = _context.TaxItemSetting.Any
  (x => x.ItemName == taxItemSetting.ItemName && x.Id != taxItemSetting.Id);
            if (IsTaxItemSettingExist == true)
            {
                ModelState.AddModelError("ItemName", "Name Already exit");
            }
            if (ModelState.IsValid)
            {
                taxItemSetting.InsertDate = DateTime.Now;
                //taxItemSetting.InsertBy=
                _context.Add(taxItemSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxItemSetting);
        }

        // GET: TaxItemSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxItemSetting = await _context.TaxItemSetting.FindAsync(id);
            if (taxItemSetting == null)
            {
                return NotFound();
            }
            return View(taxItemSetting);
        }

        // POST: TaxItemSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,Remark")] TaxItemSetting taxItemSetting)
        {
            if (id != taxItemSetting.Id)
            {
                return NotFound();
            }
            bool IsTaxItemSettingExist = _context.TaxItemSetting.Any
 (x => x.ItemName == taxItemSetting.ItemName && x.Id != taxItemSetting.Id);
            if (IsTaxItemSettingExist == true)
            {
                ModelState.AddModelError("ItemName", "Name  Already exit");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    taxItemSetting.UpdateDate = DateTime.Now;
                    //taxItemSetting.UpdatedBy=
                    _context.Update(taxItemSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxItemSettingExists(taxItemSetting.Id))
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
            return View(taxItemSetting);
        }

        // GET: TaxItemSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxItemSetting = await _context.TaxItemSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxItemSetting == null)
            {
                return NotFound();
            }
            var wtr = await _context.TaxRate.FirstOrDefaultAsync(x => x.TaxItemSettingId == id);
            if (wtr!= null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("index", new { msg = msg1 });
            }
            var wtr1 = await _context.HoldingTax.FirstOrDefaultAsync(x => x.TaxItemSettingId == id);
            if (wtr1!= null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("index", new { msg = msg1 });
            }
            return View(taxItemSetting);
        }

        // POST: TaxItemSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxItemSetting = await _context.TaxItemSetting.FindAsync(id);
            _context.TaxItemSetting.Remove(taxItemSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxItemSettingExists(int id)
        {
            return _context.TaxItemSetting.Any(e => e.Id == id);
        }
    }
}
