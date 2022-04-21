using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class ALMACENES_CAIMANContext : DbContext
    {
        public ALMACENES_CAIMANContext()
        {
        }

        public ALMACENES_CAIMANContext(DbContextOptions<ALMACENES_CAIMANContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detallesventa> Detallesventas { get; set; } = null!;
        public virtual DbSet<Historialprecio> Historialprecios { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;
        public virtual DbSet<Vproducto> Vproductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AB6RA5A\\SQLEXPRESS;Database=ALMACENES_CAIMAN;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("CATEGORIAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaDeCreacion).HasColumnType("date");

                entity.Property(e => e.Fechademodificacion)
                    .HasColumnType("date")
                    .HasColumnName("fechademodificacion");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idclientes)
                    .HasName("PK__CLIENTES__3214EC278952F4C7");

                entity.ToTable("CLIENTES");

                entity.Property(e => e.Idclientes).HasColumnName("idclientes");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaDeCreacion).HasColumnType("date");

                entity.Property(e => e.Fechademodificacion)
                    .HasColumnType("date")
                    .HasColumnName("fechademodificacion");

                entity.Property(e => e.Nit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detallesventa>(entity =>
            {
                entity.HasKey(e => e.Iddetallesventas)
                    .HasName("PK__DETALLES__3214EC279880CA1A");

                entity.ToTable("DETALLESVENTAS");

                entity.Property(e => e.Iddetallesventas).HasColumnName("iddetallesventas");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaDeCreacion).HasColumnType("date");

                entity.Property(e => e.Fechademodificacion)
                    .HasColumnType("date")
                    .HasColumnName("fechademodificacion");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Idventa).HasColumnName("idventa");

                entity.Property(e => e.PrecioVenta).HasColumnType("numeric(18, 5)");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detallesventa)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK_DETALLESVENTAS_PRODUCTOS");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(p => p.Detallesventa)
                    .HasForeignKey(d => d.Idventa)
                    .HasConstraintName("FK_DETALLESVENTAS_VENTAS");
            });

            modelBuilder.Entity<Historialprecio>(entity =>
            {
                entity.ToTable("HISTORIALPRECIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaDeCreacion).HasColumnType("date");

                entity.Property(e => e.Fechademodificacion)
                    .HasColumnType("date")
                    .HasColumnName("fechademodificacion");

                entity.Property(e => e.NuevoPrecio).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.PrecioAntiguo).HasColumnType("numeric(18, 5)");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Historialprecios)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIALPRECIOS_PRODUCTOS");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedidos");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK__pedidos__idclien__4F47C5E3");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__Producto__3214EC2778E40B90");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaDeCreacion).HasColumnType("date");

                entity.Property(e => e.Fechademodificacion)
                    .HasColumnType("date")
                    .HasColumnName("fechademodificacion");

                entity.Property(e => e.PrecioCompra).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Precioventa).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTOS_CATEGORIAS");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PK__VENTAS__3214EC27F4518183");

                entity.ToTable("VENTAS");

                entity.Property(e => e.Idventa).HasColumnName("idventa");

                entity.Property(e => e.Descuento)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("descuento");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaDeCreacion).HasColumnType("date");

                entity.Property(e => e.Fechademodificacion)
                    .HasColumnType("date")
                    .HasColumnName("fechademodificacion");

                entity.Property(e => e.Idclientes).HasColumnName("idclientes");

                entity.HasOne(d => d.IdclientesNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idclientes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VENTAS_CLIENTES");
            });

            modelBuilder.Entity<Vproducto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vproductos");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ganancia)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("ganancia");

                entity.Property(e => e.Idproducto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idproducto");

                entity.Property(e => e.PrecioCompra).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Precioventa).HasColumnType("numeric(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
