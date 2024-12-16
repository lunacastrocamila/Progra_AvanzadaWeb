using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzada.Models;

namespace Proyecto_PrograAvanzada.Models;

public class ServiciosSoporteContext : DbContext
{
    public ServiciosSoporteContext(DbContextOptions<ServiciosSoporteContext> options)
        : base(options) { }

    public DbSet<Asignacion> Asignaciones { get; set; } = null!;
    public DbSet<HistorialEstado> HistorialEstados { get; set; } = null!;
    public DbSet<Notificacion> Notificaciones { get; set; } = null!;
    public DbSet<Solicitud> Solicitudes { get; set; } = null!;
    public DbSet<Tecnico> Tecnicos { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__Asignacion");

            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.FechaCierre).HasColumnType("datetime").HasColumnName("fechaCierre");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime").HasColumnName("fechaInicio");
            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

            entity.HasOne(d => d.IdSolicitudNavigation)
                .WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_Asignacion_Solicitud");

            entity.HasOne(d => d.IdTecnicoNavigation)
                .WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdTecnico)
                .HasConstraintName("FK_Asignacion_Tecnico");
        });

        modelBuilder.Entity<HistorialEstado>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__HistorialEstado");

            entity.ToTable("HistorialEstado");

            entity.Property(e => e.IdHistorial).HasColumnName("idHistorial");
            entity.Property(e => e.Comentarios).HasColumnName("comentarios");
            entity.Property(e => e.EstadoAnterior)
                .HasMaxLength(20)
                .HasColumnName("estadoAnterior");
            entity.Property(e => e.EstadoNuevo)
                .HasMaxLength(20)
                .HasColumnName("estadoNuevo");
            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCambio");
            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");

            entity.HasOne(d => d.IdSolicitudNavigation)
                .WithMany(p => p.HistorialEstados)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_Historial_Solicitud");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notificacion");

            entity.Property(e => e.IdNotificacion).HasColumnName("idNotificacion");
            entity.Property(e => e.FechaNotificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaNotificacion");
            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Mensaje).HasColumnName("mensaje");
            entity.Property(e => e.Visto).HasDefaultValue(false).HasColumnName("visto");

            entity.HasOne(d => d.IdSolicitudNavigation)
                .WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_Notificacion_Solicitud");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Notificacion_Usuario");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__Solicitud");

            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Por Asignar")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(10)
                .HasColumnName("prioridad");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Solicitud_Usuario");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.IdTecnico).HasName("PK__Tecnico");

            entity.HasIndex(e => e.IdUsuario, "UQ_Tecnico_Usuario").IsUnique();

            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .HasColumnName("especialidad");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithOne(p => p.Tecnico)
                .HasForeignKey<Tecnico>(d => d.IdUsuario)
                .HasConstraintName("FK_Tecnico_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario");

            entity.HasIndex(e => e.CorreoElectronico, "UQ_Usuario_Correo").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
        });
    }

public DbSet<Proyecto_PrograAvanzada.Models.ReporteSolicitudDetalle> ReporteSolicitudDetalle { get; set; } = default!;
}
