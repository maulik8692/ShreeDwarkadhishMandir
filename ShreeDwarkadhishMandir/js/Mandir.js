var MandirDetail = {};
$(document).ready(function () {
    ResetForm();

    $("#ImageURL").change(function () {
        if ($(this).val() !== '') {
            $('#MandirImage').attr("src", $(this).val());
        }
    });

    $("#Country").change(function () {
        GetStatesByCountryId($('option:selected', this).val());
    });

    $("#State").change(function () {
        GetCitiesByStateId($('option:selected', this).val());
    });

    $("#City").change(function () {
        GetVillagesByCityId($('option:selected', this).val());
    });

    $("#Village").change(function () {

        var selectedVillage = personalVillages.find(x => x.Id === parseInt($('option:selected', this).val()));
        if (selectedVillage !== null && selectedVillage.Id !== 0) {
            $('#PostalCode').val(selectedVillage.ZipCode)
        }
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveMandir();
    });
});

function SaveMandir() {


    showProgress();
    var mandirRequest = {
        Id: parseInt($('#Id').val()),
        Name: $('#Name').val(),
        Address: $('#Address').val(),
        CountryId: parseInt($("#Country option:selected").val()),
        StateId: parseInt($("#State option:selected").val()),
        CityId: parseInt($("#City option:selected").val()),
        VillageId: parseInt($("#Village option:selected").val()),
        PostalCode: $('#PostalCode').val(),
        PhoneNumber: $('#PhoneNumber').val(),
        Email: $('#Email').val(),
        ImageUrl: $('#ImageURL').val(),
        GurudevName: $('#GurudevName').val(),
        RegistrationNumber: $('#RegistrationNumber').val(),
        CreatedBy: 0,
        CreatedOn: new Date()
    };


    $.ajax({
        type: "POST",
        url: "/Mandir/Mandir/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(mandirRequest),
        success: function (result) {
            hideProgress();
            alert('Mandir has been saved successfully.');
            window.location.href = '/Mandir/MandirList';
            
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
                if (customErrorMessage === "Mandir Name is require.") {
                    $('#Name').focus();
                }
                else if (customErrorMessage === "Address is require.") {
                    $('#Address').focus();
                }
                else if (customErrorMessage === "Please select Country.") {
                    $('#Country').focus();
                    $("#Country").empty();
                    $("#State").empty();
                    $('#stateDiv').hide();
                    $("#City").empty();
                    $('#cityDiv').hide();

                } else if (customErrorMessage === "Please select State.") {
                    $('#State').focus();
                    $("#State").empty();
                    $("#City").empty();
                    $('#cityDiv').hide();
                } else if (customErrorMessage === "Please select City.") {
                    $('#City').focus();
                    $("#City").empty();
                } else if (customErrorMessage === "PostalCode is require.") {
                    $('#PostalCode').focus();
                } else if (customErrorMessage === "Phone Number is require.") {
                    $('#PhoneNumber').focus();
                }
                else if (customErrorMessage === "Valide email is require.") {
                    $('#Email').focus();
                }
            }
        },
    });

    ResetForm();
}

function GetCountryAll() {
    $.ajax({
        url: "/Configuration/GetCountryAll",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Country").empty();
            $("#State").empty();
            $("#City").empty();
            $("#Village").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Country'
            }).appendTo("#Country");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Country");
            });

            $('#stateDiv').hide();
            $('#cityDiv').hide();
            $('#VillageDiv').hide();

            if (typeof MandirDetail.CountryId !== "undefined" && MandirDetail.CountryId !== 0) {
                $("#Country").val(MandirDetail.CountryId);
                GetStatesByCountryId(MandirDetail.CountryId);
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetStatesByCountryId(countryId) {
    showProgress();
    var reportParamObj = new Object();
    reportParamObj.countryId = parseInt(countryId);

    if (reportParamObj.countryId > 0) {
        $.ajax({
            url: "/Configuration/GetStatesByCountryId",
            data: JSON.stringify(reportParamObj),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                $("#State").empty();
                $("#City").empty();
                $("#Village").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select State'
                }).appendTo("#State");

                $(jsondata).each(function () {
                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#State");
                });

                $('#stateDiv').show();
                $('#cityDiv').hide();
                $('#VillageDiv').hide();

                if (typeof MandirDetail.StateId !== "undefined" && MandirDetail.StateId !== 0) {
                    $("#State").val(MandirDetail.StateId);
                    GetCitiesByStateId(MandirDetail.StateId);
                }

                hideProgress();
            },
            error: function (xhr) {
                hideProgress();
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
        });
    }
}

