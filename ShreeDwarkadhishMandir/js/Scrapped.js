var BhandarList = [];
var transactionDetails = [];
var selectedbhandar = {};
var detailRequest = {};
var IsGridIntialized = false;

$(document).ready(function () {
    ResetForm();
    PageEvents();
});

function PageEvents() {

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });

    $("#Store").change(function () {
        GetBhandar();
    });

    $("#Bhandar").change(function () {
        detailRequest.BhandarId = parseInt(this.value);
        debugger;
        selectedbhandar = BhandarList[BhandarList.findIndex(item => item.Id === detailRequest.BhandarId)];
        if (typeof selectedbhandar !== "undefined" && selectedbhandar !== null && selectedbhandar.bhandarId !== 0) {
            $("#CurrentBalance").val(selectedbhandar.Balance.toFixed(5) + ' ' + selectedbhandar.UnitAbbreviation);
            detailRequest.UnitId = selectedbhandar.UnitId;
            detailRequest.CurrentBalance = selectedbhandar.Balance;
        }
        showProgress();
        GetUnitMeasurement();
    });

    $("#SaveItem").click(function (e) {
        SaveItem();
        $('#staticModal').modal('toggle');
    });

    $("#SaveNNewItem").click(function (e) {
        SaveItem();
    });

    $("#ResetItem").click(function (e) {
        ResetDetail();
    });

    $("#NewDetail").click(function (e) {
        ResetDetail();
    });

};

function SaveForm() {
    showProgress();
    var scrappedRequest = {};
    scrappedRequest.Description = $("#Description").val();
    scrappedRequest.ItemDetails = transactionDetails;
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
    $('#Description').val()
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
                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Store");
            });

            $('.Store').show();
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

                debugger;

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

function BindDetailList() {
    $("#TransactionDetail").jqGrid("GridUnload");
    var grid = $("#TransactionDetail")
    grid.jqGrid
        ({
            datatype: "local",
            data: transactionDetails,
            hoverrows: false,
            colNames: [
                'Id', 'Store', 'Bhandar', 'Unit', 'Action'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'StoreName', index: 'StoreName', align: 'left', sortable: false },
                { name: 'BhandarName', index: 'BhandarName', align: 'left', sortable: false },
                { name: 'Unit', index: 'Unit', align: 'right', sortable: false },
                { name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: DeleteDetailFormater },
            ],
            pgbuttons: false,
            viewrecords: false,
            pgtext: "",
            pginput: false,
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No detail item found.',
            jsonReader:
            {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            multiselect: false,
            gridComplete: function () {
                SetStyle();
            }
        })
    IsGridIntialized = true;
}

function ReloadGrid() {
    var grid = $("#TransactionDetail")
    grid.jqGrid("clearGridData");
    grid.jqGrid('setGridParam', { data: transactionDetails }).trigger("reloadGrid");
}

function SetStyle() {
    $('.HeaderButton').hide();

    $('#TransactionDetail').setGridWidth($('#divTransactionDetail').width());
}

function DeleteDetailFormater(cellvalue, options, rowObject) {
    return "<div>" +
        "<a onclick='DeleteDetail(" + rowObject.Id + ")'><i class='fa fa-trash'></i></a>"
        + "</div>";
}

function DeleteDetail(Id) {
    if (confirm('Are you sure want to remove this item?')) {
        transactionDetails.splice(transactionDetails.findIndex(item => item.Id === Id), 1);
        ReloadGrid();
    }
}

function ResetDetail() {
    $('.Bhandar').hide();
    $('.UOM').hide();
    $('#PurchaseCost').val('');
    $('#StockTransactionQuantity').val('');
    GetStoreList();
}

function SaveItem() {

    var StoreId = $('#Store').val() !== "undefined" ? parseInt($('#Store').val()) : 0
    var BhandarId = $('#Bhandar').val() !== "undefined" ? parseInt($('#Bhandar').val()) : 0;
    var Quantity = $('#StockTransactionQuantity').val() !== "undefined" ? parseFloat($('#StockTransactionQuantity').val().replace(/,/g, '')) : 0;
    var unitId = $('#UnitOfMeasurement').val() !== "undefined" ? parseInt($('#UnitOfMeasurement').val()) : 0;
    var added = false;
    $.map(transactionDetails, function (e, i) {
        if (e.BhandarId == BhandarId) {
            added = true;
        }
    });
    if (!added) {
        var purchaseDetail = {}
        purchaseDetail.StoreId = StoreId;
        purchaseDetail.StoreName = StoreId > 0 ? $('#Store').find("option:selected").text() : '';
        purchaseDetail.BhandarId = BhandarId;
        purchaseDetail.BhandarName = BhandarId > 0 ? $('#Bhandar').find("option:selected").text() : '';
        purchaseDetail.UnitId = unitId;
        purchaseDetail.CurrentBalance = selectedbhandar.Balance;
        purchaseDetail.StockTransactionQuantity = Quantity;
        purchaseDetail.Unit = Quantity.toFixed(5) + ' ' + (unitId > 0 ? $('#UnitOfMeasurement').find("option:selected").text().split("(")[1].split(")")[0] : '');
        purchaseDetail.Id = (typeof transactionDetails == "undefined" || transactionDetails === null || transactionDetails.length === 0 ?
            0 : transactionDetails.reduce((max, p) => p.Id > max ? p.Id : max, transactionDetails[0].Id)) + 1;

        transactionDetails.push(purchaseDetail);

        var totalAmount = 0;
        $(transactionDetails).each(function () {
            totalAmount += this.Price;
        });

        $('#TransactionAmount').val(totalAmount.toFixed(2));
        if (IsGridIntialized === false) {
            BindDetailList();
        } else {
            ReloadGrid();
        }

        ResetDetail();
    } else {
        alert($('#Bhandar').text() + ' already added.');
    }
}