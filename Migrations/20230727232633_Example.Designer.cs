﻿// <auto-generated />
using System;
using Control_De_Rutas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Control_De_Rutas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230727232633_Example")]
    partial class Example
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Control_De_Rutas.Entities.Cliente", b =>
                {
                    b.Property<int>("PkIdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorreoCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FkCodigoPostal")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TelefonoCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkIdCliente");

                    b.HasIndex("FkCodigoPostal");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.CodigoPostal", b =>
                {
                    b.Property<int>("PkIdDirrecion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Codigo_Postal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkIdDirrecion");

                    b.ToTable("CodigoPostales");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Envio", b =>
                {
                    b.Property<int>("PkIdEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkPaquete")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkIdEnvio");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkPaquete");

                    b.ToTable("Envios");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.EstadoPaquete", b =>
                {
                    b.Property<int>("FkIdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FkIdEstado");

                    b.ToTable("EstadoPaquetes");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Paquete", b =>
                {
                    b.Property<int>("PkIdPaquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkEstados")
                        .HasColumnType("int");

                    b.Property<int?>("FkTipoPaquete")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Peso")
                        .HasColumnType("float");

                    b.HasKey("PkIdPaquete");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkEstados");

                    b.HasIndex("FkTipoPaquete");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Rol", b =>
                {
                    b.Property<int>("PkIdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkIdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.TipoPaquete", b =>
                {
                    b.Property<int>("FkIdTipoPaquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreTipoPaquete")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FkIdTipoPaquete");

                    b.ToTable("TiposPaquetes");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Usuario", b =>
                {
                    b.Property<int>("PkIdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkIdUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Cliente", b =>
                {
                    b.HasOne("Control_De_Rutas.Entities.CodigoPostal", "CodigosPostales")
                        .WithMany()
                        .HasForeignKey("FkCodigoPostal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CodigosPostales");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Envio", b =>
                {
                    b.HasOne("Control_De_Rutas.Entities.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("FkCliente");

                    b.HasOne("Control_De_Rutas.Entities.Paquete", "Paquetes")
                        .WithMany()
                        .HasForeignKey("FkPaquete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Paquetes");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Paquete", b =>
                {
                    b.HasOne("Control_De_Rutas.Entities.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("FkCliente");

                    b.HasOne("Control_De_Rutas.Entities.EstadoPaquete", "EstadosPaquetes")
                        .WithMany()
                        .HasForeignKey("FkEstados");

                    b.HasOne("Control_De_Rutas.Entities.TipoPaquete", "TiposPaquete")
                        .WithMany()
                        .HasForeignKey("FkTipoPaquete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("EstadosPaquetes");

                    b.Navigation("TiposPaquete");
                });

            modelBuilder.Entity("Control_De_Rutas.Entities.Usuario", b =>
                {
                    b.HasOne("Control_De_Rutas.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
