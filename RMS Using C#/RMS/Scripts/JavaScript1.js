/// <reference path="jquery-2.2.3.js" />

$(document).ready(function () {

    var username = $('#txtUsername');
    var password = $('#txtPassword');
    var login = $('#btnLogin');
    var getPassword = $('#btnGetPassword');

    login.click(function () {
        if (username.val() == '') {
            alert('Please Enter Username...');
            return false;
        }
        else if (password.val() == '') {
            alert('Please Enter Password...');
            return false;
        }
        return true;
    });

    getPassword.click(function () {
        if (username.val() == '') {
            alert('Please Enter Username...');
            return false;
        }
        return true;
    });

});

