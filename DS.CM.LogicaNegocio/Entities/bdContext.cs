namespace DS.CM.LogicaNegocio.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class bdContext : DbContext
    {
        public bdContext()
            : base("name=bdContext")
        {
        }

        public virtual DbSet<tbl_Cat_Cliente> tbl_Cat_Cliente { get; set; }
        public virtual DbSet<tbl_Cat_Productos> tbl_Cat_Productos { get; set; }
        public virtual DbSet<tbl_Det_Ventas> tbl_Det_Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Cat_Cliente>()
                .Property(e => e.Cliente_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cat_Cliente>()
                .Property(e => e.Cliente_Pais)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cat_Cliente>()
                .HasMany(e => e.tbl_Det_Ventas)
                .WithRequired(e => e.tbl_Cat_Cliente)
                .HasForeignKey(e => e.Ventas_Cliente_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Cat_Productos>()
                .Property(e => e.Producto_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cat_Productos>()
                .Property(e => e.Producto_Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cat_Productos>()
                .Property(e => e.Producto_Marca)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Cat_Productos>()
                .HasMany(e => e.tbl_Det_Ventas)
                .WithRequired(e => e.tbl_Cat_Productos)
                .HasForeignKey(e => e.Ventas_Producto_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Det_Ventas>()
                .Property(e => e.Ventas_Unidades)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Det_Ventas>()
                .Property(e => e.Ventas_Precio)
                .HasPrecision(20, 2);
        }
    }
}
