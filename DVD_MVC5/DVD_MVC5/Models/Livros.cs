using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVD_MVC5.Models
{
    public class Livros
    {
        //Colocar a anotacao [key] para poder colocar IdLivro ou pode deixar so ID
        [Key]
        public int IDLivro { get; set; }
        
        public string Titulo { get; set; }

        [Required(ErrorMessage ="Atributo requerido")]
        [StringLength(100, ErrorMessage ="O tamanho máximo é {1}",MinimumLength =6)]
        public string Autor { get; set; }

        [Required(ErrorMessage ="Digite o autor do livro")]
        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public bool Disponivel { get; set; }
    }
}