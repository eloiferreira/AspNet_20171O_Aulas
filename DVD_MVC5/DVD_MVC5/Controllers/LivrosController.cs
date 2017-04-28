using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DVD_MVC5.Models;

namespace DVD_MVC5.Controllers
{
    public class LivrosController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: Livros

            //o index vai mostrar a lista de livros
        public ActionResult Index()
        {
            //o ToList servepara materializar, 
            //ele vai no banco materializa voltou e 
            //retorna e passa pra view o resultado, a lista de livros
            return View(db.Livros.ToList());
        }

        // GET: Livros/Details/5

            //faz a pesquisa pelo id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = db.Livros.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // GET: Livros/Create
        //Formulario que o usuario preenche
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //protege contra hacker
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLivro,Titulo,Autor,Preco,Estoque,Disponivel")] Livros livros)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(livros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livros);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Find só procura por id, se for por string deve usar o Where
            Livros livros = db.Livros.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLivro,Titulo,Autor,Preco,Estoque,Disponivel")] Livros livros)
        {
            //modelState é o estado do modelo
            if (ModelState.IsValid)
            {

                db.Entry(livros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livros);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = db.Livros.Find(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livros livros = db.Livros.Find(id);
            db.Livros.Remove(livros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
