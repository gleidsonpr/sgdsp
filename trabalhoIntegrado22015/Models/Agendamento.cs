using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Agendamento
    {
        [Key]
        public int idAgendamento { get; set; }

        [DisplayName("Observações")]
        [MaxLength(50), MinLength(0)]
        public string observacao { get; set; }

        [DisplayName("Data disponivel")]
        public DateTime dataAgendada { get; set; }

        [DisplayName("Doador")]
        public int idDoador { get; set; }

        [DisplayName("Unidades")]
        public int idUct { get; set; }

      

      
        public virtual Uct Uct { get; set; }

       
        public virtual Doador Doador { get; set; }
    }
}