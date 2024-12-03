using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PrograAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class DBActualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    correoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    idSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Por Asignar"),
                    prioridad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitud", x => x.idSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitud_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    idTecnico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    especialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tecnico", x => x.idTecnico);
                    table.ForeignKey(
                        name: "FK_Tecnico_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "HistorialEstado",
                columns: table => new
                {
                    idHistorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSolicitud = table.Column<int>(type: "int", nullable: true),
                    estadoAnterior = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    estadoNuevo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    fechaCambio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HistorialEstado", x => x.idHistorial);
                    table.ForeignKey(
                        name: "FK_Historial_Solicitud",
                        column: x => x.idSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "idSolicitud");
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    idNotificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    idSolicitud = table.Column<int>(type: "int", nullable: true),
                    mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaNotificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    visto = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notificacion", x => x.idNotificacion);
                    table.ForeignKey(
                        name: "FK_Notificacion_Solicitud",
                        column: x => x.idSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "idSolicitud");
                    table.ForeignKey(
                        name: "FK_Notificacion_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    idAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSolicitud = table.Column<int>(type: "int", nullable: true),
                    idTecnico = table.Column<int>(type: "int", nullable: true),
                    fechaAsignacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaCierre = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asignacion", x => x.idAsignacion);
                    table.ForeignKey(
                        name: "FK_Asignacion_Solicitud",
                        column: x => x.idSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "idSolicitud");
                    table.ForeignKey(
                        name: "FK_Asignacion_Tecnico",
                        column: x => x.idTecnico,
                        principalTable: "Tecnicos",
                        principalColumn: "idTecnico");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_idSolicitud",
                table: "Asignaciones",
                column: "idSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_idTecnico",
                table: "Asignaciones",
                column: "idTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEstado_idSolicitud",
                table: "HistorialEstado",
                column: "idSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_idSolicitud",
                table: "Notificaciones",
                column: "idSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_idUsuario",
                table: "Notificaciones",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_idUsuario",
                table: "Solicitudes",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ_Tecnico_Usuario",
                table: "Tecnicos",
                column: "idUsuario",
                unique: true,
                filter: "[idUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuario_Correo",
                table: "Usuarios",
                column: "correoElectronico",
                unique: true,
                filter: "[correoElectronico] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "HistorialEstado");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
