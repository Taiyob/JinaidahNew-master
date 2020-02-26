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
    public class HoldingCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoldingCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoldingCategories
        public async Task<IActionResult> Index(string msg="")
        {
            ViewBag.msg = msg;
            return View(await _context.HoldingCategory.ToListAsync());
        }

        // GET: HoldingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingCategory = await _context.HoldingCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingCategory == null)
            {
                return NotFound();
            }

            return View(holdingCategory);
        }

        // GET: HoldingCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoldingCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] HoldingCategory holdingCategory)
        {
            bool IsHoldingCategoryExist = _context.HoldingCategory.Any
    (x => x.TypeName == holdingCategory.TypeName && x.Id != holdingCategory.Id);
            if (IsHoldingCategoryExist == true)
            {
                ModelState.AddModelError("TypeName", "Name Already exit");
            }
            if (ModelState.IsValid)
            {
                _context.Add(holdingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holdingCategory);
        }

        // GET: HoldingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingCategory = await _context.HoldingCategory.FindAsync(id);
            if (holdingCategory == null)
            {
                return NotFound();
            }
            return View(holdingCategory);
        }

        // POST: HoldingCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] HoldingCategory holdingCategory)
        {
            if (id != holdingCategory.Id)
            {
                return NotFound();
            }
            bool IsHoldingCategoryExist = _context.HoldingCategory.Any
   (x => x.TypeName == holdingCategory.TypeName && x.Id != holdingCategory.Id);
            if (IsHoldingCategoryExist == true)
            {
                ModelState.AddModelError("TypeName", "Name Already exit");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holdingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingCategoryExists(holdingCategory.Id))
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
            return View(holdingCategory);
        }

        // GET: HoldingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingCategory = await _context.HoldingCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingCategory == null)
            {
                return NotFound();
            }
            var holding = await _context.HoldingInfo.FirstOrDefaultAsync(x =>x.HoldingCategoryId == id);
            if(holding!=null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("Index", new { msg = msg1 });
            }
            return View(holdingCategory);
        }

        // POST: HoldingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holdingCategory = await _context.HoldingCategory.FindAsync(id);
            _context.HoldingCategory.Remove(holdingCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingCategoryExists(int id)
        {
            return _context.HoldingCategory.Any(e => e.Id == id);
        }
    }
}
