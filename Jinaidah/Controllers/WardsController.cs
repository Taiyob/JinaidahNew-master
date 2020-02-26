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
    public class WardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wards
        public async Task<IActionResult> Index(string usrtext,string msg="")
        {
            ViewBag.msg = msg;
            var applicationDbContext = _context.Ward.Include(w => w.Municipility);
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.WardNo.ToString().Contains(usrtext.ToString()));
                                      

                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Ward
                .Include(w => w.Municipility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // GET: Wards/Create
        public IActionResult Create()
        {
            ViewData["MunicipilityId"] = new SelectList(_context.Municipility, "Id", "MName");
            return View();
        }

        // POST: Wards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MunicipilityId,WardNo,WardName")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MunicipilityId"] = new SelectList(_context.Municipility, "Id", "MName", ward.MunicipilityId);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Ward.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }
            ViewData["MunicipilityId"] = new SelectList(_context.Municipility, "Id", "MName", ward.MunicipilityId);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MunicipilityId,WardNo,WardName")] Ward ward)
        {
            if (id != ward.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ward);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardExists(ward.Id))
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
            ViewData["MunicipilityId"] = new SelectList(_context.Municipility, "Id", "MName", ward.MunicipilityId);
            return View(ward);
        }

        // GET: Wards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Ward
                .Include(w => w.Municipility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ward == null)
            {
                return NotFound();
            }
            var holding = await _context.Road.FirstOrDefaultAsync(x => x.WardId == id);
            if (holding != null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("Index", new { msg = msg1 });
            }

            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ward = await _context.Ward.FindAsync(id);
            _context.Ward.Remove(ward);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WardExists(int id)
        {
            return _context.Ward.Any(e => e.Id == id);
        }
    }
}
