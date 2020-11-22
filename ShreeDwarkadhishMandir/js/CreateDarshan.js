var LastDarshanDate=null;

$(document).ready(function () {
    LoadDarshan();

    $('#Save').click(function (e) {
        SaveDarshan();
    });

    $('#reset').click(function (e) {
        LoadDarshan();
    });

});

function LoadDarshan() {

    $(".DarshanDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
        minDate: 0,
        onClose: function (dateText, inst) {
            function isDonePressed() {
                return ($('#ui-datepicker-div').html().indexOf('ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all ui-state-hover') > -1);
            }

            if (isDonePressed()) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                if (inst.id === 'FromDate') {
                    $(this).datepicker('setDate', new Date(year, month, 1)).trigger('change');
                }
                else if (inst.id === 'ToDate') {
                    month = parseInt(month) + 1;
                    $(this).datepicker('setDate', new Date(year, month, 0)).trigger('change');
                }

                $('.datepicker').focusout()//Added to remove focus from datepicker input box on selecting date
            }
        },
        beforeShow: function customRange(input) {
            if (input.id === 'FromDate') {
                var abc = $('#ToDate').datepicker("getDate");
                return {
                    maxDate: abc == null ? "+0M" : $('#ToDate').datepicker("getDate"),
                };
            } else if (input.id === 'ToDate') {
                return {
                    minDate: $('#FromDate').datepicker("getDate"),
                };
            }
        }
    });

    $(".DarshanDate").datepicker().datepicker("setDate", new Date());

    $('#darshanForm').html('');

    $.ajax({
        url: "/Darshan/GetDarshanTime",
        data: JSON.stringify(null),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                var darshanForm = ''
                
                if (jsondata[0].FromDarshanDate !== null) {
                    var date = new Date(parseInt(jsondata[0].FromDarshanDate.replace('/Date(', '')));
                    $(".DarshanDate").datepicker("option", "minDate", date);
                }

                $.each(jsondata, function (index, value) {
                    darshanForm +=
                        '<div class="row form-group">'
                        + '<div class="col col-md-2">'
                        + '<label for="Mandir" class="form-control-label">' + value.DarshanName + '</label>'
                        + '</div>'
                        + '<div class="col-12 col-md-3">'
                        + '<input type="text" id="FromTime_' + value.DarshanId + '" name="FromTime_' + value.DarshanId + '" placeholder="hh:mm AM" class="form-control timepicker">'
                        + '</div>'
                        + '<div class="col-12 col-md-3">'
                        + '<input type="text" id="ToTime_' + value.DarshanId + '" name="ToTime_' + value.DarshanId + '" placeholder="hh:hh AM" class="form-control timepicker">'
                        + '</div>'
                        + '<div class="col-12 col-md-4">'
                        + '<input type="text" id="Note_' + value.DarshanId + '" name="Note_' + value.DarshanId + '" placeholder="Additional Notes" class="form-control ">'
                        + '</div>'
                        + '</div>'
                });

                $('#darshanForm').html(darshanForm);

                var timepicker = $('.timepicker').timepicker({
                    timeFormat: "hh:mm tt",
                    //hourMin: 8,
                    //hourMax: 18,
                    onClose: function (dateText, inst) {

                        function isDonePressed() {
                            return ($('#ui-datepicker-div').html().indexOf('ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all ui-state-hover') > -1);
                        }

                        if (isDonePressed()) {

                        }
                    },
                    beforeShow: function customRange(input) {

                        if (input.id.indexOf('FromTime_') != -1) {
                            var abc = $('#ToTime_' + input.id.replace('FromTime_', '')).datepicker("getDate");

                            return {
                                hourMax: abc === null ? 24 : $('#ToTime_' + input.id.replace('FromTime_', '')).datepicker("getDate").getHours(),
                            };
                        }
                        else if (input.id.indexOf('ToTime_') != -1) {

                            var abc = $('#FromTime_' + input.id.replace('ToTime_', '')).datepicker("getDate");
                            return {
                                hourMin: abc === null ? 0 : $('#FromTime_' + input.id.replace('ToTime_', '')).datepicker("getDate").getHours(),
                            };
                        }
                        //if (input.id === 'ContentPlaceHolder1_FromTXT') {
                        //    var abc = $('#ContentPlaceHolder1_ToTXT').datepicker("getDate");
                        //    return {
                        //        maxDate: abc == null ? "+100M" : $('#ContentPlaceHolder1_ToTXT').datepicker("getDate"),
                        //    };
                        //} else if (input.id === 'ContentPlaceHolder1_ToTXT') {
                        //    return {
                        //        minDate: $('#ContentPlaceHolder1_FromTXT').datepicker("getDate"),
                        //    };
                        //}
                    },
                    onSelect: function (timeStr) {
                    }

                });
            }
            hideProgress();
        },
        error: function (xhr) {
            hideProgress();
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function SaveDarshan() {

    var darshans = [];
    var Contain = "";
    $("#darshanForm :text").each(function () {
        if (this.id.indexOf('FromTime_') != -1) {
            var darshan = new Object();
            darshan.Id = 0;
            darshan.DarshanId = parseInt(this.id.replace('FromTime_', ''));
            darshan.DarshanName = '';

            darshan.FromDarshanDate = $('#FromDate').datepicker("getDate");
            darshan.ToDarshanDate = $('#ToDate').datepicker("getDate");
            darshan.FromTime = $(this).datepicker("getDate");
            darshan.ToTime = $('#ToTime_' + this.id.replace('FromTime_', '')).datepicker("getDate");

            darshan._FromDarshanDate = $('#FromDate').val();
            darshan._ToDarshanDate = $('#ToDate').val();
            darshan._FromTime = $(this).val();
            darshan._ToTime = $('#ToTime_' + this.id.replace('FromTime_', '')).val();
            darshan.AdditionalNote = $('#Note_' + this.id.replace('FromTime_', '')).val();
            darshans.push(darshan);
        }
        
        Contain += $(this).val() + "$";
    });

    showProgress();    

    $.ajax({
        url: "/Darshan/CreateDarshan",
        data: JSON.stringify(darshans),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
           
            alert("Darshan has been added successfully.");
            hideProgress();
            //window.location.href = '/Vaishnav/VaishnavJan';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
                if (customErrorMessage === "Mobile number is require.") {
                    $('#MobileNo').focus();
                }
                else if (customErrorMessage === "Email is require.") {
                    $('#email').focus();
                }
                else if (customErrorMessage === "First name is require.") {
                    $('#FirstName').focus();
                }
                else if (customErrorMessage === "Postalcode is require.") {
                    $('#Postalcode').focus();
                }
                else if (customErrorMessage === "Address is require.") {
                    $('#Address').focus();
                }
                else if (customErrorMessage === "Please select State.") {
                    $('#State').focus();
                    $("#State").empty();
                    $("#City").empty();
                    $('#cityDiv').hide();
                    $("#Village").empty();
                    $('#VillageDiv').hide();
                } else if (customErrorMessage === "Please select City.") {
                    $('#City').focus();
                    $("#City").empty();
                    $("#Village").empty();
                    $('#VillageDiv').hide();
                } else if (customErrorMessage === "Please select Village.") {
                    $('#Village').focus();
                    $("#Village").empty();
                } else if (customErrorMessage === "Please select occupation State.") {
                    $('#OccupationState').focus();
                    $("#OccupationState").empty();
                    $("#OccupationCity").empty();
                    $('#OccupationCityDiv').hide();
                    $("#OccupationVillage").empty();
                    $('#OccupationVillageDiv').hide();
                } else if (customErrorMessage === "Please select occupation city.") {
                    $('#OccupationCity').focus();
                    $("#OccupationCity").empty();
                    $("#OccupationVillage").empty();
                    $('#OccupationVillageDiv').hide();
                } else if (customErrorMessage === "Please select occupation village.") {
                    $('#OccupationVillage').focus();
                    $("#OccupationVillage").empty();
                } else if (customErrorMessage === "Occupation postalcode is require.") {
                    $('#OccupationPostalCode').focus();
                } else if (customErrorMessage === "Occupation Address is require.") {
                    $('#OccupationAddress').focus();
                }
            }
            hideProgress();
        },
    });
}