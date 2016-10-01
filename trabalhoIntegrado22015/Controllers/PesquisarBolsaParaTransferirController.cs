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
    public class PesquisarBolsaParaTransferirController : Controller
    {
       private ApplicationDbContext db;
        public PesquisarBolsaParaTransferirController()
        {
            db = new ApplicationDbContext();
        }

        ~PesquisarBolsaParaTransferirController()
        {
            db.Dispose();
        }

        [HttpGet]
        public ActionResult Pesquisa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pesquisa(string codBarras)
        {
            BolsaSangue bolsa = null;

            var query = db.BolsaSangues
               .Where(b => b.codBarrasBolsa == codBarras).Where(b=>b.transferida==false).ToList();

            if (query.Count > 0)
            {
                bolsa = query.First();
            }

            return View(bolsa);
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