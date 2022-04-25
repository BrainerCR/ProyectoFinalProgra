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
    public class RolEmpleadoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public RolEmpleadoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: RolEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RolEmpleado.ToListAsync());
        }

        // GET: RolEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEmpleado = await _context.RolEmpleado
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (rolEmpleado == null)
            {
                return NotFound();
            }

            return View(rolEmpleado);
        }

        // GET: RolEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,NombreRol")] RolEmpleado rolEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolEmpleado);
        }

        // GET: RolEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEmpleado = await _context.RolEmpleado.FindAsync(id);
            if (rolEmpleado == null)
            {
                return NotFound();
            }
            return View(rolEmpleado);
        }

        // POST: RolEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,NombreRol")] RolEmpleado rolEmpleado)
        {
            if (id != rolEmpleado.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolEmpleadoExists(rolEmpleado.IdRol))
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
            return View(rolEmpleado);
        }

        // GET: RolEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEmpleado = await _context.RolEmpleado
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (rolEmpleado == null)
            {
                return NotFound();
            }

            return View(rolEmpleado);
        }

        // POST: RolEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolEmpleado = await _context.RolEmpleado.FindAsync(id);
            _context.RolEmpleado.Remove(rolEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolEmpleadoExists(int id)
        {
            return _context.RolEmpleado.Any(e => e.IdRol == id);
        }
    }
}
