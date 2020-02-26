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
    public class TaxBillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxBillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaxBills
        public async Task<IActionResult> Index(string usrtext)
        {
            var applicationDbContext = _context.TaxBill.Include(t => t.HoldingInfo).Include(t => t.TaxItemSetting);
            ViewBag.data = usrtext;
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.HoldingInfo.HoldingNo.ToLower().Contains(usrtext.ToLower()));
                                     
                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaxBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxBill = await _context.TaxBill
                .Include(t => t.HoldingInfo)
                .Include(t => t.TaxItemSetting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxBill == null)
            {
                return NotFound();
            }

            return View(taxBill);
        }

        // GET: TaxBills/Create
        public IActionResult Create()
        {
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo");
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName");
            return View();
        }

        // POST: TaxBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoldingInfoId,TaxItemSettingId,BillNo,TaxRateId,BillAmount,Rebate,Discount,PaidAmount,UnPaidAmount,Ispaid,PaidDate,PaidBy,SurCharge,ServiceCharge,MonthYear,Remark")] TaxBill taxBill)
        {
            if (ModelState.IsValid)
            {
                taxBill.InsertDate = DateTime.Now;
                //taxBill.InsertBy=
                _context.Add(taxBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", taxBill.HoldingInfoId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName", taxBill.TaxItemSettingId);
            return View(taxBill);
        }

        // GET: TaxBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxBill = await _context.TaxBill.FindAsync(id);
            if (taxBill == null)
            {
                return NotFound();
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", taxBill.HoldingInfoId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName", taxBill.TaxItemSettingId);
            return View(taxBill);
        }

        // POST: TaxBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoldingInfoId,TaxItemSettingId,BillNo,TaxRateId,BillAmount,Rebate,Discount,PaidAmount,UnPaidAmount,Ispaid,PaidDate,PaidBy,SurCharge,ServiceCharge,MonthYear,Remark")] TaxBill taxBill)
        {
            if (id != taxBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    taxBill.UpdateDate = DateTime.Now;
                    //taxBill.UpdatedBy=
                    _context.Update(taxBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxBillExists(taxBill.Id))
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
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", taxBill.HoldingInfoId);
            ViewData["TaxItemSettingId"] = new SelectList(_context.TaxItemSetting, "Id", "ItemName", taxBill.TaxItemSettingId);
            return View(taxBill);
        }

        // GET: TaxBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxBill = await _context.TaxBill
                .Include(t => t.HoldingInfo)
                .Include(t => t.TaxItemSetting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxBill == null)
            {
                return NotFound();
            }

            return View(taxBill);
        }

        // POST: TaxBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxBill = await _context.TaxBill.FindAsync(id);
            _context.TaxBill.Remove(taxBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxBillExists(int id)
        {
            return _context.TaxBill.Any(e => e.Id == id);
        }
    }
}
