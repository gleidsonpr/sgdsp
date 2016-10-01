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
    public class QuestionarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Questionario/
        
        public ActionResult Index()
        {
            var questionarios = db.Questionarios.Include(q => q.Doador);
            return View(questionarios.ToList());
        }

        // GET: /Questionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionario questionario = db.Questionarios.Find(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        // GET: /Questionario/Create
        public ActionResult Create()
        {
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome");
            return View();
        }

        // POST: /Questionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include="idQuestionario,idDoador,fuma,qntCigarros,bebe,qntBebidasSemana,possuiTatuagem,qntTempoTatuagem,utilizaDrogaIlicita,descricaoDrogras,historicoDeDoenca,descricaoDoencas,hepatite,jejum,dataQuestionario")
            ] Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                db.Questionarios.Add(questionario);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", questionario.idDoador);
            return View(questionario);
        }

        // GET: /Questionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionario questionario = db.Questionarios.Find(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", questionario.idDoador);
            return View(questionario);
        }

        // POST: /Questionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include="idQuestionario,idDoador,fuma,qntCigarros,bebe,qntBebidasSemana,possuiTatuagem,qntTempoTatuagem,utilizaDrogaIlicita,descricaoDrogras,historicoDeDoenca,descricaoDoencas,hepatite,jejum,dataQuestionario")
            ] Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", questionario.idDoador);
            return View(questionario);
        }

        // GET: /Questionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionario questionario = db.Questionarios.Find(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        // POST: /Questionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionario questionario = db.Questionarios.Find(id);
            db.Questionarios.Remove(questionario);
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
