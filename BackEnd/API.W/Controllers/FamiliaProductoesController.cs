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
    public class FamiliaProductoesController : ControllerBase
    {
        private readonly Proyecto_PrograWebAvanzadaContext _context;

        public FamiliaProductoesController(Proyecto_PrograWebAvanzadaContext context)
        {
            _context = context;
        }

        // GET: api/FamiliaProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamiliaProducto>>> GetFamiliaProducto()
        {
            return await _context.FamiliaProducto.ToListAsync();
        }

        // GET: api/FamiliaProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamiliaProducto>> GetFamiliaProducto(int id)
        {
            var familiaProducto = await _context.FamiliaProducto.FindAsync(id);

            if (familiaProducto == null)
            {
                return NotFound();
            }

            return familiaProducto;
        }

        // PUT: api/FamiliaProductoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamiliaProducto(int id, FamiliaProducto familiaProducto)
        {
            if (id != familiaProducto.IdFamiliaProducto)
            {
                return BadRequest();
            }

            _context.Entry(familiaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamiliaProductoExists(id))
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

        // POST: api/FamiliaProductoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FamiliaProducto>> PostFamiliaProducto(FamiliaProducto familiaProducto)
        {
            _context.FamiliaProducto.Add(familiaProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamiliaProducto", new { id = familiaProducto.IdFamiliaProducto }, familiaProducto);
        }

        // DELETE: api/FamiliaProductoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FamiliaProducto>> DeleteFamiliaProducto(int id)
        {
            var familiaProducto = await _context.FamiliaProducto.FindAsync(id);
            if (familiaProducto == null)
            {
                return NotFound();
            }

            _context.FamiliaProducto.Remove(familiaProducto);
            await _context.SaveChangesAsync();

            return familiaProducto;
        }

        private bool FamiliaProductoExists(int id)
        {
            return _context.FamiliaProducto.Any(e => e.IdFamiliaProducto == id);
        }
    }
}
