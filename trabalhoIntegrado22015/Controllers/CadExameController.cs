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
    public class CadExameController : Controller
    {
        public static int codControle;
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create(int id)
        {
            if (id<0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

          
            codControle = id;
            var tr = codControle;
            ViewBag.idExame = new SelectList(db.Exames, "idExame", "nomeExame");

            ViewBag.idLaboratorio = tr;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idExameDoLaboratorio,idExame,idLaboratorio")] ExameDoLaboratorio examedolaboratorio)
        {
            
            examedolaboratorio.idLaboratorio =codControle;
            if (ModelState.IsValid)
            {
                db.ExameDoLaboratorios.Add(examedolaboratorio);
                db.SaveChanges();
                return RedirectToAction("Index", "Laboratorio");
              
            }

            ViewBag.idExame = new SelectList(db.Exames, "idExame", "nomeExame", examedolaboratorio.idExame);
            ViewBag.idLaboratorio = new SelectList(db.Laboratorios, "idLaboratorio", "descricaoLaboratorio", examedolaboratorio.idLaboratorio);
            return View(examedolaboratorio);
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
