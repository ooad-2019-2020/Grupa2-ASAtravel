using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using authTest.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ASA.Controllers
{
    public class PutovanjeController : Controller
    {
        private readonly ASAContext _context;

        public PutovanjeController(ASAContext context)
        {
            _context = context;
        }

        // GET: Putovanje
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://asawebapi.azurewebsites.net";
            List<Putovanje> putovanja = new List<Putovanje>();
            using (var client = new HttpClient())
            {
                //Postavljanje adrese URL od web api servisa
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                //definisanje formata koji želimo prihvatiti
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Asinhrono slanje zahtjeva za podacima o studentima
                HttpResponseMessage Res = await client.GetAsync("Putovanje");
                //Provjera da li je rezultat uspješan
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa
                    var response = Res.Content.ReadAsStringAsync().Result;
                putovanja =  JsonConvert.DeserializeObject<List<Putovanje>>(response);
                }
                return View(putovanja);
            }

        }

        // GET: Putovanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanje = await _context.Putovanje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (putovanje == null)
            {
                return NotFound();
            }

            return View(putovanje);
        }

        // GET: Putovanje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Putovanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Slika,Destinacija,Info,Aktuelno,DatumPolaska,DatumPovratka,MinBrojLjudi,MaxBrojLjudi,Cijena")] Putovanje putovanje)
        {
            if (ModelState.IsValid)
            {

                _context.Add(putovanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(putovanje);
        }

        // GET: Putovanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanje = await _context.Putovanje.FindAsync(id);
            if (putovanje == null)
            {
                return NotFound();
            }
            return View(putovanje);
        }

        // POST: Putovanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Slika,Destinacija,Info,Aktuelno,DatumPolaska,DatumPovratka,MinBrojLjudi,MaxBrojLjudi,Cijena")] Putovanje putovanje)
        {
            if (id != putovanje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(putovanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PutovanjeExists(putovanje.Id))
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
            return View(putovanje);
        }

        // GET: Putovanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanje = await _context.Putovanje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (putovanje == null)
            {
                return NotFound();
            }

            return View(putovanje);
        }

        // POST: Putovanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var putovanje = await _context.Putovanje.FindAsync(id);
            _context.Putovanje.Remove(putovanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PutovanjeExists(int id)
        {
            return _context.Putovanje.Any(e => e.Id == id);
        }
    }
}
