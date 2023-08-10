using Control_De_Rutas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Rutas.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost; database=controlderutas; user=root; password='';");
        }
        //mapeando las tablas
        public DbSet<Cliente> Clientes { get; set; }//tabla de clientes
        public DbSet<Paquete> Paquetes { get; set; }//tabla de paquetes
        public DbSet<CodigoPostal> CodigoPostales { get; set; } //tabla de CP
        public DbSet<Envio> Envios { get; set; }
        public DbSet<EstadoPaquete> EstadoPaquetes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoPaquete> TiposPaquetes { get; set; }
        public DbSet <Usuario> Usuarios { get; set; }

        //Agregar el mapeo de las demas tablas
        //al final se hace la conexion 

    }
}
