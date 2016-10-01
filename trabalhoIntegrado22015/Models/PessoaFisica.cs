using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class PessoaFisica:Pessoa
    {
        [DisplayName("CPF")]
        [MaxLength(15), MinLength(1)]
        public string cpf { get; set; }
        [DisplayName("RG")]
        [MaxLength(15), MinLength(1)]
        public string rg { get; set; }
        [DisplayName("Sexo")]
        [MaxLength(15), MinLength(1)]
        public string sexo { get; set; }
        [DisplayName("Data de nascimento")]
        public DateTime dataNascimento { get; set; }

       
    }
}