$(document).ready(function () {
    $(".DarshanDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
        setDate: new Date()
    });

    ResetForm();

    $("#Save").click(function (e) {
        SaveAccountHead();
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Mandir").change(function () {
        GetAccountHeadDropdown(0, '');
    });

    $("#CreditAccount").change(function () {

    
    });
});


function SaveAccountHead() {
    showProgress();
    var mandirVoucherRequest = {
        Id: 0,
        AccountId: parseInt($("#VoucherAccount option:selected").val()),
        VoucherNo: $('#VoucherNo').val(),
        VoucherDate: $('#VoucherDate').val(),
        Description: ($('#Description').val() !== '' ? ("Voucher No :" + $('#VoucherNo').val() + " => ") : "") + $('#Description').val(),
        VoucherAmount: $('#VoucherAmount').val() !== '' ? parseFloat($('#VoucherAmount').val().substr(2).replace(/,/g, '')) : 0
    };

    $.ajax({
        type: "POST",
        url: "/MandirVoucher/CreateMandirVoucher/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(mandirVoucherRequest),
        success: function (result) {
            ResetForm();
            if (!confirm('Transaction has been saved successfully. Do you want to add one more transaction?')) {
                window.location.href = '/MandirVoucher/CreateMandirVoucher';
            }

            hideProgress();
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
                if (customErrorMessage === "Mandir is require.") {
                    $('#Mandir').focus();
                }
                else if (customErrorMessage === "Credit Account is require.") {
                    $('#CreditAccount').focus();
                }
                else if (customErrorMessage === "Debit Account is require.") {
                    $('#DebitAccount').focus();
                }
                else if (customErrorMessage === "Transaction Date is require.") {
                    $('#TransactionDate').focus();
                }
                else if (customErrorMessage === "Transaction Amount is require.") {
                    $('#TransactionAmount').focus();
                }
            }

            hideProgress();
        },
    });
}

function GetAccountHeadDropdown(accountId, NatureOfGroup) {
    var accountDropdownRequest = {
        AccountId: accountId,
        NatureOfGroup: NatureOfGroup,
        MandirId: parseInt($("#Mandir option:selected").val())
    }
    $.ajax({
        type: "POST",
        url: "/AccountHead/AccountHeadDropdown/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(accountDropdownRequest),
        success: function (jsondata) {
            if (accountId === 0) {
                AccountHeads = jsondata;
                $("#VoucherAccount").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select Credit Account'
                }).appendTo("#VoucherAccount");

                $(jsondata).each(function () {

                    $("<option />", {
                        val: this.Id,
                        text: this.AccountName
                    }).appendTo("#VoucherAccount");
                });
            }
            else {
                $("#DebitAccount").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select Debit Account'
                }).appendTo("#DebitAccount");

                $(jsondata).each(function () {

                    $("<option />", {
                        val: this.Id,
                        text: this.AccountName
                    }).appendTo("#DebitAccount");
                });
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetMandirList() {
    $.ajax({
        url: "/Mandir/MandirList",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Mandir").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Mandir'
            }).appendTo("#Mandir");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Mandir");
            });

            $("#Mandir").val($("#Mandir option:eq(1)").val());
            GetAccountHeadDropdown(0, '');
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            hideProgress();
        }
    });
}

function ResetForm() {
    $('.DarshanDate').datepicker('setDate', new Date());

    $("#Mandir").empty();
    $("#VoucherAccount").empty();
    $('#VoucherDate').val('');
    $('#VoucherNo').val('');
    $('#VoucherAmount').val('');
    $('#Description').val('');
    GetMandirList();
}