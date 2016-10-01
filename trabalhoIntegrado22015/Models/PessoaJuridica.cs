using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class PessoaJuridica:Pessoa
    {

        [DisplayName("CNPJ")]
        [MaxLength(20), MinLength(1)]
        public string cnpj { get; set; }
        [DisplayName("Data de fundação")]
        public DateTime dataFundacao { get; set; }
    }
}