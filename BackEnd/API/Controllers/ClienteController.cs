using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using AutoMapper;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DBContext _context;


        private readonly IMapper _mapper;

        public ClienteController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Cliente>>> GetCliente()
        {
            var res = new BS.Cliente(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Cliente>, IEnumerable<DataModels.Cliente>>(res).ToList();


            return mapaux;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Cliente>> GetCliente(int id)
        {
            var cliente = new BS.Cliente(_context).GetOneByID(id);

            var mapaux = _mapper.Map<data.Cliente, DataModels.Cliente>(cliente);


            if (cliente == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, DataModels.Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Cliente, data.Cliente>(cliente);
                new BS.Cliente(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Cliente>> PostCliente(DataModels.Cliente cliente)
        {
            var mapaux = _mapper.Map<DataModels.Cliente, data.Cliente>(cliente);
            new BS.Cliente(_context).Insert(mapaux);

            return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Cliente>> DeleteCliente(int id)
        {
            var cliente = new BS.Cliente(_context).GetOneByID(id);
            if (cliente == null)
            {
                return NotFound();
            }

            new BS.Cliente(_context).Delete(cliente);
            var mapaux = _mapper.Map<data.Cliente, DataModels.Cliente>(cliente);


            return mapaux;
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.IdCliente == id);
        }
    }
}

