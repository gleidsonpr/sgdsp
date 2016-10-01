using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Transferencia
    {
        [Key]
        public int idTransferencia { get; set; }


        [DisplayName("Hospital de destino")]

        public int idHospital { get; set; }
        [DisplayName("Bolsa de sangue")]
        public int idBolsaSangue { get; set; }

        [DisplayName("Data da transferencia")]
        public DateTime dataTransferencia { get; set; }

        [DisplayName("Obrservações")]
        [MaxLength(40), MinLength(1)]
        public string observacoes { get; set; }


        public virtual BolsaSangue Bolsa { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}