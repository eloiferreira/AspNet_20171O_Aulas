using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploDataAnotattion.Models
{
    public class QuestaoAlternativas
    {
        public int QuestaoAlternativasId { get; set; }
        public int QuestaoId { get; set; }
        public int AlternativaId { get; set; }

        public virtual Questao _Questao { get; set; }
        public virtual ICollection<Alternativa> _Alternativa { get; set; }
    }
}