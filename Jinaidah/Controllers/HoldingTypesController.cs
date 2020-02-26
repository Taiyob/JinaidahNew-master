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
    public class HoldingTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoldingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoldingTypes
        public async Task<IActionResult> Index(string msg="")
        {
            ViewBag.msg = msg;
            return View(await _context.HoldingType.ToListAsync());
        }

        // GET: HoldingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingType = await _context.HoldingType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingType == null)
            {
                return NotFound();
            }

            return View(holdingType);
        }

        // GET: HoldingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoldingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] HoldingType holdingType)
        {
            bool IsHoldingTypeExist = _context.HoldingType.Any
          (x => x.TypeName == holdingType.TypeName && x.Id != holdingType.Id);
            if (IsHoldingTypeExist == true)
            {
                ModelState.AddModelError("TypeName", "Holding Type already exists");
            }
            if (ModelState.IsValid)
            {

                _context.Add(holdingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holdingType);
        }

        // GET: HoldingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingType = await _context.HoldingType.FindAsync(id);
            if (holdingType == null)
            {
                return NotFound();
            }
            return View(holdingType);
        }

        // POST: HoldingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] HoldingType holdingType)
        {
            if (id != holdingType.Id)
            {
                return NotFound();
            }
            bool IsHoldingTypeExist = _context.HoldingType.Any
       (x => x.TypeName == holdingType.TypeName && x.Id != holdingType.Id);
            if (IsHoldingTypeExist == true)
            {
                ModelState.AddModelError("TypeName", "Holding Type already exists");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holdingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingTypeExists(holdingType.Id))
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
            return View(holdingType);
        }

        // GET: HoldingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingType = await _context.HoldingType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingType == null)
            {
                return NotFound();
            }
            var holding = await _context.HoldingInfo.FirstOrDefaultAsync(x => x.HoldingTypeId == id);
            if (holding != null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("Index", new { msg = msg1 });
            }
            var holding1 = await _context.WaterRate.FirstOrDefaultAsync(x => x.HoldingTypeId == id);
            if (holding1 != null)
            {
                string msg2 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("Index", new { msg = msg2 });
            }


            return View(holdingType);
        }

        // POST: HoldingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holdingType = await _context.HoldingType.FindAsync(id);
            _context.HoldingType.Remove(holdingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingTypeExists(int id)
        {
            return _context.HoldingType.Any(e => e.Id == id);
        }
    }
}
