using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class DistribuidorController : Controller
    {
        private readonly IDistribuidorServicio distribuidorServicio;

        public DistribuidorController(IDistribuidorServicio _distribuidorServicio)
        {
            distribuidorServicio = _distribuidorServicio;
        }

        // GET: Distribuidors
        public async Task<IActionResult> Index()
        {
            return View(distribuidorServicio.GetAll());
        }

        // GET: Distribuidors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = distribuidorServicio.GetOneById((int)id);

            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // GET: Distribuidors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distribuidors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDistribuidor,CedulaDistribuidor,FechaIngreso,NombreDistribuidor,CorreoDistribuidor,Provincia,TelefonoDistribuidor")] Models.Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                distribuidorServicio.Insert(distribuidor);
                return RedirectToAction(nameof(Index));

            }
            return View(distribuidor);
        }

        // GET: Distribuidors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = distribuidorServicio.GetOneById((int)id);

            if (distribuidor == null)
            {
                return NotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDistribuidor,CedulaDistribuidor,FechaIngreso,NombreDistribuidor,CorreoDistribuidor,Provincia,TelefonoDistribuidor")] Models.Distribuidor distribuidor)
        {
            if (id != distribuidor.IdDistribuidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    distribuidorServicio.Update(distribuidor);

                }
                catch (Exception ee)
                {
                    if (!DistribuidorExists(distribuidor.IdDistribuidor))
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
            return View(distribuidor);
        }

        // GET: Distribuidors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = distribuidorServicio.GetOneById((int)id);

            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // POST: Distribuidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distribuidor = distribuidorServicio.GetOneById((int)id);
            distribuidorServicio.Delete(distribuidor);
            return RedirectToAction(nameof(Index));
        }

        private bool DistribuidorExists(int id)
        {
            return (distribuidorServicio.GetOneById((int)id) != null);
        }
    }
}
