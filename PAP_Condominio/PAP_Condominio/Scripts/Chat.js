/// <reference path="jquery-1.7.1.min.js" />
/// <reference path="jquery.signalR-1.0.0.js" />
//Após isso, podemos criar um arquivo chamado chat.js ou até mesmo definir os métodos js no próprio html.
//Como eu criei o Chat.js, vou referenciar o script do jquery e do plugin jquery do SignalR. A primeira 
//coisa a se fazer é criar uma função jQuery e criar um objeto chamado hub, com o nome da minha classe em C#. 
//por convenção iniciando em minúsculo:

$(function () {
    var chat = $.connection.chatHub;

//O passo seguinte será definir a implementação daquela função que chamamos dinamicamente no C# ( publicarMensagem )

    chat.client.publicarMensagem = function (nome, mensagem) {
        var containerNome = $('<span/>').text(nome).html();
        var containerMensagem = $('<div/>').text(mensagem).html();

        $("#conversa").append(
            '<li><strong>'
                + containerNome +
                '</strong>: '
                + containerMensagem + '</li>');
    };
//A ultima parte que precisaremos implementar nesse js será o método que inicializa a conexão com o hub, e,
//quando essa conexão estiver estabelecida, vamos definir o método que enviará a mensagem para o server, método
//o qual fará o broadcast para todos os clients.

    $.connection.hub.start().done(function () {
        $("#enviar").click(function () {
            var nome = $("#nome").val();
            var mensagem = $("#mensagem").val();

            chat.server.enviarMensagem(nome, mensagem);

            $("#mensagem").val('');
        });
    });
});