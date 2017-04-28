using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAP_Condominio.Models;

namespace PAP_Condominio.Controllers
{
    public class MoradoresController : Controller
    {
        private PAP_CondominioContext db = new PAP_CondominioContext();

        ////TESTE PESQUISAR
        // GET: Moradores
        //public ActionResult Index()
        //{
        //    var moradors = db.Moradors.Include(m => m._CondominioId);
        //    return View(moradors.ToList());
        //}

        ////TESTE PESQUISAR
        public ActionResult Index(string filtroNome)
        {
            IQueryable<Morador> morador = db.Moradors;

            if (!string.IsNullOrEmpty(filtroNome))
            {
                filtroNome = filtroNome.ToLower();
                morador = morador.Where(m => m.NomeSobrenome.ToLower().Contains(filtroNome));

               }
            return View(morador.ToList());
        }


        // GET: Moradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = db.Moradors.Find(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // GET: Moradores/Create
        public ActionResult Create()
        {
            ViewBag.CondominioID = new SelectList(db.Condominios, "CondominioId", "Nome");
            return View();
        }

        // POST: Moradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoradorId,NomeSobrenome,Cpf,Telefone,Email,Apartamento,CondominioId")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                db.Moradors.Add(morador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondominioID = new SelectList(db.Condominios, "CondominioId", "Nome", morador.CondominioId);
            return View(morador);
        }

        // GET: Moradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = db.Moradors.Find(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondominioID = new SelectList(db.Condominios, "CondominioId", "Nome", morador.CondominioId);
            return View(morador);
        }

        // POST: Moradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoradorId,NomeSobrenome,Cpf,Telefone,Email,Apartamento,CondominioId")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(morador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondominioID = new SelectList(db.Condominios, "CondominioId", "Nome", morador.CondominioId);
            return View(morador);
        }

        // GET: Moradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morador morador = db.Moradors.Find(id);
            if (morador == null)
            {
                return HttpNotFound();
            }
            return View(morador);
        }

        // POST: Moradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Morador morador = db.Moradors.Find(id);
            db.Moradors.Remove(morador);
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
