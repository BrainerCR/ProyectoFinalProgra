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
    public class DistribuidorsController : ControllerBase
    {
        private readonly ProyectoFinalContext _context;

        public DistribuidorsController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: api/Distribuidors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribuidor>>> GetDistribuidor()
        {
            return await _context.Distribuidor.ToListAsync();
        }

        // GET: api/Distribuidors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distribuidor>> GetDistribuidor(int id)
        {
            var distribuidor = await _context.Distribuidor.FindAsync(id);

            if (distribuidor == null)
            {
                return NotFound();
            }

            return distribuidor;
        }

        // PUT: api/Distribuidors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribuidor(int id, Distribuidor distribuidor)
        {
            if (id != distribuidor.IdDistribuidor)
            {
                return BadRequest();
            }

            _context.Entry(distribuidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistribuidorExists(id))
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

        // POST: api/Distribuidors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Distribuidor>> PostDistribuidor(Distribuidor distribuidor)
        {
            _context.Distribuidor.Add(distribuidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistribuidor", new { id = distribuidor.IdDistribuidor }, distribuidor);
        }

        // DELETE: api/Distribuidors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Distribuidor>> DeleteDistribuidor(int id)
        {
            var distribuidor = await _context.Distribuidor.FindAsync(id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            _context.Distribuidor.Remove(distribuidor);
            await _context.SaveChangesAsync();

            return distribuidor;
        }

        private bool DistribuidorExists(int id)
        {
            return _context.Distribuidor.Any(e => e.IdDistribuidor == id);
        }
    }
}
