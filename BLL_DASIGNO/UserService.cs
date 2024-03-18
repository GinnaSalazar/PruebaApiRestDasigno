using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo_Dasigno.Context;
using Modelo_Dasigno.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Dasigno
{
    public class UserService : DbContext
    {
        private readonly DasignoDbContext _context;
        public UserService(DasignoDbContext context)
        {
            _context = context;

        }

        public bool CreateUser(User user)
        {
            try
            {
                User datos = _context.User.FirstOrDefault(u => u.IdUsuario == user.IdUsuario);
                if (datos == null && user.PrimerNombre != string.Empty && user.PrimerApellido != string.Empty && user.FechaNacimiento != null && user.Sueldo != 0)
                {
                    user.FechaInsercion = DateTime.Now.ToString("d");
                    user.FechaActualizacion = string.Empty;
                    _context.User.Add(user);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Los campos Primer Nombre, Primer Apellido, Fecha de Nacimiento y Sueldo son obligatorios");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User GetUserId(long id)
        {
            try
            {
                var usuario = _context.User.FirstOrDefault(u => u.IdUsuario == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("No se logró realizar la consulta del usuario" + ex.Message);
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                List<User> usuarios = _context.User.ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("No se logró realizar la consulta de los usuarios" + ex.Message);
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                User datos = GetUserId(user.IdUsuario);
                if (datos != null && datos.IdUsuario != 0 && user.PrimerNombre != string.Empty && user.PrimerApellido != string.Empty && user.FechaNacimiento != null && user.Sueldo != 0)
                {
                    datos.PrimerNombre = user.PrimerNombre;
                    datos.SegundoNombre = user.SegundoNombre;
                    datos.PrimerApellido = user.PrimerApellido;
                    datos.SegundoApellido = user.SegundoApellido;
                    datos.FechaNacimiento = user.FechaNacimiento;
                    datos.Sueldo = user.Sueldo;
                    datos.FechaInsercion = datos.FechaInsercion;
                    datos.FechaActualizacion = DateTime.Now.ToString("d");
                    _context.User.Update(datos);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("No se logró realizar la actualización del usuario");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteUser(long id)
        {
            try
            {
                var usuario = _context.User.FirstOrDefault(u => u.IdUsuario == id);
                if (usuario != null)
                {
                    _context.User.Remove(usuario);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("No se logró realizar la eliminación del usuario");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<User> GetUsersPaginate(string primerNombre, string primerApellido, int numeroRegistros, int numeroPaginas, out int totalRegistros)
        {
            totalRegistros = _context.User.Where(x => x.PrimerNombre == primerNombre || x.PrimerApellido == primerApellido).Count();
            return _context.User.Where(x => x.PrimerNombre == primerNombre || x.PrimerApellido == primerApellido).Skip((numeroPaginas - 1) * numeroRegistros).Take(numeroRegistros).ToList();
        }
    }
}
