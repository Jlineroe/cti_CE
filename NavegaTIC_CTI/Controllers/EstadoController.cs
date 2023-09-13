using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            List<Estado> estados = CargaDataCasoCE.GetEstados();
            return View(estados);
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Estado estados = new Estado();
                    estados.EstadoName = collection["EstadoName"];
                    _ = CargaDataCasoCE.GuardarDisposition("Estado", "CTICENTROEXP", estados.EstadoName);
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            List<Estado> estados = CargaDataCasoCE.GetEstados();
            Estado sd = estados.Find(z => z.EstadoId == id);
            
            return View(sd);
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Estado estados = new Estado();
                    estados.EstadoName = collection["EstadoName"];
                    
                    _ = CargaDataCasoCE.UpdateDisposition(estados.EstadoName,id);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            List<Estado> estados = CargaDataCasoCE.GetEstados();
            Estado sd = estados.Find(z => z.EstadoId == id);

            return View(sd);
        }

        // POST: Estado/Delete/5
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
