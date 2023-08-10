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
    public class ClienteServices
    {
        public void AddCliente(Cliente request )
        {
            try
            {
                if (request != null)//validamos que no llegue en nulo 
                {
                    //si llega con datos se agrega a la base de datos
                    using (var _context = new ApplicationDbContext())
                    {//abrimos la conexion

                        Cliente res = new Cliente();//el objeto que va a recibir
                       
                        
                        res.NombreCliente = request.NombreCliente;//traemos los datos
                        res.ApellidoCliente = request.ApellidoCliente;
                        res.CorreoCliente = request.CorreoCliente;
                        res.TelefonoCliente = request.TelefonoCliente;
                        res.FkCodigoPostal = request.FkCodigoPostal;
                        _context.Clientes.Add(res);//guarda en la base de datos el nuevo objeto
                        _context.SaveChanges();//guardamos en la base

                    }//cerramos la conexion
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error :( " + ex.Message);
            }
        }
        public List<CodigoPostal> GetCPS()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<CodigoPostal> codigopostales = _context.CodigoPostales.ToList();
                    return codigopostales;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error" + ex.Message); ;
            }
        }

        public Cliente VerifyExist(int IdCliente)
        {
            bool exist = false;
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var cliente = _context.Clientes.FirstOrDefault(x=> x.PkIdCliente ==  IdCliente);
                    if (cliente != null)
                    {
                        exist = true;
                    }
                    return cliente;
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente SearchCliente(int ClienteId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var cliente = _context.Clientes.FirstOrDefault(x => x.PkIdCliente == ClienteId);
                    return cliente;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeleteCliente(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente res = _context.Clientes.Find(Id);
                    if (res != null)
                    {
                        _context.Clientes.Remove(res);//si existe esa PkUsuarios en la base de datos se elimina
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

        public void UpdateCliente(Cliente request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente update = _context.Clientes.Find(request.PkIdCliente);
                    update.NombreCliente = request.NombreCliente;                   
                    update.ApellidoCliente = request.ApellidoCliente;
                    update.CorreoCliente = request.CorreoCliente;
                    update.TelefonoCliente = request.TelefonoCliente;
                    update.FkCodigoPostal = request.FkCodigoPostal;
                    _context.Clientes.Update(update);                    
                    _context.SaveChanges();
                    //_context.Entry(update).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }
    }
}
