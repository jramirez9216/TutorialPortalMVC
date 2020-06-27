namespace DS.CM.LogicaNegocio.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Det_Ventas
    {
        [Key]
        public int Ventas_Id { get; set; }

        public int Ventas_Producto_Id { get; set; }

        public int Ventas_Cliente_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ventas_Unidades { get; set; }

        public decimal Ventas_Precio { get; set; }

        public virtual tbl_Cat_Cliente tbl_Cat_Cliente { get; set; }

        public virtual tbl_Cat_Productos tbl_Cat_Productos { get; set; }
    }
}
