using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
using System.Threading.Tasks;

namespace NavegaTIC_CTI.Controllers
{
    public class FormularioContactoController : Controller
    {
        // GET: FormularioContacto
        public ActionResult Index()
        {
            //List<Categoria> categorias = CargaDataCasoCE.GetCategoria_aibt(cat);
            
            //ViewBag.categorias = categorias;
           

            return View();
        }

        // GET: FormularioContacto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormularioContacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormularioContacto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult Subcategoria(int clave)
        {
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoriaid(clave);
            return Json(subcategorias, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Subcategoria_aib(int clave)
        {
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoriaid_aibt(clave);
            return Json(subcategorias, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Categoria_aib(int clave)
        {
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria_aibt(clave);
            return Json(categorias, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SaveWorkOrder(WorkOrder Ticket)
        {
            Users UserActual = await CargaDataCasoCE.InforUserActual();
            WorkOrder ReturnTicket = await CargaDataCasoCE.SaveCrearTicket(UserActual.IdMasterUsers,Ticket, Ticket.Group);
            /*Mover los archivos*/

            return new EmptyResult();
        }
            // GET: FormularioContacto/Edit/5

            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FormularioContacto/Edit/5
        [HttpPost]
        public async Task<ActionResult> Index(WorkOrder Ticket)
        {
            Users UserActual = await CargaDataCasoCE.InforUserActual();
            WorkOrder ReturnTicket = await CargaDataCasoCE.SaveCrearTicket(UserActual.IdMasterUsers, Ticket, Ticket.Group);
            /*Mover los archivos*/
            Caso caso = new Caso();
            caso.CasoId = ReturnTicket.IdWorkOrder.ToString();
            //return new EmptyResult();


            return View(caso);
        }
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FormularioContacto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormularioContacto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
