using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabalhoIntegrado22015.Models
{
    public class Sangue
    {
        [Key]
        public int idSangue { get; set; }
        public string tipoDeSangue { get; set; }
    }
}