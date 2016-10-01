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
    public class TransferenciaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public static int codControle;
        // GET: /Transferencia/
        public ActionResult Index()
        {
            var transferencias = db.Transferencias.Include(t => t.Bolsa).Include(t => t.Hospital);
            return View(transferencias.ToList());
        }

        // GET: /Transferencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transferencia transferencia = db.Transferencias.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            return View(transferencia);
        }

        // GET: /Transferencia/Create
        public ActionResult Create(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            codControle = id;
            
            ViewBag.idHospital = new SelectList(db.Hospitals, "idHospital", "descricaoHospital");
            return View();
        }

        // POST: /Transferencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include="idTransferencia,idHospital,idBolsaSangue,dataTransferencia,observacoes")]
            Transferencia transferencia)
        {
            transferencia.idBolsaSangue = codControle;

            if (ModelState.IsValid)
            {
                db.Transferencias.Add(transferencia);
                db.SaveChanges();

                //depois q a bolsa foi transferida ela e pesquisada e sua propriedade transferida é alterada para true
                var bolsaQFoiTransfrerida= db.BolsaSangues.Find(codControle);
                bolsaQFoiTransfrerida.transferida = true;
                db.Entry(bolsaQFoiTransfrerida).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.idBolsaSangue = new SelectList(db.BolsaSangues, "idBolsaSangue", "codBarrasBolsa", transferencia.idBolsaSangue);
            ViewBag.idHospital = new SelectList(db.Hospitals, "idHospital", "descricaoUct", transferencia.idHospital);
            return View(transferencia);
        }

        // GET: /Transferencia/Edit/5

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
