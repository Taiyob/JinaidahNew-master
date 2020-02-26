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
    public class RoadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roads
        public async Task<IActionResult> Index(string msg="")
        {
            ViewBag.msg = msg;
            var applicationDbContext = _context.Road.Include(r => r.Ward);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Roads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var road = await _context.Road
                .Include(r => r.Ward)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (road == null)
            {
                return NotFound();
            }

            return View(road);
        }

        // GET: Roads/Create
        public IActionResult Create()
        {
            ViewData["WardId"] = new SelectList(_context.Set<Ward>(), "Id", "Id");
            return View();
        }

        // POST: Roads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WardId,RoadNo,RoadName")] Road road)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(road);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WardId"] = new SelectList(_context.Set<Ward>(), "Id", "Id", road.WardId);
            return View(road);
        }

        // GET: Roads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var road = await _context.Road.FindAsync(id);
            if (road == null)
            {
                return NotFound();
            }
            ViewData["WardId"] = new SelectList(_context.Set<Ward>(), "Id", "Id", road.WardId);
            return View(road);
        }

        // POST: Roads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WardId,RoadNo,RoadName")] Road road)
        {
            if (id != road.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(road);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoadExists(road.Id))
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
            ViewData["WardId"] = new SelectList(_context.Set<Ward>(), "Id", "Id", road.WardId);
            return View(road);
        }

        // GET: Roads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var road = await _context.Road
                .Include(r => r.Ward)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (road == null)
            {
                return NotFound();
            }
            var holding = await _context.HoldingInfo.FirstOrDefaultAsync(x => x.RoadId == id);
            if (holding != null)
            {
                string msg1 = "You dont have permision to delete, contact with admin";
                return RedirectToAction("Index", new { msg = msg1 });
            }

            return View(road);
        }

        // POST: Roads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var road = await _context.Road.FindAsync(id);
            _context.Road.Remove(road);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoadExists(int id)
        {
            return _context.Road.Any(e => e.Id == id);
        }
    }
}
