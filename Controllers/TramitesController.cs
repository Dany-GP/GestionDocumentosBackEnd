using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGestionDocumentos.Data;
using APIGestionDocumentos.Models;

namespace APIGestionDocumentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramitesController : ControllerBase
    {
        private readonly GestionDocumentosContext _context;

        public TramitesController(GestionDocumentosContext context)
        {
            _context = context;
        }

        // GET: api/Tramites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tramite>>> GetTramites()
        {
          if (_context.Tramites == null)
          {
              return NotFound();
          }
            return await _context.Tramites.ToListAsync();
        }

        // GET: api/Tramites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tramite>> GetTramite(int id)
        {
          if (_context.Tramites == null)
          {
              return NotFound();
          }
            var tramite = await _context.Tramites.FindAsync(id);

            if (tramite == null)
            {
                return NotFound();
            }

            return tramite;
        }

        // PUT: api/Tramites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTramite(int id, Tramite tramite)
        {
            if (id != tramite.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(tramite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramiteExists(id))
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

        // POST: api/Tramites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tramite>> PostTramite(Tramite tramite)
        {
          if (_context.Tramites == null)
          {
              return Problem("Entity set 'GestionDocumentosContext.Tramites'  is null.");
          }
            _context.Tramites.Add(tramite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTramite", new { id = tramite.Codigo }, tramite);
        }

        // DELETE: api/Tramites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTramite(int id)
        {
            if (_context.Tramites == null)
            {
                return NotFound();
            }
            var tramite = await _context.Tramites.FindAsync(id);
            if (tramite == null)
            {
                return NotFound();
            }

            _context.Tramites.Remove(tramite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TramiteExists(int id)
        {
            return (_context.Tramites?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
