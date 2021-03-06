﻿var UnitMeasurement = [];
var BhandarForDropdown = [];
var SamagriDetail = {};
var samagriBhandar = [];

$(document).ready(function () {
    Reset();
    $("#SaveAdd").click(function (e) {
        SaveSamagri();
    });

    $("#NewSamagriBhandar").click(function (e) {
        ResetSamagriBhandar(null);
        var nextId = 0;
        var isNew = $('#IsNew').is(":checked")
        if (isNew === true && samagriBhandar.length > 0) {
            nextId = Math.max.apply(Math, samagriBhandar.map(function (o) { return o.Id; })) + 1
        } else if (isNew === true) {
            nextId = 1
        }
        $('#SamagriBhandarId').val(nextId);
        $('#scrollmodal').modal('show');
    });

    $("#UnitOfMeasurement").change(function () {
        var selectedUOM = UnitMeasurement
            .filter(function (index) {
                return index.Id === parseInt($("#UnitOfMeasurement").val());
            })

        $('.Balance').inputmask("numeric", {
            radixPoint: ".",
            groupSeparator: "",
            digits: 5,
            autoGroup: true,
            suffix: ' ' + selectedUOM[0].UnitAbbreviation, //Space after $, this will not truncate the first character.
            rightAlign: false//,
            //oncleared: function () { self.Value(''); }
        });
    });

    $("#SamagriBhandarUOM").change(function () {

        var selectedUOM = UnitMeasurement
            .filter(function (index) {
                return index.Id === parseInt($("#SamagriBhandarUOM").val());
            })

        $('#BhandarNoOfUnit').inputmask("numeric", {
            radixPoint: ".",
            groupSeparator: "",
            digits: 5,
            autoGroup: true,
            suffix: ' ' + selectedUOM[0].UnitAbbreviation, //Space after $, this will not truncate the first character.
            rightAlign: false//,
            //oncleared: function () { self.Value(''); }
        });

    });

    $("#SaveBhandar").click(function (e) {
        SaveSamagriBhandar();
    });

    $("#resetBhandar").click(function (e) {
        ResetSamagriBhandar();
    });

});

function GetSamagriDetail() {
    var Id = getUrlParameter('Id');

    $('#Id').val(Id);
    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        showProgress();

        var samagriRequest = {
            Id: parseInt($('#Id').val()),
            Name: '',
            Description: '',
            UnitId: 0,
            NoOfUnit: 0,
            Balance: 0,
            MinStockValidation: 0,
            CreatedBy: 0,
            IsActive: false,
            PageNumber: 0,
            PageSize: 0,
            Page: 0,
            Total: 0,
            UnitDescription: '',
            UnitAbbreviation: '',
            SamagriBhandarRequest: []
        }
        $.ajax({
            url: "/Samagri/GetSamagriDetail",
            data: JSON.stringify(samagriRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                SamagriDetail = jsondata;
                SetSamagriDetail();
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {

                hideProgress();
            },
        });
    }
    else {
        GetUnitMeasurementList();
    }
}

function SetSamagriDetail() {
    $('#Balance').prop('disabled', true);
    $('#NoOfUnit').prop('disabled', true);
    $('#SamagriName').val(SamagriDetail.Name);
    $('#Description').val(SamagriDetail.Description);
    $('#Balance').val(SamagriDetail.Balance);
    $('#NoOfUnit').val(SamagriDetail.NoOfUnit);
    $('#MinmumAmount').val(SamagriDetail.MinStockValidation);
    $('#IsActive').prop('checked', SamagriDetail.IsActive);
    GetUnitMeasurementList();
    GetSamagriBhandarList();
}

