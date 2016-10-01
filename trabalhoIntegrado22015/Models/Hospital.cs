using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace trabalhoIntegrado22015.Models
{
    public class Hospital:PessoaJuridica
    {
        [Key]
        public int idHospital { get; set; }


        [DisplayName("Descrição do Hospital")]
        [MaxLength(40), MinLength(1)]
        public string descricaoHospital { get; set; }

        public virtual ICollection<Transferencia> Transferencias { get; set; }
    }
}