using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PAP_Condominio.Models
{
    public class Morador
    {
        public int MoradorId { get; set; }

        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string NomeSobrenome { get; set; }

        [Required(ErrorMessage = "Cpf obrigatório")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[2-9]\d{1}-\d{4}-\d{4}$", ErrorMessage = "Você deve digitar um telefone no formato ##-####-####")]
        public string Telefone { get; set; }


        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required]
        public string Apartamento { get; set; }

        //UM PARA MUITOS - Um condominio tem muitos moradores
        public int CondominioId { get; set; }
        public virtual Condominio _CondominioId { get; set; }

        


    }
}