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
    public class FuncionarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Funcionario/
        public ActionResult Index(string cpf)
        {


            Funcionario funcionario = null;
            if (cpf != null)
            {
                var query = from c in db.Funcionarios where c.cpf == cpf select c;

                if (query.Count()<1)
                {
                    
                    return View(funcionario);
                }
                funcionario = query.Single();

            }
          

            return View(funcionario);


        }

        // GET: /Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: /Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idFuncionario,matriculaFuncionario,cargo,dataAdmimissao,registroProssional,salario,cpf,rg,sexo,dataNascimento,usuario,senha,permissao,nome,telefone,rua,numero,complemento,bairro,cep,cidade,estado")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(funcionario);
        }

        // GET: /Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: /Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idFuncionario,matriculaFuncionario,cargo,dataAdmimissao,registroProssional,salario,cpf,rg,sexo,dataNascimento,usuario,senha,permissao,nome,telefone,rua,numero,complemento,bairro,cep,cidade,estado")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: /Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: /Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
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
