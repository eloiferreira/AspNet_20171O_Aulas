using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Util;

namespace PAP_Condominio.Models
{
    public class MuralDigital
    {
       

        public int MuralDigitalId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTimeOffset Data { get; set; }

        public Class1.Tipo Tipo  { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        public int MoradorId { get; set; }

        public virtual  Morador _Morador { get; set; }


    }
}