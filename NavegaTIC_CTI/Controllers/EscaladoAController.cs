using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class EscaladoAController : Controller
    {
        // GET: EscaladoA
        public ActionResult Index()
        {
            List<EscaladoA> escaladoa = CargaDataCasoCE.GetEscaladoa();
            return View(escaladoa);
        }

        // GET: EscaladoA/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EscaladoA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscaladoA/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EscaladoA escaladoa = new EscaladoA();
                    escaladoa.EscaladoAName = collection["EscaladoAName"];
                    _ = CargaDataCasoCE.GuardarDisposition("Escalado A", "CTICENTROEXP", escaladoa.EscaladoAName);
                }
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EscaladoA/Edit/5
        public ActionResult Edit(int id)
        {
            List<EscaladoA> escaladoa = CargaDataCasoCE.GetEscaladoa();
            EscaladoA sd = escaladoa.Find(z => z.EscaladoAId == id);
            
            return View(sd);
        }

        // POST: EscaladoA/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    EscaladoA escaladoa = new EscaladoA();
                    escaladoa.EscaladoAName = collection["EscaladoAName"];
                    
                    _ = CargaDataCasoCE.UpdateDisposition(escaladoa.EscaladoAName,id);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EscaladoA/Delete/5
        public ActionResult Delete(int id)
        {
            List<EscaladoA> escaladoa = CargaDataCasoCE.GetEscaladoa();
            EscaladoA sd = escaladoa.Find(z => z.EscaladoAId == id);

            return View(sd);
        }

        // POST: EscaladoA/Delete/5
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
