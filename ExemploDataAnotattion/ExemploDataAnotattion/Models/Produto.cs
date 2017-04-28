using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ExemploDataAnotattion.Models
{
    public class Produto
    {
       
        public int ProdutoId { get; set; }
        public int Nome { get; set; }
        public string Descricao { get; set; }

        
    }
}