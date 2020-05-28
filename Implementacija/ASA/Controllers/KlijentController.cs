using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using authTest.Models;

namespace ASA.Controllers
{
    public class KlijentController : Controller
    {
        private readonly ASAContext _context;

        public KlijentController(ASAContext context)
        {
            _context = context;
        }

        // GET: Klijent
        public async Task<IActionResult> Index()
        {
            var aSAContext = _context.Klijent.Include(k => k.Agencija).Include(k => k.Racun);
            return View(await aSAContext.ToListAsync());
        }

        // GET: Klijent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijent
                .Include(k => k.Agencija)
                .Include(k => k.Racun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // GET: Klijent/Create
        public IActionResult Create()
        {
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id");
            ViewData["RacunId"] = new SelectList(_context.Racun, "Id", "Id");
            return View();
        }

        // POST: Klijent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Prezime,DatumRodjenja,MjestoStanovanja,Email,RacunId,Id,Username,Password,AgencijaId")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klijent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id", klijent.AgencijaId);
            ViewData["RacunId"] = new SelectList(_context.Racun, "Id", "Id", klijent.RacunId);
            return View(klijent);
        }

        // GET: Klijent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijent.FindAsync(id);
            if (klijent == null)
            {
                return NotFound();
            }
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id", klijent.AgencijaId);
            ViewData["RacunId"] = new SelectList(_context.Racun, "Id", "Id", klijent.RacunId);
            return View(klijent);
        }

        // POST: Klijent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ime,Prezime,DatumRodjenja,MjestoStanovanja,Email,RacunId,Id,Username,Password,AgencijaId")] Klijent klijent)
        {
            if (id != klijent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klijent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlijentExists(klijent.Id))
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
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id", klijent.AgencijaId);
            ViewData["RacunId"] = new SelectList(_context.Racun, "Id", "Id", klijent.RacunId);
            return View(klijent);
        }

        // GET: Klijent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijent
                .Include(k => k.Agencija)
                .Include(k => k.Racun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // POST: Klijent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klijent = await _context.Klijent.FindAsync(id);
            _context.Klijent.Remove(klijent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlijentExists(int id)
        {
            return _context.Klijent.Any(e => e.Id == id);
        }
    }
}
