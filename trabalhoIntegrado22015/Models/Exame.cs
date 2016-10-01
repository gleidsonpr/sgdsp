using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Exame
    {
        [Key]
        public int idExame { get; set; }
        [DisplayName("Nome do exame")]
        [MaxLength(40), MinLength(1)]
        public string nomeExame { get; set; }
        [DisplayName("Departamento")]
        [MaxLength(40), MinLength(1)]
        public string departamento { get; set; }
        [DisplayName("Método do exame")]
        [MaxLength(40), MinLength(1)]
        public string metodoExame { get; set; }

        [DisplayName("Observações")]
        [MaxLength(40), MinLength(1)]
        public string observacao { get; set; }
        public virtual ICollection<ExameDoLaboratorio> ExameLaboratorios { get; set; }
        public virtual ICollection<ExameDaBolsa> ExameDaBolsas { get; set; }

    }
}