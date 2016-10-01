using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Campanha
    {
        [Key]
        public int idCampanha { get; set; }

        [DisplayName("Nome da Uct")]
        public int idUct { get; set; }
        [DisplayName("Nome da Campanha")]
        [MaxLength(100), MinLength(1)]
        public string nomeCampanha { get; set; }
        [DisplayName("Data de inicio da Campanha")]
        public DateTime dataCampanhaInicio { get; set; }
        [DisplayName("Data de final da Campanha")]
        public DateTime dataCampanhaFinal { get; set; }
        [DisplayName("Tipo da Campanha")]
        [MaxLength(40), MinLength(1)]
        public string tipoCampanha { get; set; }
       
        public virtual Uct uct { get; set; }
    }
}