using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class VinculoProductoController : Controller
    {
        private readonly IVinculoProductoServicio vinculoProductoServicio;

        public VinculoProductoController(IVinculoProductoServicio _vinculoProductoServicio)
        {
            vinculoProductoServicio = _vinculoProductoServicio;
        }

        // GET: VinculoProductoes
        public async Task<IActionResult> Index()
        {
            return View(vinculoProductoServicio.GetAll());
        }

        // GET: VinculoProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinculoProducto = vinculoProductoServicio.GetOneById((int)id);

            if (vinculoProducto == null)
            {
                return NotFound();
            }

            return View(vinculoProducto);
        }

        // GET: VinculoProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VinculoProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVinculoProducto,NombreVinculoProducto")] Models.VinculoProducto vinculoProducto)
        {
            if (ModelState.IsValid)
            {
                vinculoProductoServicio.Insert(vinculoProducto);
                return RedirectToAction(nameof(Index));
            }
            return View(vinculoProducto);
        }

        // GET: VinculoProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinculoProducto = vinculoProductoServicio.GetOneById((int)id);

            if (vinculoProducto == null)
            {
                return NotFound();
            }
            return View(vinculoProducto);
        }

        // POST: VinculoProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVinculoProducto,NombreVinculoProducto")] Models.VinculoProducto vinculoProducto)
        {
            if (id != vinculoProducto.IdVinculoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vinculoProductoServicio.Update(vinculoProducto);

                }
                catch (Exception ee)
                {
                    if (!VinculoProductoExists(vinculoProducto.IdVinculoProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vinculoProducto);
        }

        // GET: VinculoProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinculoProducto = vinculoProductoServicio.GetOneById((int)id);

            if (vinculoProducto == null)
            {
                return NotFound();
            }

            return View(vinculoProducto);
        }

        // POST: VinculoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vinculo = vinculoProductoServicio.GetOneById((int)id);
            vinculoProductoServicio.Delete(vinculo);
            return RedirectToAction(nameof(Index));
        }

        private bool VinculoProductoExists(int id)
        {
            return (vinculoProductoServicio.GetOneById((int)id) != null);
        }
    }
}
