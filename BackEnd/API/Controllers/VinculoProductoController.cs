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
    public class VinculoProductoController : ControllerBase
    {
        private readonly DBContext _context;

        private readonly IMapper _mapper;

        public VinculoProductoController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/VinculoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.VinculoProducto>>> GetVinculoProducto()
        {
            var res = new BS.VinculoProducto(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.VinculoProducto>, IEnumerable<DataModels.VinculoProducto>>(res).ToList();

            return mapaux;
        }

        // GET: api/VinculoProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.VinculoProducto>> GetVinculoProducto(int id)
        {
            var vinculoProducto = new BS.VinculoProducto(_context).GetOneByID(id);


            var mapaux = _mapper.Map<data.VinculoProducto, DataModels.VinculoProducto>(vinculoProducto);


            if (vinculoProducto == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/VinculoProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinculoProducto(int id, DataModels.VinculoProducto vinculoProducto)
        {
            if (id != vinculoProducto.IdVinculoProducto)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = _mapper.Map<DataModels.VinculoProducto, data.VinculoProducto>(vinculoProducto);
                new BS.VinculoProducto(_context).Update(mapaux);
            }
            catch (Exception ee)
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

        // POST: api/VinculoProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.VinculoProducto>> PostVinculoProducto(DataModels.VinculoProducto vinculoProducto)
        {
            var mapaux = _mapper.Map<DataModels.VinculoProducto, data.VinculoProducto>(vinculoProducto);
            new BS.VinculoProducto(_context).Insert(mapaux);

            return CreatedAtAction("GetVinculoProducto", new { id = vinculoProducto.IdVinculoProducto }, vinculoProducto);
        }

        // DELETE: api/VinculoProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.VinculoProducto>> DeleteVinculoProducto(int id)
        {
            var vinculoProducto = new BS.VinculoProducto(_context).GetOneByID(id);

            if (vinculoProducto == null)
            {
                return NotFound();
            }

            new BS.VinculoProducto(_context).Delete(vinculoProducto);
            var mapaux = _mapper.Map<data.VinculoProducto, DataModels.VinculoProducto>(vinculoProducto);

            return mapaux;
        }

        private bool VinculoProductoExists(int id)
        {
            return _context.VinculoProducto.Any(e => e.IdVinculoProducto == id);
        }
    }
}
