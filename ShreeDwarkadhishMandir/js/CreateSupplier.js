var personalVillages = [];
var SupplierDetail = {};

$(document).ready(function () {

    ResetForm();

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
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

            if (typeof SupplierDetail.MandirId !== "undefined" && SupplierDetail.MandirId !== 0) {
                $("#Mandir").val(SupplierDetail.MandirId);
            }
            else {
                $("#Mandir").val($("#Mandir option:eq(1)").val());
            }
            
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
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

            if (typeof SupplierDetail.CountryId !== "undefined" && SupplierDetail.CountryId !== 0) {
                $("#Country").val(SupplierDetail.CountryId);
                GetStatesByCountryId(SupplierDetail.CountryId);
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

                if (typeof SupplierDetail.StateId !== "undefined" && SupplierDetail.StateId !== 0) {
                    $("#State").val(SupplierDetail.StateId);
                    GetCitiesByStateId(SupplierDetail.StateId);
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

                if (typeof SupplierDetail.CityId !== "undefined" && SupplierDetail.CityId !== 0) {
                    $("#City").val(SupplierDetail.CityId);
                    GetVillagesByCityId(SupplierDetail.CityId);
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


                if (typeof SupplierDetail.VillageId !== "undefined" && SupplierDetail.VillageId !== 0) {
                    $("#Village").val(SupplierDetail.VillageId);
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
    showProgress();
    $(".LoadingText").html("Please wait resting form in progress..");

    $('#Id').val('');
    $('#SupplierName').val('')
    $('#PostalCode').val('')
    $('#MobileNo').val('')
    $('#email').val('')
    $('#IsActive').prop('checked', false);

    $("#Country").empty();
    $("#State").empty();
    $("#City").empty();
    $("#Village").empty();

    $('#stateDiv').hide();
    $('#cityDiv').hide();
    $('#VillageDiv').hide();

    GetDetail();

    hideProgress();
}

function SaveForm() {
    showProgress();
    var supplier = {
        Id: parseInt($('#Id').val()),
        MandirId: parseInt($('#Mandir').val()),
        SupplierId: $('#SupplierId').val(),
        SupplierName: $('#SupplierName').val(),
        CountryId: parseInt($("#Country option:selected").val()),
        StateId: parseInt($("#State option:selected").val()),
        CityId: parseInt($("#City option:selected").val()),
        VillageId: parseInt($("#Village option:selected").val()),
        PostalCode: $('#PostalCode').val(),
        MobileNo: $('#MobileNo').val(),
        Email: $('#email').val(),
        IsActive: $('#IsActive').is(":checked")
    };

    $.ajax({
        url: "/Supplier/CreateSupplier",
        data: JSON.stringify(supplier),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            hideProgress();
            alert("Supplier has been saved successfully.");
            window.location.href = '/Supplier/Supplier';
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

function GetDetail() {

    var SupplierId = getUrlParameter('Id');

    $('#SupplierId').val(SupplierId);

    if (typeof SupplierId !== "undefined" && SupplierId !== null && SupplierId !== '') {
        showProgress();
        var supplier = {
            Id: 0,
            SupplierId: $('#SupplierId').val(),
            SupplierName: '',
            CountryId: 0,
            StateId: 0,
            CityId: 0,
            VillageId: 0,
            PostalCode: '',
            MobileNo: '',
            Email: '',
            IsActive: false
        };

        $.ajax({
            url: "/Supplier/SupplierDetail",
            data: JSON.stringify(supplier),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                SupplierDetail = jsondata;
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
        GetCountryAll();
        GetMandirList();
        hideProgress();
    }
}

function setdetail() {
    $('#MobileNo').val(SupplierDetail.MobileNo);
    $('#SupplierName').val(SupplierDetail.SupplierName);
    $("#PostalCode").val(SupplierDetail.PostalCode);

    $('#email').val(SupplierDetail.Email);
    
    $('#IsActive').prop('checked', SupplierDetail.IsActive);
    GetMandirList();
    GetCountryAll();

}