namespace DS.CM.LogicaNegocio.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Cat_Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Cat_Productos()
        {
            tbl_Det_Ventas = new HashSet<tbl_Det_Ventas>();
        }

        [Key]
        public int Producto_Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Producto_Nombre { get; set; }

        [Required]
        [StringLength(300)]
        public string Producto_Descripcion { get; set; }

        [StringLength(150)]
        public string Producto_Marca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Det_Ventas> tbl_Det_Ventas { get; set; }
    }
}
