using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventorium.Data;
using InventoriumLib;
using Microsoft.AspNetCore.Identity;

namespace Inventorium.Controllers
{
    public class BinsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BinsController(ApplicationDbContext context,
                                      UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bins
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartsBin.ToListAsync());
        }

        // GET: Bins/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partsBin = await _context.PartsBin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partsBin == null)
            {
                return NotFound();
            }

            return View(partsBin);
        }

        // GET: Bins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RackIndexX,RackIndexY,RackIndexZ,ID,OwnerID,Name")] PartsBin partsBin)
        {
            if (ModelState.IsValid)
            {
                partsBin.ID = Guid.NewGuid();

                // Assign to the current user
                IdentityUser currUser = await _userManager.GetUserAsync(User);
                if (null != currUser)
                {
                    partsBin.OwnerID = currUser.Id;
                }

                _context.Add(partsBin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partsBin);
        }

        // GET: Bins/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partsBin = await _context.PartsBin.FindAsync(id);
            if (partsBin == null)
            {
                return NotFound();
            }
            return View(partsBin);
        }

        // POST: Bins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RackIndexX,RackIndexY,RackIndexZ,ID,OwnerID,Name")] PartsBin partsBin)
        {
            if (id != partsBin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partsBin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartsBinExists(partsBin.ID))
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
            return View(partsBin);
        }

        // GET: Bins/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partsBin = await _context.PartsBin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partsBin == null)
            {
                return NotFound();
            }

            return View(partsBin);
        }

        // POST: Bins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partsBin = await _context.PartsBin.FindAsync(id);
            _context.PartsBin.Remove(partsBin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartsBinExists(Guid id)
        {
            return _context.PartsBin.Any(e => e.ID == id);
        }
    }
}
