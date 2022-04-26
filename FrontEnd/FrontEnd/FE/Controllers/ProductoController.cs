using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoServicio productoServicio;

        DistribuidorServicio proveedor = new DistribuidorServicio();
        VinculoProductoServicio familiaP = new VinculoProductoServicio();

        public ProductoController(IProductoServicio _productoServicio)
        {
            productoServicio = _productoServicio;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            return View(productoServicio.GetAll());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = productoServicio.GetOneById((int)id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["IdDistribuidor"] = new SelectList(proveedor.GetAll(), "IdDistribuidor", "CorreoDistribuidor");
            ViewData["IdVinculoProducto"] = new SelectList(familiaP.GetAll(), "IdVinculoProducto", "NombreVinculoProducto");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,FechaIngreso,NombreProducto,CantidadProducto,PrecioUnitario,PrecioVenta,IdVinculoProducto,IdDistribuidor")] Models.Producto producto)
        {
            if (ModelState.IsValid)
            {
                productoServicio.Insert(producto);
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdDistribuidor"] = new SelectList(proveedor.GetAll(), "IdDistribuidor", "CorreoDistribuidor", producto.IdDistribuidor);
            ViewData["IdVinculoProducto"] = new SelectList(familiaP.GetAll(), "IdVinculoProducto", "NombreVinculoProducto", producto.IdVinculoProducto);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = productoServicio.GetOneById((int)id);

            if (producto == null)
            {
                return NotFound();
            }

            ViewData["IdDistribuidor"] = new SelectList(proveedor.GetAll(), "IdDistribuidor", "CorreoDistribuidor", producto.IdDistribuidor);
            ViewData["IdVinculoProducto"] = new SelectList(familiaP.GetAll(), "IdVinculoProducto", "NombreVinculoProducto", producto.IdVinculoProducto);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,FechaIngreso,NombreProducto,CantidadProducto,PrecioUnitario,PrecioVenta,IdVinculoProducto,IdDistribuidor")] Models.Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productoServicio.Update(producto);
                }
                catch (Exception ee)
                {
                    if (!ProductoExists(producto.IdProducto))
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

            ViewData["IdDistribuidor"] = new SelectList(proveedor.GetAll(), "IdDistribuidor", "CorreoDistribuidor", producto.IdDistribuidor);
            ViewData["IdVinculoProducto"] = new SelectList(familiaP.GetAll(), "IdVinculoProducto", "NombreVinculoProducto", producto.IdVinculoProducto);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = productoServicio.GetOneById((int)id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = productoServicio.GetOneById((int)id);
            productoServicio.Delete(producto);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return (productoServicio.GetOneById((int)id) != null);
        }
    }
}
