namespace trabalhoIntegrado22015.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using trabalhoIntegrado22015.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<trabalhoIntegrado22015.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(trabalhoIntegrado22015.Models.ApplicationDbContext context)
        {




            var procedimentos = new List<Procedimento>
            {
                new Procedimento { descricaoProcedimento="Doacao exporadica"},
                new Procedimento { descricaoProcedimento="Doacao programada"},
                new Procedimento { descricaoProcedimento="Doacao voluntaria"}
                
            };

        


            var exames = new List<Exame>
        {

            new Exame{nomeExame="Exame-1",departamento="Departamento-1",metodoExame="Metodo-1",observacao="Observação-1"},
            new Exame{nomeExame="Exame-2",departamento="Departamento-2",metodoExame="Metodo-2",observacao="Observação-2"},
            new Exame{nomeExame="Exame-3",departamento="Departamento-3",metodoExame="Metodo-3",observacao="Observação-3"},
            new Exame{nomeExame="Exame-4",departamento="Departamento-4",metodoExame="Metodo-4",observacao="Observação-4"},
            new Exame{nomeExame="Exame-5",departamento="Departamento-5",metodoExame="Metodo-5",observacao="Observação-5"}
        };
            exames.ForEach(s => context.Exames.AddOrUpdate(p => p.idExame, s));

            var tiposSangue = new List<Sangue>
            {

                new Sangue {tipoDeSangue="A+" },
                new Sangue {tipoDeSangue="A-" },
                new Sangue {tipoDeSangue="B+" },
                new Sangue {tipoDeSangue="B-" },
                new Sangue {tipoDeSangue="AB+" },
                new Sangue {tipoDeSangue="AB-" },
                new Sangue {tipoDeSangue="O+" },
                new Sangue {tipoDeSangue="O-" }
            };
            tiposSangue.ForEach(s => context.Sangues.AddOrUpdate(p => p.idSangue, s));







        }
    }
}
