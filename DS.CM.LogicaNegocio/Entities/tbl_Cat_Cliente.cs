namespace DS.CM.LogicaNegocio.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tbl_Cat_Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Cat_Cliente()
        {
            tbl_Det_Ventas = new HashSet<tbl_Det_Ventas>();
        }

        [Key]
        public int Cliente_Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Cliente_Nombre { get; set; }

        public int Cliente_Edad { get; set; }

        [Required]
        [StringLength(150)]
        public string Cliente_Pais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Det_Ventas> tbl_Det_Ventas { get; set; }

        /// <summary>
        /// Método encargado de obtener todo el listado de clientes.
        /// </summary>
        /// <returns>Devuelve un objto List de Clientes.</returns>
        public List<tbl_Cat_Cliente> GetAllCLientes()
        {
            try
            {
                List<tbl_Cat_Cliente> listaCliente = new List<tbl_Cat_Cliente>();
                using (var context = new bdContext())
                {
                    listaCliente = context.tbl_Cat_Cliente.ToList();
                }
                return listaCliente;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message,ex);
            }
        }

        public void Guardar()
        {
            try
            {
                using (var context = new bdContext())
                {
                    //this = objeto tbl_Cat_Cliente
                    if (this.Cliente_Id == 0)
                    {
                        // Aqui indicamos el tipo de accion a realizar en el objeto.
                        context.Entry(this).State = System.Data.Entity.EntityState.Added;
                    }
                    else
                    {
                        context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    //Guardamos cambios en base de datos.
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
