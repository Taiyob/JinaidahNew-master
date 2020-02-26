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
    public class MunicipilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MunicipilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Municipilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Municipility.ToListAsync());
        }

        // GET: Municipilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipility = await _context.Municipility
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipility == null)
            {
                return NotFound();
            }

            return View(municipility);
        }

        // GET: Municipilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MName,Address,Phone,Fax,Email,logo")] Municipility municipility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(municipility);
        }

        // GET: Municipilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipility = await _context.Municipility.FindAsync(id);
            if (municipility == null)
            {
                return NotFound();
            }
            return View(municipility);
        }

        // POST: Municipilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MName,Address,Phone,Fax,Email,logo")] Municipility municipility)
        {
            if (id != municipility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipilityExists(municipility.Id))
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
            return View(municipility);
        }

        // GET: Municipilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipility = await _context.Municipility
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipility == null)
            {
                return NotFound();
            }

            return View(municipility);
        }

        // POST: Municipilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipility = await _context.Municipility.FindAsync(id);
            _context.Municipility.Remove(municipility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipilityExists(int id)
        {
            return _context.Municipility.Any(e => e.Id == id);
        }
    }
}
