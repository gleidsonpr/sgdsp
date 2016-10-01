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
    public class ExameDaBolsaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static int? idDaBolsa, idDoExame, idDoLabroratorio;

        public ActionResult Index(string codBarras)
        {
            BolsaSangue bolsa = null;

            var query = db.BolsaSangues
               .Where(b => b.codBarrasBolsa == codBarras).Where(b => b.transferida == false).ToList();

            if (query.Count > 0)
            {
                bolsa = query.First();
            }

            return View(bolsa);

        }

        public ActionResult PesquisarLaboratorio(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exame = db.Laboratorios.Where(l => l.ExameLaboratorios.Any(e => e.idExame == id));

            idDoExame = id;//seta o id da bolsa para cadastro futuro

          

            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        public ActionResult PesquisarExame(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idDaBolsa = id;//seta o id da bolsa para cadastro futuro

            var exame = db.Exames.ToList();//pesquisar

            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExameDaBolsa exameDaBolsa = db.ExameDaBolsas.Find(id);
            if (exameDaBolsa == null)
            {
                return HttpNotFound();
            }
            return View(exameDaBolsa);
        }


        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idDoLabroratorio = id;//seta o id da laboratorio para cadastro futuro

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idExameDaBolsa,observacao,idBolsaSangue,idLaboratorio,idExame")] ExameDaBolsa exameDaBolsa)
        {
            exameDaBolsa.idBolsaSangue = (int)idDaBolsa;
            exameDaBolsa.idExame = (int)idDoExame;
            exameDaBolsa.idLaboratorio = (int)idDoLabroratorio;

            if (ModelState.IsValid)
            {
                db.ExameDaBolsas.Add(exameDaBolsa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBolsaSangue = new SelectList(db.BolsaSangues, "idBolsaSangue", "codBarrasBolsa", exameDaBolsa.idBolsaSangue);
            ViewBag.idExame = new SelectList(db.Exames, "idExame", "nomeExame", exameDaBolsa.idExame);
            ViewBag.idLaboratorio = new SelectList(db.Laboratorios, "idLaboratorio", "descricaoLaboratorio", exameDaBolsa.idLaboratorio);
            return View(exameDaBolsa);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExameDaBolsa exameDaBolsa = db.ExameDaBolsas.Find(id);
            if (exameDaBolsa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBolsaSangue = new SelectList(db.BolsaSangues, "idBolsaSangue", "codBarrasBolsa", exameDaBolsa.idBolsaSangue);
            ViewBag.idExame = new SelectList(db.Exames, "idExame", "nomeExame", exameDaBolsa.idExame);
            ViewBag.idLaboratorio = new SelectList(db.Laboratorios, "idLaboratorio", "descricaoLaboratorio", exameDaBolsa.idLaboratorio);
            return View(exameDaBolsa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExameDaBolsa,observacao,idBolsaSangue,idLaboratorio,idExame")] ExameDaBolsa exameDaBolsa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exameDaBolsa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBolsaSangue = new SelectList(db.BolsaSangues, "idBolsaSangue", "codBarrasBolsa", exameDaBolsa.idBolsaSangue);
            ViewBag.idExame = new SelectList(db.Exames, "idExame", "nomeExame", exameDaBolsa.idExame);
            ViewBag.idLaboratorio = new SelectList(db.Laboratorios, "idLaboratorio", "descricaoLaboratorio", exameDaBolsa.idLaboratorio);
            return View(exameDaBolsa);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExameDaBolsa exameDaBolsa = db.ExameDaBolsas.Find(id);
            if (exameDaBolsa == null)
            {
                return HttpNotFound();
            }
            return View(exameDaBolsa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExameDaBolsa exameDaBolsa = db.ExameDaBolsas.Find(id);
            db.ExameDaBolsas.Remove(exameDaBolsa);
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
