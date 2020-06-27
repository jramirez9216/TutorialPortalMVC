using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DS.CM.LogicaNegocio.Entities;

namespace DS.CM.UI.Controllers
{
    public class ClientesController : Controller
    {
        private tbl_Cat_Cliente objCLientes = new tbl_Cat_Cliente();
        // GET: Clientes
        public ActionResult Index()
        {            
            return View(objCLientes.GetAllCLientes());
        }

        public ActionResult Registro( int id = 0)
        {
            return View(id > 0 ? objCLientes.GetAllCLientes().Where(item => item.Cliente_Id == id).FirstOrDefault<tbl_Cat_Cliente>() : new tbl_Cat_Cliente());
        }

        public ActionResult Detalle(int? id = 0)
        {
            return View(objCLientes.GetAllCLientes().Where(item => item.Cliente_Id == id).FirstOrDefault<tbl_Cat_Cliente>());
        }

        public ActionResult Guardar(tbl_Cat_Cliente objCliente)
        {
            try
            {
                if (objCliente != null && objCliente.Cliente_Id == 0)
                {
                    tbl_Cat_Cliente objClientenew = new tbl_Cat_Cliente()
                    {
                        Cliente_Nombre = objCliente.Cliente_Nombre,
                        Cliente_Edad = objCliente.Cliente_Edad,
                        Cliente_Pais = objCliente.Cliente_Pais
                    };
                    ///Mandamos a llamar el método que acabamos de crear.
                    objClientenew.Guardar();
                }
                else
                {
                    objCliente.Guardar();
                }

            }
            catch (Exception ex)
            {
                string m = ex.Message;
                return View("~/Clientes/Registro.cshtml", objCliente);
            }
            return Redirect("~/Clientes/Registro/");
        }
    }

}