function GetCitiesByStateId(stateId) {
    showProgress();
    var reportParamObj = new Object();
    reportParamObj.stateId = parseInt(stateId);

    if (reportParamObj.stateId > 0) {
        $.ajax({
            url: "/Configuration/GetCitiesByStateId",
            data: JSON.stringify(reportParamObj),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                $("#City").empty();
                $("#Village").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select City'
                }).appendTo("#City");

                $(jsondata).each(function () {
                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#City");
                });

                $('#cityDiv').show();
                $('#VillageDiv').hide();

                if (typeof MandirDetail.CityId !== "undefined" && MandirDetail.CityId !== 0) {
                    $("#City").val(MandirDetail.CityId);
                    GetVillagesByCityId(MandirDetail.CityId);
                }

                hideProgress();
            },
            error: function (xhr) {
                hideProgress();
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
        });
    }
}

function GetVillagesByCityId(cityId) {
    showProgress();
    var reportParamObj = new Object();
    reportParamObj.cityId = parseInt(cityId);

    if (reportParamObj.cityId > 0) {
        $.ajax({
            url: "/Configuration/GetVillagesByCityId",
            data: JSON.stringify(reportParamObj),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                $("#Village").empty();
                personalVillages = jsondata;

                $("<option />", {
                    val: 0,
                    text: 'Please Select Village'
                }).appendTo("#Village");

                $(jsondata).each(function () {
                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#Village");
                });
                $('#VillageDiv').show();


                if (typeof MandirDetail.VillageId !== "undefined" && MandirDetail.VillageId !== 0) {
                    $("#Village").val(MandirDetail.VillageId);
                }

                hideProgress();
            },
            error: function (xhr) {
                hideProgress();
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
        });
    }
}

function ResetForm() {
    $("#Country").empty();
    $("#State").empty();
    $("#City").empty();
    $('#stateDiv').hide();
    $('#cityDiv').hide();
    $("#ImageURL").val('');
    $('#RegistrationNumber').val('');
    $('#GurudevName').val('');
    GetDetail();
}

function GetDetail() {

    var Id = getUrlParameter('Id');

    $('#Id').val(Id);

    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        showProgress();
        var mandirRequest = {
            Id: Id,
            Name: '',
            Address: '',
            CountryId: 0,
            StateId: 0,
            CityId: 0,
            VillageId: 0,
            PostalCode: '',
            PhoneNumber: '',
            Email: '',
            ImageUrl: '',
            CreatedBy: 0,
            CreatedOn: new Date()
        };

        $.ajax({
            url: "/Mandir/MandirDetail",
            data: JSON.stringify(mandirRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                MandirDetail = jsondata;
                setdetail();
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                if (xhr.status === 410) {
                    alert(customErrorMessage);

                }
                hideProgress();
            },
        });
    }
    else {
        GetCountryAll();

        hideProgress();
    }
}

function setdetail() {

    $('#PhoneNumber').val(MandirDetail.PhoneNumber);
    $("#PostalCode").val(MandirDetail.PostalCode);
    $('#Email').val(MandirDetail.Email);
    $('#Address').val(MandirDetail.Address);
    $('#ImageURL').val(MandirDetail.ImageUrl);
    $('#Name').val(MandirDetail.Name);

    $('#RegistrationNumber').val(MandirDetail.RegistrationNumber);
    $('#GurudevName').val(MandirDetail.GurudevName);
    if (MandirDetail.ImageUrl !== '') {
        $('#MandirImage').attr("src", MandirDetail.ImageUrl);
    }

    GetCountryAll();
}