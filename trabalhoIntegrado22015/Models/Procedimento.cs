using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Procedimento
    {
        [Key]
        public int idProcedimento { get; set; }
        [DisplayName("Descrição do Procedimento")]
        [MaxLength(40), MinLength(1)]
        public string descricaoProcedimento { get; set; }
        public List<BolsaSangue> BolsasDesangue { get; set; }
        //falta-idpessoa
    }
}