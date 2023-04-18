using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ATMExercise.Models;

public partial class AtmContext : DbContext
{
    public AtmContext()
    {
    }

    public AtmContext(DbContextOptions<AtmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EstadoTarjetum> EstadoTarjeta { get; set; }

    public virtual DbSet<OperacionAdministrativa> OperacionAdministrativas { get; set; }

    public virtual DbSet<OperacionMonetarium> OperacionMonetaria { get; set; }

    public virtual DbSet<Tarjetum> Tarjeta { get; set; }

    public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstadoTarjetum>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("Estado_Tarjeta");

            entity.Property(e => e.IdEstado)
                .ValueGeneratedNever()
                .HasColumnName("ID_Estado");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasColumnType("text");
        });

        modelBuilder.Entity<OperacionAdministrativa>(entity =>
        {
            entity.HasKey(e => e.IdOperacionAdministrativa);

            entity.ToTable("Operacion_Administrativa");

            entity.Property(e => e.IdOperacionAdministrativa)
                .ValueGeneratedNever()
                .HasColumnName("ID_Operacion_Administrativa");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdTarjeta).HasColumnName("ID_Tarjeta");
            entity.Property(e => e.IdTipoOperacion).HasColumnName("ID_Tipo_Operacion");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.OperacionAdministrativas)
                .HasForeignKey(d => d.IdTarjeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_Administrativa_Tarjeta");

            entity.HasOne(d => d.IdTipoOperacionNavigation).WithMany(p => p.OperacionAdministrativas)
                .HasForeignKey(d => d.IdTipoOperacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_Administrativa_Tipo_Operacion");
        });

        modelBuilder.Entity<OperacionMonetarium>(entity =>
        {
            entity.HasKey(e => e.IdOperacionMonetaria);

            entity.ToTable("Operacion_Monetaria");

            entity.Property(e => e.IdOperacionMonetaria)
                .ValueGeneratedNever()
                .HasColumnName("ID_Operacion_Monetaria");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdTarjeta).HasColumnName("ID_Tarjeta");
            entity.Property(e => e.IdTipoOperacion).HasColumnName("ID_Tipo_Operacion");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.OperacionMonetaria)
                .HasForeignKey(d => d.IdTarjeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_Monetaria_Tarjeta");

            entity.HasOne(d => d.IdTipoOperacionNavigation).WithMany(p => p.OperacionMonetaria)
                .HasForeignKey(d => d.IdTipoOperacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_Monetaria_Tipo_Operacion");
        });

        modelBuilder.Entity<Tarjetum>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta);

            entity.Property(e => e.IdTarjeta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Tarjeta");
            entity.Property(e => e.FechaVencimiento)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");
            entity.Property(e => e.NumeroTarjeta).HasColumnName("Numero_Tarjeta");
            entity.Property(e => e.Pin).HasColumnName("PIN");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tarjeta_Estado_Tarjeta");
        });

        modelBuilder.Entity<TipoOperacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoOperacion);

            entity.ToTable("Tipo_Operacion");

            entity.Property(e => e.IdTipoOperacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Tipo_Operacion");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
