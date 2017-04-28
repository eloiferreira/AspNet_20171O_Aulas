using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class Categoria
    {
       
        public int CategoriaID { get; set; }

        [Required]
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

    }
}