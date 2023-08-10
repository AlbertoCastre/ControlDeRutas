using Control_De_Rutas.Context;
using Control_De_Rutas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Control_De_Rutas.Services
{
    public class EnvioServices
    {
        public void AddEnvio(Envio request)
        {
            try
            {
                if (request != null)//validamos que no llegue en nulo 
                {
                    //si llega con datos se agrega a la base de datos
                    using (var _context = new ApplicationDbContext())
                    {//abrimos la conexion

                        Envio res = new Envio();//el objeto que va a recibir

                        res.Hora = request.Hora;//traemos los datos
                        res.Fecha = request.Fecha;
                        res.FkPaquete = request.FkPaquete;
                        res.FkCliente = request.FkCliente;                        
                        _context.Envios.Add(res);//guarda en la base de datos el nuevo objeto
                        _context.SaveChanges();//guardamos en la base

                    }//cerramos la conexion
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error :( " + ex.Message);
            }
        }
        public Envio SearchEnvio(int IdEnvio)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var envio = _context.Envios.FirstOrDefault(x => x.PkIdEnvio == IdEnvio);
                    return envio;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message);
            }
        }
        public void UpdateEnvio(Envio request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Envio update = _context.Envios.Find(request.PkIdEnvio);      
                    
                    update.Hora = request.Hora;
                    update.Fecha = request.Fecha;                    
                    _context.Envios.Update(update);
                    _context.SaveChanges();
                    //_context.Entry(update).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }
        public void DeleteEnvio(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Envio res = _context.Envios.Find(Id);
                    if (res != null)
                    {
                        _context.Envios.Remove(res);//si existe esa PkUsuarios en la base de datos se elimina
                        _context.SaveChanges();//Guardamos datos
                    }
                    else
                    {
                        MessageBox.Show("No existe ese registro");
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("No hay ese registro" + ex.Message);
            }
        }

        public List<Envio> GetEnvios()//Sirve para traer la tabla y sus Fk
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Envio> envios = new List<Envio>();
                    envios = _context.Envios.Include(x => x.Clientes).ToList();
                    return envios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error " + ex.Message);
            }

        }
    }
}
