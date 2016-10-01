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

    public class UctController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Uct/
        public ActionResult Index(string cnpj)
        {
            Uct uct = null;
            if (cnpj != null)
            {
                var query = from c in db.Ucts  where c.cnpj == cnpj select c;
                if(query.Count()<1)
                    return View(uct);
                uct = query.Single();
            }

           
            return View(uct);



        }

        // GET: /Uct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uct uct = db.Ucts.Find(id);
            if (uct == null)
            {
                return HttpNotFound();
            }
            return View(uct);
        }

        // GET: /Uct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Uct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idUct,descricaoUct,cnpj,dataFundacao,nome,telefone,rua,numero,complemento,bairro,cep,cidade,estado")] Uct uct)
        {
            if (ModelState.IsValid)
            {
                db.Ucts.Add(uct);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(uct);
        }

        // GET: /Uct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uct uct = db.Ucts.Find(id);
            if (uct == null)
            {
                return HttpNotFound();
            }
            return View(uct);
        }

        // POST: /Uct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idUct,descricaoUct,cnpj,dataFundacao,nome,telefone,rua,numero,complemento,bairro,cep,cidade,estado")] Uct uct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uct);
        }

        // GET: /Uct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uct uct = db.Ucts.Find(id);
            if (uct == null)
            {
                return HttpNotFound();
            }
            return View(uct);
        }

        // POST: /Uct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uct uct = db.Ucts.Find(id);
            db.Ucts.Remove(uct);
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
