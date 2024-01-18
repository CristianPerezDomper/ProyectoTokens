using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto01.Models;
using System.Security.Claims;

namespace Proyecto01.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    nombre = "Miguel",
                    edad = "33",
                    correo = "google1@gmail.com"

                },
                new Cliente
                {
                    id = "2",
                    nombre = "Jose",
                    edad = "29",
                    correo = "jose@gmail.com"

                }
            };

        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {        

            return clientes;
            
        }

        [HttpGet]
        [Route("listarId")]
        public dynamic listarClienteId(string id)
        {
            //Cliente persona = new Cliente();

            //foreach (var cliente in clientes) 
            //{
            //    if (cliente.id == id) 
            //    {
            //        persona = cliente;
            //    }
            //}

            //return persona;

            //Obtienes cliente de la base de datos

            //return clientes.Where(c => c.id == id).First();

            return new Cliente
            {
                id = id,
                nombre = "Miguel",
                edad = "33",
                correo = "google1@gmail.com"

            };

        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";
            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        [Authorize]
        public dynamic eliminarCliente(Cliente cliente)
        {
            /* Validación token
             * string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            
            //Eliminar cliente de la DB

            if(token != "cristian123") 
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }*/

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            Usuario usuario = rToken.result;

            if(usuario.rol != "administrador") 
            {
                return new
                {
                    success = false,
                    message = "No tienes permisos para eliminar clientes",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };
        }
    }
}
