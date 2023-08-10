using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Entities
{
    public class CodigoPostal
    {
        [Key]
        public int PkIdDirrecion { get; set; }
        public string Codigo_Postal { get; set; }
 
    }
}
