var IsGridIntialized = false;
var SamagriDropdownData = [];
var ItemDetails = [];
var SamagriDetails = [];
var BhandarForDropdown = [];
var _SamagriDetail = {};

$(document).ready(function () {
    ResetForm();
    //$("#NewSamagriDetail").click(function (e) {
    //    ResetSamagriDetail();
    //});
    //$("#SaveBhandar").click(function (e) {
    //    SaveSamagriDetails();
    //});

    //$("#KachiSamagri").change(function () {
    //    BindDetailUnitMeasurement();
    //});

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });

    $("#Samagri").change(function () {
        GetDetail(parseInt(this.value), 0, 0);
    });

    $('#OutputQuantity').on('blur', function (e) {
        if ($('#OutputQuantity').val() !== null && $('#OutputQuantity').val().trim() !== '') {
            GetDetail(parseInt($("#Samagri").val()), parseFloat($('#OutputQuantity').val()), parseInt($("#UnitOfMeasurement").val()));
        }
    });
});

function SaveForm() {
    //showProgress();
    var Samagri = {
        BhandarId: parseInt($('#Samagri').val()) > 0 ?
            SamagriDropdownData.filter(function (i, n) { return i.Id === parseInt($('#Samagri').val()) })[0].BhandarId : 0,
        SamagriId: parseInt($('#Samagri').val()),
        StockTransactionQuantity: parseFloat($('#OutputQuantity').val()),
        UnitId: parseInt($('#UnitOfMeasurement').val()),
        StoreId: _SamagriDetail.StoreId,
        Description: $('#Description').val(),
        ItemDetails: ItemDetails
    };
    $.ajax({
        url: "/SamagriTransaction/IssueForSamagri",
        data: JSON.stringify(Samagri),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Issue for Samagri has been saved successfully.");
            hideProgress();

            window.location.href = '/Samagri/Samagri';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (customErrorMessage !== '' && customErrorMessage !== null) {
                alert(customErrorMessage);
            } else {
                alert(SomethingWentWrong)
            }
            hideProgress();
        },
    });
}

function ResetForm() {
    showProgress();
    $('.UOM').hide();
    SamagriDropdownData = [];
    ItemDetails = [];
    SamagriDetails = [];
    BhandarForDropdown = [];
    _SamagriDetail = {};

    GetSamagri();
}

function GetSamagri() {
    $.ajax({
        url: "/Samagri/GetSamagriDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            SamagriDropdownData = jsondata;
            $("#Samagri").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Samagri'
            }).appendTo("#Samagri");

            var filterResult = []
            if (typeof SamagriDropdownData !== "undefined") {
                filterResult = SamagriDropdownData.filter(function (i, n) {
                    return i.IsActive === true;
                })
            }

            $(filterResult).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Samagri");
            });

            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetDetail(Id, Quantity, UnitId) {

    if (typeof Id !== "undefined" && Id !== null && Id !== '' && Id > 0) {
        showProgress();
        var Samagri = {
            Id: Id,
            OutputQuantity: Quantity,
            UnitId: UnitId
        };

        $.ajax({
            url: "/Samagri/SamagriDetail",
            data: JSON.stringify(Samagri),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                console.log("SamagriDetail");
                _SamagriDetail = jsondata;
                if (Quantity > 0) {
                    _SamagriDetail.Quantity = Quantity;
                }
                GetSamagriDetail(_SamagriDetail.Id, _SamagriDetail.Quantity, _SamagriDetail.UnitId);
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                if (xhr.status === 410) {
                    alert(customErrorMessage);
                }
                hideProgress();
            },
        });
    }
}

