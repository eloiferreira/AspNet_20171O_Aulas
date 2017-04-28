using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Class1
    {
       
        public enum Tipo
        {

           
            Aluguel,
            
            Venda,

            [Description("Solicitação ")]
            Solicitacao,

            [Description("Indicação")]
            Indicacao


        }

    }
}
