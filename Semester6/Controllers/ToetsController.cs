using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Semester6.Models;

namespace Semester6.Controllers
{
    public class ToetsController : Controller
    {
        private readonly ToetsContext _context;

        public ToetsController(ToetsContext context)
        {
            _context = context;
        }

        // GET: Toets
        public async Task<IActionResult> Index()
        {
            var toetsContext = _context.Toetsen.Include(t => t.Vak);
            return View(await toetsContext.ToListAsync());
        }

        // GET: Toets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toets = await _context.Toetsen
                .Include(t => t.Vak)
                .FirstOrDefaultAsync(m => m.ToetsId == id);
            if (toets == null)
            {
                return NotFound();
            }

            return View(toets);
        }

        // GET: Toets/Create
        public IActionResult Create()
        {
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId");
            return View();
        }

        // POST: Toets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToetsId,Naam,Datum,VakId")] Toets toets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId", toets.VakId);
            return View(toets);
        }

        // GET: Toets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toets = await _context.Toetsen.FindAsync(id);
            if (toets == null)
            {
                return NotFound();
            }
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId", toets.VakId);
            return View(toets);
        }

        // POST: Toets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToetsId,Naam,Datum,VakId")] Toets toets)
        {
            if (id != toets.ToetsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToetsExists(toets.ToetsId))
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
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId", toets.VakId);
            return View(toets);
        }

        // GET: Toets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toets = await _context.Toetsen
                .Include(t => t.Vak)
                .FirstOrDefaultAsync(m => m.ToetsId == id);
            if (toets == null)
            {
                return NotFound();
            }

            return View(toets);
        }

        // POST: Toets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toets = await _context.Toetsen.FindAsync(id);
            if (toets != null)
            {
                _context.Toetsen.Remove(toets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToetsExists(int id)
        {
            return _context.Toetsen.Any(e => e.ToetsId == id);
        }
    }
}
