$(document).ready(function () {
    hideProgress();
    PageEvent();
    ResetForm();
});

function PageEvent() {
    $(".CreatedDate").datepicker({
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
            //    if (inst.id === 'CreatedFromDate') {
            //        $(this).datepicker('setDate', new Date(year, month, 1)).trigger('change');
            //    }
            //    else if (inst.id === 'CreatedToDate') {
            //        month = parseInt(month) + 1;
            //        $(this).datepicker('setDate', new Date(year, month, 0)).trigger('change');
            //    }

            //    $('.datepicker').focusout()//Added to remove focus from datepicker input box on selecting date
            //}
        },
        beforeShow: function customRange(input) {
            if (input.id === 'CreatedFromDate') {
                var abc = $('#CreatedToDate').datepicker("getDate");
                return {
                    maxDate: abc == null ? "+10M" : $('#CreatedToDate').datepicker("getDate"),
                };
            } else if (input.id === 'CreatedToDate') {
                return {
                    minDate: $('#CreatedFromDate').datepicker("getDate"),
                    //maxDate: new Date()
                };
            }
        }
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Search").click(function (e) {
       if (isValidDate($('#CreatedFromDate').val()) === true && isValidDate($('#CreatedToDate').val()) === false) {
           alert('Please select valid Transaction To Date');
            $('#CreatedToDate').focus()
        }
        else if (isValidDate($('#CreatedToDate').val()) === true && isValidDate($('#CreatedFromDate').val()) === false) {
           alert('Please select valid Transaction From Date');
            $('#CreatedFromDate').focus()
        }
       else {
           var StoreId = $('#Store').val() !== "undefined" ? parseInt($('#Store').val()) : 0
           var BhandarId = $('#Bhandar').val() !== "undefined" ? parseInt($('#Bhandar').val()) : 0;
           var BhandarTransactionCodeId = $('#TransactionType').val() !== "undefined" ? parseInt($('#TransactionType').val()) : 0;

           $.redirect('/Report/BhandarTransactionReport', {
                'FromDate': $('#CreatedFromDate').val(),
                'ToDate': $('#CreatedToDate').val(),
                'BhandarTransactionCodeId': BhandarTransactionCodeId,
                'BhandarId': BhandarId,
                'StoreId': StoreId
            }, 'POST', '_Blank');
        }
    });
}

function ResetForm() {
    showProgress();
    $('#CreatedToDate').val('');
    $('#CreatedFromDate').val('');
    GetStoreList();
}

function GetBhandar() {
    $.ajax({
        url: "/Bhandar/GetBhandarForDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Bhandar").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Bhandar'
            }).appendTo("#Bhandar");

            var filterResult = []
            if (typeof jsondata !== "undefined") {
                filterResult = jsondata.filter(function (i, n) {
                    return i.IsActive === true
                });

                $(filterResult).each(function () {

                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#Bhandar");
                });
            }
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetStoreList() {
    $.ajax({
        url: "/Store/StoreDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Store").empty();
            $("<option />", {
                val: 0,
                text: 'Please Select Store'
            }).appendTo("#Store");

            $(jsondata).each(function () {
                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Store");
            });

            GetBhandar();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}