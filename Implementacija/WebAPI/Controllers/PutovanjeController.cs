using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PutovanjeController : ControllerBase
    {
        private readonly ASAbazaContext _context;

        public PutovanjeController(ASAbazaContext context)
        {
            _context = context;
        }

        // GET: api/Putovanje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Putovanje>>> GetPutovanje()
        {
            return await _context.Putovanje.ToListAsync();
        }

        // GET: api/Putovanje/5
        [HttpGet("find/{Id}")]
        public async Task<ActionResult<Putovanje>> GetPutovanje(int id)
        {
              var putovanje = await _context.Putovanje.FindAsync(id);

            if (putovanje == null)
            {
                return NotFound();
            }

            return putovanje;
        }

        // PUT: api/Putovanje/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPutovanje(int id, Putovanje putovanje)
        {
            if (id != putovanje.Id)
            {
                return BadRequest();
            }

            _context.Entry(putovanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PutovanjeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Putovanje
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Putovanje>> PostPutovanje(Putovanje putovanje)
        {
            _context.Putovanje.Add(putovanje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPutovanje", new { id = putovanje.Id }, putovanje);
        }

        // DELETE: api/Putovanje/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Putovanje>> DeletePutovanje(int id)
        {
            var putovanje = await _context.Putovanje.FindAsync(id);
            if (putovanje == null)
            {
                return NotFound();
            }

            _context.Putovanje.Remove(putovanje);
            await _context.SaveChangesAsync();

            return putovanje;
        }

        private bool PutovanjeExists(int id)
        {
            return _context.Putovanje.Any(e => e.Id == id);
        }
    }
}
