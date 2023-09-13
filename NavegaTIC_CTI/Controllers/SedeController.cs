using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class SedeController : Controller
    {
        // GET: Sede
        public ActionResult Index()
        {
            List<Sede> sedes = CargaDataCasoCE.GetSedes();
            return View(sedes);
        }

        // GET: Sede/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Sede sedes = new Sede();
                    sedes.SedeName = collection["SedeName"];
                    _ = CargaDataCasoCE.GuardarDisposition("Sede", "CTICENTROEXP", sedes.SedeName);
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int id)
        {
            List<Sede> sedes = CargaDataCasoCE.GetSedes();
            Sede sd = sedes.Find(z => z.SedeId == id);
            
            return View(sd);
        }

        // POST: Sede/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Sede sedes = new Sede();
                    sedes.SedeName = collection["SedeName"];
                    
                    _ = CargaDataCasoCE.UpdateDisposition(sedes.SedeName,id);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sede/Delete/5
        public ActionResult Delete(int id)
        {
            List<Sede> sedes = CargaDataCasoCE.GetSedes();
            Sede sd = sedes.Find(z => z.SedeId == id);

            return View(sd);
        }

        // POST: Sede/Delete/5
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
