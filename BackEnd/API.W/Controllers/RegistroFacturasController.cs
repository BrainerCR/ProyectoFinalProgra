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
    public class RegistroFacturasController : ControllerBase
    {
        private readonly ProyectoFinalContext _context;

        public RegistroFacturasController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: api/RegistroFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroFactura>>> GetRegistroFactura()
        {
            return await _context.RegistroFactura.ToListAsync();
        }

        // GET: api/RegistroFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroFactura>> GetRegistroFactura(int id)
        {
            var registroFactura = await _context.RegistroFactura.FindAsync(id);

            if (registroFactura == null)
            {
                return NotFound();
            }

            return registroFactura;
        }

        // PUT: api/RegistroFacturas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroFactura(int id, RegistroFactura registroFactura)
        {
            if (id != registroFactura.IdRegistro)
            {
                return BadRequest();
            }

            _context.Entry(registroFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroFacturaExists(id))
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

        // POST: api/RegistroFacturas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegistroFactura>> PostRegistroFactura(RegistroFactura registroFactura)
        {
            _context.RegistroFactura.Add(registroFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroFactura", new { id = registroFactura.IdRegistro }, registroFactura);
        }

        // DELETE: api/RegistroFacturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroFactura>> DeleteRegistroFactura(int id)
        {
            var registroFactura = await _context.RegistroFactura.FindAsync(id);
            if (registroFactura == null)
            {
                return NotFound();
            }

            _context.RegistroFactura.Remove(registroFactura);
            await _context.SaveChangesAsync();

            return registroFactura;
        }

        private bool RegistroFacturaExists(int id)
        {
            return _context.RegistroFactura.Any(e => e.IdRegistro == id);
        }
    }
}
