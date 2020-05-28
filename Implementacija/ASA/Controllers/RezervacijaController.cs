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
    public class RezervacijaController : Controller
    {
        private readonly ASAContext _context;

        public RezervacijaController(ASAContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index()
        {
            var aSAContext = _context.Rezervacija.Include(r => r.Klijent).Include(r => r.Kod).Include(r => r.Putovanje);
            return View(await aSAContext.ToListAsync());
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Klijent)
                .Include(r => r.Kod)
                .Include(r => r.Putovanje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create()
        {
            ViewData["KlijentId"] = new SelectList(_context.Set<Klijent>(), "Id", "Discriminator");
            ViewData["KodId"] = new SelectList(_context.Kod, "Id", "Id");
            ViewData["PutovanjeId"] = new SelectList(_context.Putovanje, "Id", "Id");
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KlijentId,PutovanjeId,KodId,Cijena")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlijentId"] = new SelectList(_context.Set<Klijent>(), "Id", "Discriminator", rezervacija.KlijentId);
            ViewData["KodId"] = new SelectList(_context.Kod, "Id", "Id", rezervacija.KodId);
            ViewData["PutovanjeId"] = new SelectList(_context.Putovanje, "Id", "Id", rezervacija.PutovanjeId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["KlijentId"] = new SelectList(_context.Set<Klijent>(), "Id", "Discriminator", rezervacija.KlijentId);
            ViewData["KodId"] = new SelectList(_context.Kod, "Id", "Id", rezervacija.KodId);
            ViewData["PutovanjeId"] = new SelectList(_context.Putovanje, "Id", "Id", rezervacija.PutovanjeId);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KlijentId,PutovanjeId,KodId,Cijena")] Rezervacija rezervacija)
        {
            if (id != rezervacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.Id))
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
            ViewData["KlijentId"] = new SelectList(_context.Set<Klijent>(), "Id", "Discriminator", rezervacija.KlijentId);
            ViewData["KodId"] = new SelectList(_context.Kod, "Id", "Id", rezervacija.KodId);
            ViewData["PutovanjeId"] = new SelectList(_context.Putovanje, "Id", "Id", rezervacija.PutovanjeId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Klijent)
                .Include(r => r.Kod)
                .Include(r => r.Putovanje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.Id == id);
        }
    }
}
