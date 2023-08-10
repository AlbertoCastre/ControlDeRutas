using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{
    public class TipoPaquete
    {
        [Key]
        public int FkIdTipoPaquete { get; set; }
        public string NombreTipoPaquete { get; set; }

    }
}
