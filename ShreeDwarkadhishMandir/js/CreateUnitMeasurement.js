var UnitMeasurementDetail = {};

$(document).ready(function () {
    ResetForm();
    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });
});

function SaveForm() {
    showProgress();
    var unitMeasurement = {
        Id: parseInt($('#Id').val()),
        UnitAbbreviation: $('#UnitAbbreviation').val(),
        UnitDescription: $('#UnitDescription').val(),
        IsActive: $('#IsActive').is(":checked")
    };

    $.ajax({
        url: "/UnitMeasurement/CreateUnitMeasurement",
        data: JSON.stringify(unitMeasurement),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Unit Measurement has been saved successfully.");
            hideProgress();

            window.location.href = '/UnitMeasurement/UnitMeasurement';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            alert(customErrorMessage);
            hideProgress();
        },
    });
}

function GetDetail() {
    var UnitMeasurementId = getUrlParameter('Id');
    $('#Id').val(UnitMeasurementId);

    if (typeof UnitMeasurementId !== "undefined" && UnitMeasurementId !== null && UnitMeasurementId !== '') {
        showProgress();
        var unitMeasurement = {
            Id: parseInt($('#Id').val()),
            UnitAbbreviation: '',
            UnitDescription: '',
            IsActive: false
        };

        $.ajax({
            url: "/UnitMeasurement/UnitMeasurementDetail",
            data: JSON.stringify(unitMeasurement),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                UnitMeasurementDetail = jsondata;
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

    hideProgress();
}

function setdetail() {
    $('#UnitAbbreviation').val(UnitMeasurementDetail.UnitAbbreviation);
    $('#UnitDescription').val(UnitMeasurementDetail.UnitDescription);
    $('#IsActive').prop('checked', UnitMeasurementDetail.IsActive);
}

function ResetForm() {
    $('#UnitAbbreviation').val('');
    $('#UnitDescription').val('');
    $('#IsActive').prop('checked', false);
    GetDetail();
}