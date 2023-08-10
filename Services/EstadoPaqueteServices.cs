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
    public class EstadoPaqueteServices
    {
        #region Search Estado
        public EstadoPaquete SearchEstado (int IdEstados)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var estado = _context.EstadoPaquetes.FirstOrDefault(x => x.FkIdEstado == IdEstados);
                    return estado;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        
    }
}
