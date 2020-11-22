$(document).ready(function () {
    $(".DarshanDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
    });

    ResetForm();

    $("#Save").click(function (e) {

        var radioValue = $("input[name='Accont-head-type']:checked").val();
        if (radioValue) {
            alert("Your are a - " + radioValue);
        }

        SaveFixedDeposit();
    });

    $("#reset").click(function (e) {
        ResetForm();
    });
});

function SaveFixedDeposit() {
    ResetForm();
}

function ResetForm() {
    $(".DarshanDate").datepicker().datepicker("setDate", new Date());
    $('#AccountName').val('');
    $('#RateOfInterest').val('');
    $('#Amount').val('');
    $('#MaturityAmount').val('');
}