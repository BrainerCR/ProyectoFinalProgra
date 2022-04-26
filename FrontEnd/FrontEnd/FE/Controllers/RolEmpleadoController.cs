using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class RolEmpleadoController : Controller
    {
        private readonly IRolEmpleadoServicio rolEmpleadoServicio;

        public RolEmpleadoController(IRolEmpleadoServicio _rolEmpleadoServicio)
        {
            rolEmpleadoServicio = _rolEmpleadoServicio;
        }

        // GET: RolEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(rolEmpleadoServicio.GetAll());
        }

        // GET: RolEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEmpleado = rolEmpleadoServicio.GetOneById((int)id);

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
        public async Task<IActionResult> Create([Bind("IdRol,NombreRol")] Models.RolEmpleado rolEmpleado)
        {
            if (ModelState.IsValid)
            {
                rolEmpleadoServicio.Insert(rolEmpleado);
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

            var rolEmpleado = rolEmpleadoServicio.GetOneById((int)id);

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
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,NombreRol")] Models.RolEmpleado rolEmpleado)
        {
            if (id != rolEmpleado.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    rolEmpleadoServicio.Update(rolEmpleado);
                }
                catch (Exception ee)
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

            var rolEmpleado = rolEmpleadoServicio.GetOneById((int)id);

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
            var rolEmpleado = rolEmpleadoServicio.GetOneById((int)id);
            rolEmpleadoServicio.Delete(rolEmpleado);
            return RedirectToAction(nameof(Index));
        }

        private bool RolEmpleadoExists(int id)
        {
            return (rolEmpleadoServicio.GetOneById((int)id) != null);
        }
    }
}
