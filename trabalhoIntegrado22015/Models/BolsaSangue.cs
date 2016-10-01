using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class BolsaSangue
    {
        [Key]
        public int idBolsaSangue { get; set; }


        [DisplayName("Nome da UCT")]
        public int idUct { get; set; }

        [DisplayName("Descrição do procedimento")]
        public int idProcedimento { get; set; }

        [DisplayName("Nome do doador")]
        public int idDoador { get; set; }

        [DisplayName("Código de barras")]
        [MaxLength(40), MinLength(1)]
        public string codBarrasBolsa { get; set; }
       

        [DisplayName("Data da coleta")]
        public DateTime dataColeta { get; set; }

        public bool transferida { get; set; }
        public virtual Uct Uct { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public virtual Doador Doador { get; set; }



        public virtual ICollection<ExameDaBolsa> ExamesFeitos { get; set; }

       public virtual ICollection<Transferencia> Transferencias { get; set; }
    }
}