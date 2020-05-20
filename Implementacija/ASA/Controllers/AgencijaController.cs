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
    public class AgencijaController : Controller
    {
        private readonly ASAContext _context;

        public AgencijaController(ASAContext context)
        {
            _context = context;
        }

        // GET: Agencija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agencija.ToListAsync());
        }

        // GET: Agencija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencija = await _context.Agencija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agencija == null)
            {
                return NotFound();
            }

            return View(agencija);
        }

        // GET: Agencija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agencija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Info,Naziv,UsloviPutovanja")] Agencija agencija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agencija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agencija);
        }

        // GET: Agencija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencija = await _context.Agencija.FindAsync(id);
            if (agencija == null)
            {
                return NotFound();
            }
            return View(agencija);
        }

        // POST: Agencija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Info,Naziv,UsloviPutovanja")] Agencija agencija)
        {
            if (id != agencija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agencija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgencijaExists(agencija.Id))
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
            return View(agencija);
        }

        // GET: Agencija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencija = await _context.Agencija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agencija == null)
            {
                return NotFound();
            }

            return View(agencija);
        }

        // POST: Agencija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencija = await _context.Agencija.FindAsync(id);
            _context.Agencija.Remove(agencija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgencijaExists(int id)
        {
            return _context.Agencija.Any(e => e.Id == id);
        }
    }
}
