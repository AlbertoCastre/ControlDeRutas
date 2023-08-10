using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{
    public class Paquete // se pasa a public
    {
        [Key]
        public int PkIdPaquete { get; set; }
        public string Descripcion { get; set; }
        public float Peso { get; set; }        
        public string Observaciones { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

        [ForeignKey("Clientes")]
        public int? FkCliente { get; set; }//se obtiene y se registra de que paquete es
        public Cliente Clientes { get; set; }

        [ForeignKey("TiposPaquete")]//selecciono que tipo de paquete es
        public int? FkTipoPaquete { get; set;}
        public TipoPaquete TiposPaquete { get; set; }

        [ForeignKey("EstadosPaquetes")]//selecciono en que estado esta el paquete
        public int? FkEstados { get; set; }
        public EstadoPaquete EstadosPaquetes { get; set; }

    }
}
