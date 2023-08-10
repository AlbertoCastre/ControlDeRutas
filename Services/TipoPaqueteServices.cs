using Control_De_Rutas.Context;
using Control_De_Rutas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Services
{
    public class TipoPaqueteServices
    {
        public TipoPaquete SearchTipo (int IdTipo)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var tipo = _context.TiposPaquetes.FirstOrDefault(x => x.FkIdTipoPaquete == IdTipo);
                    return tipo;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message);
            }
        }
    }
}
