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
    public class ClientInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientInfoes
        public async Task<IActionResult> Index(string usrtext, string msg = "")
        {
            var applicationDbContext = _context.ClientInfo.Include(c => c.District).Include(c => c.Division).Include(c => c.Upzilla);
            ViewBag.data = usrtext;
            if (!string.IsNullOrEmpty(usrtext))
            {
                var cinfo1 = applicationDbContext.Where(e => e.ClientName.ToLower().Contains(usrtext.ToLower())
                                        || e.MobileNo.ToLower().Contains(usrtext.ToLower())
                                        || e.NID.ToLower().Contains(usrtext.ToLower()));
                ViewBag.count = cinfo1.Count();
                return View(cinfo1);

            }
            ViewBag.msg = msg;
           
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfo
                .Include(c => c.District)
                .Include(c => c.Division)
                .Include(c => c.Upzilla)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // GET: ClientInfoes/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName");
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName");
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName");
            return View();
        }

        // POST: ClientInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClientName,ClientType,Father,Husband,verifyCode,Verified,Address,DivisionId,DistrictId,UpzillaId,NID,Email,PWD,MobileNo,ClientAttachment,IsActive,Remark")] ClientInfo clientInfo)
        {
            bool IsClientInfoExist = _context.ClientInfo.Any
       (x => x.UserId == clientInfo.UserId && x.Id != clientInfo.Id);
            if (IsClientInfoExist == true)
            {
                ModelState.AddModelError("UserID", "Client Id Already exit");
            }
            if (ModelState.IsValid)
            {

                clientInfo.InsertDate = DateTime.Now;
                //clientInfo.InsertBy=
                _context.Add(clientInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", clientInfo.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName", clientInfo.DivisionId);
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName", clientInfo.UpzillaId);
            return View(clientInfo);
        }

        // GET: ClientInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfo.FindAsync(id);
            if (clientInfo == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", clientInfo.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName", clientInfo.DivisionId);
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName", clientInfo.UpzillaId);
            return View(clientInfo);
        }

        // POST: ClientInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClientName,ClientType,Father,Husband,verifyCode,Verified,Address,DivisionId,DistrictId,UpzillaId,NID,Email,PWD,MobileNo,ClientAttachment,IsActive,Remark")] ClientInfo clientInfo)
        {
            if (id != clientInfo.Id)
            {
                return NotFound();
            }
            bool IsClientInfoExist = _context.ClientInfo.Any
      (x => x.UserId == clientInfo.UserId && x.Id != clientInfo.Id);
            if (IsClientInfoExist == true)
            {
                ModelState.AddModelError("UserID", "Client Id Already exit");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    clientInfo.UpdateDate = DateTime.Now;
                    //clientInfo.UpdatedBy=
                    _context.Update(clientInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientInfoExists(clientInfo.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", clientInfo.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "DivisonName", clientInfo.DivisionId);
            ViewData["UpzillaId"] = new SelectList(_context.Upzilla, "Id", "UpzillaName", clientInfo.UpzillaId);
            return View(clientInfo);
        }

        // GET: ClientInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfo
                .Include(c => c.District)
                .Include(c => c.Division)
                .Include(c => c.Upzilla)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }
            var ClntInfo = await _context.HoldingInfo.FirstOrDefaultAsync(x => x.ClientInfoId == id);
            if(ClntInfo!=null)
            {
                string msg1 = "You cant delete, contact with administor";
                return RedirectToAction("Index", new { msg = msg1 });
            }
            return View(clientInfo);
        }

        // POST: ClientInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientInfo = await _context.ClientInfo.FindAsync(id);
            _context.ClientInfo.Remove(clientInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientInfoExists(int id)
        {
            return _context.ClientInfo.Any(e => e.Id == id);
        }
    }
}
