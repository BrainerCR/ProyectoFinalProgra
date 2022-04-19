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
    public class RolEmpleadoesController : ControllerBase
    {
        private readonly Proyecto_PrograWebAvanzadaContext _context;

        public RolEmpleadoesController(Proyecto_PrograWebAvanzadaContext context)
        {
            _context = context;
        }

        // GET: api/RolEmpleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolEmpleado>>> GetRolEmpleado()
        {
            return await _context.RolEmpleado.ToListAsync();
        }

        // GET: api/RolEmpleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolEmpleado>> GetRolEmpleado(int id)
        {
            var rolEmpleado = await _context.RolEmpleado.FindAsync(id);

            if (rolEmpleado == null)
            {
                return NotFound();
            }

            return rolEmpleado;
        }

        // PUT: api/RolEmpleadoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolEmpleado(int id, RolEmpleado rolEmpleado)
        {
            if (id != rolEmpleado.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(rolEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolEmpleadoExists(id))
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

        // POST: api/RolEmpleadoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RolEmpleado>> PostRolEmpleado(RolEmpleado rolEmpleado)
        {
            _context.RolEmpleado.Add(rolEmpleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolEmpleadoExists(rolEmpleado.IdRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRolEmpleado", new { id = rolEmpleado.IdRol }, rolEmpleado);
        }

        // DELETE: api/RolEmpleadoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolEmpleado>> DeleteRolEmpleado(int id)
        {
            var rolEmpleado = await _context.RolEmpleado.FindAsync(id);
            if (rolEmpleado == null)
            {
                return NotFound();
            }

            _context.RolEmpleado.Remove(rolEmpleado);
            await _context.SaveChangesAsync();

            return rolEmpleado;
        }

        private bool RolEmpleadoExists(int id)
        {
            return _context.RolEmpleado.Any(e => e.IdRol == id);
        }
    }
}
