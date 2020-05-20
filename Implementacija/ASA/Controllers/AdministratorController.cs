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
    public class AdministratorController : Controller
    {
        private readonly ASAContext _context;

        public AdministratorController(ASAContext context)
        {
            _context = context;
        }

        // GET: Administrator
        public async Task<IActionResult> Index()
        {
            var aSAContext = _context.Administrator.Include(a => a.Agencija);
            return View(await aSAContext.ToListAsync());
        }

        // GET: Administrator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrator
                .Include(a => a.Agencija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // GET: Administrator/Create
        public IActionResult Create()
        {
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id");
            return View();
        }

        // POST: Administrator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,AgencijaId")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id", administrator.AgencijaId);
            return View(administrator);
        }

        // GET: Administrator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id", administrator.AgencijaId);
            return View(administrator);
        }

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,AgencijaId")] Administrator administrator)
        {
            if (id != administrator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.Id))
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
            ViewData["AgencijaId"] = new SelectList(_context.Agencija, "Id", "Id", administrator.AgencijaId);
            return View(administrator);
        }

        // GET: Administrator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrator
                .Include(a => a.Agencija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrator = await _context.Administrator.FindAsync(id);
            _context.Administrator.Remove(administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrator.Any(e => e.Id == id);
        }
    }
}
