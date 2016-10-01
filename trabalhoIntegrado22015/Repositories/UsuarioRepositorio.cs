using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using trabalhoIntegrado22015.Models;

namespace trabalhoIntegrado22015.Repositories
{
    public class UsuarioRepositorio
    {
       
        [HttpPost]
        public static bool AutenticarFuncionario(string Usuario,string Senha)
        {
             ApplicationDbContext db=new ApplicationDbContext();

             var Query = (from f in db.Funcionarios
                          where f.usuario == Usuario &&
                          f.senha == Senha
                          select f).SingleOrDefault();

            if(Query==null)
            { return false; }
           
            FormsAuthentication.SetAuthCookie(Query.nome, false);

            return true;
        }

        public static Funcionario GetFfuncionarioLogado()
        {
            string _Login = HttpContext.Current.User.Identity.Name;
            if(_Login=="")
            {
                return null;
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                Funcionario user = (from f in db.Funcionarios
                                    where f.usuario == _Login
                                    select f).SingleOrDefault();

               return user;
            }
        }
        public static void Deslogar()
        {
            FormsAuthentication.SignOut();
        }
    }
}
