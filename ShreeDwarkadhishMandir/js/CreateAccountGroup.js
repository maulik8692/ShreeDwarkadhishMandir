var AccountGroupDetail = {};

$(document).ready(function () {

    ResetForm();

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });

});

function GetDefaultGroups() {
    $.ajax({
        url: "/AccountGroup/GetDefaultGroups",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#DefaultGroup").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Default Group'
            }).appendTo("#DefaultGroup");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.GroupName
                }).appendTo("#DefaultGroup");
            });

            if (typeof AccountGroupDetail.DefaultGroupId !== "undefined" && AccountGroupDetail.DefaultGroupId !== 0) {
                $("#DefaultGroup").val(AccountGroupDetail.DefaultGroupId);
            }

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function ResetForm() {
    showProgress();
    $(".LoadingText").html("Please wait resting form in progress..");

    $('#Id').val('');
    $('#AccountGroupName').val('')
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
    var AccountGroup = {
        Id: parseInt($('#AccountGroupId').val()),
        GroupName: $('#GroupName').val(),
        AliasName: $('#AliasName').val(),
        DefaultGroupId: parseInt($("#DefaultGroup option:selected").val()),
        GroupType: parseInt($("#GroupType option:selected").val()),
        IsActive: $('#IsActive').is(":checked"),
        IsEditable: $('#IsEditable').is(":checked")
    };

    $.ajax({
        url: "/AccountGroup/CreateAccountGroup",
        data: JSON.stringify(AccountGroup),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            hideProgress();
            alert("AccountGroup has been saved successfully.");
            window.location.href = '/AccountGroup/AccountGroup';
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

    var AccountGroupId = getUrlParameter('Id');

    $('#AccountGroupId').val(AccountGroupId);

    if (typeof AccountGroupId !== "undefined" && AccountGroupId !== null && AccountGroupId !== '') {
        showProgress();
        var AccountGroup = {
            Id: parseInt($('#AccountGroupId').val()),
            GroupName: '',
            AliasName: '',
            DefaultGroupId: 0,
            GroupType: 0,
            IsActive: false,
            IsEditable: false
        };

        $.ajax({
            url: "/AccountGroup/AccountGroupDetail",
            data: JSON.stringify(AccountGroup),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                AccountGroupDetail = jsondata;
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
        GetDefaultGroups();
        hideProgress();
    }
}

function setdetail() {
    debugger;
    $('#GroupName').val(AccountGroupDetail.GroupName);
    $('#AliasName').val(AccountGroupDetail.AliasName);
    $('#AccountGroupId').val(AccountGroupDetail.Id);
    $('#IsActive').prop('checked', AccountGroupDetail.IsActive);
    $('#IsEditable').prop('checked', AccountGroupDetail.IsEditable);
    GetDefaultGroups();
}