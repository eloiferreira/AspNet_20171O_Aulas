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
    public class SindicoController : Controller
    {
        private PAP_CondominioContext db = new PAP_CondominioContext();

        // GET: Sindico
        public ActionResult Index()
        {
            var sindicoes = db.Sindicoes.Include(s => s._CondominioId);
            return View(sindicoes.ToList());
        }

        // GET: Sindico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sindico sindico = db.Sindicoes.Find(id);
            if (sindico == null)
            {
                return HttpNotFound();
            }
            return View(sindico);
        }

        // GET: Sindico/Create
        public ActionResult Create()
        {
            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome");
            return View();
        }

        // POST: Sindico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SindicoId,NomeSobrenome,Cpf,Telefone,Email,Apartamento,CondominioId")] Sindico sindico)
        {
            if (ModelState.IsValid)
            {
                db.Sindicoes.Add(sindico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome", sindico.CondominioId);
            return View(sindico);
        }

        // GET: Sindico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sindico sindico = db.Sindicoes.Find(id);
            if (sindico == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome", sindico.CondominioId);
            return View(sindico);
        }

        // POST: Sindico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SindicoId,NomeSobrenome,Cpf,Telefone,Email,Apartamento,CondominioId")] Sindico sindico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sindico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondominioId = new SelectList(db.Condominios, "CondominioId", "Nome", sindico.CondominioId);
            return View(sindico);
        }

        // GET: Sindico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sindico sindico = db.Sindicoes.Find(id);
            if (sindico == null)
            {
                return HttpNotFound();
            }
            return View(sindico);
        }

        // POST: Sindico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sindico sindico = db.Sindicoes.Find(id);
            db.Sindicoes.Remove(sindico);
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
