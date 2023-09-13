using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class UbicacionController : Controller
    {
        // GET: Sede
        public ActionResult Index()
        {
            
            List<Ubicacion> ubicaciones = CargaDataCasoCE.GetUbicacion();
            List<Sede> sedes = CargaDataCasoCE.GetSedes();
            List<Ubicacion> ubicaciones_fin = new List<Ubicacion>();
            foreach (var item in ubicaciones)
            {
                Sede sd = sedes.Find(z => z.SedeId == item.pri);
                Ubicacion ubicaciones1 = new Ubicacion
                {
                    UbicacionId=item.UbicacionId,
                    UbicacionName=item.UbicacionName,
                    SedeName=sd.SedeName

                };
                ubicaciones_fin.Add(ubicaciones1);
            }

            return View(ubicaciones_fin);
        }

        // GET: Sede/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            List<Sede> sedes = CargaDataCasoCE.GetSedes();
            ViewBag.sedes = sedes;
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
                    Ubicacion ubicaciones = new Ubicacion();
                    ubicaciones.UbicacionName = collection["UbicacionName"];
                    ubicaciones.IdSede = Convert.ToInt32(collection["IdSede"]);
                    _ = CargaDataCasoCE.GuardarDisposition("Ubicacion", "CTICENTROEXP", ubicaciones.UbicacionName, (ubicaciones.IdSede).ToString());
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
            List<Ubicacion> ubicaciones = CargaDataCasoCE.GetUbicacion();
            Ubicacion sd = ubicaciones.Find(z => z.UbicacionId == id);
            List<Sede> sedes = CargaDataCasoCE.GetSedes();
            ViewBag.sedes = sedes;


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
                    Ubicacion ubicaciones = new Ubicacion();
                    ubicaciones.UbicacionName = collection["UbicacionName"];
                    ubicaciones.IdSede = Convert.ToInt32(collection["IdSede"]);


                    _ = CargaDataCasoCE.UpdateDisposition(ubicaciones.UbicacionName, id, (ubicaciones.IdSede).ToString());
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
            List<Ubicacion> ubicaciones = CargaDataCasoCE.GetUbicacion();
            Ubicacion sd = ubicaciones.Find(z => z.UbicacionId == id);

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
