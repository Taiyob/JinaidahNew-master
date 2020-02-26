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
    public class WaterBillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaterBillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WaterBills
        public async Task<IActionResult> Index(string usrtext)
        {
            var applicationDbContext = _context.WaterBill.Include(w => w.HoldingInfo);
            ViewBag.data = usrtext;
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.BillNo.ToLower().Contains(usrtext.ToLower())
                                        || e.HoldingInfo.HoldingNo.ToLower().Contains(usrtext.ToLower()));
                                       
                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WaterBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterBill = await _context.WaterBill
                .Include(w => w.HoldingInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterBill == null)
            {
                return NotFound();
            }

            return View(waterBill);
        }

        // GET: WaterBills/Create
        public IActionResult Create()
        {
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo");
            return View();
        }

        // POST: WaterBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoldingInfoId,MeterNo,BillNo,BillMonth,BillYear,Unit,SurCharge,Others,Fine,Due,PreReading,PreReadingDate,CurrentReading,CurrentReadingDate,NetReading,Discount,BillAmount,PaidAmount,UnPaidAmount,IsPaid,PaidDate,Remark")] WaterBill waterBill)
        {
            if (ModelState.IsValid)
            {
                waterBill.InsertDate = DateTime.Now;
                //waterBill.InsertBy=
                _context.Add(waterBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", waterBill.HoldingInfoId);
            return View(waterBill);
        }

        // GET: WaterBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterBill = await _context.WaterBill.FindAsync(id);
            if (waterBill == null)
            {
                return NotFound();
            }
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", waterBill.HoldingInfoId);
            return View(waterBill);
        }

        // POST: WaterBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoldingInfoId,MeterNo,BillNo,BillMonth,BillYear,Unit,SurCharge,Others,Fine,Due,PreReading,PreReadingDate,CurrentReading,CurrentReadingDate,NetReading,Discount,BillAmount,PaidAmount,UnPaidAmount,IsPaid,PaidDate,Remark")] WaterBill waterBill)
        {
            if (id != waterBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    waterBill.UpdateDate = DateTime.Now;
                    //waterBill.UpdatedBy=
                    _context.Update(waterBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterBillExists(waterBill.Id))
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
            ViewData["HoldingInfoId"] = new SelectList(_context.HoldingInfo, "Id", "HoldingNo", waterBill.HoldingInfoId);
            return View(waterBill);
        }

        // GET: WaterBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterBill = await _context.WaterBill
                .Include(w => w.HoldingInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterBill == null)
            {
                return NotFound();
            }

            return View(waterBill);
        }

        // POST: WaterBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterBill = await _context.WaterBill.FindAsync(id);
            _context.WaterBill.Remove(waterBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterBillExists(int id)
        {
            return _context.WaterBill.Any(e => e.Id == id);
        }
    }
}
