//import { url } from "inspector";

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Bind the submit_button click event to Login action
$('#submit_button').bind("click", Login);
var game = new object();
function Login() {
    var username = $('#username_input').val();

    var call = $.ajax({
        type: "POST",
        url: '/Home/Login',
        data: JSON.stringify(username),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            window.location = "/Game";
            game = response;
          

        },
        error: function () {

            alert("Error");

        }

    });

}  


function LoadGame() {

    var x = $("#button").length;
    for (var user in game.users) {

        $("#users_list").append('<li>'+(game.users[user].name)+'</li>');

    }

}