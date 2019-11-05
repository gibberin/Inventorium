﻿using System;
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
    public class RacksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RacksController(ApplicationDbContext context,
                                      UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Racks
        public async Task<IActionResult> Index()
        {
            return View(await _context.BinRack.ToListAsync());
        }

        // GET: Racks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binRack = await _context.BinRack
                .FirstOrDefaultAsync(m => m.ID == id);
            if (binRack == null)
            {
                return NotFound();
            }

            return View(binRack);
        }

        // GET: Racks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Racks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Height,Width,Depth,ID,OwnerID,Name")] BinRack binRack)
        {
            if (ModelState.IsValid)
            {
                binRack.ID = Guid.NewGuid();

                // Assign to the current user
                IdentityUser currUser = await _userManager.GetUserAsync(User);
                if (null != currUser)
                {
                    binRack.OwnerID = currUser.Id;
                }

                _context.Add(binRack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(binRack);
        }

        // GET: Racks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binRack = await _context.BinRack.FindAsync(id);
            if (binRack == null)
            {
                return NotFound();
            }
            return View(binRack);
        }

        // POST: Racks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Height,Width,Depth,ID,OwnerID,Name")] BinRack binRack)
        {
            if (id != binRack.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    binRack.Edition++;

                    _context.Update(binRack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinRackExists(binRack.ID))
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
            return View(binRack);
        }

        // GET: Racks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binRack = await _context.BinRack
                .FirstOrDefaultAsync(m => m.ID == id);
            if (binRack == null)
            {
                return NotFound();
            }

            return View(binRack);
        }

        // POST: Racks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var binRack = await _context.BinRack.FindAsync(id);
            _context.BinRack.Remove(binRack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinRackExists(Guid id)
        {
            return _context.BinRack.Any(e => e.ID == id);
        }
    }
}