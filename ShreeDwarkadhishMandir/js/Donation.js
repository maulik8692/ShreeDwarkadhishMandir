var donatedRequest = {}

$(document).ready(function () {
    ResetForm();

    $("#reset").click(function (e) {
        //ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });

    $("#Store").change(function () {
        //scrappedRequest = {};
        donatedRequest.StoreId = parseInt(this.value);
        //showProgress();
        //GetBhandar();
    });

    $("#Bhandar").change(function () {
        donatedRequest.BhandarId = parseInt(this.value);
        selectedbhandar = BhandarList[BhandarList.findIndex(item => item.Id === donatedRequest.BhandarId)];
        if (typeof selectedbhandar !== "undefined" && selectedbhandar !== null && selectedbhandar.bhandarId !== 0) {
            $("#CurrentBalance").val(selectedbhandar.Balance.toFixed(5) + ' ' + selectedbhandar.UnitAbbreviation);
            donatedRequest.UnitId = selectedbhandar.UnitId;
            donatedRequest.CurrentBalance = selectedbhandar.Balance;
        }
        showProgress();
        GetUnitMeasurement();
    });

    GetVaishnav();

});

function SaveForm() {
    showProgress();
    donatedRequest.StockTransactionQuantity = parseFloat($("#DonatedQuantity").val());
    donatedRequest.Description = $("#Description").val();
    donatedRequest.UnitId = $('#UnitOfMeasurement').val();
    donatedRequest.VaishnavId = parseInt($('#VaishnavId').val());
    $.ajax({
        url: "/SamagriTransaction/Donation",
        data: JSON.stringify(donatedRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Bhandar has been donated successfully.");
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
    $("#VaishnavIds").val('');
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
            GetBhandar();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetBhandar() {
    $.ajax({
        url: "/Bhandar/GetBhandarForDropdown",
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
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetVaishnav() {
    $("#VaishnavIds").autocomplete({
        source: function (request, response) {
            var reportParamObj = new Object();
            reportParamObj.sidx = '';
            reportParamObj.sord = '';
            reportParamObj.vaishnavId = $("#VaishnavIds").val();
            reportParamObj.page = 1;
            reportParamObj.rows = 50;

            $.ajax({
                url: "/Vaishnav/VaishnavList",
                data: JSON.stringify(reportParamObj),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8"
            }).done(function (data) {
                if (data.rows) {
                    response($.map(eval(data.rows), function (item) {
                        return {
                            label: item.VaishnavId + " (" + item.FirstName + ")",
                            value: item.VaishnavId,
                            id: item
                        };
                    }));
                }
            });
        },
        response: function (event, ui) {
            if (!ui.content.length) {
                var noResult = { value: "", label: "No vaishnav id matching your request" };
                ui.content.push(noResult);
            }
        },
        select: function (event, ui) {
            //$('.Manorathi').attr("disabled", true);
            //$('#ManorathiName').val(ui.item.id.FirstName);
            $('#VaishnavId').val(ui.item.id.Id);
            //$('#email').val(ui.item.id.Email);
            //var mobileNo = ui.item.id.MobileNo;
            //if ((mobileNo.charAt(0) === '9' || mobileNo.charAt(0) === '1') && mobileNo.length === 10) {
            //    mobileNo = '91' + mobileNo;
            //}
            //$('#MobileNo').val(mobileNo);
        },
        minLength: 2
    });
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