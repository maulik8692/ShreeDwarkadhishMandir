var BhandarList = [];
var selectedbhandar = {};
var scrappedRequest = {}
$(document).ready(function () {
    ResetForm();

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });

    $("#Store").change(function () {
        scrappedRequest = {};
        scrappedRequest.StoreId = parseInt(this.value);
        showProgress();
        GetBhandar();
    });

    $("#Bhandar").change(function () {
        scrappedRequest.BhandarId = parseInt(this.value);
        selectedbhandar = BhandarList[BhandarList.findIndex(item => item.Id === scrappedRequest.BhandarId)];
        if (typeof selectedbhandar !== "undefined" && selectedbhandar !== null && selectedbhandar.bhandarId !== 0) {
            //$("#UnitOfMeasurement").val(unitId).trigger('change.select2');;
            $("#CurrentBalance").val(selectedbhandar.Balance.toFixed(5) + ' ' + selectedbhandar.UnitAbbreviation);
            scrappedRequest.UnitId = selectedbhandar.UnitId;
            scrappedRequest.CurrentBalance = selectedbhandar.Balance;
        }
        showProgress();
        GetUnitMeasurement();
    });
});

function SaveForm() {
    showProgress();
    scrappedRequest.StockTransactionQuantity = parseFloat($("#ScrappedQuantity").val());
    scrappedRequest.Description = $("#Description").val();
    $.ajax({
        url: "/SamagriTransaction/Scrapped",
        data: JSON.stringify(scrappedRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Bhandar has been scrapped successfully.");
            hideProgress();

            window.location.href = '/SamagriTransaction/SamagriTransaction';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            alert(customErrorMessage);
            hideProgress();
        },
    });
}

function ResetForm() {
    showProgress();
    $(".Bhandar").hide();
    $(".UOM").hide();
    GetStoreList();
    hideProgress();
}

function GetStoreList() {
    $.ajax({
        url: "/Store/StoreDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Store").empty();
            $("<option />", {
                val: 0,
                text: 'Please Select Store'
            }).appendTo("#Store");

            $(jsondata).each(function () {
                Store
                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Store");
            });

            $('.Store').show();
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetBhandar() {
    var storeId = $('#Store').val() !== "undefined" ? parseInt($('#Store').val()) : 0
    if (storeId > 0) {
        $.ajax({
            url: "/Bhandar/GetBhandarForDropdown",
            data: JSON.stringify({ StoreId: storeId }),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                $("#Bhandar").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select Bhandar'
                }).appendTo("#Bhandar");

                var filterResult = []
                filterResult = jsondata.filter(function (i, n) {
                    return i.IsActive === true;
                })

                BhandarList = filterResult;
                $(filterResult).each(function () {

                    $("<option />", {
                        val: this.Id,
                        text: this.Name
                    }).appendTo("#Bhandar");
                });

                $(".Bhandar").show();
                hideProgress();
            },
            error: function (xhr) {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

                hideProgress();
            }
        });
    }
}

function GetUnitMeasurement() {

    var bhandarId = $('#Bhandar').val() !== "undefined" ? parseInt($('#Bhandar').val()) : 0
    if (bhandarId > 0) {
        $.ajax({
            url: "/UnitMeasurement/UnitOfMeasurementDropdown",
            data: JSON.stringify({ bhandarId: bhandarId }),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                $("#UnitOfMeasurement").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select UnitOfMeasurement'
                }).appendTo("#UnitOfMeasurement");

                if (typeof jsondata !== "undefined") {
                    $(jsondata).each(function () {
                        $("<option />", {
                            val: this.Id,
                            text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
                        }).appendTo("#UnitOfMeasurement");
                    });
                }

                $("#UnitOfMeasurement").val(selectedbhandar.UnitId).trigger('change.select2');

                $(".UOM").show();
                hideProgress();
            },
            error: function (xhr) {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

                hideProgress();
            }
        });
    }
}