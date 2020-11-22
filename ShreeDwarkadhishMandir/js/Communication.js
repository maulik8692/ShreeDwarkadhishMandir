$(document).ready(function () {
    hideProgress();
    $("#reset").click(function (e) {
        $('#EmailContent').val('')
    });

    $("#Save").click(function (e) {
        SaveForm();
    });
});

function SaveForm() {
    showProgress();
    var communicationRequest = {
        EmailContent: CKEDITOR.instances['EmailContent'].getData(),
        EmailSubject: $('#EmailSubject').val()
    };

    $.ajax({
        url: "/Communication/Communication",
        data: JSON.stringify(communicationRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Email will be sent sortly.");
            hideProgress();

            window.location.href = '/Home/Index';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            alert(customErrorMessage);
            $('#EmailContent').focus();
            hideProgress();
        },
    });
}