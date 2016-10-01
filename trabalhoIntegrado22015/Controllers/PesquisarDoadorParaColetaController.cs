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
    public class PesquisarDoadorParaColetaController : Controller
    {
        
        private ApplicationDbContext db;
        public PesquisarDoadorParaColetaController()
        {
            db = new ApplicationDbContext();
        }

        ~PesquisarDoadorParaColetaController()
        {
            db.Dispose();
        }

        [HttpGet]
        public ActionResult Pesquisa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pesquisa(string cpf)
        {
            using (var db2 = new ApplicationDbContext())
            {
                db2.Configuration.LazyLoadingEnabled = false;


                var model = from c in db2.Doadors where c.cpf == cpf select c;

                return View(model.ToList());
            }

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