using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class SolucionController : Controller
    {
        // GET: Solucion
        public ActionResult Index()
        {
            List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
            return View(soluciones);
        }

        // GET: Solucion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Solucion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solucion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Solucion soluciones = new Solucion();
                    soluciones.SolucionName = collection["SolucionName"];
                    _ = CargaDataCasoCE.GuardarDisposition("Solucion", "CTICENTROEXP", soluciones.SolucionName);
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Solucion/Edit/5
        public ActionResult Edit(int id)
        {
            List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
            Solucion sd = soluciones.Find(z => z.SolucionId == id);
            
            return View(sd);
        }

        // POST: Solucion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Solucion soluciones = new Solucion();
                    soluciones.SolucionName = collection["SolucionName"];
                    
                    _ = CargaDataCasoCE.UpdateDisposition(soluciones.SolucionName,id);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Solucion/Delete/5
        public ActionResult Delete(int id)
        {
            List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
            Solucion sd = soluciones.Find(z => z.SolucionId == id);

            return View(sd);
        }

        // POST: Solucion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _ = CargaDataCasoCE.DeleteDisposition(id);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
