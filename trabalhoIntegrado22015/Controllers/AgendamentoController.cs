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
    public class AgendamentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var agendamentoes = db.Agendamentoes.Include(a => a.Doador).Include(a => a.Uct);
            return View(agendamentoes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentoes.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        public ActionResult Create()
        {
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome");
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idAgendamento,observacao,dataAgendada,idDoador,idUct")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Agendamentoes.Add(agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", agendamento.idDoador);
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "nome", agendamento.idUct);
            return View(agendamento);
        }

        // GET: /Agendamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentoes.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", agendamento.idDoador);
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "nome", agendamento.idUct);
            return View(agendamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idAgendamento,observacao,dataAgendada,idDoador,idUct")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", agendamento.idDoador);
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "nome", agendamento.idUct);
            return View(agendamento);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentoes.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendamento agendamento = db.Agendamentoes.Find(id);
            db.Agendamentoes.Remove(agendamento);
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
