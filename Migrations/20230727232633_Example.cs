using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Control_De_Rutas.Migrations
{
    public partial class Example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodigoPostales",
                columns: table => new
                {
                    PkIdDirrecion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Codigo_Postal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoPostales", x => x.PkIdDirrecion);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPaquetes",
                columns: table => new
                {
                    FkIdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPaquetes", x => x.FkIdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkIdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkIdRol);
                });

            migrationBuilder.CreateTable(
                name: "TiposPaquetes",
                columns: table => new
                {
                    FkIdTipoPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreTipoPaquete = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPaquetes", x => x.FkIdTipoPaquete);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PkIdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreCliente = table.Column<string>(type: "text", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "text", nullable: false),
                    CorreoCliente = table.Column<string>(type: "text", nullable: false),
                    TelefonoCliente = table.Column<string>(type: "text", nullable: false),
                    FkCodigoPostal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PkIdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_CodigoPostales_FkCodigoPostal",
                        column: x => x.FkCodigoPostal,
                        principalTable: "CodigoPostales",
                        principalColumn: "PkIdDirrecion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkIdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkIdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkIdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    PkIdPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Peso = table.Column<float>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    Origen = table.Column<string>(type: "text", nullable: false),
                    Destino = table.Column<string>(type: "text", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: true),
                    FkTipoPaquete = table.Column<int>(type: "int", nullable: false),
                    FkEstados = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.PkIdPaquete);
                    table.ForeignKey(
                        name: "FK_Paquetes_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "PkIdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquetes_EstadoPaquetes_FkEstados",
                        column: x => x.FkEstados,
                        principalTable: "EstadoPaquetes",
                        principalColumn: "FkIdEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquetes_TiposPaquetes_FkTipoPaquete",
                        column: x => x.FkTipoPaquete,
                        principalTable: "TiposPaquetes",
                        principalColumn: "FkIdTipoPaquete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    PkIdEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<string>(type: "text", nullable: false),
                    Hora = table.Column<string>(type: "text", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: true),
                    FkPaquete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.PkIdEnvio);
                    table.ForeignKey(
                        name: "FK_Envios_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "PkIdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Envios_Paquetes_FkPaquete",
                        column: x => x.FkPaquete,
                        principalTable: "Paquetes",
                        principalColumn: "PkIdPaquete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FkCodigoPostal",
                table: "Clientes",
                column: "FkCodigoPostal");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_FkCliente",
                table: "Envios",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_FkPaquete",
                table: "Envios",
                column: "FkPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_FkCliente",
                table: "Paquetes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_FkEstados",
                table: "Paquetes",
                column: "FkEstados");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_FkTipoPaquete",
                table: "Paquetes",
                column: "FkTipoPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRol",
                table: "Usuarios",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoPaquetes");

            migrationBuilder.DropTable(
                name: "TiposPaquetes");

            migrationBuilder.DropTable(
                name: "CodigoPostales");
        }
    }
}
