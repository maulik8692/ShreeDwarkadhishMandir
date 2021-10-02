$(document).ready(function () {
    resetConfiguration();

    resetEmailConfiguration();

    $("#SaveConfiguration").click(function (e) {
        SaveConfiguration();
    });

    $("#resetConfiguration").click(function (e) {
        resetConfiguration();
    });

    $("#SaveEmailConfiguration").click(function (e) {
        SaveEmailConfiguration();
    });

    $("#resetEmailConfiguration").click(function (e) {
        resetEmailConfiguration();
    });
});

function SaveEmailConfiguration() {
    showProgress();
    var emailRequest = {
        Server: $('#Server').val(),
        Username: $('#Username').val(),
        Password: $('#Password').val(),
        Port: $('#Port').val(),
        DisplayName: $('#DisplayName').val(),
        SSL: $('#SSL').is(":checked"),
        ExchangeService: false,
        IsActive: true
    };

    $.ajax({
        url: "/EmailConfiguration/SaveEmailConfiguration",
        data: JSON.stringify(emailRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null) {
                alert('Email configuration has been successfully updated.');
                resetEmailConfiguration();
                hideProgress();
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function resetEmailConfiguration() {
    GetEmailConfiguration();
}

function SaveConfiguration() {
    showProgress();
    var col = $(".keyValueSelect");
    var keyValues = [];
    var keyValue;

    for (i = 0; i < col.length; i++) {
        keyValue = new Object();

        if ($(col[i]).attr('id').indexOf('Select') !== -1) {
            keyValue.Id = $(col[i]).attr('id').replace("Select_", "");
        }
        else {
            keyValue.Id = $(col[i]).attr('id').replace("TextArea_", "");
        }

        keyValue.KeyName = '';
        keyValue.KeyValue = $(col[i]).val();
        keyValues.push(keyValue);
    }

    $.ajax({
        url: "/Configuration/SetConfiguration",
        data: JSON.stringify(keyValues),  // For empty input data use "{}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert("Record updated successfully.");
            location.reload(true);
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function resetConfiguration() {
    LoadKeys();
}

function LoadKeys() {

    showProgress();
    $("#ConfigurationKeys").html('');

    $.ajax({
        url: "/Configuration/GetConfiguration",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null) {
                for (var i = 0; i < jsondata.length; i++) {

                    if (jsondata[i].KeyName === 'DefaultReceiptId') {
                        $("#ConfigurationKeys").append(

                            '<div class="row form-group">' +
                            '<div class="col col-md-5">' +
                            '<label style="word-break: break-all;" for="Select_' + jsondata[i].Id + '" class="form-control-label">' + jsondata[i].KeyDisplayName + '</label>' +
                            '</div>' +
                            '<div class="col-12 col-md-6">' +
                            '<select name="Select_' + jsondata[i].Id + '" id="Select_' + jsondata[i].Id + '" class="form-control keyValueSelect"></select>' +
                            '</div>' +
                            '</div>'
                        );

                        GetManorathDropdown('Select_' + jsondata[i].Id, jsondata[i].KeyValue)
                    }
                    else if (jsondata[i].KeyName === 'DefaultVaishnavId') {
                        $("#ConfigurationKeys").append(

                            '<div class="row form-group">' +
                            '<div class="col col-md-5">' +
                            '<label style="word-break: break-all;" for="Select_' + jsondata[i].Id + '" class="form-control-label">' + jsondata[i].KeyDisplayName + '</label>' +
                            '</div>' +
                            '<div class="col-12 col-md-6">' +
                            '<select name="Select_' + jsondata[i].Id + '" id="Select_' + jsondata[i].Id + '" class="form-control keyValueSelect"></select>' +
                            '</div>' +
                            '</div>'
                        );

                        AccountHeadDropdown(jsondata[i]);
                    }
                }
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetManorathDropdown(accountHeadDropdownId, selectedId) {
    $.ajax({
        type: "POST",
        url: "/Manorath/ManorathDropdown/",
        contentType: "application/json",
        dataType: "json",
        success: function (jsondata) {
            $("#" + accountHeadDropdownId).empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Manorath for receipt transaction'
            }).appendTo("#" + accountHeadDropdownId);

            $(jsondata).each(function () {
                $("<option />", {
                    val: this.Id,
                    text: this.ManorathName + ' - ' + this.Nyochhawar.toFixed(2)
                }).appendTo("#" + accountHeadDropdownId);
            });

            $("#" + accountHeadDropdownId).val(selectedId);
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function AccountHeadDropdown(configuration) {
    var accountDropdownRequest = {
        AccountId: 0,
        NatureOfGroup: 'Income'
    }

    var accountHeadDropdownId = 'Select_' + configuration.Id;

    $.ajax({
        type: "POST",
        url: "/AccountHead/AccountHeadDropdown/",
        data: JSON.stringify(accountDropdownRequest),
        contentType: "application/json",
        dataType: "json",
        success: function (jsondata) {
            $("#" + accountHeadDropdownId).empty();
            debugger;
            $("<option />", {
                val: 0,
                text: 'Please Default Manorath Vaishnav Account Id'
            }).appendTo("#" + accountHeadDropdownId);

            $(jsondata).each(function () {
                $("<option />", {
                    val: this.Id,
                    text: this.AccountName
                }).appendTo("#" + accountHeadDropdownId);
            });

            $("#" + accountHeadDropdownId).val(configuration.KeyValue);
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetEmailConfiguration() {
    $.ajax({
        url: "/EmailConfiguration/EmailConfiguration",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null) {
                $('#Server').val(jsondata.Server);
                $('#Username').val(jsondata.Username);
                $('#Password').val(jsondata.Password);
                $('#Port').val(jsondata.Port);
                $('#DisplayName').val(jsondata.DisplayName);
                $('#SSL').prop('checked', jsondata.SSL);

                hideProgress();
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}