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
    public class DistribuidorController : ControllerBase
    {
        private readonly DBContext _context;

        private readonly IMapper _mapper;

        public DistribuidorController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Distribuidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Distribuidor>>> GetDistribuidor()
        {
            var res =  new BS.Distribuidor(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Distribuidor>, IEnumerable<DataModels.Distribuidor>>(res).ToList(); 


            return mapaux;
        }

        // GET: api/Distribuidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Distribuidor>> GetDistribuidor(int id)
        {
            var distribuidor = new BS.Distribuidor(_context).GetOneByID(id);

            var mapaux = _mapper.Map<data.Distribuidor, DataModels.Distribuidor>(distribuidor);

            if (distribuidor == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Distribuidores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribuidor(int id, DataModels.Distribuidor distribuidor)
        {
            if (id != distribuidor.IdDistribuidor)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Distribuidor, data.Distribuidor>(distribuidor);
                new BS.Distribuidor(_context).Update(mapaux);
            }
            catch (Exception ee)
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

        // POST: api/Distribuidores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Distribuidor>> PostDistribuidorr(DataModels.Distribuidor distribuidor)
        {
            var mapaux = _mapper.Map<DataModels.Distribuidor, data.Distribuidor>(distribuidor);
            new BS.Distribuidor(_context).Insert(mapaux);

            return CreatedAtAction("GetDistribuidor", new { id = distribuidor.IdDistribuidor }, distribuidor);
        }

        // DELETE: api/Proveedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Distribuidor>> DeleteProveedor(int id)
        {
            var proveedor = new BS.Distribuidor(_context).GetOneByID(id);
            if (proveedor == null)
            {
                return NotFound();
            }


            new BS.Distribuidor(_context).Delete(proveedor);
            var mapaux = _mapper.Map<data.Distribuidor, DataModels.Distribuidor>(proveedor);

            return mapaux;
        }

        private bool DistribuidorExists(int id)
        {
            return _context.Distribuidor.Any(e => e.IdDistribuidor == id);
        }
    }
}
