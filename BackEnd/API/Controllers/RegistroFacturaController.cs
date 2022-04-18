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
    public class RegistroFacturaController : ControllerBase
    {
        private readonly NDbContex _context;

        private readonly IMapper _mapper;

        public RegistroFacturaController(NDbContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RegistroFactura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.RegistroFactura>>> GetRegistroFactura()
        {
            var res = await new BS.RegistroFactura(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.RegistroFactura>, IEnumerable<DataModels.RegistroFactura>>(res).ToList(); //izquierda dato que viene, derecha el dato que va a terminar siendo

            return mapaux;
        }

        // GET: api/RegistroFactura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.RegistroFactura>> GetRegistroFactura(int id)
        {
            var historialFactura = new BS.RegistroFactura(_context).GetOneByID(id);

            var mapaux = _mapper.Map<data.RegistroFactura, DataModels.RegistroFactura>(historialFactura);

            if (historialFactura == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/RegistroFactura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroFactura(int id, DataModels.RegistroFactura registroFactura)
        {
            if (id != registroFactura.IdRegistro)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.RegistroFactura, data.RegistroFactura>(registroFactura);
                new BS.RegistroFactura(_context).Update(mapaux);
            }
            catch (Exception ee)
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

        // POST: api/RegistroFactura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.RegistroFactura>> PostRegistroFactura(DataModels.RegistroFactura registroFactura)
        {
            var mapaux = _mapper.Map<DataModels.RegistroFactura, data.RegistroFactura>(registroFactura);
            new BS.RegistroFactura(_context).Insert(mapaux);

            return CreatedAtAction("GetHistorialFactura", new { id = registroFactura.IdRegistro }, registroFactura);
        }

        // DELETE: api/RegistroFactura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.RegistroFactura>> DeleteRegistroFactura(int id)
        {
            var registroFactura = new BS.RegistroFactura(_context).GetOneByID(id);
            if (registroFactura == null)
            {
                return NotFound();
            }


            new BS.RegistroFactura(_context).Delete(registroFactura);
            var mapaux = _mapper.Map<data.RegistroFactura, DataModels.RegistroFactura>(registroFactura);

            return mapaux;
        }

        private bool RegistroFacturaExists(int id)
        {
            return _context.RegistroFactura.Any(e => e.IdRegistro == id);
        }
    }
}
