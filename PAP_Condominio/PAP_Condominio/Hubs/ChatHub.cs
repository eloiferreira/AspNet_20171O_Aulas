using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PAP_Condominio.Hubs
{
    public class ChatHub : Hub
    {
        //public void EnviarMensagem(string nome, string mensagem)
        //{
        //    Clients.All.publicarMensagem(nome, mensagem);
        //}
       
        public void SendMessage(string remetente, string destinatario, string message)
        {
            Clients.All.messageAdded(remetente, destinatario, message);
        }
       

    }
}