function GetSamagriDetail(Id, Quantity, UnitId) {

    if (typeof Id !== "undefined" && Id !== null && Id !== '' && Id > 0) {

        showProgress();

        _SamagriDetail.Quantity = Quantity;

        var Samagri = {
            SamagriId: Id,
            Quantity: Quantity,
            UnitId: UnitId
        };

        $.ajax({
            url: "/Samagri/GetSamagriDetailList",
            data: JSON.stringify(Samagri),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                SamagriDetails = jsondata;
                GetBhandar();
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                if (xhr.status === 410) {
                    alert(customErrorMessage);
                }
                hideProgress();
            },
        });
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
            $('.UOM').show();
            setdetail();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            hideProgress();
        }
    });
}

function setdetail() {
    $('#OutputQuantity').val(_SamagriDetail.Quantity.toFixed(5));
    GetUnitMeasurementList();
}

function GetUnitMeasurementList() {
    $.ajax({
        url: "/UnitMeasurement/UnitOfMeasurementDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $('#UnitOfMeasurement').attr("disabled", true);
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

                if (typeof _SamagriDetail.UnitId !== "undefined" && _SamagriDetail.UnitId !== null && _SamagriDetail.UnitId !== 0) {
                    $("#UnitOfMeasurement").val(_SamagriDetail.UnitId);
                }
            }
            setSamagriDetailList();

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function setSamagriDetailList() {
    ItemDetails = [];
    $(SamagriDetails).each(function () {
        var ItemDetail = {}
        ItemDetail.BhandarId = this.BhandarId;
        ItemDetail.UnitId = this.UnitId;
        ItemDetail.StoreId = this.StoreId;
        ItemDetail.CurrentBalance = this.Balance;
        ItemDetail.StockTransactionQuantity = this.Quantity;

        ItemDetail.BhandarName = this.BhandarId > 0 ? BhandarForDropdown[BhandarForDropdown.findIndex(item => item.Id === this.BhandarId)].Name : '';
        ItemDetail.Unit = this.Quantity.toFixed(5) + ' ' + this.UnitAbbreviation;
        ItemDetail.StoreName = this.StoreName;
        ItemDetail.Balance = this.Balance.toFixed(5) + ' ' + ' ' + this.UnitAbbreviation;


        ItemDetails.push(ItemDetail);
    });

    if (IsGridIntialized === false) {
        BindSamagriDetailList();
    } else {
        ReloadGrid();
    }

    hideProgress();
}

function ReloadGrid() {
    var grid = $("#bhandar")
    grid.jqGrid("clearGridData");
    grid.jqGrid('setGridParam', { data: ItemDetails }).trigger("reloadGrid");
}

function BindSamagriDetailList() {
    $("#bhandar").jqGrid("GridUnload");
    var grid = $("#bhandar")
    grid.jqGrid
        ({
            datatype: "local",
            data: ItemDetails,
            hoverrows: false,
            colNames: [
                'Id', 'Bhandar', 'Store Name', 'Require Quantity', 'Balance in Bhandar'
            ],
            colModel: [
                { name: 'BhandarId', index: 'BhandarId', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'BhandarName', index: 'BhandarName', align: 'left', sortable: false },
                { name: 'StoreName', index: 'StoreName', align: 'right', sortable: false },
                { name: 'Unit', index: 'Unit', align: 'right', sortable: false },
                { name: 'Balance', index: 'Balance', align: 'right', sortable: false }
            ],
            pgbuttons: false,
            viewrecords: false,
            pgtext: "",
            pginput: false,
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No bhandar found.',
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

function SetStyle() {
    $('.HeaderButton').hide();

    $('#bhandar').setGridWidth($('#divBhandar').width());
}

function GetStoreList() {
    $.ajax({
        url: "/Store/StoreDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            StoreList = jsondata;

            $("#Samagri").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Samagri'
            }).appendTo("#Samagri");

            var rasoiGharResult = []
            if (typeof StoreList !== "undefined") {
                rasoiGharResult = StoreList.filter(function (i, n) {
                    return i.IsActive === true;
                })
            }

            $(rasoiGharResult).each(function () {
                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Samagri");
            });
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}