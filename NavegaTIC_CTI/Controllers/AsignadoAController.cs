using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class AsignadoAController : Controller
    {
        // GET: Sede
        public ActionResult Index()
        {
            List<AsignadoA> asignadoa = CargaDataCasoCE.GetAsignadoA();
            return View(asignadoa);
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
                    AsignadoA asignadoa = new AsignadoA();
                    asignadoa.AsignadoAName = collection["AsignadoAName"];
                    _ = CargaDataCasoCE.GuardarDisposition("Asignado a", "CTICENTROEXP", asignadoa.AsignadoAName);
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
            List<AsignadoA> asignadoa = CargaDataCasoCE.GetAsignadoA();
            AsignadoA sd = asignadoa.Find(z => z.AsignadoAId == id);
            
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
                    AsignadoA asignadoa = new AsignadoA();
                    asignadoa.AsignadoAName = collection["AsignadoAName"];

                    _ = CargaDataCasoCE.UpdateDisposition(asignadoa.AsignadoAName, id);
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
            List<AsignadoA> asignadoa = CargaDataCasoCE.GetAsignadoA();
            AsignadoA sd = asignadoa.Find(z => z.AsignadoAId == id);

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
