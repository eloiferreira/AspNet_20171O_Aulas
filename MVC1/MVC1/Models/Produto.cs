using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class Produto
    {
        
        public int ProdutoID { get; set; }

        [Required]
        //dataAnotation 
       // [StringLength(20), RegularExpression(@"^\d{2}.\d{3}-\{3}", ErrorMessage ="Formato do cep errado")]
        public string Nome { get; set; }

        [Display(Name = "Descrição"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        [Display(Name="Categoria")]
        public virtual Categoria _Categoria { get; set; }

    }
}