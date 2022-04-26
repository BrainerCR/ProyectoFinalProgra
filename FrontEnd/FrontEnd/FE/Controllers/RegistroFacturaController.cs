using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class RegistroFacturaController : Controller
    {
        ClienteServicio clienteS = new ClienteServicio();
        EmpleadoSerivicio empleadoS = new EmpleadoSerivicio();

        private readonly IRegistroFacturaServicio registroFacturaServicio;

        public RegistroFacturaController(IRegistroFacturaServicio _registroFacturaServicio)
        {
            registroFacturaServicio = _registroFacturaServicio;
        }

        // GET: RegistroFacturas
        public async Task<IActionResult> Index()
        {
            return View(registroFacturaServicio.GetAll());
        }

        // GET: RegistroFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroFactura = registroFacturaServicio.GetOneById((int)id);

            if (registroFactura == null)
            {
                return NotFound();
            }

            return View(registroFactura);
        }

        // GET: RegistroFacturas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(clienteS.GetAll(), "IdCliente", "CorreoEmpleado");
            ViewData["IdEmpleado"] = new SelectList(empleadoS.GetAll(), "IdEmpleado", "ApellidoEmpleado");
            return View();
        }

        // POST: RegistroFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistro,CodigoRegistro,IdCliente,IdEmpleado,FechaFactura,TotalFactura")] Models.RegistroFactura registroFactura)
        {
            if (ModelState.IsValid)
            {
                registroFacturaServicio.Insert(registroFactura);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(clienteS.GetAll(), "IdCliente", "CorreoEmpleado", registroFactura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(empleadoS.GetAll(), "IdEmpleado", "ApellidoEmpleado", registroFactura.IdEmpleado);
            return View(registroFactura);
        }

        // GET: RegistroFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroFactura = registroFacturaServicio.GetOneById((int)id);

            if (registroFactura == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(clienteS.GetAll(), "IdCliente", "CorreoEmpleado", registroFactura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(empleadoS.GetAll(), "IdEmpleado", "ApellidoEmpleado", registroFactura.IdEmpleado);
            return View(registroFactura);
        }

        // POST: RegistroFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistro,CodigoRegistro,IdCliente,IdEmpleado,FechaFactura,TotalFactura")] Models.RegistroFactura registroFactura)
        {
            if (id != registroFactura.IdRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    registroFacturaServicio.Update(registroFactura);

                }
                catch (Exception ee)
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
            ViewData["IdCliente"] = new SelectList(clienteS.GetAll(), "IdCliente", "CorreoEmpleado", registroFactura.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(empleadoS.GetAll(), "IdEmpleado", "ApellidoEmpleado", registroFactura.IdEmpleado);
            return View(registroFactura);
        }

        // GET: RegistroFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroFactura = registroFacturaServicio.GetOneById((int)id);

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
            var registroFactura = registroFacturaServicio.GetOneById((int)id);
            registroFacturaServicio.Delete(registroFactura);
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroFacturaExists(int id)
        {
            return (registroFacturaServicio.GetOneById((int)id) != null);
        }
    }
}
