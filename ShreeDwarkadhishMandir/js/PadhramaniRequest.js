var VaishnavDetail = {};

$(document).ready(function () {

    showDialog();
    $('.Address').hide();
    $('.PersonalDetail').hide();

    $("#Cancel").click(function () {
        CloseDialog();
    });

    $("#Search").click(function () {
        SearchVaishnav();
    });

    $("#RequestForgot").click(function () {
        CloseDialog();
        ShowForgot();
    });

    $("#ForgotCancel").click(function () {
        HideForgot();
        showDialog();
    });

    $("#ForgotRequest").click(function () {
        ForgotRequest();
    });

    $("#SendRequest").click(function () {
        SendPadhramaniRequest();
    });

    $('#ChangeAddress').change(function () {
        if (this.checked) {
            $('.Address').show();
        }
        else {
            $('.Address').hide();
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
        debugger;
        var selectedVillage = personalVillages.find(x => x.Id === parseInt($('option:selected', this).val()));
        if (selectedVillage !== null && selectedVillage.Id !== 0) {
            $('#PostalCode').val(selectedVillage.ZipCode)
        }
    });

    $('#VaishnavId').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            SearchVaishnav();
        }
    });
});

function SendPadhramaniRequest() {
    var padhramaniRequest = {
        Id: 0,
        VallabhId: '',
        VaishnavUserId: $('#Id').val(),
        Address: $('#Address').val(),
        CountryId: parseInt($("#Country option:selected").val()),
        StateId: parseInt($("#State option:selected").val()),
        CityId: parseInt($("#City option:selected").val()),
        VillageId: parseInt($("#Village option:selected").val()),
        PostalCode: $('#PostalCode').val(),
        VaishnavId: $('#VaishnavId').val(),
        RequestNumber: '',
        RequestStatus: 0,
        PadhramaniDate: null,
        CompletionDate: null,
        IsCompled: false
    };
    debugger;
    $.ajax({
        url: "/Padhramani/SavePadhramaniRequest",
        data: JSON.stringify(padhramaniRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert('Your request has been added successfully.');
            window.location.href = '/Home/Index';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
                window.location.href = '/Home/Index';
            }
            hideProgress();
        },
    });
}

function ForgotRequest() {

}

function SearchVaishnav() {

    showProgress();
    var vaishnavRequest = {
        Id: 0,
        EncryptedId: '',
        FirstName: '',
        MiddleName: '',
        LastName: '',
        Nickname: '',
        Address: '',
        CountryId: 0,
        StateId: 0,
        CityId: 0,
        VillageId: 0,
        PostalCode: 0,
        Gender: '',
        DateOfBirth: new Date(),
        BloodGroup: '',
        MaritalStatus: '',
        MobileNo: '',
        Email: '',
        ResidencePhone: '',
        Occupation: 0,
        OccupationDetail: '',
        OccupationAddress: '',
        OccupationCountryId: 0,
        OccupationStateId: 0,
        OccupationCityId: 0,
        OccupationVillageId: 0,
        OccupationPostalCode: '',
        OfficePhone: '',
        AddtionalNote: '',
        IsActive: false,
        VaishnavId: $('#VaishnavId').val()
    };

    $.ajax({
        url: "/Vaishnav/GetVaishnavById",
        data: JSON.stringify(vaishnavRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            CloseDialog();
            VaishnavDetail = jsondata;
            setdetail();
            $('.PersonalDetail').show();

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

function setdetail() {

    $('#MobileNo').html(VaishnavDetail.MobileNo);
    $('#Id').val(VaishnavDetail.EncryptedId);

    $('#FirstName').html(VaishnavDetail.FirstName);
    $('#MiddleName').html(VaishnavDetail.MiddleName);
    $('#LastName').html(VaishnavDetail.LastName);

    var vaishnavAddress = '';

    if (typeof VaishnavDetail.Address !== "undefined" && VaishnavDetail.Address !== '') {
        vaishnavAddress += VaishnavDetail.Address;
    }
    if (typeof VaishnavDetail.VillageName !== "undefined" && VaishnavDetail.VillageName !== '') {
        vaishnavAddress += ',\n' + VaishnavDetail.VillageName;
    }
    if (typeof VaishnavDetail.CityName !== "undefined" && VaishnavDetail.CityName !== '') {
        vaishnavAddress += ',\n' + VaishnavDetail.CityName;
    }
    if (typeof VaishnavDetail.StateName !== "undefined" && VaishnavDetail.StateName !== '') {
        vaishnavAddress += ',\n' + VaishnavDetail.StateName;
    }
    if (typeof VaishnavDetail.CountryName !== "undefined" && VaishnavDetail.CountryName !== '') {
        vaishnavAddress += ',\n' + VaishnavDetail.CountryName;
    }
    if (typeof VaishnavDetail.PostalCode !== "undefined" && VaishnavDetail.PostalCode !== '') {
        vaishnavAddress += ',\n' + VaishnavDetail.PostalCode;
    }

    $('#VaishnavAddress').val(vaishnavAddress);
    $('#Address').val(VaishnavDetail.Address);
    $('#email').html(VaishnavDetail.Email);

    GetCountryAll();

    $('.Address').hide();
    $('.PersonalDetail').hide();
}

function showDialog() {
    $('#SearchVaishnav').modal('show');

}

function CloseDialog() {
    $('#SearchVaishnav').modal('hide');
}

function ShowForgot() {
    $('#ForgotId').modal('show');

}

function HideForgot() {
    $('#ForgotId').modal('hide');
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

            if (typeof VaishnavDetail.CountryId !== "undefined" && VaishnavDetail.CountryId !== 0) {
                $("#Country").val(VaishnavDetail.CountryId);
                GetStatesByCountryId(VaishnavDetail.CountryId);
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

                if (typeof VaishnavDetail.StateId !== "undefined" && VaishnavDetail.StateId !== 0) {
                    $("#State").val(VaishnavDetail.StateId);
                    GetCitiesByStateId(VaishnavDetail.StateId);
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

                if (typeof VaishnavDetail.CityId !== "undefined" && VaishnavDetail.CityId !== 0) {
                    $("#City").val(VaishnavDetail.CityId);
                    GetVillagesByCityId(VaishnavDetail.CityId);
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

                debugger;
                if (typeof VaishnavDetail.VillageId !== "undefined" && VaishnavDetail.VillageId !== 0) {
                    $("#Village").val(VaishnavDetail.VillageId);
                    $('#PostalCode').val(VaishnavDetail.PostalCode)
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