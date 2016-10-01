using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Uct:PessoaJuridica
    {
        [Key]
        public int idUct { get; set; }

       
        [DisplayName("Descrição da UCT")]
        [MaxLength(70), MinLength(1)]
        public string descricaoUct { get; set; }


        //public List<Transferencia> transferencias { get; set; }
        public List<Campanha> Campanhas { get; set; }
        public List<BolsaSangue> Bolsas { get; set; }
        public List<Agendamento> Agendamentos { get; set; }

       
    }
}