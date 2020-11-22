var ApplicationUserDetail = {}
$(document).ready(function () {
    ResetForm();

    $('#reset').click(function () {
        ResetForm();
    });

    $('#Save').click(function () {
        var applicationUserRequest = {
            Id: parseInt($('#Id').val()),
            UserName: $('#Username').val(),
            Password: $('#password').val(),
            DisplayName: $("#DisplayName").val(),
            MandirId: parseInt($("#Mandir option:selected").val()),
            UserTypeId: parseInt($("#UserType option:selected").val()),
            UserTypeName: $("#UserType option:selected").text(),
            Email: $('#Email').val(),
            PhoneNumber: $('#PhoneNumber').val(),
            Address: $('#Address').val()
        };

        $.ajax({
            type: "POST",
            url: "/ApplicationUser/ApplicationUser/",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(applicationUserRequest),
            success: function (result) {

                ResetForm();
                alert('Application user has been saved successfully.');
                window.location.href = '/ApplicationUser/ApplicationUserList';
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                if (xhr.status === 410) {
                    alert(customErrorMessage);
                    if (customErrorMessage === "Mandir is require.") {
                        $('#Mandir').focus();
                    }
                    else if (customErrorMessage === "User Type is require.") {
                        $('#UserType').focus();
                    }
                    else if (customErrorMessage === "User Name is require.") {
                        $('#Username').focus();
                    }
                    else if (customErrorMessage === "Password is require.") {
                        $('#password').focus();
                    }
                    else if (customErrorMessage === "The password must be at least 8 characters, at least 1 uppercase character, at least 1 lowercase character, at least one number and a maximum of 30 characters.") {
                        $('#password').focus();
                    }
                    else if (customErrorMessage === "Display Name is require.") {
                        $('#DisplayName').focus();
                    }
                    else if (customErrorMessage === "Phone Number is require.") {
                        $('#PhoneNumber').focus();
                    }
                    else if (customErrorMessage === "Email is require.") {
                        $('#Address').focus();
                    }
                    else if (customErrorMessage === "Check if the current value is a valid email address.") {
                        $('#Address').focus();
                    }
                    else if (customErrorMessage === "Address is require.") {
                        $('#Address').focus();
                    }
                }
            },
        });

    });

    $('#Username').bind('keyup blur', function () {

        var Username = $(this).val();
        if (Username.length === 0) {
            $('#UsernameCheck').removeClass()
            $('#UsernameCheck').addClass('fa')
            $('#UsernameCheck').addClass('fa-times-circle')
            $('#UsernameCheck').addClass('short')

        }
        else {
            //$.ajax({
            //    url: "/Mandir/MandirList",
            //    dataType: "json",
            //    type: "POST",
            //    contentType: "application/json; charset=utf-8",
            //    success: function (jsondata) {
            //        $("#Mandir").empty();

            //        $("<option />", {
            //            val: 0,
            //            text: 'Please Select Mandir'
            //        }).appendTo("#Mandir");

            //        $(jsondata).each(function () {

            //            $("<option />", {
            //                val: this.Id,
            //                text: this.Name
            //            }).appendTo("#Mandir");
            //        });
            //    },
            //    error: function (xhr) {
            //        alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            //    }
            //});
        }

    });

    $('#password').bind('keyup blur', function () {
        var result = "";
        var password = $(this).val();
        var strength = 0;
        if (password.length < 8) {
            $('#passwordCheck').removeClass();
            $('#passwordCheck').addClass('fa');
            $('#passwordCheck').addClass('fa-check-circle');
            $('#passwordCheck').addClass('short');
            result = 'Too short';
        }
        if (password.length > 9) strength += 1
        // If password contains both lower and uppercase characters, increase strength value.
        if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) strength += 1;
        // If it has numbers and characters, increase strength value.
        if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) strength += 1;
        // If it has one special character, increase strength value.
        if (password.match(/([!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1;
        // If it has two special characters, increase strength value.
        if (password.match(/(.*[!,%,&,@,#,$,^,*,?,_,~].*[!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1;
        // Calculated strength value, we can return messages
        // If value is less than 2
        if (strength === 0) {
            $('#passwordCheck').removeClass();
            $('#passwordCheck').addClass('fa');
            $('#passwordCheck').addClass('fa-times-circle');
            $('#passwordCheck').addClass('short');
            result = 'Too short';

        }
        else if (strength < 2) {
            $('#passwordCheck').removeClass()
            $('#passwordCheck').addClass('fa')
            $('#passwordCheck').addClass('fa-times-circle')
            $('#passwordCheck').addClass('weak')
            result = 'Weak'

        } else if (strength === 2) {
            $('#passwordCheck').removeClass()
            $('#passwordCheck').addClass('fa')
            $('#passwordCheck').addClass('fa-check-circle')
            $('#passwordCheck').addClass('good')
            result = 'Good'

        } else {
            $('#passwordCheck').removeClass()
            $('#passwordCheck').addClass('fa')
            $('#passwordCheck').addClass('fa-check-circle')
            $('#passwordCheck').addClass('strong')
            result = 'Strong'
        }

    });

    GetMandirList();
    GetUserType();
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

            if (ApplicationUserDetail.MandirId > 0) {
                $("#Mandir").val(ApplicationUserDetail.MandirId);
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetUserType() {
    $.ajax({
        url: "/Configuration/GetUserType",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#UserType").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select UserType'
            }).appendTo("#UserType");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.TypeName
                }).appendTo("#UserType");
            });

            if (ApplicationUserDetail.UserTypeId > 0) {
                $("#UserType").val(ApplicationUserDetail.UserTypeId);
            }

            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
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
        var applicationUserRequest = {
            Id: $('#Id').val()
        };

        $.ajax({
            url: "/ApplicationUser/ApplicationUserDetail",
            data: JSON.stringify(applicationUserRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                ApplicationUserDetail = jsondata;
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

        $('#Username').val('');
        $('#password').val('');
        $('#DisplayName').val('');
        $('#email').val('');
        $('#PhoneNumber').val('');
        $('#Address').val('');

        $('#UsernameCheck').removeClass();
        $('#passwordCheck').removeClass();

        GetMandirList();
        GetUserType();

        hideProgress();
    }
}

function setdetail() {
    $('#Username').val(ApplicationUserDetail.UserName);
    $('#password').hide();
    $('.Password ').hide();
    $("#DisplayName").val(ApplicationUserDetail.DisplayName);
    $('#Email').val(ApplicationUserDetail.Email);
    $('#PhoneNumber').val(ApplicationUserDetail.PhoneNumber);
    $('#Address').val(ApplicationUserDetail.Address);
    GetMandirList();
    GetUserType();
}