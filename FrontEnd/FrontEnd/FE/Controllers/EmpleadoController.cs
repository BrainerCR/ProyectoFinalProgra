using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServicio empleadoServicio;

        public EmpleadoController(IEmpleadoServicio _empleadoServicio)
        {
            empleadoServicio = _empleadoServicio;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            return View(empleadoServicio.GetAll());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = empleadoServicio.GetOneById((int)id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,CedulaEmpleado,NombreEmpleado,ApellidoEmpleado,CorreoEmpleado,ClaveEmpleado,Provincia,TelefonoEmpleado,IdRol")] Models.Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleadoServicio.Insert(empleado);
                return RedirectToAction(nameof(Index));
            }
            
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = empleadoServicio.GetOneById((int)id);

            if (empleado == null)
            {
                return NotFound();
            }
            
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,CedulaEmpleado,NombreEmpleado,ApellidoEmpleado,CorreoEmpleado,ClaveEmpleado,Provincia,TelefonoEmpleado,IdRol")] Models.Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    empleadoServicio.Update(empleado);
                }
                catch (Exception ee)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = empleadoServicio.GetOneById((int)id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = empleadoServicio.GetOneById((int)id);
            empleadoServicio.Delete(empleado);
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return (empleadoServicio.GetOneById((int)id) != null);
        }
    }
}
