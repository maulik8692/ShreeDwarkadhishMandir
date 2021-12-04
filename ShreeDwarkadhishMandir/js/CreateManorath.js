var ManorathDetail = {};
var AccountGroups = [];
$(document).ready(function () {
    ResetForm();

    $("#Save").click(function (e) {
        SaveManorath();
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#ManorathType").change(function () {
        if (parseInt($("#ManorathType option:selected").val()) === 2) {
            $('.Darshan').show();
            $('.Funds').hide();
            $('.notFunds').show();
        }
        else if (parseInt($("#ManorathType option:selected").val()) === 4) {
            $('.Darshan').hide();
            $("#Darshan").val(0);
            $('.Funds').show();
            $('.notFunds').hide();
        }
        else {
            $('.Darshan').hide();
            $("#Darshan").val(0);
            $('.Funds').hide();
            $('.notFunds').show();
        }
    });
});

function SaveManorath() {

    var ManorathRequest = {
        Id: parseInt($('#Id').val()),
        ManorathName: $('#ManorathName').val(),
        ManorathType: parseInt($('#ManorathType option:selected').val()),
        DarshanId: parseInt($('#Darshan option:selected').val()) === 0 ? null : parseInt($('#Darshan').val()),
        Nyochhawar: $('#Nyochhawar').val() !== '' ? parseFloat($('#Nyochhawar').val().substr(2).replace(/,/g, '')) : 0,
        CashAccountId: parseInt($('#CashAccount').val()),
        ChequeAccountId: parseInt($('#ChequeAccount').val()),
        VaishnavAccountId: parseInt($('#ManorathType option:selected').val()) === 4 ? parseInt($('#FundsAccount').val()) : parseInt($('#VaishnavAccount').val()),
        IsActive: $('#IsActive').is(":checked")
    };
    $.ajax({
        type: "POST",
        url: "/Manorath/Manorath/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(ManorathRequest),
        success: function (result) {
            ResetForm();
            alert('Manorath has been saved successfully.')
            window.location.href = '/Manorath/Manorath';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
                if (customErrorMessage === "Mandir is require.") {
                    $('#Mandir').focus();
                }
                else if (customErrorMessage === "Account Type is require.") {
                    $('#AccountType').focus();
                }
                else if (customErrorMessage === "Account Name is require.") {
                    $('#AccountName').focus();
                }
                else if (customErrorMessage === "Bank Name is require.") {
                    $('#BankName').focus();
                }
                else if (customErrorMessage === "Bank Address is require.") {
                    $('#BankAddress').focus();
                }
                else if (customErrorMessage === "IFSC Code is require.") {
                    $('#IFSCCode').focus();
                }
                else if (customErrorMessage === "Account Number is require.") {
                    $('#AccountNumber').focus();
                }
                else if (customErrorMessage === "Amount is require.") {
                    $('#Amount').focus();
                }
                else if (customErrorMessage === "Date of Issue is require.") {
                    $('#DateOfIssue').focus();
                }
                else if (customErrorMessage === "Date of Maturity is require.") {
                    $('#DateOfMaturity').focus();
                }
                else if (customErrorMessage === "Rate of Interest is require.") {
                    $('#RateOfInterest').focus();
                } else if (customErrorMessage === "Maturity Amount is require.") {
                    $('#MaturityAmount').focus();
                }
            }
        },
    });
}

