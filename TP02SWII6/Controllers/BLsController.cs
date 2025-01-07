using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02SWII6.Model;

namespace TP02SWII6.Controllers
{
    public class BLsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BLsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BLs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BLs.ToListAsync());
        }

        // GET: BLs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var bl = await _context.BLs
                .Include(b => b.Containers)
                .FirstOrDefaultAsync(b => b.ID == id);

            if (bl == null) return NotFound();

            return View(bl);
        }

        // GET: BLs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Consignee,Navio")] BL bL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bL);
        }

        // GET: BLs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bL = await _context.BLs.FindAsync(id);
            if (bL == null)
            {
                return NotFound();
            }
            return View(bL);
        }

        // POST: BLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Consignee,Navio")] BL bL)
        {
            if (id != bL.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BLExists(bL.ID))
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
            return View(bL);
        }

        // GET: BLs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bL = await _context.BLs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bL == null)
            {
                return NotFound();
            }

            return View(bL);
        }

        // POST: BLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bL = await _context.BLs.FindAsync(id);
            if (bL != null)
            {
                _context.BLs.Remove(bL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BLExists(int id)
        {
            return _context.BLs.Any(e => e.ID == id);
        }
    }
}
