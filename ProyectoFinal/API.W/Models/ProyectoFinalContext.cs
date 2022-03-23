using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class ProyectoFinalContext : DbContext
    {
        public ProyectoFinalContext()
        {
        }

        public ProyectoFinalContext(DbContextOptions<ProyectoFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Distribuidor> Distribuidor { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<RegistroFactura> RegistroFactura { get; set; }
        public virtual DbSet<RolEmpleado> RolEmpleado { get; set; }
        public virtual DbSet<VinculoProducto> VinculoProducto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-I7BKT69T\\SQLEXPRESS;Database=ProyectoFinal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642BD41757F");

                entity.Property(e => e.CorreoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distribuidor>(entity =>
            {
                entity.HasKey(e => e.IdDistribuidor)
                    .HasName("PK__Distribu__258A56003D3E8C31");

                entity.Property(e => e.CorreoDistribuidor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.NombreDistribuidor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoDistribuidor)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__CE6D8B9EC3AC167B");

                entity.Property(e => e.ApellidoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmpleado)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado__IdRol__300424B4");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__098892103AADDB8D");

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.IdVinculoProducto).HasColumnName("IdVinculo_Producto");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDistribuidorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdDistribuidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__IdDist__33D4B598");

                entity.HasOne(d => d.IdVinculoProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdVinculoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__IdVinc__32E0915F");
            });

            modelBuilder.Entity<RegistroFactura>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK__Registro__FFA45A99029210CA");

                entity.Property(e => e.CodigoRegistro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.RegistroFactura)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroF__IdCli__30F848ED");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroFactura)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RegistroF__IdEmp__31EC6D26");
            });

            modelBuilder.Entity<RolEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol_Empl__2A49584C96B5E11E");

                entity.ToTable("Rol_Empleado");

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VinculoProducto>(entity =>
            {
                entity.HasKey(e => e.IdVinculoProducto)
                    .HasName("PK__Vinculo___E01B484E6999E018");

                entity.ToTable("Vinculo_Producto");

                entity.Property(e => e.IdVinculoProducto).HasColumnName("IdVinculo_Producto");

                entity.Property(e => e.NombreVinculoProducto)
                    .IsRequired()
                    .HasColumnName("NombreVinculo_Producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
