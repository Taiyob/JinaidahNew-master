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
    public class UpzillasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpzillasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Upzillas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Upzilla.Include(u => u.District);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Upzillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upzilla = await _context.Upzilla
                .Include(u => u.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upzilla == null)
            {
                return NotFound();
            }

            return View(upzilla);
        }

        // GET: Upzillas/Create
        public IActionResult Create()
        {
            ViewData["DistrictID"] = new SelectList(_context.District, "Id", "DistrictName");
            return View();
        }

        // POST: Upzillas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DistrictID,UpzillaName")] Upzilla upzilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upzilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictID"] = new SelectList(_context.District, "Id", "DistrictName", upzilla.DistrictID);
            return View(upzilla);
        }

        // GET: Upzillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upzilla = await _context.Upzilla.FindAsync(id);
            if (upzilla == null)
            {
                return NotFound();
            }
            ViewData["DistrictID"] = new SelectList(_context.District, "Id", "DistrictName", upzilla.DistrictID);
            return View(upzilla);
        }

        // POST: Upzillas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DistrictID,UpzillaName")] Upzilla upzilla)
        {
            if (id != upzilla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upzilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpzillaExists(upzilla.Id))
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
            ViewData["DistrictID"] = new SelectList(_context.District, "Id", "DistrictName", upzilla.DistrictID);
            return View(upzilla);
        }

        // GET: Upzillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upzilla = await _context.Upzilla
                .Include(u => u.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upzilla == null)
            {
                return NotFound();
            }

            return View(upzilla);
        }

        // POST: Upzillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upzilla = await _context.Upzilla.FindAsync(id);
            _context.Upzilla.Remove(upzilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpzillaExists(int id)
        {
            return _context.Upzilla.Any(e => e.Id == id);
        }
    }
}
