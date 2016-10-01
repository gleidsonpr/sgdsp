using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trabalhoIntegrado22015.Models;

namespace trabalhoIntegrado22015.Controllers
{
     [Authorize]
    public class CampanhaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            var campanhas = db.Campanhas.Include(c => c.uct);
            return View(campanhas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanha campanha = db.Campanhas.Find(id);
            if (campanha == null)
            {
                return HttpNotFound();
            }
            return View(campanha);
        }

        public ActionResult Create()
        {
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idCampanha,idUct,nomeCampanha,dataCampanhaInicio,dataCampanhaFinal,tipoCampanha")] Campanha campanha)
        {
            if (ModelState.IsValid)
            {
                db.Campanhas.Add(campanha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "descricaoUct", campanha.idUct);
            return View(campanha);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanha campanha = db.Campanhas.Find(id);
            if (campanha == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "descricaoUct", campanha.idUct);
            return View(campanha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idCampanha,idUct,nomeCampanha,dataCampanhaInicio,dataCampanhaFinal,tipoCampanha")] Campanha campanha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campanha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "descricaoUct", campanha.idUct);
            return View(campanha);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanha campanha = db.Campanhas.Find(id);
            if (campanha == null)
            {
                return HttpNotFound();
            }
            return View(campanha);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campanha campanha = db.Campanhas.Find(id);
            db.Campanhas.Remove(campanha);
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
