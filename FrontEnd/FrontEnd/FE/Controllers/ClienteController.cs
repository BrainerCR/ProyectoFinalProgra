using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicio clienteServicio;

        public ClienteController(IClienteServicio _clienteServicio)
        {
            clienteServicio = _clienteServicio;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(clienteServicio.GetAll());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicio.GetOneById((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,CedulaCliente,FechaIngreso,NombreCliente,CorreoEmpleado,Provincia")] Models.Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteServicio.Insert(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicio.GetOneById((int)id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,CedulaCliente,FechaIngreso,NombreCliente,CorreoEmpleado,Provincia")] Models.Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clienteServicio.Update(cliente);
                }
                catch (Exception ee)
                {
                    if (!ClienteExists(cliente.IdCliente))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicio.GetOneById((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = clienteServicio.GetOneById((int)id);
            clienteServicio.Delete(cliente);
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return (clienteServicio.GetOneById((int)id) != null);
        }
    }
}
