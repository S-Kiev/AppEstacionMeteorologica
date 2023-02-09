using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class estasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDispositivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDispositivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    Longitud = table.Column<float>(type: "real", nullable: false),
                    IdSupervisor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacion_Usuarios_IdSupervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FecAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstacion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispositivo_Estacion_IdEstacion",
                        column: x => x.IdEstacion,
                        principalTable: "Estacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dispositivo_TipoDispositivo_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TipoDispositivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_IdEstacion",
                table: "Dispositivo",
                column: "IdEstacion");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_IdTipo",
                table: "Dispositivo",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Estacion_IdSupervisor",
                table: "Estacion",
                column: "IdSupervisor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropTable(
                name: "Estacion");

            migrationBuilder.DropTable(
                name: "TipoDispositivo");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
