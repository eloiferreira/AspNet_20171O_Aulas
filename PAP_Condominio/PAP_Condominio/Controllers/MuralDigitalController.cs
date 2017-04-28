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
    public class MuralDigitalController : Controller
    {
        private PAP_CondominioContext db = new PAP_CondominioContext();

        // GET: MuralDigital
        public ActionResult Index()
        {
            var solicitacaos = db.Solicitacaos.Include(m => m._Morador);
            return View(solicitacaos.ToList());
        }

        // GET: MuralDigital/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuralDigital muralDigital = db.Solicitacaos.Find(id);
            if (muralDigital == null)
            {
                return HttpNotFound();
            }
            return View(muralDigital);
        }

        // GET: MuralDigital/Create
        public ActionResult Create()
        {
            ViewBag.Data = DateTime.Now.ToShortDateString();
            //ViewBag.Data = DateTime.Now.ToShortDateString();
           
            ViewBag.MoradorId = new SelectList(db.Moradors, "MoradorId", "NomeSobrenome");
            return View();
        }

        // POST: MuralDigital/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuralDigitalId,Data,Tipo,Assunto,Mensagem,MoradorId")] MuralDigital muralDigital)
        {
            if (ModelState.IsValid)
            {



               
                db.Solicitacaos.Add(muralDigital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MoradorId = new SelectList(db.Moradors, "MoradorId", "NomeSobrenome", muralDigital.MoradorId);
            return View(muralDigital);
        }

        // GET: MuralDigital/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuralDigital muralDigital = db.Solicitacaos.Find(id);
            if (muralDigital == null)
            {
                return HttpNotFound();
            }
            ViewBag.MoradorId = new SelectList(db.Moradors, "MoradorId", "NomeSobrenome", muralDigital.MoradorId);
            return View(muralDigital);
        }

        // POST: MuralDigital/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuralDigitalId,Data,Tipo,Assunto,Mensagem,MoradorId")] MuralDigital muralDigital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muralDigital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MoradorId = new SelectList(db.Moradors, "MoradorId", "NomeSobrenome", muralDigital.MoradorId);
            return View(muralDigital);
        }

        // GET: MuralDigital/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuralDigital muralDigital = db.Solicitacaos.Find(id);
            if (muralDigital == null)
            {
                return HttpNotFound();
            }
            return View(muralDigital);
        }

        // POST: MuralDigital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MuralDigital muralDigital = db.Solicitacaos.Find(id);
            db.Solicitacaos.Remove(muralDigital);
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
