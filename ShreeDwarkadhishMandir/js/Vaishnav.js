var personalVillages = [];
var OccupationVillages = [];
var VaishnavDetail = {};

$(document).ready(function () {
    $(".DarshanDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
        maxDate: 0,
        yearRange: "-100:+0", // last hundred years
        setDate: new Date()
    });

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

    $("#OccupationCountry").change(function () {
        GetOccupationStatesByCountryId($('option:selected', this).val());
    });

    $("#OccupationState").change(function () {
        GetOccupationCitiesByStateId($('option:selected', this).val());
    });

    $("#OccupationCity").change(function () {
        GetOccupationVillagesByCityId($('option:selected', this).val());
    });

    $("#OccupationVillage").change(function () {

        var selectedVillage = OccupationVillages.find(x => x.Id === parseInt($('option:selected', this).val()));
        if (selectedVillage !== null && selectedVillage.Id !== 0) {
            $('#OccupationPostalCode').val(selectedVillage.ZipCode)
        }
    });

});

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


                if (typeof VaishnavDetail.VillageId !== "undefined" && VaishnavDetail.VillageId !== 0) {
                    $("#Village").val(VaishnavDetail.VillageId);
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

function GetOccupationCountryAll() {
    $.ajax({
        url: "/Configuration/GetCountryAll",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#OccupationCountry").empty();
            $("#OccupationState").empty();
            $("#OccupationCity").empty();
            $("#OccupationVillage").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Country'
            }).appendTo("#OccupationCountry");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#OccupationCountry");
            });

            $('#OccupationStateDiv').hide();
            $('#OccupationCityDiv').hide();
            $('#OccupationVillageDiv').hide();

            if (typeof VaishnavDetail.OccupationCountryId !== "undefined" && VaishnavDetail.OccupationCountryId !== 0) {
                $("#OccupationCountry").val(VaishnavDetail.OccupationCountryId);
                GetOccupationStatesByCountryId(VaishnavDetail.OccupationCountryId);
            }
            else {
                hideProgress();
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetOccupationStatesByCountryId(countryId) {

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
                $("#OccupationState").empty();
                $("#OccupationCity").empty();
                $("#OccupationVillage").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select State'
                }).appendTo("#OccupationState");

                $(jsondata).each(function () {
                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#OccupationState");
                });

                $('#OccupationStateDiv').show();
                $('#OccupationCityDiv').hide();
                $('#OccupationVillageDiv').hide();

                if (typeof VaishnavDetail.OccupationStateId !== "undefined" && VaishnavDetail.OccupationStateId !== 0) {
                    $("#OccupationState").val(VaishnavDetail.OccupationStateId);
                    GetOccupationCitiesByStateId(VaishnavDetail.OccupationStateId);
                }

            },
            error: function (xhr) {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
        });
    }
}

function GetOccupationCitiesByStateId(stateId) {

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
                $("#OccupationCity").empty();
                $("#OccupationVillage").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select City'
                }).appendTo("#OccupationCity");

                $(jsondata).each(function () {
                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#OccupationCity");
                });

                $('#OccupationCityDiv').show();
                $('#OccupationVillageDiv').hide();

                if (typeof VaishnavDetail.OccupationCityId !== "undefined" && VaishnavDetail.OccupationCityId !== 0) {
                    $("#OccupationCity").val(VaishnavDetail.OccupationCityId);
                    GetOccupationVillagesByCityId(VaishnavDetail.OccupationCityId);
                }
            },
            error: function (xhr) {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
        });
    }
}

function GetOccupationVillagesByCityId(cityId) {

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
                $("#OccupationVillage").empty();
                OccupationVillages = jsondata;
                $("<option />", {
                    val: 0,
                    text: 'Please Select Village'
                }).appendTo("#OccupationVillage");

                $(jsondata).each(function () {
                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#OccupationVillage");
                });
                $('#OccupationVillageDiv').show();

                if (typeof VaishnavDetail.OccupationVillageId !== "undefined" && VaishnavDetail.OccupationVillageId !== 0) {
                    $("#OccupationVillage").val(VaishnavDetail.OccupationVillageId);
                }
            },
            error: function (xhr) {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
        });
    }
}

