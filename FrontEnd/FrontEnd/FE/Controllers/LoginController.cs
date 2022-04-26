using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class LoginController : Controller
    {
        const string SessionUser = "_User";

        //PARA ACCEDER AL ARCHIVO DE CONFIGURACIÓN APPSETTINGS
        public IConfiguration Configuration { get; }

        public LoginController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public ActionResult Login()
        {
            return View(new Models.Empleado());
        }

        /// <param name="model"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public async Task<IActionResult> Login(Models.Empleado model)
        {
            //SE CREA LA CONECCION CON LA BASE DE DATOS
            string connectionString = Configuration["ConnectionStrings:FronEndAPIContext"];

            //SE USA ADO.NET PARA INTERACTUAR CON LA BASE DE DATOS
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var list_users = new List<Models.Empleado>();

                if (model.CorreoEmpleado == null || model.CorreoEmpleado.Equals("") ||

                        model.ClaveEmpleado == null || model.ClaveEmpleado.Equals(""))

                {

                    ModelState.AddModelError("", "Por favor ingrese sus credenciales");

                }
                else
                {
                    connection.Open();

                    //PROCEDIMIENTO ALMACEANDO PARA EXTRAER USUARIO

                    SqlCommand com = new SqlCommand("GET_SEG_USUARIO", connection);

                    //PARA IDENTIFICAR EL TIPO DE OBJETO A MANIPULAR

                    com.CommandType = CommandType.StoredProcedure; 

                    //ENVIAMOS LOS PARAMETROS AL PROCEDIMIENTO ALMACEANDO

                    com.Parameters.AddWithValue("@usuario", model.CorreoEmpleado);

                    com.Parameters.AddWithValue("@contrasena", model.ClaveEmpleado);

                    //EJECUTAMOS EL COMANDO 

                    SqlDataReader dr = com.ExecuteReader();

                    //RECORREMOS LOS DATOS Y GUARDAMOS LOS DATOS DEL USUARIO EN list_users

                    while (dr.Read())

                    {

                        Models.Empleado empleado = new Models.Empleado();

                        empleado.CorreoEmpleado = Convert.ToString(dr["CorreoEmpleado"]);

                        empleado.ClaveEmpleado = Convert.ToString(dr["ClaveEmpleado"]);

                        empleado.IdRol = Convert.ToInt32(dr["IdRol"]);

                        //GUARDAMOS EN LA LISTA

                        list_users.Add(empleado);

                    }

                    //VALIDAMOS SI COINCIDEN LOS DATOS INGRESADOS CON LA LISTA

                    if (list_users.Any(p => p.CorreoEmpleado == model.CorreoEmpleado && p.ClaveEmpleado == model.ClaveEmpleado))
                    {
                        var grandmaClaims = new List<Claim>{
                          new Claim(ClaimTypes.Email, model.CorreoEmpleado),
                          new Claim ("Grandma says","Ok"),};

                        var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma identity");
                        var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                        HttpContext.SignInAsync(userPrincipal);

                        //SE INICIA LA SESION CON EL CORREO

                        HttpContext.Session.SetString(SessionUser, model.CorreoEmpleado);

                        for (int i = 0; i < list_users.Count; i++)
                        {
                            var rol = list_users[i].IdRol.ToString();
                            HttpContext.Session.SetString("Rol", rol);
                        }

                        return RedirectToAction("Index", "Home");

                    } else
                    {
                        ModelState.AddModelError("", "Datos ingresado no válidos.");
                    }
                }

                return View(model);
            }
            
        }

        [HttpPost]
        public ActionResult LogOff()

        {
            //LIMPIAMOS LA SESÍON

            HttpContext.Session.Clear();

            //ENVIAMOS AL USUARIO AL LOGIN

            return RedirectToAction("Login", "Login");

        }
    }
}
