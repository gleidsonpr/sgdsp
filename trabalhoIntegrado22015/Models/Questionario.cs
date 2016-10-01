using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Questionario
    {
        [Key]
        public int idQuestionario { get; set; }


        [DisplayName("Nome do doador")]

        public int idDoador { get; set; }
        [DisplayName("Fuma?")]
       
        public bool fuma { get; set; }
        [DisplayName("Quantos por dia?")]
        
        public int qntCigarros { get; set; }
        [DisplayName("Bebe?")]
       
        public bool bebe { get; set; }
        [DisplayName("Quantas vezes por semana?")]

        public int qntBebidasSemana { get; set; }
        [DisplayName("Possui tatuagem?")]
        
        public bool possuiTatuagem { get; set; }
        [DisplayName("Quanto tempo?")]

        public int qntTempoTatuagem { get; set; }
        [DisplayName("Utiliza alguma droga ilicita?")]
       
        public bool utilizaDrogaIlicita { get; set; }
        [DisplayName("Informe quais?")]

        public string descricaoDrogras { get; set; }
        [DisplayName("Possui historico de doenças?")]
       
        public bool historicoDeDoenca { get; set; }
        [DisplayName("Informe quais?")]

        public string descricaoDoencas { get; set; }
        [DisplayName("Possui hepatite?")]
       
        public bool hepatite { get; set; }
        [DisplayName("Está de jejum")]
      
        public bool jejum { get; set; }


        [DisplayName("Data do questionario")]
        public DateTime dataQuestionario { get; set; }

        public virtual Doador Doador { get; set; }
    }
}