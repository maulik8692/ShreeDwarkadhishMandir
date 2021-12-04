var BhandarList = [];
var selectedbhandar = {};
var transactionDetails = [];
var IsGridIntialized = false;

$(document).ready(function () {

    GetDetail();

    $("#Store").change(function () {
        GetBhandar();
    });

    $("#Bhandar").change(function () {
        var BhandarId = parseInt(this.value);
        selectedbhandar = {};
        selectedbhandar = BhandarList[BhandarList.findIndex(item => item.Id === BhandarId)];
        if (typeof selectedbhandar !== "undefined" && selectedbhandar !== null && selectedbhandar.bhandarId !== 0) {
            $("#CurrentBalance").val(selectedbhandar.Balance.toFixed(5) + ' ' + selectedbhandar.UnitAbbreviation);
            selectedbhandar.UnitId = selectedbhandar.UnitId;
            selectedbhandar.CurrentBalance = selectedbhandar.Balance;
        }
        showProgress();
        GetUnitMeasurement();
    });

    $("#SaveItem").click(function (e) {
        SaveItem(true);
    });

    $("#SaveNNewItem").click(function (e) {
        SaveItem(false);
    });

    $("#ResetItem").click(function (e) {
        $('#SamagriTransaction').hide();
        ResetDetail();
    });
});

function GetDetail() {

    var grid = $("#Receipt"), headerRow, rowHight, resizeSpanHeight;

    $("#ReceiptNo").on('keyup change', function () {
        if (this.value.length > 3 || this.value.length === 0) {
            var postData = jQuery('#Receipt').jqGrid("getGridParam", "postData");
            postData.ReceiptNo = jQuery('#ReceiptNo').val().trim(),
                jQuery('#Receipt').jqGrid("setGridParam", { vaishnavId: true });
                jQuery('#Receipt').trigger("reloadGrid", [{ page: 1, current: true }]);
            SetStyle();
        }
    });

    grid.jqGrid
        ({
            url: "/Receipt/GetReceiptList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Receipt No', 'Manorath Name', 'Manorathi', 'Nek', 'Manorath Date', 'Created User', 'View', 'Add Samagri'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'ReceiptNo', index: 'ReceiptNo', align: 'left', sortable: false },
                { name: 'ManorathName', index: 'ManorathName', align: 'left', sortable: false },
                { name: 'ManorathiName', index: 'ManorathiName', align: 'left', sortable: false },
                { name: 'Nek', index: 'Nek', align: 'right', sortable: false, formatter: DisplayNek },
                { name: 'ManorathDate', index: 'ManorathDate', align: 'right', sortable: false, formatter: ManorathDate },
                { name: 'CreatedDisplayName', index: 'CreatedDisplayName', align: 'left', sortable: false },
                { name: 'editoperation', index: 'editoperation', align: 'center', sortable: false, formatter: EditReceipt },
                { name: 'AddSamagri', index: 'AddSamagri', align: 'center', sortable: false, formatter: AddSamagri },
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No receipt found.',
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
        });

    hideProgress();
};

function SetStyle() {
    $('.HeaderButton').hide();

    $('#Receipt').setGridWidth($('#divReceipt').width());
}

function ManorathDate(cellvalue, options, rowObject) {
    var ManorathDate = new Date(parseInt(rowObject.ManorathDate.substr(6)));

    return "<div>" + ManorathDate.format("dd-mmm-yyyy") + "</div>";
}

function DisplayNek(cellvalue, options, rowObject) {

    return "<div>₹ " + parseFloat(rowObject.Nek).toFixed(2) + "</div>";
}

function EditReceipt(cellvalue, options, rowObject) {
    return "<div><a target='_blank' href=/Receipt/ReceiptDetail?Id=" + rowObject.Id +
        "><i class='fa fa-eye'></i></a></div>";
}

function AddSamagri(cellvalue, options, rowObject) {
    if (rowObject.PendingSamagri === false) {
        return "<div id='SamagriToReceipt_" + rowObject.Id + "'><div onclick='AddSamagriToReceipt(" + rowObject.Id +
            ");' data-toggle='modal' data-target='#staticModal'><i class='fa fa-plus-square'></i></div></div>";
    } else {
        return "<div id='SamagriToReceipt_" + rowObject.Id + "'><div onclick='AddSamagriToReceipt(" + rowObject.Id +
            ");'</div></div>";
    }
}

function AddSamagriToReceipt(receiptId) {
    $('#ReceiptId').val(receiptId);
    $('#SamagriTransaction').hide();
    ResetDetail();
}

function ResetDetail() {
    $('.Bhandar').hide();
    $('.UOM').hide();
    $('#StockTransactionQuantity').val('');
    BhandarList = [];
    selectedbhandar = {};
    transactionDetails = [];
    GetStoreList();
}

function GetStoreList() {
    $.ajax({
        url: "/Store/StoreDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Store").empty();
            if (typeof jsondata !== "undefined") {
                var prasadGhar = jsondata.filter(function (i, n) { return i.StoreType === 3 && i.IsActive === true });
                if (typeof prasadGhar !== "undefined") {
                    $("<option />", {
                        val: 0,
                        text: 'Please Select Store'
                    }).appendTo("#Store");

                    $(prasadGhar).each(function () {
                        $("<option />", {
                            val: this.Id,
                            text: this.Name
                        }).appendTo("#Store");
                    });

                    if (prasadGhar.length === 1) {
                        $("#Store").val(prasadGhar[0].Id).trigger('change.select2');
                        $('.Store').hide();
                        GetBhandar();
                    }
                    else {
                        $('.Store').show();
                    }
                }
            }
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

function SaveItem(isfinal) {

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

        if (isfinal) {


            showProgress();
            var purchaseRequest = {};
            purchaseRequest.ReceiptId = parseInt($('#ReceiptId').val());
            purchaseRequest.ItemDetails = transactionDetails;
            $.ajax({
                url: "/Receipt/ReceiptSamagriTransaction",
                data: JSON.stringify(purchaseRequest),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (jsondata) {
                    $('#staticModal').modal('toggle');
                    $('#SamagriToReceipt_' + $('#ReceiptId').val()).hide();
                    transactionDetails = [];
                    $('#ReceiptId').val("");
                    $('#SamagriTransaction').hide();
                    alert("Samagri for receipt has been saved successfully.");

                    ResetDetail();
                },
                error: function (xhr, httpStatusMessage, customErrorMessage) {
                    alert(customErrorMessage);
                    hideProgress();
                },
            });

            hideProgress();
        }
        else {
            $('#SamagriTransaction').show();
            if (IsGridIntialized === false) {
                BindDetailList();
            } else {
                ReloadGrid();
            }

            ResetDetail();
        }
    } else {
        alert($('#Bhandar').text() + ' already added.');
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
                { name: 'Id', index: 'Id', align: 'center', width: 70, sortable: false, formatter: DeleteDetailFormater },
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