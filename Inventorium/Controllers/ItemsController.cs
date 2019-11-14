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
using Microsoft.AspNetCore.Authorization;

namespace Inventorium.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ItemsController(ApplicationDbContext context,
                               UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Item
                                      .Include("Bin")
                                      .OrderBy(i => i.Name)
                                      .ThenBy(i => i.Bin.Name)
                                      .ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Features,Manufacturer,Model,SerialNumber,Source,UnitPrice,Tax,Shipping,DateOfAcquisition,ExpirationDate,Height,Width,Depth,Weight,ID,OwnerID,Name")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ID = Guid.NewGuid();

                // Assign to the current user
                IdentityUser currUser = await _userManager.GetUserAsync(User);
                if (null != currUser)
                {
                    item.OwnerID = currUser.Id;
                }

                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/CreateLike/5
        [Authorize]
        public async Task<IActionResult> CreateLike(Guid? id)
        {
            Item part = await _context.Item.FirstOrDefaultAsync(p => p.ID == id);

            if (null != part)
            {
                part.Name = "Like the " + part.Name;
                part.SerialNumber = "";
            }

            return View(part);
        }

        // POST: Items/CreateLike
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLike([Bind("Description,Features,Manufacturer,Model,SerialNumber,Source,UnitPrice,Tax,Shipping,DateOfAcquisition,ExpirationDate,Height,Width,Depth,Weight,ID,OwnerID,Name")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ID = Guid.NewGuid();

                // Assign to the current user
                IdentityUser currUser = await _userManager.GetUserAsync(User);
                if (null != currUser)
                {
                    item.OwnerID = currUser.Id;
                }

                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        // GET: Items/Find
        public async Task<IActionResult> Find(string searchString)
        {
            if(string.IsNullOrWhiteSpace(searchString))
            {
                return View();
            }

            // Search for any items with the search string in their name/description/model # etc.
            List<Item> foundList = await _context.Item.Where(p => p.Name.Contains(searchString) ||
                                                                  p.Description.Contains(searchString) ||
                                                                  p.Features.Contains(searchString) ||
                                                                  p.Model.Contains(searchString) ||
                                                                  p.Manufacturer.Contains(searchString) ||
                                                                  p.Source.Contains(searchString))
                                                                  .ToListAsync();

            return View(foundList);
        }

        // GET: Items/FindLike/5
        public async Task<IActionResult> FindLike(Guid? id)
        {
            Item part = await _context.Item.FirstOrDefaultAsync(p => p.ID == id);

            if(null != part)
            {
                part.SerialNumber = "";
            }

            // Insert content if any of the source search indicies are blank
            if(string.IsNullOrWhiteSpace(part.Name))
            {
                part.Name = "=*=";
            }

            if (string.IsNullOrWhiteSpace(part.Description))
            {
                part.Description = "=*=";
            }

            if (string.IsNullOrWhiteSpace(part.Model))
            {
                part.Model = "=*=";
            }

            // Seek all parts with the same name, model # or description
            List<Item> itemList = await _context.Item.Where<Item>(p => p.Name == part.Name ||
                                                                  p.Model == part.Model ||
                                                                  p.Description == part.Description)
                                                                  .ToListAsync();

            return View(itemList);
        }

        // GET: Items/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Description,Features,Manufacturer,Model,SerialNumber,Source,UnitPrice,Tax,Shipping,DateOfAcquisition,ExpirationDate,Height,Width,Depth,Weight,ID,OwnerID,Name")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    item.Edition++;

                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
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
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(Guid id)
        {
            return _context.Item.Any(e => e.ID == id);
        }
    }
}
