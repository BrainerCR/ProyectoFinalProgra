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
    public class VinculoProductoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public VinculoProductoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: VinculoProductoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VinculoProducto.ToListAsync());
        }

        // GET: VinculoProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinculoProducto = await _context.VinculoProducto
                .FirstOrDefaultAsync(m => m.IdVinculoProducto == id);
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
        public async Task<IActionResult> Create([Bind("IdVinculoProducto,NombreVinculoProducto")] VinculoProducto vinculoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vinculoProducto);
                await _context.SaveChangesAsync();
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

            var vinculoProducto = await _context.VinculoProducto.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdVinculoProducto,NombreVinculoProducto")] VinculoProducto vinculoProducto)
        {
            if (id != vinculoProducto.IdVinculoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinculoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
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

            var vinculoProducto = await _context.VinculoProducto
                .FirstOrDefaultAsync(m => m.IdVinculoProducto == id);
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
            var vinculoProducto = await _context.VinculoProducto.FindAsync(id);
            _context.VinculoProducto.Remove(vinculoProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinculoProductoExists(int id)
        {
            return _context.VinculoProducto.Any(e => e.IdVinculoProducto == id);
        }
    }
}
