using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class PreAgendamento
    {
        [Key]
        public int idPreAgendamento { get; set; }
        [DisplayName("Tipo sanguineo")]
        [MaxLength(10), MinLength(1)]
        public string tipoSangue { get; set; }
        [DisplayName("Nome")]
        [MaxLength(100), MinLength(1)]
        public string nome { get; set; }
        [DisplayName("Telefone")]
        [MaxLength(20), MinLength(1)]
        public string telefone { get; set; }
        [DisplayName("Observações")]
        [MaxLength(100), MinLength(1)]
        public string observacao { get; set; }
        [DisplayName("Data de preferencia")]
        public DateTime dataDePreferencia { get; set; }

        public bool jaAgendado { get; set; }
    }
}