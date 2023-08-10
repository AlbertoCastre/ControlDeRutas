using Control_De_Rutas.Context;
using Control_De_Rutas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Services
{
    public class UsuarioServices
    {
        public void AddUsuario(Usuario request)//recibe el objeto usuario
        {//todos deben llevar try catch
            try
            {
                if (request != null)//validamos que no llegue en nulo 
                {
                    //si llega con datos se agrega a la base de datos
                    using (var _context = new ApplicationDbContext())
                    {//abrimos la conexion

                        Usuario res = new Usuario();//el objeto que va a recibir
                        res.Nombre = request.Nombre;
                        res.Username = request.Username;
                        res.Password = request.Password;
                        res.FkRol = request.FkRol;

                        _context.Usuarios.Add(res);//guarda en la base de datos el nuevo objeto
                        _context.SaveChanges();//guardamos en la base

                    }//cerramos la conexion
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error :( " + ex.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario Login(string Username, string Password)//regresa usuario y recibe 
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x => x.Username == Username && x.Password == Password);
                    //por defecto el primero que encuentre
                    return usuario;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message);
            }
        }
    }
}