function GetSamagriBhandarList() {
    var SamagriId = parseInt($('#Id').val());

    if (typeof SamagriId !== "undefined" && SamagriId !== null && SamagriId !== '') {
        showProgress();
        var samagriBhandarRequest = {
            Id: 0,
            SamagriId: SamagriId,
            UnitId: 0,
            NoOfUnit: 0,
            BhandarId: 0,
            UnitPerSamagri: 0,
            CreatedBy: 0,
            NoOfSamagri: 0,
            MinStockValidation: 0,
            UnitAbbreviation: '',
            UnitDescription: '',
        }
        $.ajax({
            url: "/Samagri/GetSamagriBhandarList",
            data: JSON.stringify(samagriBhandarRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                samagriBhandar = jsondata;
                SetSamagriBhandarList();
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {

                hideProgress();
            },
        });
    }
    else {

        GetUnitMeasurementList();
    }
}

function GetSamagriBhandar(id) {

    var samagriBhandarDetail = samagriBhandar.find(x => x.Id === parseInt(id));
    ResetSamagriBhandar(samagriBhandarDetail);
    $('#BhandarNoOfUnit').val(samagriBhandarDetail.NoOfUnit.toFixed(4));
    $('#SamagriBhandarId').val(id);
    $('#IsNew').prop('checked', samagriBhandarDetail.IsNew);
    $('#SamagriBhandarIsActive').prop('checked', samagriBhandarDetail.IsActive);
    $('#scrollmodal').modal('show');
}

function SetSamagriBhandarList() {
    if (samagriBhandar !== null) {
        $('#SamagriBhandar').DataTable({
            destroy: true,
            fixedHeader: true,
            "data": samagriBhandar,
            "columns": [
                { "data": "BhandarName", "title": "Bhandar Name", "className": "dt-body-left" },
                {
                    data: "NoOfUnit",
                    title: "NoOfUnit",
                    render: function (data, type, row) {
                        return parseFloat(row.NoOfUnit).toFixed(4) + ' ' + row.UnitAbbreviation;
                    },
                    className: "dt-body-Center"
                },
                {
                    data: "Edit",
                    title: "Edit",
                    render: function (data, type, row) {
                        return "<div onclick='GetSamagriBhandar(" + row.Id + ")'><i class='fa fa-edit'></i></div>"
                    },
                    className: "dt-body-Center"
                }
            ],
            "language": {
                "zeroRecords": "Darshan not available.",
                "emptyTable": "Darshan not available."
            },
            ordering: false,
            searching: false,
            paging: false,
            "bInfo": false
        });

        $('#DarshanTime thead').hide();
        $('.fg-toolbar').hide();
        hideProgress();
    }
}

function SetSamagriUOM() {
    $("#UnitOfMeasurement").empty();

    $("<option />", {
        val: 0,
        text: 'Please Select UnitOfMeasurement'
    }).appendTo("#UnitOfMeasurement");

    $(UnitMeasurement).each(function () {

        $("<option />", {
            val: this.Id,
            text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
        }).appendTo("#UnitOfMeasurement");
    });

    if (typeof SamagriDetail.UnitId !== "undefined" && SamagriDetail.UnitId !== 0) {
        $("#UnitOfMeasurement").val(SamagriDetail.UnitId);
    }
}

function SetSamagriBhandarUOM(samagriBhandarDetail) {
    $("#SamagriBhandarUOM").empty();

    $("<option />", {
        val: 0,
        text: 'Please Select UnitOfMeasurement'
    }).appendTo("#SamagriBhandarUOM");

    $(UnitMeasurement).each(function () {

        $("<option />", {
            val: this.Id,
            text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
        }).appendTo("#SamagriBhandarUOM");
    });

    if (samagriBhandarDetail !== null && samagriBhandarDetail !== "undefined" && typeof samagriBhandarDetail.UnitId !== "undefined" && samagriBhandarDetail.UnitId !== 0) {
        $('#SamagriBhandarUOM').prop('disabled', true);
        $("#SamagriBhandarUOM").val(samagriBhandarDetail.UnitId);
    }
    else {
        $('#SamagriBhandarUOM').prop('disabled', false);
    }
}

function SetBhandarDropdown(samagriBhandarDetail) {
    $("#Bhandar").empty();

    $("<option />", {
        val: 0,
        text: 'Please Select Bhandar'
    }).appendTo("#Bhandar");

    $(BhandarForDropdown).each(function () {

        $("<option />", {
            val: this.Id,
            text: this.Name
        }).appendTo("#Bhandar");
    });

    if (samagriBhandarDetail !== null && samagriBhandarDetail !== "undefined" && typeof samagriBhandarDetail.BhandarId !== "undefined" && samagriBhandarDetail.BhandarId !== 0) {
        $('#Bhandar').prop('disabled', true);
        $("#Bhandar").val(samagriBhandarDetail.BhandarId);
    }
    else {
        $('#Bhandar').prop('disabled', false);
    }
    hideProgress();
}

function GetUnitMeasurementList() {
    $.ajax({
        url: "/UnitMeasurement/UnitOfMeasurementDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            UnitMeasurement = jsondata;
            SetSamagriUOM();

            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function Reset() {
    showProgress();
    $('#SamagriName').val('');
    $('#Description').val('');
    $('#Balance').val('');
    $('#NoOfUnit').val('');
    $('#MinmumAmount').val('');

    GetSamagriDetail();

    GetBhandar();
}

function ResetSamagriBhandar(samagriBhandarDetail) {
    SetSamagriBhandarUOM(samagriBhandarDetail);
    SetBhandarDropdown(samagriBhandarDetail);
    $('#BhandarNoOfUnit').val('');
    $('#SamagriBhandarIsActive').prop('checked', false);
    if (samagriBhandarDetail === null) {
        $('#IsNew').prop('checked', true);
    } else {
        $('#IsNew').prop('checked', false);
    }
}

function GetBhandar() {
    $.ajax({
        url: "/Bhandar/GetBhandarForDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            BhandarForDropdown = jsondata;

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function SaveSamagriBhandar() {

    var SamagriBhandarId = parseInt($('#SamagriBhandarId').val());
    var samagriBhandarDetail = samagriBhandar.find(x => x.Id === parseInt(SamagriBhandarId));
    samagriBhandarDetail = {}
    samagriBhandarDetail.UnitId = $("#SamagriBhandarUOM").val();
    samagriBhandarDetail.BhandarId = $("#Bhandar").val();
    samagriBhandarDetail.NoOfUnit = parseFloat($('#BhandarNoOfUnit').val());

    $.ajax({
        url: "/Samagri/ValidateSamagriBhandarDetail",
        data: JSON.stringify(samagriBhandarDetail),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (typeof samagriBhandar !== 'undefined') {
                var data = $.grep(samagriBhandar, function (e) {
                    return e.id != SamagriBhandarId;
                });
                samagriBhandar = data;
            }

            samagriBhandarDetail.Id = parseInt($('#SamagriBhandarId').val());
            samagriBhandarDetail.IsNew = $('#IsNew').is(":checked");
            samagriBhandarDetail.IsActive = $('#SamagriBhandarIsActive').is(":checked");
            samagriBhandarDetail.UnitAbbreviation = UnitMeasurement.find(x => x.Id === parseInt(samagriBhandarDetail.UnitId)).UnitAbbreviation;
            samagriBhandarDetail.UnitDescription = UnitMeasurement.find(x => x.Id === parseInt(samagriBhandarDetail.UnitId)).UnitDescription;
            samagriBhandarDetail.BhandarName = $("#Bhandar option:selected").text();

            samagriBhandar.push(samagriBhandarDetail);

            $('#scrollmodal').modal('hide');
            SetSamagriBhandarList();
        },
        error: function (xhr) {
            alert(xhr.statusText);
            if (xhr.statusText === "Please select Unit Of Measurement.") {
                $("#SamagriBhandarUOM").focus();
            } else if (xhr.statusText === "Please select Bhandar.") {
                $("#Bhandar").focus();
            } else if (xhr.statusText === "Please enter No of unit to be required.") {
                $("#BhandarNoOfUnit").focus();
            }
            hideProgress();
        }
    });
}

function SaveSamagri() {
    showProgress();
    var samagriRequest = {
        Id: parseInt($('#Id').val()),
        Name: $('#SamagriName').val(),
        Description: $('#Description').val(),
        UnitId: parseInt($('#UnitOfMeasurement').val()),
        NoOfUnit: parseFloat($('#NoOfUnit').val()),
        Balance: parseFloat($('#Balance').val()),
        MinStockValidation: parseFloat($('#MinmumAmount').val()),
        CreatedBy: 0,
        IsActive: $('#IsActive').is(":checked"),
        PageNumber: 0,
        PageSize: 0,
        Page: 0,
        Total: 0,
        UnitDescription: '',
        UnitAbbreviation: '',
        SamagriBhandarRequest: samagriBhandar
    }

    $.ajax({
        url: "/Samagri/CreateSamagri",
        data: JSON.stringify(samagriRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert('Samagri saved successfully.');
            hideProgress();
            window.location.href = '/Samagri/Samagri';
        },
        error: function (xhr) {
            alert(xhr.statusText);
            if (xhr.statusText === "Samagri name is require.") {
                $("#SamagriName").focus();
            } else if (xhr.statusText === "Please enter Description.") {
                $("#Description").focus();
            } else if (xhr.statusText === "Please select samagri's Unit Of Measurement.") {
                $("#UnitOfMeasurement").focus();
            } else if (xhr.statusText === "Please enter no of unit.") {
                $("#NoOfUnit").focus();
            }

            hideProgress();
        }
    });
}