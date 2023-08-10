using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{
    public class Cliente
    {
        [Key]
        public int PkIdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }

        [ForeignKey("CodigosPostales")]
        public int FkCodigoPostal { get; set; }//Para asignar un codigo postal al cliente
        public CodigoPostal CodigosPostales { get; set; }
    }
}
