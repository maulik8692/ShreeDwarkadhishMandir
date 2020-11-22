$(document).ready(function () {
   
    $("#Mandir").change(function () {
        GetAccountHeadForBhet($('#Mandir').val());
    });

    $("#ManorathType").change(function () {
        ////ManorathTypies.find(x => x.AccountId === parseInt($('#ManorathType').val())).Nyochavar
        //$('#Nek').prop('readonly', false);
        //$('#Nek').val('')
        //var Nyochavar = ManorathTypies.find(x => x.AccountId === parseInt($('#ManorathType').val())).Nyochavar
        //if (Nyochavar > 0) {
        //    $('#Nek').val(Nyochavar)
        //    $('#Nek').prop('readonly', true);
        //    $(".Nek").hide();
        //}
        //else {
        //    $(".Nek").show();
        //}
    });

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

    $(".ManorathDate").datepicker({
        dateFormat: "dd-M-yy",
        changeMonth: true,
        changeYear: true,
        buttonText: "Select date",
        onClose: function (dateText, inst) {
            function isDonePressed() {
                return ($('#ui-datepicker-div').html().indexOf('ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all ui-state-hover') > -1);
            }

            //if (isDonePressed()) {
            //    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            //    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            //    if (inst.id === 'ManorathFromDate') {
            //        $(this).datepicker('setDate', new Date(year, month, 1)).trigger('change');
            //    }
            //    else if (inst.id === 'ManorathToDate') {
            //        month = parseInt(month) + 1;
            //        $(this).datepicker('setDate', new Date(year, month, 0)).trigger('change');
            //    }

            //    $('.ManorathDate').focusout()//Added to remove focus from datepicker input box on selecting date
            //}
        },
        beforeShow: function customRange(input) {
            if (input.id === 'ManorathFromDate') {
                var abc = $('#ManorathToDate').datepicker("getDate");
                return {
                    maxDate: abc == null ? "+10M" : $('#ManorathToDate').datepicker("getDate"),
                };
            } else if (input.id === 'ManorathToDate') {
                return {
                    minDate: $('#ManorathFromDate').datepicker("getDate"),
                    //maxDate: new Date()
                };
            }
        }
    });

    $("#Search").click(function (e) {
        if (isValidDate($('#ManorathFromDate').val()) === true && isValidDate($('#ManorathToDate').val()) === false) {
            alert('Please select valid Manorath To Date');
            $('#ManorathToDate').focus()
        }
        else if (isValidDate($('#ManorathToDate').val()) === true && isValidDate($('#ManorathFromDate').val()) === false) {
            alert('Please select valid Manorath From Date');
            $('#ManorathFromDate').focus()
        }
        else if (isValidDate($('#CreatedFromDate').val()) === true && isValidDate($('#CreatedToDate').val()) === false) {
            alert('Please select valid Created To Date');
            $('#CreatedToDate').focus()
        }
        else if (isValidDate($('#CreatedToDate').val()) === true && isValidDate($('#CreatedFromDate').val()) === false) {
            alert('Please select valid Created From Date');
            $('#CreatedFromDate').focus()
        }
        else {
            $.redirect('/Report/ManorathReceiptReport', {
                'FromDate': $('#CreatedFromDate').val(),
                'ToDate': $('#CreatedToDate').val(),
                'ManorathFromDate': $('#ManorathFromDate').val(),
                'ManorathToDate': $('#ManorathToDate').val(),
                'AccountId': $('#ManorathType').val(),
                'OnlyManorath': $('#OnlyManorath').is(":checked"),
                'CreatedBy': 0,
                'MandirId': $('#Mandir').val()
            },'POST','_Blank');
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

            GetAccountHeadForBhet($("#Mandir option:eq(1)").val());
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function ResetForm() {
    GetMandirList();
    $('#OnlyManorath').prop('checked', false);
    $('#ManorathToDate').val('');
    $('#ManorathFromDate').val('');
    $('#CreatedToDate').val('');
    $('#CreatedFromDate').val('');
}

function GetAccountHeadForBhet(mandirId) {
    showProgress();

    var reportParamObj = new Object();
    reportParamObj.MandirId = parseInt(mandirId);
    reportParamObj.AccountId = 0;

    $.ajax({
        url: "/Manorath/ManorathDropdown/",
        data: JSON.stringify(reportParamObj),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#ManorathType").empty();

            ManorathTypies = jsondata;

            $("<option />", {
                val: 0,
                text: 'Please Select Manorath for receipt transaction'
            }).appendTo("#ManorathType");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.ManorathName
                }).appendTo("#ManorathType");
            });
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}