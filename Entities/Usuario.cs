using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509;
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
    public class Usuario
    {
        [Key]
        public int PkIdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey ("Roles")]
        public int? FkRol { get; set; }
        public Rol Roles { get; set; }
        
    }
}
