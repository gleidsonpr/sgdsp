using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Doador:PessoaFisica
    {
        [Key]
        public int idDoador { get; set; }
               
        [DisplayName("Tipo de doador")]
        [MaxLength(30), MinLength(1)]
        public string tipoDoador { get; set; }
        public int idSangue { get; set; }
        public virtual Sangue TipoDoSangue { get; set; }
        public virtual ICollection<BolsaSangue> BolsasDeSangue { get; set; }
              

        
        
    }
}