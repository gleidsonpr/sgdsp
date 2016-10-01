using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trabalhoIntegrado22015.Models;


namespace trabalhoIntegrado22015.Controllers
{
     [Authorize]
    public class PesquisarBolsaController : Controller
    {
        private ApplicationDbContext db;
        public PesquisarBolsaController()
        {
        db = new ApplicationDbContext();
        }

        ~PesquisarBolsaController()
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

            BolsaSangue bolsa=null;
            
            var query= db.BolsaSangues
               .Where(b => b.codBarrasBolsa == codBarras).ToList();

            if(query.Count>0)
            {
                bolsa = query.First();
            }

            return View(bolsa);
           
        }

      
	}
}