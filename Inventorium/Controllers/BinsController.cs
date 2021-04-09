using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventorium.Data;
using NventoriumLib;
using Microsoft.AspNetCore.Identity;
using Nventorium.Models;

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
            return View(await _context.PartsBin
                                      .Include("Rack")
                                      .OrderBy(b => b.Rack.Name)
                                      .ThenBy(b => b.RackIndexX)
                                      .ThenBy(b => b.RackIndexY)
                                      .ThenBy(b => b.RackIndexZ)
                                      .ThenBy(b => b.Name)
                                      .ToListAsync());
        }

        // GET: Bins/Contents/5
        /// <summary>
        /// Shows the items reported to be in a given bin
        /// </summary>
        /// <param name="id">The unique ID of the bin</param>
        /// <returns>A view listing the bin's contents</returns>
        public async Task<IActionResult> Contents(Guid? id)
        {
            BinContentsViewModel contents = new BinContentsViewModel();

            contents.Bin = await _context.PartsBin.FindAsync(id);

            contents.Items = await _context.Item
                                           .Where(i => i.Bin.ID == id)
                                           .OrderBy(i => i.Name)
                                           .ToListAsync();

            return View(contents);
        }

        // GET: Bins/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bin = await _context.PartsBin.Include("Rack")
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bin == null)
            {
                return NotFound();
            }

            return View(bin);
        }

        // GET: Bins/Create
        public async Task<IActionResult> Create()
        {
            BinViewModel binViewModel = new BinViewModel();

            binViewModel.RackIndexX = 1;
            binViewModel.RackIndexY = 1;
            binViewModel.RackIndexZ = 1;

            binViewModel.Racks = await _context.BinRack.ToListAsync();

            return View(binViewModel);
        }

        // POST: Bins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RackIndexX,RackIndexY,RackIndexZ,Name,Description,SelectedRackID")] BinViewModel binViewModel)
        {
            Bin bin = binViewModel.ToBin();

            if (ModelState.IsValid)
            {
                bin.Rack = await _context.BinRack.FindAsync(binViewModel.SelectedRackID);

                // Assign to the current user
                IdentityUser currUser = await _userManager.GetUserAsync(User);
                if (null != currUser)
                {
                    bin.OwnerID = currUser.Id;
                }

                _context.Add(bin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bin);
        }

        // GET: Bins/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bin = await _context.PartsBin.FindAsync(id);
            if (bin == null)
            {
                return NotFound();
            }
            
            BinViewModel binViewModel = new BinViewModel(bin);
            binViewModel.Racks = await _context.BinRack.ToListAsync();

            return (View(binViewModel));
        }

        // POST: Bins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SelectedRackID,Edition,Created,OwnerID,ID,RackIndexX,RackIndexY,RackIndexZ,Name,Description")] BinViewModel binViewModel)
        {
            if (id != binViewModel.ID)
            {
                return NotFound();
            }

            Bin bin = binViewModel.ToBin();

            if (ModelState.IsValid)
            {
                try
                {
                    bin.IncrementEdition();
                    bin.Rack = await _context.BinRack.FindAsync(binViewModel.SelectedRackID);

                    _context.Update(bin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartsBinExists(bin.ID))
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
            return View(bin);
        }

        // GET: Bins/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bin = await _context.PartsBin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bin == null)
            {
                return NotFound();
            }

            return View(bin);
        }

        // POST: Bins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bin = await _context.PartsBin.FindAsync(id);
            _context.PartsBin.Remove(bin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartsBinExists(Guid id)
        {
            return _context.PartsBin.Any(e => e.ID == id);
        }
    }
}
