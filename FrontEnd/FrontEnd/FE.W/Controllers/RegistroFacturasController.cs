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
    public class RegistroFacturasController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public RegistroFacturasController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: RegistroFacturas
        public async Task<IActionResult> Index()
        {
            var proyectoFinalContext = _context.RegistroFactura.Include(r => r.IdClienteNavigation).Include(r => r.IdEmpleadoNavigation);
            return View(await proyectoFinalContext.ToListAsync());
        }

        // GET: RegistroFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroFactura = await _context.RegistroFactura
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registroFactura == null)
            {
                return NotFound();
            }

            return View(registroFactura);
        }

        // GET: RegistroFacturas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "CorreoEmpleado");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "ApellidoEmpleado");
            return View();
        }

        // POST: RegistroFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistro,CodigoRegistro,IdCliente,IdEmpleado,FechaFactura,TotalFactura")] RegistroFactura registroFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "CorreoEmpleado", registroFactura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "ApellidoEmpleado", registroFactura.IdEmpleado);
            return View(registroFactura);
        }

        // GET: RegistroFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroFactura = await _context.RegistroFactura.FindAsync(id);
            if (registroFactura == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "CorreoEmpleado", registroFactura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "ApellidoEmpleado", registroFactura.IdEmpleado);
            return View(registroFactura);
        }

        // POST: RegistroFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistro,CodigoRegistro,IdCliente,IdEmpleado,FechaFactura,TotalFactura")] RegistroFactura registroFactura)
        {
            if (id != registroFactura.IdRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroFacturaExists(registroFactura.IdRegistro))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "CorreoEmpleado", registroFactura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "ApellidoEmpleado", registroFactura.IdEmpleado);
            return View(registroFactura);
        }

        // GET: RegistroFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroFactura = await _context.RegistroFactura
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registroFactura == null)
            {
                return NotFound();
            }

            return View(registroFactura);
        }

        // POST: RegistroFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroFactura = await _context.RegistroFactura.FindAsync(id);
            _context.RegistroFactura.Remove(registroFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroFacturaExists(int id)
        {
            return _context.RegistroFactura.Any(e => e.IdRegistro == id);
        }
    }
}
