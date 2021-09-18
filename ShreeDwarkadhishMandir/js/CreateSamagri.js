var UnitMeasurement = [];
var BhandarForDropdown = [];
var SamagriDetail = {};
var SamagriDetails = [];
var IsGridIntialized = false;

$(document).ready(function () {
    ResetForm();
    $("#NewSamagriDetail").click(function (e) {
        ResetSamagriDetail();
    });
    $("#SaveBhandar").click(function (e) {
        SaveSamagriDetails();
    });

    $("#KachiSamagri").change(function () {
        BindDetailUnitMeasurement();
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });
});

function SaveForm() {
    showProgress();
    var Samagri = {
        Id: parseInt($('#Id').val()),
        BhandarId: parseInt($('#Samagri').val()),
        Recipe: $('#Recipe').val(),
        Description: $('#Description').val(),
        IsActive: $('#IsActive').is(":checked"),
        OutputQuantity: parseFloat($('#OutputQuantity').val()),
        OutputUnitId: parseInt($('#UnitOfMeasurement').val()),
        SamagriDetailRequest: SamagriDetails
    };

    $.ajax({
        url: "/Samagri/CreateSamagri",
        data: JSON.stringify(Samagri),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Samagri has been saved successfully.");
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

    //$('#SamagriName').val('');
    //$('#Description').val('');
    //$('#Balance').val('');
    //$('#NoOfUnit').val('');
    //$('#MinmumAmount').val('');

    //GetSamagriDetail();

    GetDetail();
}

function GetDetail() {

    var Id = getUrlParameter('Id');

    $('#Id').val(Id);

    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        showProgress();
    }
    else {

        $('#IsActive').prop('checked', true);
        //$('#Name').val();
        //$('#Description').val();
        //$('#Balance').val();
        //$('#AllowToChangeBalance').val(true);
        //$('#IsActive').prop('checked', BhandarDetail.IsActive);
        //GetUnitMeasurementList();
        //GetStoreList();
        GetBhandar();

        hideProgress();
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
            GetUnitMeasurementList();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function GetUnitMeasurementList() {
    $.ajax({
        url: "/UnitMeasurement/UnitOfMeasurementDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            UnitMeasurement = jsondata;
            BindSamagriDropdown(0, 0);
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function BindSamagriDropdown(MainBhandarId, Id) {
    $("#Samagri").empty();

    $("<option />", {
        val: 0,
        text: 'Please Select Bhandar'
    }).appendTo("#Samagri");

    var filterResult = []
    if (typeof BhandarForDropdown !== "undefined") {
        if (typeof Id !== "undefined" && Id !== null && Id !== 0) {
            filterResult = BhandarForDropdown.filter(function (i, n) {
                return i.IsActive === true && i.IsSamagri === true;
            })
        } else {
            filterResult = BhandarForDropdown.filter(function (i, n) {
                return i.IsSamagri === true;
            })
        }
    }

    $(filterResult).each(function () {

        $("<option />", {
            val: this.Id,
            text: this.Name
        }).appendTo("#Samagri");
    });

    if (typeof MainBhandarId !== "undefined" && MainBhandarId !== null && MainBhandarId !== 0) {
        $("#Samagri").val(MainBhandarId);
        $('#Samagri').attr("disabled", true);
    }

    BindOutputUnitMeasurement();
}

function BindOutputUnitMeasurement(MainUnitId) {
    $("#UnitOfMeasurement").empty();

    $("<option />", {
        val: 0,
        text: 'Please Select UnitOfMeasurement'
    }).appendTo("#UnitOfMeasurement");

    if (typeof UnitMeasurement !== "undefined") {
        $(UnitMeasurement).each(function () {
            $("<option />", {
                val: this.Id,
                text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
            }).appendTo("#UnitOfMeasurement");
        });

        if (typeof MainUnitId !== "undefined" && MainUnitId !== null && MainUnitId !== 0) {
            $("#UnitOfMeasurement").val(MainUnitId);
            $('#UnitOfMeasurement').attr("disabled", true);
        }
    }
}

function ResetSamagriDetail() {
    BindSamagriDetailDropdown();
    $("#UOM").empty();
    $(".UOM").hide();
    $('#Quantity').val('');
}

function BindSamagriDetailDropdown() {
    $("#KachiSamagri").empty();

    $("<option />", {
        val: 0,
        text: 'Please Select Bhandar'
    }).appendTo("#KachiSamagri");

    var filterResult = []
    if (typeof BhandarForDropdown !== "undefined") {
        filterResult = BhandarForDropdown.filter(function (i, n) {
            return i.IsActive === true && i.IsBhandar === true;
        })
    }

    $(filterResult).each(function () {

        $("<option />", {
            val: this.Id,
            text: this.Name
        }).appendTo("#KachiSamagri");
    });
}

function BindDetailUnitMeasurement() {

    var bhandarId = $('#KachiSamagri').val() !== "undefined" ? parseInt($('#KachiSamagri').val()) : 0
    if (bhandarId > 0) {
        $.ajax({
            url: "/UnitMeasurement/UnitOfMeasurementDropdown",
            data: JSON.stringify({ bhandarId: bhandarId }),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                $("#UOM").empty();

                $("<option />", {
                    val: 0,
                    text: 'Please Select UnitOfMeasurement'
                }).appendTo("#UOM");

                if (typeof jsondata !== "undefined") {
                    $(jsondata).each(function () {
                        $("<option />", {
                            val: this.Id,
                            text: this.UnitDescription + ' (' + this.UnitAbbreviation + ')'
                        }).appendTo("#UOM");
                    });
                }

                $(".UOM").show();
            },
            error: function (xhr) {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

                hideProgress();
            }
        });
    }
}

function SaveSamagriDetails(addMore) {
    var added = false;
    var bhandarId = $('#KachiSamagri').val() !== "undefined" ? parseInt($('#KachiSamagri').val()) : 0
    var unitId = $('#UOM').val() !== "undefined" ? parseInt($('#UOM').val()) : 0;
    var Quantity = $('#Quantity').val() !== "undefined" ? parseFloat($('#Quantity').val()) : 0;
    $.map(SamagriDetails, function (e, i) {
        if (e.BhandarId == bhandarId) {
            added = true;
        }
    });
    if (!added) {
        SamagriDetail = {};
        SamagriDetail.BhandarId = bhandarId;
        SamagriDetail.UnitId = unitId;
        SamagriDetail.BhandarName = unitId > 0 ? $('#KachiSamagri').find("option:selected").text() : '';
        SamagriDetail.Unit = Quantity.toFixed(5) + ' ' + (unitId > 0 ? $('#UOM').find("option:selected").text().split("(")[1].split(")")[0] : '');
        SamagriDetail.Quantity = Quantity;
        SamagriDetail.CanDelete = true;
        SamagriDetail.IsNew = true;
        //(typeof SamagriDetails == "undefined" || SamagriDetails === null || SamagriDetails.length === 0
        //    ||
        //    typeof SamagriDetails.Id == "undefined" || SamagriDetails.Id === null || SamagriDetails.Id === 0
        //    || isNaN(SamagriDetails.Id) === true ?
        //    true : false);

        SamagriDetails.Id = (typeof SamagriDetails == "undefined" || SamagriDetails === null || SamagriDetails.length === 0 ?
            0 : SamagriDetails.reduce((max, p) => p.Id > max ? p.Id : max, SamagriDetails[0].Id)) + 1;

        //    SamagriDetail.IsNew === true ? SamagriDetails.Id :
        //((typeof SamagriDetails == "undefined" || SamagriDetails === null || SamagriDetails.length === 0 ?
        //    0 : SamagriDetails.reduce((max, p) => p.Id > max ? p.Id : max, SamagriDetails[0].Id)) + 1);

        SamagriDetails.push(SamagriDetail);
        if (addMore) {
            ResetSamagriDetail();
        } else {
            $('#staticModal').modal('toggle');
        }


        if (IsGridIntialized === false) {
            BindSamagriDetailList();
        } else {
            ReloadGrid();
        }


    } else {
        alert($('#KachiSamagri').text() + ' already added.');
    }
}

function ReloadGrid() {
    var grid = $("#bhandar")
    grid.jqGrid("clearGridData");
    grid.jqGrid('setGridParam', { data: SamagriDetails }).trigger("reloadGrid");
}

function BindSamagriDetailList() {
    $("#bhandar").jqGrid("GridUnload");
    var grid = $("#bhandar")
    grid.jqGrid
        ({
            datatype: "local",
            data: SamagriDetails,
            hoverrows: false,
            colNames: [
                'Id', 'Bhandar', 'Unit', 'Action'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'BhandarName', index: 'BhandarName', align: 'left', sortable: false },
                { name: 'Unit', index: 'Unit', align: 'left', sortable: false },
                { name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: DeleteSamagriDetailFormater },
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

function DeleteSamagriDetailFormater(cellvalue, options, rowObject) {
    return "<div>" +
        (rowObject.CanDelete ?
            "<a onclick='DeleteSamagriDetail(" + rowObject.Id + ")'><i class='fa fa-trash'></i></a>"
            : "")
        + "</div>";
}

function DeleteSamagriDetail(Id) {
    if (confirm('Are you sure want to remove this samagri?')) {
        SamagriDetails.splice(SamagriDetails.findIndex(item => item.Id === Id), 1);
        ReloadGrid();
    }
}