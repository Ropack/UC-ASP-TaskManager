// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/issuesHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("UpdateIssues", function (count, issues) {
    var json = JSON.parse(issues);
    $("#issuesList").empty();
    json.forEach(function(obj, i) {
        var li = document.createElement("li");
        li.innerHTML = obj.createdDate + ' - ' + obj.userName + ' - ' + '<button data-toggle="collapse" data-target="#collapse-' +
            i +
            '">Show description</button>\r\n\r\n<div id="collapse-' +
            i +
            '" class="collapse">' +
            obj.description +
            '</div>';
        $("#issuesList").append(li);
    });
    $("#issuesCount").text(count);
});

connection.start().then(function(){
    connection.invoke("GetIssues").catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});