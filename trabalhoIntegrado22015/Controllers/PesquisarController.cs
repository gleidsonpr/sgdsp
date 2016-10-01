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
    public class PesquisarController : Controller
    {
        //private readonly ModelDb db;
        private ApplicationDbContext db;
        public PesquisarController()
        {
            db = new ApplicationDbContext();
        }

        ~PesquisarController()
        {
            db.Dispose();
        }

        [HttpGet]
        public ActionResult Pesquisa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pesquisa(string texto)
        {

            var pesquisa = db.Doadors.Where(x => x.nome.Contains(texto));

            return View(pesquisa.ToList());
           
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doador pesquisa = db.Doadors.Find(id);
            if (pesquisa == null)
            {
                return HttpNotFound();
            }
            return View(pesquisa);
        }
    }
}