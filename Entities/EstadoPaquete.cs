using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{
    public class EstadoPaquete
    {
        [Key] 
        public int FkIdEstado { get; set; }
        public string NombreEstado { get; set; }

    }
}
