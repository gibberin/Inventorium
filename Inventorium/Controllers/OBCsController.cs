using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventorium.Data;
using InventoriumLib;

namespace Inventorium.Controllers
{
    public class OBCsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OBCsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OBCs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OBC.ToListAsync());
        }

        // GET: OBCs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oBC = await _context.OBC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oBC == null)
            {
                return NotFound();
            }

            return View(oBC);
        }

        // GET: OBCs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OBCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Platform,CPU,Voltage,FlashMemory,RAM,GPIOCount,AnalogPinCount,PWMPinCount,USBConnectorCount,PowerJack,USBPower,ResetButton,Wifi,Bluetooth,BLE,Out5V,Out3_3V,MaxSourceAmps,Description,Features,Manufacturer,Model,SerialNumber,Source,UnitPrice,Tax,Shipping,DateOfAcquisition,Height,Width,Depth,Weight,ID,OwnerID,Name")] OBC oBC)
        {
            if (ModelState.IsValid)
            {
                oBC.ID = Guid.NewGuid();
                _context.Add(oBC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oBC);
        }

        // GET: OBCs/CreateLike/5
        public async Task<IActionResult> Create(Guid id)
        {
            OBC obc = await _context.OBC.FirstOrDefaultAsync(o => o.ID == id);

            if (null != obc)
            {
                obc.Name = "Like the " + obc.Name;
                obc.SerialNumber = "";
            }

            return View(obc);
        }

        // POST: OBCs/Create/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLike([Bind("Platform,CPU,Voltage,FlashMemory,RAM,GPIOCount,AnalogPinCount,PWMPinCount,USBConnectorCount,PowerJack,USBPower,ResetButton,Wifi,Bluetooth,BLE,Out5V,Out3_3V,MaxSourceAmps,Description,Features,Manufacturer,Model,SerialNumber,Source,UnitPrice,Tax,Shipping,DateOfAcquisition,Height,Width,Depth,Weight,ID,OwnerID,Name")] OBC OBC)
        {
            if (ModelState.IsValid)
            {
                OBC.ID = Guid.NewGuid();
                _context.Add(OBC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(OBC);
        }

        // GET: OBCs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oBC = await _context.OBC.FindAsync(id);
            if (oBC == null)
            {
                return NotFound();
            }
            return View(oBC);
        }

        // POST: OBCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Platform,CPU,Voltage,FlashMemory,RAM,GPIOCount,AnalogPinCount,PWMPinCount,USBConnectorCount,PowerJack,USBPower,ResetButton,Wifi,Bluetooth,BLE,Out5V,Out3_3V,MaxSourceAmps,Description,Features,Manufacturer,Model,SerialNumber,Source,UnitPrice,Tax,Shipping,DateOfAcquisition,Height,Width,Depth,Weight,ID,OwnerID,Name")] OBC OBC)
        {
            if (id != OBC.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    OBC.IncrementEdition();

                    _context.Update(OBC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OBCExists(OBC.ID))
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
            return View(OBC);
        }

        // GET: OBCs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oBC = await _context.OBC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oBC == null)
            {
                return NotFound();
            }

            return View(oBC);
        }

        // POST: OBCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var oBC = await _context.OBC.FindAsync(id);
            _context.OBC.Remove(oBC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OBCExists(Guid id)
        {
            return _context.OBC.Any(e => e.ID == id);
        }
    }
}
