using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploDataAnotattion.Models
{
    public class Alternativa
    {
        public int AlternativeId { get; set; }
        public string Descricao { get; set; }
        public int OrdemIndice { get; set; }
        public double Peso { get; set; }
    }
}