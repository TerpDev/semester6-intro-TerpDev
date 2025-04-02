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
    public class ToetsResultaatsController : Controller
    {
        private readonly ToetsContext _context;

        public ToetsResultaatsController(ToetsContext context)
        {
            _context = context;
        }

        // GET: ToetsResultaats
        public async Task<IActionResult> Index()
        {
            var toetsContext = _context.ToetsResultaten.Include(t => t.Student).Include(t => t.Toets);
            return View(await toetsContext.ToListAsync());
        }

        // GET: ToetsResultaats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten
                .Include(t => t.Student)
                .Include(t => t.Toets)
                .FirstOrDefaultAsync(m => m.ToetsResultaatId == id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // GET: ToetsResultaats/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId");
            ViewData["ToetsId"] = new SelectList(_context.Toetsen, "ToetsId", "ToetsId");
            return View();
        }

        // POST: ToetsResultaats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToetsResultaatId,StudentId,ToetsId,IsHerkansing,Cijfer")] ToetsResultaat toetsResultaat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toetsResultaat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", toetsResultaat.StudentId);
            ViewData["ToetsId"] = new SelectList(_context.Toetsen, "ToetsId", "ToetsId", toetsResultaat.ToetsId);
            return View(toetsResultaat);
        }

        // GET: ToetsResultaats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten.FindAsync(id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", toetsResultaat.StudentId);
            ViewData["ToetsId"] = new SelectList(_context.Toetsen, "ToetsId", "ToetsId", toetsResultaat.ToetsId);
            return View(toetsResultaat);
        }

        // POST: ToetsResultaats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToetsResultaatId,StudentId,ToetsId,IsHerkansing,Cijfer")] ToetsResultaat toetsResultaat)
        {
            if (id != toetsResultaat.ToetsResultaatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toetsResultaat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToetsResultaatExists(toetsResultaat.ToetsResultaatId))
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
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", toetsResultaat.StudentId);
            ViewData["ToetsId"] = new SelectList(_context.Toetsen, "ToetsId", "ToetsId", toetsResultaat.ToetsId);
            return View(toetsResultaat);
        }

        // GET: ToetsResultaats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten
                .Include(t => t.Student)
                .Include(t => t.Toets)
                .FirstOrDefaultAsync(m => m.ToetsResultaatId == id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // POST: ToetsResultaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toetsResultaat = await _context.ToetsResultaten.FindAsync(id);
            if (toetsResultaat != null)
            {
                _context.ToetsResultaten.Remove(toetsResultaat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToetsResultaatExists(int id)
        {
            return _context.ToetsResultaten.Any(e => e.ToetsResultaatId == id);
        }
    }
}