function CheckMobile() {

    $("#MobileNo").autocomplete({
        minLength: 3,
        source: function (request, response) {

            $.ajax({
                type: "POST",
                url: "/Vaishnav/VaishnavJan/",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify({
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
                    MobileNo: $('#MobileNo').val(),
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
                    IsActive: false
                }),
                success: function (result) {


                },
                error: function (xhr, httpStatusMessage, customErrorMessage) {

                },
            });
        },
        focus: function (event, ui) {

            $("#MobileNo").val(ui.item.label);
            return false;
        },
        select: function (event, ui) {
            $("#MobileNo").val(ui.item.label);

            return false;
        }
    }).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<div>" + item.value + "<br>" + item.label + "<br>" + item.desc + "</div>")
            .appendTo(ul);
    };
}

function ResetForm() {
    showProgress();
    $(".LoadingText").html("Please wait resting form in progress..");

    $('#Id').val('');
    $('#FirstName').val('');
    $('#MiddleName').val('');
    $('#LastName').val('');
    $('#Nickname').val('');
    $('#Address').val('');
    $('#PostalCode').val('');
    $('input[name="Gender"]').attr('checked', false);
    $('#DateOfBirth').val('');
    $("#BloodGroup").val($("#BloodGroup option:eq(0)").val());
    $("#BloodGroup option:selected").val('');
    $("#MaritalStatus").val($("#MaritalStatus option:eq(0)").val());
    $('#MobileNo').val('');
    $('#email').val('');
    $('#AlternateNumber').val('');
    $('#OccupationDetail').val('');
    $('#OccupationAddress').val('');
    $('#OccupationPostalCode').val('');
    $('#OfficePhone').val('');
    $('#AddtionalNote').val('');
    $('#IsActive').prop('checked', false);

    $("#Country").empty();
    $("#State").empty();
    $("#City").empty();
    $("#Village").empty();

    $('#OccupationStateDiv').hide();
    $('#OccupationCityDiv').hide();
    $('#OccupationVillageDiv').hide();

    $('#stateDiv').hide();
    $('#cityDiv').hide();
    $('#VillageDiv').hide();

    $("#OccupationCountry").empty();
    $("#OccupationState").empty();
    $("#OccupationCity").empty();
    $("#OccupationVillage").empty();

    GetDetail();

    hideProgress();
}

