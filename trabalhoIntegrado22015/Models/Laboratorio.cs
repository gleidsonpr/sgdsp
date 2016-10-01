using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Laboratorio:PessoaJuridica
    {
        [Key]
        public int idLaboratorio { get; set; }
        [DisplayName("Descrição do laboratório")]
        [MaxLength(40), MinLength(1)]
        public string descricaoLaboratorio { get; set; }

        public virtual ICollection<ExameDoLaboratorio> ExameLaboratorios { get; set; }

    }
}