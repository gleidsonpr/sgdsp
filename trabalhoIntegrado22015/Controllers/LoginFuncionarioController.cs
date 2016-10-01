using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trabalhoIntegrado22015.Models;
using trabalhoIntegrado22015.Repositories;

namespace trabalhoIntegrado22015.Controllers
{
    public class LoginFuncionarioController:Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Login()
        {
           

            return View();

        }
     
        [Authorize]
        public ActionResult Painel()
        {


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include="Login,Senha")] FuncionarioLogin funcionario)
        {

            if(UsuarioRepositorio.AutenticarFuncionario(funcionario.Login,funcionario.Senha)==false)
            {
                ViewBag.msg_Error = "Usuario ou senha errado";//ajustar nao funciona ainda
                
                return View(funcionario);
            }
            
            return RedirectToAction("Painel");

        }

        [Authorize]
        public ActionResult Sair()
        {

            UsuarioRepositorio.Deslogar();
            return RedirectToAction("Index", "Home");

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