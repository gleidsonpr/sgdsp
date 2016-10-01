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
    public class BolsaController : Controller
    {
        public static int codControle;
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            var bolsasangues = db.BolsaSangues.Include(b => b.Doador).Include(b => b.Procedimento).Include(b => b.Uct);
            return View(bolsasangues.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaSangue bolsasangue = db.BolsaSangues.Find(id);
            if (bolsasangue == null)
            {
                return HttpNotFound();
            }
            return View(bolsasangue);
        }


        public ActionResult Create(int id)
        {
            if (id<1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            codControle = id;
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome");
            ViewBag.idProcedimento = new SelectList(db.Procedimentoes, "idProcedimento", "descricaoProcedimento");
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idBolsaSangue,idUct,idProcedimento,idDoador,codBarrasBolsa,dataColeta")] BolsaSangue bolsasangue)
        {
            bolsasangue.idDoador = codControle;
            if (ModelState.IsValid)
            {
                db.BolsaSangues.Add(bolsasangue);
                db.SaveChanges();
                return RedirectToAction("Pesquisa", "PesquisarDoadorParaColeta");//retornar para registrar coleta
            }

            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", bolsasangue.idDoador);
            ViewBag.idProcedimento = new SelectList(db.Procedimentoes, "idProcedimento", "descricaoProcedimento", bolsasangue.idProcedimento);
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "descricaoUct", bolsasangue.idUct);
            return View(bolsasangue);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaSangue bolsasangue = db.BolsaSangues.Find(id);
            if (bolsasangue == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", bolsasangue.idDoador);
            ViewBag.idProcedimento = new SelectList(db.Procedimentoes, "idProcedimento", "descricaoProcedimento", bolsasangue.idProcedimento);
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "descricaoUct", bolsasangue.idUct);
            return View(bolsasangue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idBolsaSangue,idUct,idProcedimento,idDoador,codBarrasBolsa,dataColeta")] BolsaSangue bolsasangue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolsasangue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");//retornar para registrar coleta
            }
            ViewBag.idDoador = new SelectList(db.Doadors, "idDoador", "nome", bolsasangue.idDoador);
            ViewBag.idProcedimento = new SelectList(db.Procedimentoes, "idProcedimento", "descricaoProcedimento", bolsasangue.idProcedimento);
            ViewBag.idUct = new SelectList(db.Ucts, "idUct", "descricaoUct", bolsasangue.idUct);
            return View(bolsasangue);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaSangue bolsasangue = db.BolsaSangues.Find(id);
            if (bolsasangue == null)
            {
                return HttpNotFound();
            }
            return View(bolsasangue);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BolsaSangue bolsasangue = db.BolsaSangues.Find(id);
            db.BolsaSangues.Remove(bolsasangue);
            db.SaveChanges();
            return RedirectToAction("Create");//retornar para registrar coleta
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
