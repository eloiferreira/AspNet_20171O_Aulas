using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploDataAnotattion.Models
{
    public class Questao
    {
        public int QuestaoId { get; set; }
        public int ClienteId { get; set; }
        public string Descricao { get; set; }
        public string Complemento { get; set; }
        public int OrdemIndice { get; set; }
        public double Peso { get; set; }

        public virtual Cliente _Cliente { get; set; }


    

    }
}