using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class ExameDaBolsa
    {
        [Key]
        public int idExameDaBolsa { get; set; }     

        [DisplayName("Observações")]
        public string observacao { get; set; }


        [DisplayName("Código da bolsa")]
        public int idBolsaSangue { get; set; }
        [DisplayName("Laboratório")]
        public int idLaboratorio { get; set; }
        [DisplayName("Exame")]
        public int idExame { get; set; }

        public virtual Exame ExameFeito { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
        public virtual BolsaSangue Bolsa { get; set; }


    }
}