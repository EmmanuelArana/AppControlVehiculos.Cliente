using System;
using System.Collections.Generic;
using AppControlVehiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppControlVehiculos.AccesoDatos;

public partial class DbAbb191BdvehiculosContext : DbContext
{
    public DbAbb191BdvehiculosContext()
    {
    }

    public DbAbb191BdvehiculosContext(DbContextOptions<DbAbb191BdvehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaLicencium> CategoriaLicencia { get; set; }

    public virtual DbSet<Combustible> Combustibles { get; set; }

    public virtual DbSet<Conductore> Conductores { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Incidente> Incidentes { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<TallerServicio> TallerServicios { get; set; }

    public virtual DbSet<TipoCombustible> TipoCombustibles { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoMantenimiento> TipoMantenimientos { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaLicencium>(entity =>
        {
            entity.HasKey(e => e.CategoriaLicenciaId).HasName("PK__Categori__88581D1BAC8D89D8");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Combustible>(entity =>
        {
            entity.HasKey(e => e.CombustibleId).HasName("PK__Combusti__EA82AB3BC38A6EC4");

            entity.ToTable("Combustible");

            entity.Property(e => e.CantidadLitros).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaCarga).HasColumnType("datetime");

            entity.HasOne(d => d.TipoCombustible).WithMany(p => p.Combustibles)
                .HasForeignKey(d => d.TipoCombustibleId)
                .HasConstraintName("FK__Combustib__TipoC__5165187F");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Combustibles)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Combustib__Vehic__52593CB8");
        });

        modelBuilder.Entity<Conductore>(entity =>
        {
            entity.HasKey(e => e.ConductorId).HasName("PK__Conducto__BDDAB68084B48532");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.NumeroLicencia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoriaLicencia).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.CategoriaLicenciaId)
                .HasConstraintName("FK__Conductor__Categ__534D60F1");

            entity.HasOne(d => d.Estado).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Conductor__Estad__5441852A");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Conductor__Vehic__5535A963");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__Document__5DDBFC76E5D557D5");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.TipoDocumentoId)
                .HasConstraintName("FK__Documento__TipoD__5629CD9C");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Documento__Vehic__571DF1D5");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B00FE1F805B");

            entity.ToTable("Estado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.HasKey(e => e.IncidenteId).HasName("PK__Incident__16C7A36A351B7392");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaIncidente).HasColumnType("datetime");
            entity.Property(e => e.Responsable).HasMaxLength(100);

            entity.HasOne(d => d.Estado).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Incidente__Estad__5812160E");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Incidente__Vehic__59063A47");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.MantenimientoId).HasName("PK__Mantenim__A62E61A2979449C0");

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.TallerServicio).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.TallerServicioId)
                .HasConstraintName("FK__Mantenimi__Talle__59FA5E80");

            entity.HasOne(d => d.TipoMantenimiento).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.TipoMantenimientoId)
                .HasConstraintName("FK__Mantenimi__TipoM__5AEE82B9");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Mantenimi__Vehic__5BE2A6F2");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marcas__D5B1CD8B35857E6A");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.ModeloId).HasName("PK__Modelos__FA60529ACC265935");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.RutaId).HasName("PK__Rutas__7B61998EAD7B3BA4");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.NombreRuta).HasMaxLength(100);
            entity.Property(e => e.PuntosControl).HasMaxLength(500);
        });

        modelBuilder.Entity<TallerServicio>(entity =>
        {
            entity.HasKey(e => e.TallerServicioId).HasName("PK__TallerSe__C4176A07FE27CBF4");

            entity.ToTable("TallerServicio");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoCombustible>(entity =>
        {
            entity.HasKey(e => e.TipoCombustibleId).HasName("PK__TipoComb__A94761B67DCFB82B");

            entity.ToTable("TipoCombustible");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__TipoDocu__A329EA87E3021C63");

            entity.ToTable("TipoDocumento");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoMantenimiento>(entity =>
        {
            entity.HasKey(e => e.TipoMantenimientoId).HasName("PK__TipoMant__CF3911C7AA610B04");

            entity.ToTable("TipoMantenimiento");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposVehiculo>(entity =>
        {
            entity.HasKey(e => e.TipoVehiculoId).HasName("PK__TiposVeh__1EA21D0DD8B6F9C7");

            entity.ToTable("TiposVehiculo");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA08860012F396C2");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).HasMaxLength(500);
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Estado).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Vehiculos__Estad__5CD6CB2B");

            entity.HasOne(d => d.Marca).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK__Vehiculos__Marca__5DCAEF64");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ModeloId)
                .HasConstraintName("FK__Vehiculos__Model__5EBF139D");

            entity.HasOne(d => d.TipoVehiculo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipoVehiculoId)
                .HasConstraintName("FK__Vehiculos__TipoV__5FB337D6");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.ViajeId).HasName("PK__Viajes__D76D88CC0322C106");

            entity.Property(e => e.FechaLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");

            entity.HasOne(d => d.Conductor).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.ConductorId)
                .HasConstraintName("FK__Viajes__Conducto__60A75C0F");

            entity.HasOne(d => d.Ruta).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.RutaId)
                .HasConstraintName("FK__Viajes__RutaId__619B8048");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Viajes__Vehiculo__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
