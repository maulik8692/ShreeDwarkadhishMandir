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

});

function SaveForm() {
    showProgress();
    var Bhandar = {
        Id: parseInt($('#Id').val()),
        MandirId: parseInt($('#Mandir').val()),
        Name: $('#BhandarName').val(),
        UnitId: parseInt($('#UnitOfMeasurement').val()),
        CategoryId: parseInt($('#BhandarCategory').val()),
        Balance: parseFloat($('#Balance').val()),
        IsActive: $('#IsActive').is(":checked")
    };

    $.ajax({
        url: "/Bhandar/CreateBhandar",
        data: JSON.stringify(Bhandar),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Bhandar has been updated successfully.");
            hideProgress();

            window.location.href = '/Bhandar/Bhandar';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            alert(customErrorMessage);
            hideProgress();
        },
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

            if (typeof BhandarDetail.MandirId !== "undefined" && BhandarDetail.MandirId !== 0) {
                $("#Mandir").val(BhandarDetail.MandirId);
            }
            else {
                $("#Mandir").val($("#Mandir option:eq(1)").val());
            }

            GetUnitMeasurementList();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetUnitMeasurementList() {
    $.ajax({
        url: "/UnitMeasurement/UnitOfMeasurementDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#UnitOfMeasurement").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select UnitOfMeasurement'
            }).appendTo("#UnitOfMeasurement");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
                }).appendTo("#UnitOfMeasurement");
            });

            if (typeof BhandarDetail.UnitId !== "undefined" && BhandarDetail.UnitId !== 0) {
                $("#UnitOfMeasurement").val(BhandarDetail.UnitId);
            }

            GetBhandarCategoriesForDrodown();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetBhandarCategoriesForDrodown() {
    $.ajax({
        url: "/BhandarCategory/GetBhandarCategoriesForDrodown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#BhandarCategory").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Bhandar Category'
            }).appendTo("#BhandarCategory");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.CategoryName
                }).appendTo("#BhandarCategory");
            });

            if (typeof BhandarDetail.CategoryId !== "undefined" && BhandarDetail.CategoryId !== 0) {
                $("#BhandarCategory").val(BhandarDetail.CategoryId);
            }

            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function ResetForm() {
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
   
}