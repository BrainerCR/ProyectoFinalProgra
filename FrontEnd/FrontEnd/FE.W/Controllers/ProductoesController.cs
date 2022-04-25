using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.W.Models;

namespace FE.W.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public ProductoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var proyectoFinalContext = _context.Producto.Include(p => p.IdDistribuidorNavigation).Include(p => p.IdVinculoProductoNavigation);
            return View(await proyectoFinalContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdDistribuidorNavigation)
                .Include(p => p.IdVinculoProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["IdDistribuidor"] = new SelectList(_context.Distribuidor, "IdDistribuidor", "CorreoDistribuidor");
            ViewData["IdVinculoProducto"] = new SelectList(_context.VinculoProducto, "IdVinculoProducto", "NombreVinculoProducto");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,FechaIngreso,NombreProducto,CantidadProducto,PrecioUnitario,PrecioVenta,IdVinculoProducto,IdDistribuidor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDistribuidor"] = new SelectList(_context.Distribuidor, "IdDistribuidor", "CorreoDistribuidor", producto.IdDistribuidor);
            ViewData["IdVinculoProducto"] = new SelectList(_context.VinculoProducto, "IdVinculoProducto", "NombreVinculoProducto", producto.IdVinculoProducto);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdDistribuidor"] = new SelectList(_context.Distribuidor, "IdDistribuidor", "CorreoDistribuidor", producto.IdDistribuidor);
            ViewData["IdVinculoProducto"] = new SelectList(_context.VinculoProducto, "IdVinculoProducto", "NombreVinculoProducto", producto.IdVinculoProducto);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,FechaIngreso,NombreProducto,CantidadProducto,PrecioUnitario,PrecioVenta,IdVinculoProducto,IdDistribuidor")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
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
            ViewData["IdDistribuidor"] = new SelectList(_context.Distribuidor, "IdDistribuidor", "CorreoDistribuidor", producto.IdDistribuidor);
            ViewData["IdVinculoProducto"] = new SelectList(_context.VinculoProducto, "IdVinculoProducto", "NombreVinculoProducto", producto.IdVinculoProducto);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdDistribuidorNavigation)
                .Include(p => p.IdVinculoProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
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
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.IdProducto == id);
        }
    }
}
