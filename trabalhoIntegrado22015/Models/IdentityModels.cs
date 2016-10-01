using Microsoft.AspNet.Identity.EntityFramework;

namespace trabalhoIntegrado22015.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Uct> Ucts { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.BolsaSangue> BolsaSangues { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Procedimento> Procedimentoes { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Doador> Doadors { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Laboratorio> Laboratorios { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Exame> Exames { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Campanha> Campanhas { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Agendamento> Agendamentoes { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.ExameDoLaboratorio> ExameDoLaboratorios { get; set; }
        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.PreAgendamento> PreAgendamentos { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Transferencia> Transferencias { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Questionario> Questionarios { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Medico> Medicos { get; set; }


        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.Sangue> Sangues { get; set; }

        public System.Data.Entity.DbSet<trabalhoIntegrado22015.Models.ExameDaBolsa> ExameDaBolsas { get; set; }
    }
}