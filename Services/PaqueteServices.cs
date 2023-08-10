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
    public class PaqueteServices
    {//CRUD de los paquetes
        #region AgregarPaquete
        public void AddPaquete(Paquete request)//recibe el objeto usuario
        {//todos deben llevar try catch
            try
            {
                if (request != null)//validamos que no llegue en nulo 
                {
                    //si llega con datos se agrega a la base de datos
                    using (var _context = new ApplicationDbContext())
                    {//abrimos la conexion

                        Paquete res = new Paquete();//el objeto que va a recibir
                        res.FkCliente = request.FkCliente;
                        res.Origen = request.Origen;
                        res.Destino = request.Destino;
                        res.Peso = request.Peso;
                        res.Descripcion = request.Descripcion;                        
                        res.Observaciones = request.Observaciones;                        
                        res.FkEstados = request.FkEstados;
                        res.FkTipoPaquete = request.FkTipoPaquete;                        

                        _context.Paquetes.Add(res);//guarda en la base de datos el nuevo objeto
                        _context.SaveChanges();//guardamos en la base

                    }//cerramos la conexion
                }                
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error :( " + ex.Message);
            }
        }
        #endregion

        #region DeletePaquete
        public void DeletePaquete(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Paquete res = _context.Paquetes.Find(Id);
                    if (res != null)
                    {
                        _context.Paquetes.Remove(res);//si existe esa PkUsuarios en la base de datos se elimina
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
        #endregion

        #region ActualizarPaquete
        public void UpdatePaquete(Paquete request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Paquete update = _context.Paquetes.Find(request.PkIdPaquete);                    
                    update.Origen = request.Origen;
                    update.Destino = request.Destino;
                    update.Peso = request.Peso;
                    update.Descripcion = request.Descripcion;                    
                    update.Observaciones = request.Observaciones;
                    update.FkTipoPaquete = request.FkTipoPaquete;
                    update.FkEstados = request.FkEstados;                    
                    _context.Paquetes.Update(update);
                    _context.SaveChanges();
                    //_context.Entry(update).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }
        #endregion        

        #region TraerTabla
        public List<Paquete> GetPaquetes()//Sirve para traer la tabla y sus Fk
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Paquete> paquetes = new List<Paquete>();
                    paquetes = _context.Paquetes.Include(x => x.Clientes).ToList();
                    return paquetes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error " + ex.Message);
            }

        }
        #endregion

        #region Search Paquete
        public Paquete Search (int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var paquete = _context.Paquetes.Include(y=> y.Clientes).FirstOrDefault(x=> x.PkIdPaquete ==Id);
                    return paquete;
                }   
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region TraerComboBoxTipoPaquetes
        public List<TipoPaquete> GetTypePaquetes()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<TipoPaquete> tipospack = _context.TiposPaquetes.ToList();
                    return tipospack;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TraerComboBoxEstadoPaquete

        public List<EstadoPaquete> GetEstadoPaquetes()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<EstadoPaquete> estadopack = _context.EstadoPaquetes.ToList();
                    return estadopack;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
