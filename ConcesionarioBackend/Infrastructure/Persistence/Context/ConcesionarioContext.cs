using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public partial class ConcesionarioContext : DbContext
{
    public ConcesionarioContext()
    {
    }

    public ConcesionarioContext(DbContextOptions<ConcesionarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asesor> Asesores { get; set; }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public DbSet<User> Users => Set<User>();

    public DbSet<Compra> Compras {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asesor>(entity =>
        {
            entity.HasKey(e => e.IdAsesor).HasName("PK__asesor__A801FCE964A6485D");

            entity.ToTable("asesor");

            entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Asesors)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK__asesor__idCiudad__123EB7A3");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Asesors)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__asesor__idDepart__10566F31");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__ciudad__AEA2A71B55117C15");

            entity.ToTable("ciudad");

            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__ciudad__idDepart__04E4BC85");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__C225F98D0FD2AE73");

            entity.ToTable("departamento");

            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipovehiculo).HasName("PK__tipoVehi__2D7E95E096546F59");

            entity.ToTable("tipoVehiculo");

            entity.Property(e => e.IdTipovehiculo).HasColumnName("idTipovehiculo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__Vehiculo__4868297009360C0E");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Kilometraje)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("kilometraje");
            entity.Property(e => e.Marca)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("placa");
            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipoVehiculo");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.IdUser)
                .HasColumnName("IdUser");

            entity.Property(e => e.Username)
                .HasColumnName("Username")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasColumnName("Password")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Role)
                .HasColumnName("Role")
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente)
                .HasColumnName("IdCliente");

            entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Apellido)
                .HasColumnName("Apellido")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.TipoDocumento)
                .HasColumnName("TipoDocumento")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.NumeroDocumento)
                .HasColumnName("NumeroDocumento")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Telefono)
                .HasColumnName("Telefono")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Direccion)
                .HasColumnName("Direccion")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.FechaNacimiento)
                .HasColumnName("FechaNacimiento")
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>().ToTable("Cliente");

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__compra__idCompra");

            entity.ToTable("compra");

            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            entity.Property(e => e.FechaCompra)
                .HasColumnName("fechaCompra")
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.Total)
                .HasColumnName("total")
                .HasColumnType("decimal(18,2)");

            // Relaciones
            entity.HasOne(d => d.IdVehiculoNavegation)
                .WithOne(p => p.Compra)
                .HasForeignKey<Compra>(d => d.IdVehiculo)
                .HasConstraintName("FK__Compra__idVehicu__72C60C4A");

            entity.HasOne(d => d.IdAsesorNavegation)
                .WithOne(p => p.Compra)
                .HasForeignKey<Compra>(d => d.IdAsesor)
                .HasConstraintName("FK__Compra__idAsesor__73BA3083");

            entity.HasOne(d => d.IdClienteNavegation)
                .WithOne(p => p.Compra)
                .HasForeignKey<Compra>(d => d.IdCliente)
                .HasConstraintName("FK__Compra__idClient__74AE54BC");
        });

        modelBuilder.Entity<Compra>().ToTable("Compra");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
