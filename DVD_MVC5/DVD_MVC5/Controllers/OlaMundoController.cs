using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVD_MVC5.Controllers
{
    //selecionando o Controller + F12 abre todos os possiveis metodos
    public class OlaMundoController : Controller
    {
        // GET: OlaMundo
        //todo controller nao necessariamento retorna uma view
        public string Index()
        {
            return "Ola MVC 5 gratidao";
        }

        // GET: OlaMundo
        public string QueridoController()
        {
            return "Texto <b>em negrito </b>, retorno do controller";

        }
    }
}