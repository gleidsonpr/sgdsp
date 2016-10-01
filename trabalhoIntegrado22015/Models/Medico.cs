using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Medico:PessoaFisica
    {
        [Key]
        public int idMedico { get; set; }
        [DisplayName("CRM")]
        [MaxLength(15), MinLength(1)]
        public string crm { get; set; }
       
    }
}