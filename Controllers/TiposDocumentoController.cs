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
    public class TiposDocumentoController : ControllerBase
    {
        private readonly GestionDocumentosContext _context;

        public TiposDocumentoController(GestionDocumentosContext context)
        {
            _context = context;
        }

        // GET: api/TiposDocumentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetTiposDocumentos()
        {
          if (_context.TiposDocumentos == null)
          {
              return NotFound();
          }
            return await _context.TiposDocumentos.ToListAsync();
        }

        // GET: api/TiposDocumentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposDocumento>> GetTiposDocumento(int id)
        {
          if (_context.TiposDocumentos == null)
          {
              return NotFound();
          }
            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);

            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return tiposDocumento;
        }

        // PUT: api/TiposDocumentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposDocumento(int id, TiposDocumento tiposDocumento)
        {
            if (id != tiposDocumento.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(tiposDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposDocumentoExists(id))
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

        // POST: api/TiposDocumentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposDocumento>> PostTiposDocumento(TiposDocumento tiposDocumento)
        {
          if (_context.TiposDocumentos == null)
          {
              return Problem("Entity set 'GestionDocumentosContext.TiposDocumentos'  is null.");
          }
            _context.TiposDocumentos.Add(tiposDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposDocumento", new { id = tiposDocumento.Codigo }, tiposDocumento);
        }

        // DELETE: api/TiposDocumentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposDocumento(int id)
        {
            if (_context.TiposDocumentos == null)
            {
                return NotFound();
            }
            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }

            _context.TiposDocumentos.Remove(tiposDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposDocumentoExists(int id)
        {
            return (_context.TiposDocumentos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
