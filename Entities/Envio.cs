using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{
    public class Envio
    {
        [Key]
        public int PkIdEnvio { get ; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }       

        [ForeignKey("Clientes")]
        public int? FkCliente { get; set; }
        public Cliente Clientes { get; set; }

        [ForeignKey("Paquetes")]
        public int? FkPaquete { get; set; }
        public Paquete Paquetes { get; set; }

    }
}
