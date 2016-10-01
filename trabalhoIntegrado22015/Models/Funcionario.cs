using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Funcionario:PessoaFisica
    {
        [Key]
        public int idFuncionario { get; set; }

        [DisplayName("Matrícula")]
        
        public int matriculaFuncionario { get; set; }
        [DisplayName("Cargo")]
        [MaxLength(40), MinLength(1)]
        public string cargo { get; set; }
        [DisplayName("Data de admissão")]
        public DateTime dataAdmimissao { get; set; }
        [DisplayName("Regsitro Profissional")]
        [MaxLength(40), MinLength(1)]
        public string registroProssional { get; set; }
        [DisplayName("Salário")]
        public double salario { get; set; }

        [DisplayName("Usuário")]
        [MaxLength(40), MinLength(4)]
        public string usuario { get; set; }
        [DisplayName("Senha")]
        [MaxLength(40), MinLength(4)]
        public string senha { get; set; }
        [DisplayName("Permissão")]
        [MaxLength(40), MinLength(4)]
        public string permissao { get; set; }

    }
}