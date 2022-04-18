using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolEmpleadoController : ControllerBase
    {
        private readonly NDbContex _context;

        private readonly IMapper _mapper;

        public RolEmpleadoController(NDbContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RolEmpleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.RolEmpleado>>> GetRolEmpleado()
        {
            var res = new BS.Empleado(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.RolEmpleado>, IEnumerable<DataModels.RolEmpleado>>(res).ToList();


            return mapaux;
        }

        // GET: api/RolEmpleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.RolEmpleado>> GetRolEmpleado(int id)
        {
            var rolEmpleado = new BS.RolEmpleado(_context).GetOneByID(id);

            var mapaux = _mapper.Map<data.RolEmpleado, DataModels.RolEmpleado>(rolEmpleado);

            if (rolEmpleado == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/RolEmpleadoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolEmpleado(int id, DataModels.RolEmpleado rolEmpleado)
        {
            if (id != rolEmpleado.IdRol)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.RolEmpleado, data.RolEmpleado>(rolEmpleado);
                new BS.RolEmpleado(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<DataModels.RolEmpleado>> PostRolEmpleado(DataModels.RolEmpleado rolEmpleado)
        {
            var mapaux = _mapper.Map<DataModels.RolEmpleado, data.RolEmpleado>(rolEmpleado);
            new BS.RolEmpleado(_context).Insert(mapaux);
            return CreatedAtAction("GetRolEmpleado", new { id = rolEmpleado.IdRol }, rolEmpleado);
        }

        // DELETE: api/RolEmpleadoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.RolEmpleado>> DeleteRolEmpleado(int id)
        {
            var rolEmpleado = new BS.RolEmpleado(_context).GetOneByID(id);
            if (rolEmpleado == null)
            {
                return NotFound();
            }

            new BS.RolEmpleado(_context).Delete(rolEmpleado);
            var mapaux = _mapper.Map<data.RolEmpleado, DataModels.RolEmpleado>(rolEmpleado);

            return mapaux;
        }

        private bool RolEmpleadoExists(int id)
        {
            return _context.RolEmpleado.Any(e => e.IdRol == id);
        }
    }
}
