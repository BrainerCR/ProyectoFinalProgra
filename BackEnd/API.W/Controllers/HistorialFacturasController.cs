using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialFacturasController : ControllerBase
    {
        private readonly Proyecto_PrograWebAvanzadaContext _context;

        public HistorialFacturasController(Proyecto_PrograWebAvanzadaContext context)
        {
            _context = context;
        }

        // GET: api/HistorialFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialFactura>>> GetHistorialFactura()
        {
            return await _context.HistorialFactura.ToListAsync();
        }

        // GET: api/HistorialFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialFactura>> GetHistorialFactura(int id)
        {
            var historialFactura = await _context.HistorialFactura.FindAsync(id);

            if (historialFactura == null)
            {
                return NotFound();
            }

            return historialFactura;
        }

        // PUT: api/HistorialFacturas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialFactura(int id, HistorialFactura historialFactura)
        {
            if (id != historialFactura.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(historialFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialFacturaExists(id))
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

        // POST: api/HistorialFacturas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HistorialFactura>> PostHistorialFactura(HistorialFactura historialFactura)
        {
            _context.HistorialFactura.Add(historialFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialFactura", new { id = historialFactura.IdFactura }, historialFactura);
        }

        // DELETE: api/HistorialFacturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistorialFactura>> DeleteHistorialFactura(int id)
        {
            var historialFactura = await _context.HistorialFactura.FindAsync(id);
            if (historialFactura == null)
            {
                return NotFound();
            }

            _context.HistorialFactura.Remove(historialFactura);
            await _context.SaveChangesAsync();

            return historialFactura;
        }

        private bool HistorialFacturaExists(int id)
        {
            return _context.HistorialFactura.Any(e => e.IdFactura == id);
        }
    }
}
