using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Pessoa
    {
       
        [DisplayName("Nome")]
        [MaxLength(100), MinLength(1)]
        public string nome { get; set; }
        [DisplayName("Telefone")]
        public string telefone { get; set; }
        //endereço
        [DisplayName("Rua")]
        [MaxLength(100), MinLength(1)]
        public string rua { get; set; }
        [DisplayName("Número")]
        [MaxLength(10), MinLength(1)]
        public string numero { get; set; }
        [DisplayName("Complemento")]
        [MaxLength(20), MinLength(1)]
        public string complemento { get; set; }
        [DisplayName("Bairro")]
        [MaxLength(40), MinLength(1)]
        public string bairro { get; set; }
        [DisplayName("CEP")]
        [MaxLength(15), MinLength(1)]
        public string cep { get; set; }
        [DisplayName("Cidade")]
        [MaxLength(40), MinLength(1)]
        public string cidade { get; set; }
        [DisplayName("Estado")]
        [MaxLength(40), MinLength(1)]
        public string estado { get; set; }



       
        //fim endereco

        //VEREIFICAR ABAIXO
        
    }
}