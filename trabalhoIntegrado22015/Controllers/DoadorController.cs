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
    public class DoadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string cpf)
        {

           
            Doador doador = null;
            if (cpf != null)
            {
                var query = from c in db.Doadors where c.cpf == cpf select c;

                if (query.Count()<1)
                {
                   
                    return View(doador);
                }
                doador = query.First();
            }


            return View(doador);
 
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doador doador = db.Doadors.Find(id);
            if (doador == null)
            {
                return HttpNotFound();
            }
            return View(doador);
        }

        public ActionResult Create()
        {
            

           ViewBag.idSangue = new SelectList(db.Sangues, "idSangue", "tipoDeSangue");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include="idDoador,tipoDoador,cpf,rg,sexo,dataNascimento,nome,telefone,rua,numero,complemento,bairro,cep,cidade,estado,idSangue")]
            Doador doador)
        {
            if (ModelState.IsValid)
            {
                db.Doadors.Add(doador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doador);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doador doador = db.Doadors.Find(id);
            if (doador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSangue = new SelectList(db.Sangues, "idSangue", "tipoDeSangue");
           
            return View(doador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include="idDoador,tipoDoador,cpf,rg,sexo,dataNascimento,nome,telefone,rua,numero,complemento,bairro,cep,cidade,estado,idSangue")]
            Doador doador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doador);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doador doador = db.Doadors.Find(id);
            if (doador == null)
            {
                return HttpNotFound();
            }
            return View(doador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doador doador = db.Doadors.Find(id);
            db.Doadors.Remove(doador);
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
