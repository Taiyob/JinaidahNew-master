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
    public class HoldingInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoldingInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoldingInfoes
        public async Task<IActionResult> Index(string usrtext)
        {
           
            var applicationDbContext = _context.HoldingInfo.Include(h => h.ClientInfo).Include(h => h.District).Include(h => h.Division).Include(h => h.HoldingCategory).Include(h => h.HoldingType).Include(h => h.Road).Include(h => h.Upzilla).Include(h => h.Ward);
            ViewBag.data = usrtext;
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.HoldingNo.ToLower().Contains(usrtext.ToLower())
                                        || e.ClientInfo.UserId.ToLower().Contains(usrtext.ToLower()));
                                       
                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoldingInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingInfo = await _context.HoldingInfo
                .Include(h => h.ClientInfo)
                .Include(h => h.District)
                .Include(h => h.Division)
                .Include(h => h.HoldingCategory)
                .Include(h => h.HoldingType)
                .Include(h => h.Road)
                .Include(h => h.Upzilla)
                .Include(h => h.Ward)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingInfo == null)
            {
                return NotFound();
            }

            return View(holdingInfo);
        }

        // GET: HoldingInfoes/Create
        public IActionResult Create()
        {
            ViewData["ClientInfoId"] = new SelectList(_context.ClientInfo, "Id", "UserId");
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName");
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName");
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName");
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName");
            ViewData["RoadId"] = new SelectList(_context.Road, "Id", "Id");
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName");
            ViewData["WardId"] = new SelectList(_context.Ward, "Id", "Id");
            return View();
        }

        // POST: HoldingInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoldingNo,ClientInfoId,HoldingTypeId,HoldingCategoryId,WardId,RoadId,Address,MeterNo,Floor,Flat,AssetValue,Status,EffectDate,DivisionId,DistrictId,UpzillaId,Remark")] HoldingInfo holdingInfo)
        {
            bool IsHoldingInfoExist = _context.HoldingInfo.Any
   (x => x.HoldingNo == holdingInfo.HoldingNo && x.Id != holdingInfo.Id);
            if (IsHoldingInfoExist == true)
            {
                ModelState.AddModelError("HoldingNo", "Holding No  Already exit");
            }
            if (ModelState.IsValid)
            {
                holdingInfo.InsertDate = DateTime.Now;
               // holdingInfo.InsertBy=
                _context.Add(holdingInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientInfoId"] = new SelectList(_context.ClientInfo, "Id", "UserId", holdingInfo.ClientInfoId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", holdingInfo.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName", holdingInfo.DivisionId);
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName", holdingInfo.HoldingCategoryId);
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", holdingInfo.HoldingTypeId);
            ViewData["RoadId"] = new SelectList(_context.Road, "Id", "Id", holdingInfo.RoadId);
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName", holdingInfo.UpzillaId);
            ViewData["WardId"] = new SelectList(_context.Ward, "Id", "Id", holdingInfo.WardId);
            return View(holdingInfo);
        }

        // GET: HoldingInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingInfo = await _context.HoldingInfo.FindAsync(id);
            if (holdingInfo == null)
            {
                return NotFound();
            }
            ViewData["ClientInfoId"] = new SelectList(_context.ClientInfo, "Id", "UserId", holdingInfo.ClientInfoId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", holdingInfo.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName", holdingInfo.DivisionId);
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName", holdingInfo.HoldingCategoryId);
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", holdingInfo.HoldingTypeId);
            ViewData["RoadId"] = new SelectList(_context.Road, "Id", "Id", holdingInfo.RoadId);
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName", holdingInfo.UpzillaId);
            ViewData["WardId"] = new SelectList(_context.Ward, "Id", "Id", holdingInfo.WardId);
            return View(holdingInfo);
        }

        // POST: HoldingInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoldingNo,ClientInfoId,HoldingTypeId,HoldingCategoryId,WardId,RoadId,Address,MeterNo,Floor,Flat,AssetValue,Status,EffectDate,DivisionId,DistrictId,UpzillaId,Remark")] HoldingInfo holdingInfo)
        {
            if (id != holdingInfo.Id)
            {
                return NotFound();
            }
            bool IsHoldingInfoExist = _context.HoldingInfo.Any
   (x => x.HoldingNo == holdingInfo.HoldingNo && x.Id != holdingInfo.Id);
            if (IsHoldingInfoExist == true)
            {
                ModelState.AddModelError("HoldingNo", "Holding No  Already exit");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    holdingInfo.UpdateDate = DateTime.Now;
                    //holdingInfo.UpdatedBy=
                    _context.Update(holdingInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingInfoExists(holdingInfo.Id))
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
            ViewData["ClientInfoId"] = new SelectList(_context.ClientInfo, "Id", "UserId", holdingInfo.ClientInfoId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", holdingInfo.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName", holdingInfo.DivisionId);
            ViewData["HoldingCategoryId"] = new SelectList(_context.HoldingCategory, "Id", "TypeName", holdingInfo.HoldingCategoryId);
            ViewData["HoldingTypeId"] = new SelectList(_context.HoldingType, "Id", "TypeName", holdingInfo.HoldingTypeId);
            ViewData["RoadId"] = new SelectList(_context.Road, "Id", "Id", holdingInfo.RoadId);
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName", holdingInfo.UpzillaId);
            ViewData["WardId"] = new SelectList(_context.Ward, "Id", "Id", holdingInfo.WardId);
            return View(holdingInfo);
        }

        // GET: HoldingInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holdingInfo = await _context.HoldingInfo
                .Include(h => h.ClientInfo)
                .Include(h => h.District)
                .Include(h => h.Division)
                .Include(h => h.HoldingCategory)
                .Include(h => h.HoldingType)
                .Include(h => h.Road)
                .Include(h => h.Upzilla)
                .Include(h => h.Ward)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holdingInfo == null)
            {
                return NotFound();
            }
            

            return View(holdingInfo);
        }

        // POST: HoldingInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holdingInfo = await _context.HoldingInfo.FindAsync(id);
            _context.HoldingInfo.Remove(holdingInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingInfoExists(int id)
        {
            return _context.HoldingInfo.Any(e => e.Id == id);
        }
    }
}
