using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class CategoriasController : Controller

    {
        private MVC1Context banco = new MVC1Context();

        //GET: Categorias (www.meusite.com/Categoria/Index
        public ActionResult Index()
        {
            return View(banco.Categorias.ToList());


        }
        //GET: Categorias/Create
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                banco.Categorias.Add(categoria);
                banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);

        }

        //GET: Categorias/Edit
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Categoria categorias = banco.Categorias.Find(id);
            

            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);

        }
        //POST: Categorias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //o estado da categoria é modificado
                banco.Entry(categoria).State = EntityState.Modified;
                banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = banco.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
    }
}