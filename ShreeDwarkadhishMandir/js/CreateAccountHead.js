var accountHeadDetail = {}
var AccountGroups = []
$(document).ready(function () {
    $(".DarshanDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
    });

    ResetForm();

    $("#Save").click(function (e) {
        SaveAccountHead();
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#AccountGroup").change(function () {
        AccountGroup();
    });
});

function AccountGroup() {
    $('.bank').hide();
    $('.fixedDeposite').hide();
    var GroupType = AccountGroups.filter(x => x.Id === parseInt($('#AccountGroup option:selected').val())).map(x => x.GroupType)[0];

    var NatureOfGroup = AccountGroups.filter(x => x.Id === parseInt($('#AccountGroup option:selected').val())).map(x => x.NatureOfGroup)[0];

    $('input[name="TransactionType"]').prop('checked', false);
    if (NatureOfGroup === 'Liabilities') {

        $('#Credit').prop("checked", true);
        $('input[name="TransactionType"]').prop('disabled', true);
    }
    else if (NatureOfGroup === 'Assets') {

        $('#Debit').prop("checked", true);
        $('input[name="TransactionType"]').prop('disabled', true);
    }

    SetAccountHeadFeilds(GroupType);
}

function SaveAccountHead() {

    var accountHeadRequest = {
        Id: parseInt($('#Id').val()),
        MandirId: parseInt($("#Mandir option:selected").val()),
        GroupId: parseInt($("#AccountGroup option:selected").val()),
        AccountName: $('#AccountName').val(),
        Alias: $('#Alias').val(),
        BalanceAmount: $('#BalanceAmount').val() !== '' ? parseFloat($('#BalanceAmount').val().substr(2).replace(/,/g, '')) : 0,
        DebitCredit: $("input[name='TransactionType']:checked").val(),
        AccountHolderName: $('#AccountHolderName').val(),
        BankName: $('#BankName').val(),
        BankAddress: $('#BankAddress').val(),
        AccountNumber: $('#AccountNumber').val(),
        IFSCCode: $('#IFSCCode').val(),
        BankBranch: $('#BankBranch').val(),
        DateOfIssue: $('#DateOfIssue').val(),
        AnnexureOrder: $('#AnnexureOrder').val(),
        AnnexureName: $('#AnnexureName').val(),
        DateOfMaturity: $('#DateOfMaturity').val(),
        InterestRate: $('#RateOfInterest').val() !== '' ? parseFloat($('#RateOfInterest').val().substr(2).replace(/,/g, '')) : 0,//parseFloat($('#RateOfInterest').val()),
        MaturityAmount: $('#MaturityAmount').val() !== '' ? parseFloat($('#MaturityAmount').val().substr(2).replace(/,/g, '')) : 0,//parseFloat($('#MaturityAmount').val()),
        IsEditable: $('#IsActive').is(":checked"),
        IsActive: $('#IsEditable').is(":checked")
    };

    $.ajax({
        type: "POST",
        url: "/AccountHead/AccountHead/",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(accountHeadRequest),
        success: function (result) {

            ResetForm();
            alert('Account Head has been saved successfully.')
            window.location.href = '/AccountHead/AccountHead';
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
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetAccountGroupsForDropdown() {
    $.ajax({
        url: "/AccountGroup/GetAccountGroupsForDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#AccountGroup").empty();

            AccountGroups = [];
            AccountGroups = jsondata;
            $("<option />", {
                val: 0,
                text: 'Please Select Account Group'
            }).appendTo("#AccountGroup");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.GroupName + ' (' + this.NatureOfGroup + ')'
                }).appendTo("#AccountGroup");
            });

            if (typeof accountHeadDetail.GroupId !== "undefined" && accountHeadDetail.GroupId !== 0) {
                $("#AccountGroup").val(accountHeadDetail.GroupId);
            }

            AccountGroup();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function ResetFormData() {
    $('#AccountGroup').val(0);
    $('#AccountName').val('');
    $('#Alias').val('');
    $('#BalanceAmount').val('');
    $('#AccountHolderName').val('');
    $('#BankName').val('');
    $('#BankAddress').val('');
    $('#IFSCCode').val('');
    $('#AccountNumber').val('');
    $('#BankBranch').val('');
    $('#DateOfIssue').val('');
    $('#DateOfMaturity').val('');
    $('#RateOfInterest').val('');
    $('#MaturityAmount').val('');
    $('#Balance').val('');
    $('#IsActive').prop('checked', true);
    $('#IsEditable').prop('checked', true);
    $('input[name="TransactionType"]').prop('checked', false);
    $('input[name="TransactionType"]').prop('disabled', false);
    $('#AccountGroup').prop("disabled", false);
    $('#BalanceAmount').prop("disabled", false);
}

function ResetForm() {
    showProgress();
    GetMandirList();
    var Id = getUrlParameter('Id');

    $('#Id').val(Id);
    $('.supplier').hide();
    $('.bank').hide();
    $('.darshan').hide();
    $('.fixedDeposite').hide();
    $('.bhet').hide();

    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        var accountHeadRequest = {
            Id: parseInt($('#Id').val())
        };

        $.ajax({
            url: "/AccountHead/AccountHeadDetail",
            data: JSON.stringify(accountHeadRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                accountHeadDetail = jsondata;
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
        GetAccountGroupsForDropdown();
        ResetFormData();
    }
    hideProgress();

}

function setdetail() {
    SetAccountHeadFeilds(accountHeadDetail.AccountTypeId);
    //$('#AccountType').val(accountHeadDetail.AccountTypeId);
    $('#AccountType').prop("disabled", true);
    $('#AccountGroup').prop("disabled", true);
    $('#BalanceAmount').prop("disabled", true);
    $('#BalanceAmount').val(parseFloat(Math.abs(accountHeadDetail.BalanceAmount)).toFixed(2));
    $('#AccountName').val(accountHeadDetail.AccountName);
    $('#Alias').val(accountHeadDetail.Alias)
    //
    $('#BankBranch').val(accountHeadDetail.BankBranch);
    $('#BankName').val(accountHeadDetail.BankName);
    $('#BankAddress').val(accountHeadDetail.BankAddress);
    $('#IFSCCode').val(accountHeadDetail.IFSCCode);
    $('#AccountNumber').val(accountHeadDetail.AccountNumber);
    $('#AccountHolderName').val(accountHeadDetail.AccountHolderName);
    //
    $('#DateOfIssue').val(accountHeadDetail.DateOfIssue);
    $('#DateOfMaturity').val(accountHeadDetail.DateOfMaturity);
    $('#RateOfInterest').val(accountHeadDetail.InterestRate);
    $('#MaturityAmount').val(accountHeadDetail.MaturityAmount);
    $('#Nyochavar').val(accountHeadDetail.Nyochavar);

    $('#AnnexureOrder').val(accountHeadDetail.AnnexureOrder);
    $('#AnnexureName').val(accountHeadDetail.AnnexureName);
    if (accountHeadDetail.IsDefaultRecord == true) {
        $('.IsActive').hide();
    } else {
        $('.IsActive').show();
    }
    $('#IsActive').prop('checked', accountHeadDetail.IsActive);
    //$('#IsEditable').prop('checked', accountHeadDetail.IsEditable);
    $('#IsEditable').prop('checked', false);
    GetAccountGroupsForDropdown();
}

function SetAccountHeadFeilds(groupType) {
    if (groupType === 1) {
        $('.bank').show();
    }
    else if (groupType === 2) {
        $('.fixedDeposite').show();
    }
}