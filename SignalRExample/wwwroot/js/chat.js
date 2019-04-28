"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    if (user == $("#userInput").val()) {
        var mesaj = `<div class="d-flex justify-content-end">
                <div class="alert alert-info" role="alert">
                    `+ msg + ` <b>@` + user + `</b>
                      </div>
                 </div>`;
    $("#messageList").append(mesaj);
    } else {
            var mesaj = `<div class="d-flex">
                <div class="alert alert-dark" role="alert">
                    `+ user + ` <b>@` + msg + `</b>
                      </div>
                 </div>`;
    $("#messageList").append(mesaj);
    }
    $(".card-body").scrollTop($('.card-body')[0].scrollHeight - $('.card-body')[0].clientHeight);
});

connection.start().then(function(){
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    $("#messageInput").val('');
    event.preventDefault();
});

document.getElementById("loginButton").addEventListener("click", function (event) {
       var kadi = $("#userInput").val();
        if (kadi != "") {
            $("#girisEkrani").hide();
            $("#chatEkrani").show();
            $(".card-body").scrollTop($('.card-body')[0].scrollHeight - $('.card-body')[0].clientHeight);
        } else {
            alert("Kullanıcı adını boş bırakmayınız!");
        }
    event.preventDefault();
});