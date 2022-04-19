using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Proyecto_PrograWebAvanzadaContext : DbContext
    {
        public Proyecto_PrograWebAvanzadaContext()
        {
        }

        public Proyecto_PrograWebAvanzadaContext(DbContextOptions<Proyecto_PrograWebAvanzadaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<FamiliaProducto> FamiliaProducto { get; set; }
        public virtual DbSet<HistorialFactura> HistorialFactura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<RolEmpleado> RolEmpleado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RMN4MKS;Database=Proyecto_PrograWebAvanzada;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642B68F7BCC");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
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

                entity.Property(e => e.TelefonoEmpleado)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__CE6D8B9E486CB2B1");

                entity.Property(e => e.ApellidoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordEmpleado)
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
                    .HasConstraintName("FK__Empleado__IdRol__267ABA7A");
            });

            modelBuilder.Entity<FamiliaProducto>(entity =>
            {
                entity.HasKey(e => e.IdFamiliaProducto)
                    .HasName("PK__Familia___3D1FC61DA50E21F3");

                entity.ToTable("Familia_Producto");

                entity.Property(e => e.IdFamiliaProducto).HasColumnName("IdFamilia_Producto");

                entity.Property(e => e.NombreFamiliaProducto)
                    .IsRequired()
                    .HasColumnName("NombreFamilia_Producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistorialFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Historia__50E7BAF19BE456AF");

                entity.Property(e => e.CodigoFactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.HistorialFactura)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historial__IdCli__32E0915F");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.HistorialFactura)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historial__IdEmp__33D4B598");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__098892102DDBAD28");

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.IdFamiliaProducto).HasColumnName("IdFamilia_Producto");

                //entity.Property(e => e.ImagenProducto).IsRequired();

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamiliaProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdFamiliaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__IdFami__2F10007B");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__IdProv__300424B4");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__E8B631AFD1110563");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaBancariaProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.NombreProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoProveedor)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol_Empl__2A49584C95C65A77");

                entity.ToTable("Rol_Empleado");

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
