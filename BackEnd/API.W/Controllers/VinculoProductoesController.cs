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
    public class VinculoProductoesController : ControllerBase
    {
        private readonly ProyectoFinalContext _context;

        public VinculoProductoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: api/VinculoProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinculoProducto>>> GetVinculoProducto()
        {
            return await _context.VinculoProducto.ToListAsync();
        }

        // GET: api/VinculoProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VinculoProducto>> GetVinculoProducto(int id)
        {
            var vinculoProducto = await _context.VinculoProducto.FindAsync(id);

            if (vinculoProducto == null)
            {
                return NotFound();
            }

            return vinculoProducto;
        }

        // PUT: api/VinculoProductoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoProducto(int id, VinculoProducto vinculoProducto)
        {
            if (id != vinculoProducto.IdVinculoProducto)
            {
                return BadRequest();
            }

            _context.Entry(vinculoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinculoProductoExists(id))
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

        // POST: api/VinculoProductoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VinculoProducto>> PostVinculoProducto(VinculoProducto vinculoProducto)
        {
            _context.VinculoProducto.Add(vinculoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinculoProducto", new { id = vinculoProducto.IdVinculoProducto }, vinculoProducto);
        }

        // DELETE: api/VinculoProductoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VinculoProducto>> DeleteVinculoProducto(int id)
        {
            var vinculoProducto = await _context.VinculoProducto.FindAsync(id);
            if (vinculoProducto == null)
            {
                return NotFound();
            }

            _context.VinculoProducto.Remove(vinculoProducto);
            await _context.SaveChangesAsync();

            return vinculoProducto;
        }

        private bool VinculoProductoExists(int id)
        {
            return _context.VinculoProducto.Any(e => e.IdVinculoProducto == id);
        }
    }
}
