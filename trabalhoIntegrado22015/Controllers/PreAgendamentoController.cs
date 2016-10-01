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
    public class PreAgendamentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PreAgendamento/
        public ActionResult Index()
        {
            return View(db.PreAgendamentos.ToList());
        }

        // GET: /PreAgendamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreAgendamento preagendamento = db.PreAgendamentos.Find(id);
            if (preagendamento == null)
            {
                return HttpNotFound();
            }
            return View(preagendamento);
        }

        // GET: /PreAgendamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PreAgendamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idPreAgendamento,tipoSangue,nome,telefone,observacao,dataDePreferencia,jaAgendado")] PreAgendamento preagendamento)
        {
            if (ModelState.IsValid)
            {
                db.PreAgendamentos.Add(preagendamento);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(preagendamento);
        }

        // GET: /PreAgendamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreAgendamento preagendamento = db.PreAgendamentos.Find(id);
            if (preagendamento == null)
            {
                return HttpNotFound();
            }
            return View(preagendamento);
        }

        // POST: /PreAgendamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idPreAgendamento,tipoSangue,nome,telefone,observacao,dataDePreferencia,jaAgendado")] PreAgendamento preagendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preagendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(preagendamento);
        }

        // GET: /PreAgendamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreAgendamento preagendamento = db.PreAgendamentos.Find(id);
            if (preagendamento == null)
            {
                return HttpNotFound();
            }
            return View(preagendamento);
        }

        // POST: /PreAgendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreAgendamento preagendamento = db.PreAgendamentos.Find(id);
            db.PreAgendamentos.Remove(preagendamento);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
