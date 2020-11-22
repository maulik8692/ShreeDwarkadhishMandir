var BhandarDetail = {};

$(document).ready(function () {
    hideProgress();
    ResetForm();

    $("#Mandir").change(function () {
        //GetAccountHeadForBhet($('#Mandir').val());
    });
    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });

    $('input[type=radio][name=TransactionType]').change(function () {
        if (this.value == 'Credit') {
            $('.DebitTransaction').hide();
            $('.CreditTransaction').show();
        }
        else if (this.value == 'Debit') {
            $('.DebitTransaction').show();
            $('.CreditTransaction').hide();
        }
    });
});

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
            GetAccountHeadDropdown();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function SaveForm() {
    var bhandarTransactionRequest = {
    }

    bhandarTransactionRequest.BhandarId = $('#Id').val();
    if ($('input[name=TransactionType]:checked').val() == 'Credit') {
        bhandarTransactionRequest.Credit = parseFloat($('#TransactionAmount').val());
        bhandarTransactionRequest.Debit = 0;
    }
    else if ($('input[name=TransactionType]:checked').val() == 'Debit') {
        bhandarTransactionRequest.Credit = 0;
        bhandarTransactionRequest.Debit = parseFloat($('#TransactionAmount').val());
    }

    bhandarTransactionRequest.SupplierId = $('#Supplier').val();
    bhandarTransactionRequest.PaymentAccountHead = $('#PaymentAccountHead').val();
    bhandarTransactionRequest.PurchasingPrice = $('#PurchaseAmount').val() !== '' ? parseFloat($('#PurchaseAmount').val().substr(2).replace(/,/g, '')) : 0;
    bhandarTransactionRequest.Notes = $('#DebitTransactionNote').val();

    $.ajax({
        url: "/BhandarTransaction/AdjustBhandar",
        data: JSON.stringify(bhandarTransactionRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert('Bhandar adjustment has been successfully.');
            window.location.href = '/Bhandar/Bhandar';0
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
           
            if (customErrorMessage === 'Either credit amount or debit amount is require.') {
                if (parseFloat($('#TransactionAmount').val()) > 0) {
                    alert('Please select Transaction Type.')
                }
                else {
                    $('#TransactionAmount').focus();
                }
               
            }
            else if (customErrorMessage === 'Please select supplier.') {
                alert(customErrorMessage);
                $('#Supplier').focus();
            } else if (customErrorMessage === 'Please select supplier.') {
                alert(customErrorMessage);
                $('#Supplier').focus();
            } else if (customErrorMessage === 'Please enter Purchasing amount.') {
                alert(customErrorMessage);
                $('#PurchaseAmount').focus();
            } else if (customErrorMessage === 'Please provide some notes for debit bhandar.') {
                alert(customErrorMessage);
                $('#DebitTransactionNote').focus();
            }
            else {
                alert(customErrorMessage);
            }

            hideProgress();
        },
    });
}

function ResetForm() {
    $('input[name="TransactionType"]').prop('checked', false);
                                                                   
    $('.DebitTransaction').hide();
    $('.CreditTransaction').hide();
    $('#TransactionAmount').val('');
    $('#PurchaseAmount').val('');

    GetDetail();
}

function GetDetail() {

    var Id = getUrlParameter('Id');

    $('#Id').val(Id);

    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        showProgress();
        var Bhandar = {
            Id: $('#Id').val()
        };

        $.ajax({
            url: "/Bhandar/BhandarDetail",
            data: JSON.stringify(Bhandar),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                BhandarDetail = jsondata;
                setdetail();
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                alert(customErrorMessage);
                hideProgress();
            },
        });
    }
    else {
        GetMandirList();
        hideProgress();
    }
}

function setdetail() {
    $('#BhandarName').val(BhandarDetail.Name);
    $('#Balance').val(parseFloat(BhandarDetail.Balance).toFixed(5));
    $('#IsActive').prop('checked', BhandarDetail.IsActive);
    GetMandirList();

    $('.bhandar').inputmask("numeric", {
        radixPoint: ".",
        groupSeparator: "",
        digits: 5,
        autoGroup: true,
        suffix: ' ' + BhandarDetail.UnitAbbreviation, //Space after $, this will not truncate the first character.
        rightAlign: false//,
        //oncleared: function () { self.Value(''); }
    });

}

function GetAccountHeadDropdown() {
    var accountDropdownRequest = {
        AccountId: 0,
        MandirId: parseInt($("#Mandir option:selected").val())
    }
    $.ajax({
        type: "POST",
        url: "/AccountHead/AccountHeadDropdown/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(accountDropdownRequest),
        success: function (jsondata) {
         
                $("#PaymentAccountHead").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select Payment from account'
                }).appendTo("#PaymentAccountHead");

                $(jsondata).each(function () {

                    $("<option />", {
                        val: this.Id,
                        text: this.AccountName
                    }).appendTo("#PaymentAccountHead");
            });

            GetSuppliersForDropdown();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetSuppliersForDropdown() {
   
    $.ajax({
        type: "POST",
        url: "/Supplier/GetSuppliersForDropdown/",
        contentType: "application/json",
        dataType: "json",
        success: function (jsondata) {

            $("#Supplier").empty();

            $("<option />", {
                val: 0,
                text: 'Please select Purchase from'
            }).appendTo("#Supplier");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.SupplierName
                }).appendTo("#Supplier");
            });
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            hideProgress();
        }
    });
}