function GetDarshan() {

    $.ajax({
        url: "/Darshan/GetDarshanTime",
        data: JSON.stringify(null),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Darshan").empty();

            AccountGroups = [];
            AccountGroups = jsondata;
            $("<option />", {
                val: 0,
                text: 'Please Select Account Group'
            }).appendTo("#Darshan");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.DarshanId,
                    text: this.DarshanName
                }).appendTo("#Darshan");
            });

            if (parseInt($("#ManorathType option:selected").val()) === 2) {
                $('.Darshan').show();
            }
            else {
                $('.Darshan').hide();
                $("#Darshan").val(0)
            }

            if (typeof ManorathDetail.DarshanId !== "undefined" && ManorathDetail.DarshanId !== 0) {
                $("#Darshan").val(ManorathDetail.DarshanId);
            }

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetCashManorath() {

    var accountHeadRequest = {
        NatureOfGroup: 'Assets'
    };

    $.ajax({
        url: "/AccountHead/AccountHeadDropdown",
        data: JSON.stringify(accountHeadRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#CashAccount").empty();

            AccountGroups = [];
            AccountGroups = jsondata;
            $("<option />", {
                val: 0,
                text: 'Please Select Cash Account'
            }).appendTo("#CashAccount");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.AccountName + ' (' + this.NatureOfGroup + ')'
                }).appendTo("#CashAccount");
            });

            if (typeof ManorathDetail.CashAccountId !== "undefined" && ManorathDetail.CashAccountId !== 0) {
                $("#CashAccount").val(ManorathDetail.CashAccountId);
            }

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetChequeManorath() {

    var accountHeadRequest = {
        NatureOfGroup: 'Assets'
    };

    $.ajax({
        url: "/AccountHead/AccountHeadDropdown",
        data: JSON.stringify(accountHeadRequest),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#ChequeAccount").empty();

            AccountGroups = [];
            AccountGroups = jsondata;
            $("<option />", {
                val: 0,
                text: 'Please Select Account Group'
            }).appendTo("#ChequeAccount");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.AccountName + ' (' + this.NatureOfGroup + ')'
                }).appendTo("#ChequeAccount");
            });

            if (typeof ManorathDetail.ChequeAccountId !== "undefined" && ManorathDetail.ChequeAccountId !== 0) {
                $("#ChequeAccount").val(ManorathDetail.ChequeAccountId);
            }

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetVaishnavAccount() {

    var accountHeadRequest = {
        NatureOfGroup: 'Income'
    };

    $.ajax({
        url: "/AccountHead/AccountHeadDropdown",
        data: JSON.stringify(accountHeadRequest),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#VaishnavAccount").empty();

            AccountGroups = [];
            AccountGroups = jsondata;
            $("<option />", {
                val: 0,
                text: 'Please Select Account Group'
            }).appendTo("#VaishnavAccount");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.AccountName + ' (' + this.NatureOfGroup + ')'
                }).appendTo("#VaishnavAccount");
            });

            if (typeof ManorathDetail.VaishnavAccountId !== "undefined" && ManorathDetail.VaishnavAccountId !== 0) {
                $("#VaishnavAccount").val(ManorathDetail.VaishnavAccountId);
            }

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetFundsAccount() {

    var accountHeadRequest = {
        GroupName: 'Funds'
    };

    $.ajax({
        url: "/AccountHead/AccountHeadDropdown",
        data: JSON.stringify(accountHeadRequest),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#FundsAccount").empty();

            AccountGroups = [];
            AccountGroups = jsondata;
            $("<option />", {
                val: 0,
                text: 'Please Select Account Group'
            }).appendTo("#FundsAccount");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.AccountName + ' (' + this.NatureOfGroup + ')'
                }).appendTo("#FundsAccount");
            });

            if (typeof ManorathDetail.VaishnavAccountId !== "undefined" && ManorathDetail.VaishnavAccountId !== 0) {
                $("#FundsAccount").val(ManorathDetail.VaishnavAccountId);
            }

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function ResetFormData() {
    $('#ManorathName').val('')
    $('#Nyochhawar').val('')
    $('#ManorathType').val(0)
    $('#IsActive').prop('checked', false);
}

function ResetForm() {
    showProgress();
    var Id = getUrlParameter('Id');

    $('#Id').val(Id);

    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        var ManorathRequest = {
            Id: parseInt($('#Id').val())
        };

        $.ajax({
            url: "/Manorath/ManorathDetail",
            data: JSON.stringify(ManorathRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                ManorathDetail = jsondata;
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

        $('.Funds').hide();
        $('.notFunds').show();

        $('#Id').val(0);
        GetCashManorath();
        GetChequeManorath();
        GetVaishnavAccount();
        GetFundsAccount();
        GetDarshan();
        ResetFormData();
    }
    hideProgress();
}

function setdetail() {
    $('#Nyochhawar').val(parseFloat(ManorathDetail.Nyochhawar).toFixed(2));
    $('#ManorathName').val(ManorathDetail.ManorathName);
    if (ManorathDetail.IsDefaultRecord == true) {
        $('.IsActive').hide();
    } else {
        $('.IsActive').show();
    }
    $('#IsActive').prop('checked', ManorathDetail.IsActive);
    $('#ManorathType').val(ManorathDetail.ManorathType);
    GetCashManorath();
    GetDarshan();
    GetChequeManorath();

    if (ManorathDetail.ManorathType === 4) {
        GetFundsAccount();
        $('.Funds').show();
        $('.notFunds').hide();
    } else {
        GetVaishnavAccount();
        $('.Funds').hide();
        $('.notFunds').show();
    }

}
