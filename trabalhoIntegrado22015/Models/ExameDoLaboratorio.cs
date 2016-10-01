using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class ExameDoLaboratorio
    {
        [Key]
        public int idExameDoLaboratorio { get; set; }
        public int idExame { get; set; }
        public int idLaboratorio { get; set; }
        public virtual Exame Exame { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
    }
}