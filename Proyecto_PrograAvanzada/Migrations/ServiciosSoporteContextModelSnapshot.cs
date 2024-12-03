﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_PrograAvanzada.Models;

#nullable disable

namespace Proyecto_PrograAvanzada.Migrations
{
    [DbContext(typeof(ServiciosSoporteContext))]
    partial class ServiciosSoporteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Asignacion", b =>
                {
                    b.Property<int>("IdAsignacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idAsignacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAsignacion"));

                    b.Property<DateTime?>("FechaAsignacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaAsignacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("FechaCierre")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaCierre");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaInicio");

                    b.Property<int?>("IdSolicitud")
                        .HasColumnType("int")
                        .HasColumnName("idSolicitud");

                    b.Property<int?>("IdTecnico")
                        .HasColumnType("int")
                        .HasColumnName("idTecnico");

                    b.HasKey("IdAsignacion")
                        .HasName("PK__Asignacion");

                    b.HasIndex("IdSolicitud");

                    b.HasIndex("IdTecnico");

                    b.ToTable("Asignaciones");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.HistorialEstado", b =>
                {
                    b.Property<int>("IdHistorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idHistorial");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHistorial"));

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comentarios");

                    b.Property<string>("EstadoAnterior")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("estadoAnterior");

                    b.Property<string>("EstadoNuevo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("estadoNuevo");

                    b.Property<DateTime?>("FechaCambio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaCambio")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdSolicitud")
                        .HasColumnType("int")
                        .HasColumnName("idSolicitud");

                    b.HasKey("IdHistorial")
                        .HasName("PK__HistorialEstado");

                    b.HasIndex("IdSolicitud");

                    b.ToTable("HistorialEstado", (string)null);
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Notificacion", b =>
                {
                    b.Property<int>("IdNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idNotificacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacion"));

                    b.Property<DateTime?>("FechaNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaNotificacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdSolicitud")
                        .HasColumnType("int")
                        .HasColumnName("idSolicitud");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mensaje");

                    b.Property<bool?>("Visto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("visto");

                    b.HasKey("IdNotificacion")
                        .HasName("PK__Notificacion");

                    b.HasIndex("IdSolicitud");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Solicitud", b =>
                {
                    b.Property<int>("IdSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idSolicitud");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSolicitud"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Por Asignar")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaCreacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<string>("Prioridad")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("prioridad");

                    b.HasKey("IdSolicitud")
                        .HasName("PK__Solicitud");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Tecnico", b =>
                {
                    b.Property<int>("IdTecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTecnico");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTecnico"));

                    b.Property<string>("Especialidad")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("especialidad");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.HasKey("IdTecnico")
                        .HasName("PK__Tecnico");

                    b.HasIndex(new[] { "IdUsuario" }, "UQ_Tecnico_Usuario")
                        .IsUnique()
                        .HasFilter("[idUsuario] IS NOT NULL");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("apellido");

                    b.Property<string>("Contraseña")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("contraseña");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("correoElectronico");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Rol")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("rol");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario");

                    b.HasIndex(new[] { "CorreoElectronico" }, "UQ_Usuario_Correo")
                        .IsUnique()
                        .HasFilter("[correoElectronico] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Asignacion", b =>
                {
                    b.HasOne("Proyecto_PrograAvanzada.Models.Solicitud", "IdSolicitudNavigation")
                        .WithMany("Asignaciones")
                        .HasForeignKey("IdSolicitud")
                        .HasConstraintName("FK_Asignacion_Solicitud");

                    b.HasOne("Proyecto_PrograAvanzada.Models.Tecnico", "IdTecnicoNavigation")
                        .WithMany("Asignaciones")
                        .HasForeignKey("IdTecnico")
                        .HasConstraintName("FK_Asignacion_Tecnico");

                    b.Navigation("IdSolicitudNavigation");

                    b.Navigation("IdTecnicoNavigation");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.HistorialEstado", b =>
                {
                    b.HasOne("Proyecto_PrograAvanzada.Models.Solicitud", "IdSolicitudNavigation")
                        .WithMany("HistorialEstados")
                        .HasForeignKey("IdSolicitud")
                        .HasConstraintName("FK_Historial_Solicitud");

                    b.Navigation("IdSolicitudNavigation");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Notificacion", b =>
                {
                    b.HasOne("Proyecto_PrograAvanzada.Models.Solicitud", "IdSolicitudNavigation")
                        .WithMany("Notificaciones")
                        .HasForeignKey("IdSolicitud")
                        .HasConstraintName("FK_Notificacion_Solicitud");

                    b.HasOne("Proyecto_PrograAvanzada.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Notificaciones")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Notificacion_Usuario");

                    b.Navigation("IdSolicitudNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Solicitud", b =>
                {
                    b.HasOne("Proyecto_PrograAvanzada.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Solicitudes")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Solicitud_Usuario");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Tecnico", b =>
                {
                    b.HasOne("Proyecto_PrograAvanzada.Models.Usuario", "IdUsuarioNavigation")
                        .WithOne("Tecnico")
                        .HasForeignKey("Proyecto_PrograAvanzada.Models.Tecnico", "IdUsuario")
                        .HasConstraintName("FK_Tecnico_Usuario");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Solicitud", b =>
                {
                    b.Navigation("Asignaciones");

                    b.Navigation("HistorialEstados");

                    b.Navigation("Notificaciones");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Tecnico", b =>
                {
                    b.Navigation("Asignaciones");
                });

            modelBuilder.Entity("Proyecto_PrograAvanzada.Models.Usuario", b =>
                {
                    b.Navigation("Notificaciones");

                    b.Navigation("Solicitudes");

                    b.Navigation("Tecnico");
                });
#pragma warning restore 612, 618
        }
    }
}
