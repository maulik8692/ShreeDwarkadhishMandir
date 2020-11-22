$(document).ready(function () {

    $("#doLogin").click(function (e) {

        e.preventDefault();
        DoLogin();
    });

    $('.login').keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            DoLogin();
        }
    });
    hideProgress();
});

function DoLogin() {
    showProgress();
    var loginRequest = {
        UserName: $('#Username').val(),
        Password: $('#password').val()
    };

    $.ajax({
        type: "POST",
        url: "/Login/DoLogin/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(loginRequest),
        success: function (result) {
            window.location.href = '/Home/Index';
            hideProgress();
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
                if (customErrorMessage.indexOf("User Name") >= 0) {
                    $('#Username').focus();
                }
                else if (customErrorMessage.indexOf("Password") >= 0) {
                    $('#password').focus();
                }

                hideProgress();
            }
        },
    });
}