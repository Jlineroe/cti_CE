using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
namespace NavegaTIC_CTI.Controllers
{
    public class SubCategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
            List<Subcategoria> subcategorias_fin = new List<Subcategoria>();
            foreach (var item in subcategorias)
            {
                Categoria sd = categorias.Find(z => z.CategoriaId == item.pri);
                Subcategoria subcategorias1 = new Subcategoria
                {
                    SubcategoriaId=item.SubcategoriaId,
                    SubcategoriaName=item.SubcategoriaName,
                    CategoriaName=sd.CategoriaName

                };
                subcategorias_fin.Add(subcategorias1);
            }

            return View(subcategorias_fin);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
            ViewBag.categorias = categorias;
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
                    Subcategoria subcategorias = new Subcategoria();
                    subcategorias.SubcategoriaName = collection["SubcategoriaName"];
                    subcategorias.IdCategoria = Convert.ToInt32(collection["IdCategoria"]);
                    _ = CargaDataCasoCE.GuardarDisposition("Subcategoria", "CTICENTROEXP", subcategorias.SubcategoriaName, (subcategorias.IdCategoria).ToString());
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
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
            Subcategoria sd = subcategorias.Find(z => z.SubcategoriaId == id);
            List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
            ViewBag.categorias = categorias;


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
                    Subcategoria subcategorias = new Subcategoria();
                    subcategorias.SubcategoriaName = collection["SubcategoriaName"];
                    subcategorias.IdCategoria = Convert.ToInt32(collection["IdCategoria"]);


                    _ = CargaDataCasoCE.UpdateDisposition(subcategorias.SubcategoriaName, id, (subcategorias.IdCategoria).ToString());
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
            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
            Subcategoria sd = subcategorias.Find(z => z.SubcategoriaId == id);

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
