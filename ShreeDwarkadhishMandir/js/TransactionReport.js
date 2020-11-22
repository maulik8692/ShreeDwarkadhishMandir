$(document).ready(function () {

    $("#Mandir").change(function () {
        GetAccountHeadForBhet($('#Mandir').val());
    });

   $(".TransactionDate").datepicker({
        dateFormat: "dd-M-yy",
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        buttonText: "Select date",
        onClose: function (dateText, inst) {
            function isDonePressed() {
                return ($('#ui-datepicker-div').html().indexOf('ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all ui-state-hover') > -1);
            }

            //if (isDonePressed()) {
            //    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            //    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            //    if (inst.id === 'TransactionFromDate') {
            //        $(this).datepicker('setDate', new Date(year, month, 1)).trigger('change');
            //    }
            //    else if (inst.id === 'TransactionToDate') {
            //        month = parseInt(month) + 1;
            //        $(this).datepicker('setDate', new Date(year, month, 0)).trigger('change');
            //    }

            //    $('.TransactionDate').focusout()//Added to remove focus from datepicker input box on selecting date
            //}
        },
        beforeShow: function customRange(input) {
            if (input.id === 'TransactionFromDate') {
                var abc = $('#TransactionToDate').datepicker("getDate");
                return {
                    maxDate: abc == null ? "+10M" : $('#TransactionToDate').datepicker("getDate"),
                };
            } else if (input.id === 'TransactionToDate') {
                return {
                    minDate: $('#TransactionFromDate').datepicker("getDate"),
                    //maxDate: new Date()
                };
            }
        }
    });

    $("#Search").click(function (e) {
        if (isValidDate($('#TransactionFromDate').val()) === true && isValidDate($('#TransactionToDate').val()) === false) {
            alert('Please select valid Transaction To Date');
            $('#TransactionToDate').focus()
        }
        else if (isValidDate($('#TransactionToDate').val()) === true && isValidDate($('#TransactionFromDate').val()) === false) {
            alert('Please select valid Transaction From Date');
            $('#TransactionFromDate').focus()
        }
        else {
            $.redirect('/Report/AccountTransactionReport', {
                'FromDate': $('#TransactionFromDate').val(),
                'ToDate': $('#TransactionToDate').val(),
                'AccountId': $('#TransactionAccount').val(),
                'CreatedBy': 0,
                'MandirId': $('#Mandir').val()
            }, 'POST', '_Blank');
        }
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    ResetForm();
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
        }
    });
}

function ResetForm() {
    GetMandirList();
    $('#OnlyTransaction').prop('checked', false);
    $('#TransactionToDate').val('');
    $('#TransactionFromDate').val('');
    $('#CreatedToDate').val('');
    $('#CreatedFromDate').val('');
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
         
            $("#TransactionAccount").empty();

                $("<option />", {
                    val: 0,
                    text: 'Select All'
                }).appendTo("#TransactionAccount");

                $(jsondata).each(function () {

                    $("<option />", {
                        val: this.Id,
                        text: this.AccountName
                    }).appendTo("#TransactionAccount");
                });
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}