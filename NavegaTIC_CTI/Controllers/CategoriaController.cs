using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
            return View(categorias);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria categorias = new Categoria();
                    categorias.CategoriaName = collection["CategoriaName"];
                    _ = CargaDataCasoCE.GuardarDisposition("Categoria", "CTICENTROEXP", categorias.CategoriaName);
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
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
            Categoria sd = categorias.Find(z => z.CategoriaId == id);
            
            return View(sd);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Categoria categorias = new Categoria();
                    categorias.CategoriaName = collection["CategoriaName"];
                    
                    _ = CargaDataCasoCE.UpdateDisposition(categorias.CategoriaName,id);
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
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
            Categoria sd = categorias.Find(z => z.CategoriaId == id);

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
