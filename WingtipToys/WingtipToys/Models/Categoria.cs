using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class Categoria
    {

        public int CategoriaID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name ="Descricao"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
    }
}