function SaveForm() {
    showProgress();
    var vaishnavRequest = {
        Id: 0,
        EncryptedId: $('#Id').val(),
        FirstName: $('#FirstName').val(),
        MiddleName: $('#MiddleName').val(),
        LastName: $('#LastName').val(),
        Nickname: $('#Nickname').val(),
        Address: $('#Address').val(),
        CountryId: parseInt($("#Country option:selected").val()),
        StateId: parseInt($("#State option:selected").val()),
        CityId: parseInt($("#City option:selected").val()),
        VillageId: parseInt($("#Village option:selected").val()),
        PostalCode: $('#PostalCode').val(),
        Gender: $('input[name=Gender]:checked').val(),
        DateOfBirth: $('#DateOfBirth').val(),
        BloodGroup: $("#BloodGroup option:selected").val(),
        MaritalStatus: $("#MaritalStatus option:selected").val(),
        MobileNo: $('#MobileNo').val(),
        Email: $('#email').val(),
        ResidencePhone: $('#AlternateNumber').val(),
        Occupation: parseInt($("#Occupation option:selected").val()),
        OccupationDetail: $('#OccupationDetail').val(),
        OccupationAddress: $('#OccupationAddress').val(),
        OccupationCountryId: parseInt($("#OccupationCountry option:selected").val()),
        OccupationStateId: parseInt($("#OccupationState option:selected").val()),
        OccupationCityId: parseInt($("#OccupationCity option:selected").val()),
        OccupationVillageId: parseInt($("#OccupationVillage option:selected").val()),
        OccupationPostalCode: $('#OccupationPostalCode').val(),
        OfficePhone: $('#OfficePhone').val(),
        AddtionalNote: $('#AddtionalNote').val(),
        IsActive: $('#IsActive').is(":checked")
    };

    $.ajax({
        url: "/Vaishnav/Vaishnav",
        data: JSON.stringify(vaishnavRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            hideProgress();
            alert("Vaishnav has been added successfully.");
            window.location.href = '/Vaishnav/VaishnavJan';
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

function GetOccupationAll() {
    $("#Occupation").empty();
    $.ajax({
        url: "/Configuration/GetOccupationAll",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            $("<option />", {
                val: 0,
                text: 'Please Select Occupation'
            }).appendTo("#Occupation");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Professions
                }).appendTo("#Occupation");
            });
            if (typeof VaishnavDetail.Occupation !== "undefined" && VaishnavDetail.Occupation !== 0) {
                $("#Occupation").val(VaishnavDetail.Occupation);
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetDetail() {

    var queryString = getUrlParameter('Id');
    queryString = queryString.indexOf(" ") > 0 && queryString.length > queryString.indexOf(" ") ? queryString.replace(" ", "+") : queryString;
    var VaishnavId = queryString;

    $('#Id').val(VaishnavId);

    if (typeof VaishnavId !== "undefined" && VaishnavId !== null && VaishnavId !== '') {
        showProgress();
        var vaishnavRequest = {
            Id: 0,
            EncryptedId: $('#Id').val(),
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
            VaishnavId: ''
        };

        $.ajax({
            url: "/Vaishnav/GetVaishnavById",
            data: JSON.stringify(vaishnavRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                VaishnavDetail = jsondata;
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
        GetOccupationAll();

        GetCountryAll();

        GetOccupationCountryAll();
        hideProgress();
    }
}

function setdetail() {
    $('#MobileNo').val(VaishnavDetail.MobileNo);

    $('#FirstName').val(VaishnavDetail.FirstName);
    $('#MiddleName').val(VaishnavDetail.MiddleName);
    $('#LastName').val(VaishnavDetail.LastName);
    $('#Nickname').val(VaishnavDetail.Nickname);
    $('#Address').val(VaishnavDetail.Address);

    if (VaishnavDetail.Gender !== null && VaishnavDetail.Gender !== '') {
        $("input[name=Gender][value=" + VaishnavDetail.Gender + "]").attr('checked', 'checked');
    }

    if (VaishnavDetail.DateOfBirth !== null && VaishnavDetail.DateOfBirth !== '') {
        var date = new Date(parseInt(VaishnavDetail.DateOfBirth.replace('/Date(', '')));

        $('#DateOfBirth').datepicker("setDate", date);
    }
    $("#BloodGroup").val(VaishnavDetail.BloodGroup);
    $("#MaritalStatus").val(VaishnavDetail.MaritalStatus);
    $("#PostalCode").val(VaishnavDetail.PostalCode);
    $("#OccupationPostalCode").val(VaishnavDetail.OccupationPostalCode);

    $('#email').val(VaishnavDetail.Email);
    $('#AlternateNumber').val(VaishnavDetail.ResidencePhone);
    $('#OccupationDetail').val(VaishnavDetail.OccupationDetail);
    $('#OccupationAddress').val(VaishnavDetail.OccupationAddress);
    //OccupationCountryId: parseInt($("#OccupationCountry option:selected").val());
    //OccupationStateId: parseInt($("#OccupationState option:selected").val());
    //OccupationCityId: parseInt($("#OccupationCity option:selected").val());
    //OccupationVillageId: parseInt($("#OccupationVillage option:selected").val());
    //OccupationPostalCode: $('#OccupationPostalCode').val(VaishnavDetail);
    $('#OfficePhone').val(VaishnavDetail.OfficePhone);
    $('#AddtionalNote').val(VaishnavDetail.AddtionalNote);
    $('#IsActive').prop('checked', VaishnavDetail.IsActive);

    GetOccupationAll();

    GetCountryAll();

    GetOccupationCountryAll();
}