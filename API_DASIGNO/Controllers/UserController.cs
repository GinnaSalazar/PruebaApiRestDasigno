using BLL_Dasigno;
using Microsoft.AspNetCore.Mvc;
using Modelo_Dasigno.Context;
using Modelo_Dasigno.Entities;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_DASIGNO.Controllers
{
    [ApiController]
    [Route("Dasigno")]
    public class UserController : Controller
    {
        private readonly DasignoDbContext _context;
        public UserController(DasignoDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateUser")]
        [Produces(typeof(HttpResponseMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateUser([FromBody] User user)
        {
            try
            {
                bool resultado = new UserService(_context).CreateUser(user);
                if (resultado == true)
                {
                    return Ok("El usuario fue creado exitosamente");
                }
                else
                {
                    resultado = false;
                    throw new Exception("Ocurrio un error al crear el usuario, por favor valide la información");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("GetUserId")]
        [Produces(typeof(HttpResponseMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public User GetUserId([FromBody] long id)
        {
            try
            {
                User resultado = new UserService(_context).GetUserId(id);
                if (resultado != null)
                {
                    return resultado;
                }
                else
                {
                    throw new Exception("El usuario no existe en el sistema");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("GetAllUsers")]
        [Produces(typeof(HttpResponseMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                List<User> usuarios = new UserService(_context).GetAllUsers();
                if (usuarios != null)
                {
                    return usuarios;
                }
                else
                {
                    throw new Exception("La consulta no se logró efectuar de manera correcta");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("UpdateUser")]
        [Produces(typeof(HttpResponseMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                bool resultado = new UserService(_context).UpdateUser(user);
                if (resultado == true)
                {
                    return Ok("El usuario fue actualizado exitosamente");
                }
                else
                {
                    return Ok("Ocurrio un error al actualizar el usuario, por favor valide la información");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("DeleteUser")]
        [Produces(typeof(HttpResponseMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteUser([FromBody] long id)
        {
            try
            {
                bool resultado = new UserService(_context).DeleteUser(id);
                if (resultado == true)
                {
                    return Ok("El usuario fue eliminado exitosamente");
                }
                else
                {
                    return Ok("Ocurrio un error al eliminar el usuario, por favor valide la información");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetUsersPaginate")]
        [Produces(typeof(HttpResponseMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<User> GetUsersPaginate(string? primerNombre, string? primerApellido, int numeroRegistros, int numeroPaginas)
        {
            try
            {
                List<User> usersPaginate = new UserService(_context).GetUsersPaginate(primerNombre, primerApellido, numeroRegistros, numeroPaginas, out int totalRegistros).ToList();
                if (usersPaginate != null)
                {
                    return usersPaginate;
                }
                else
                {
                    throw new Exception("No se encontró una coincidencia");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error realizando la consulta" + e.Message);
            }
        }
    }
}
