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
    public class ProcedimentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Procedimento/
       
        public ActionResult Index()
        {
            return View(db.Procedimentoes.ToList());
        }

        // GET: /Procedimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimento procedimento = db.Procedimentoes.Find(id);
            if (procedimento == null)
            {
                return HttpNotFound();
            }
            return View(procedimento);
        }

        // GET: /Procedimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Procedimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProcedimento,descricaoProcedimento")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                db.Procedimentoes.Add(procedimento);
                db.SaveChanges();
                

                return RedirectToAction("Create");
            }

            return View(procedimento);
        }

        // GET: /Procedimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimento procedimento = db.Procedimentoes.Find(id);
            if (procedimento == null)
            {
                return HttpNotFound();
            }
            return View(procedimento);
        }

        // POST: /Procedimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idProcedimento,descricaoProcedimento")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedimento);
        }

        // GET: /Procedimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimento procedimento = db.Procedimentoes.Find(id);
            if (procedimento == null)
            {
                return HttpNotFound();
            }
            return View(procedimento);
        }

        // POST: /Procedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedimento procedimento = db.Procedimentoes.Find(id);
            db.Procedimentoes.Remove(procedimento);
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
