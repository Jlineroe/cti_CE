using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            
            List<Detalle> detalles = CargaDataCasoCE.GetDetalles();
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
            List<Detalle> detalle_fin = new List<Detalle>();
            foreach (var item in detalles)
            {
                Subcategoria sd = subcategorias.Find(z => z.SubcategoriaId == item.pri);
                if(item.pri != 33)
                {
                    item.Campaña = "";
                }
                Detalle detalles1 = new Detalle
                {
                    DetalleId=item.DetalleId,
                    DetalleName=item.DetalleName,
                    SubcategoriaName=sd.SubcategoriaName,
                    Campaña=item.Campaña

                };
                detalle_fin.Add(detalles1);
            }

            return View(detalle_fin);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
            ViewBag.subcategorias = subcategorias;
            List<Campana> campanas = CargaDataCasoCE.GetCampana();
            ViewBag.campanas = campanas;
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            string nombrecampana = "";
            try
            {
                if (ModelState.IsValid)
                {
                    Detalle detalles = new Detalle();
                    detalles.DetalleName = collection["DetalleName"];
                    detalles.IdSubcategoria = Convert.ToInt32(collection["IdSubcategoria"]);
                    detalles.Campaña= collection["Campaña"];
                    if(detalles.Campaña == "" )
                    {
                        nombrecampana = "CTICENTROEXP";
                    }
                    else
                    {
                        nombrecampana = detalles.Campaña;
                    }
                    _ = CargaDataCasoCE.GuardarDisposition("Detalle",nombrecampana, detalles.DetalleName, (detalles.IdSubcategoria).ToString());
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            List<Detalle> detalles = CargaDataCasoCE.GetDetalles();
            Detalle sd = detalles.Find(z => z.DetalleId == id);
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
            ViewBag.subcategorias = subcategorias;
            List<Campana> campanas = CargaDataCasoCE.GetCampana();
            ViewBag.campanas = campanas;


            return View(sd);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            string nombrecampana = "";
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Detalle detalles = new Detalle();
                    detalles.DetalleName = collection["DetalleName"];
                    detalles.IdSubcategoria = Convert.ToInt32(collection["IdSubcategoria"]);
                    detalles.Campaña = collection["Campaña"];
                    if (detalles.Campaña == "")
                    {
                        nombrecampana = "CTICENTROEXP";
                    }
                    else
                    {
                        nombrecampana = detalles.Campaña;
                    }

                    _ = CargaDataCasoCE.UpdateDisposition(detalles.DetalleName, id, (detalles.IdSubcategoria).ToString(),nombrecampana);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            List<Detalle> detalles = CargaDataCasoCE.GetDetalles();
            Detalle sd = detalles.Find(z => z.DetalleId == id);

            return View(sd);
        }

        // POST: Categoria/Delete/5
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
