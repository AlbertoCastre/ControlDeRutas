using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{   
    public class Rol
    {
        [Key] 
        public int PkIdRol { get; set; }
        public string Nombre { get; set; }
    }
}
