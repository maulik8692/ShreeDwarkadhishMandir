$(document).ready(function () {
    ResetForm();
    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm(false);
    });
    $("#SaveNew").click(function (e) {
        SaveForm(true);
    });
});

function UnitOfMeasurementDropdown() {
    $.ajax({
        url: "/UnitMeasurement/UnitOfMeasurementDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#MainUnit").empty();
            $("#ConversionUnit").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Unit Of Measurement'
            }).appendTo("#MainUnit");

            $("<option />", {
                val: 0,
                text: 'Please Select Unit Of Measurement'
            }).appendTo("#ConversionUnit");

            var filterResult = jsondata.filter(function (i, n) {
                return i.IsActive === true;
            })
            $(filterResult).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.UnitDescription + ' (' + this.UnitAbbreviation+')'
                }).appendTo("#MainUnit");

                $("<option />", {
                    val: this.Id,
                    text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
                }).appendTo("#ConversionUnit");
            });

            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function ResetForm() {
    //$("#MainUnit").empty();
    //$("#ConversionUnit").empty();
    UnitOfMeasurementDropdown();
}

function SaveForm(IsNew) {
    showProgress();
    var unitConversion = {
        Id: 0,
        MainUnitId: parseInt($("#MainUnit").val()),
        ConversionUnitId: parseInt($("#ConversionUnit").val()),
        MainUnitQuantity: 1,
        ConversionUnitQuantity: parseFloat($('#ConversionUnitQuantity').val().replace(/,/g, '')),
    };

    $.ajax({
        url: "/UnitConversion/CreateUnitConversion",
        data: JSON.stringify(unitConversion),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("unit Conversion has been saved successfully.");
            hideProgress();

            if (!IsNew) {
                window.location.href = '/UnitConversion/UnitConversion';
            } else {
                $('#Id').val("0");
                ResetForm();
            }
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            alert(customErrorMessage);
            hideProgress();
        },
    });
}