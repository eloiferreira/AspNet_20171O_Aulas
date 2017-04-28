using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAP_Condominio.Models
{
    public class Condominio
    {


        public int CondominioId { get; set; }

        [Required]
        [DisplayName("Condomínio")]
        public string Nome { get; set; }

        public int CEP { get; set; }
        [Required]
        [DisplayName ("Endereço")]
        public string Endereco { get; set; }
        
        [Required]
        [DisplayName("Número")]
        public int Numero { get; set; }

        
    }
}