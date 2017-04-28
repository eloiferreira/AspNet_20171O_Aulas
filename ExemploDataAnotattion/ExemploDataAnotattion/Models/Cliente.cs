using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExemploDataAnotattion.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }


        
    }
}