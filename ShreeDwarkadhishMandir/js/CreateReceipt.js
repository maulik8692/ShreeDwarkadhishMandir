var ManorathTypies = [];
var BhandarList = [];
var selectedbhandar = {};
var transactionDetails = [];
var IsGridIntialized = false;

$(document).ready(function () {
    $("#ManorathDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
        //minDate: 0
    });

    $("#ChequeDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
    });

    $('.OnSave').keypress(function (e) {
        var keycode = (e.keyCode ? e.keyCode : e.which);
        if (keycode == '13') {
            SaveForm(false);
        }
    });

    $("#VaishnavIds").on('keyup change', function () {
        if (this.value.length === 0) {
            $('.Manorathi').attr("disabled", false);
            $('#ManorathiName').val('Vaishnav');
            $('#email').val('');
            $('#PhoneNo').val('');
        }
    });

    $("#Mandir").change(function () {
        GetAccountHeadForBhet($('#Mandir').val());
    });

    $("#ManorathType").change(function () {
        ManorathTypeCHanged();
    });

    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm(false);
    });

    $("#Saveprint").click(function (e) {
        SaveForm(true);
    });

    $(".Nek").click(function (e) {

        var totalNek = $('#Nek').val() !== '' && $('#Nek').val() !== '₹ ' ? parseFloat($('#Nek').val().substr(2).replace(/,/g, '')) : 0;
        console.log(totalNek);
        totalNek = totalNek + parseFloat($(this).text());

        console.log(totalNek);

        $('#Nek').val(totalNek)
    });

    $('input[type=radio][name=TransactionType]').change(function () {
        if (this.value === 'Cash') {
            $('.Cheque').hide();
        }
        else if (this.value === 'Cheque') {
            $('.Cheque').show();
        }

        $('#ChequeBank').val('');
        $('#ChequeBranch').val('');
        $('#ChequeNumber').val('');
        $('#ChequeDate').val('');

    });

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

    $("#NewDetail").click(function (e) {
        ResetDetail();
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

    GetVaishnav();

    ResetForm();
});

function ManorathTypeCHanged() {

    if (typeof ManorathTypies.find(x => x.Id === parseInt($('#ManorathType').val())) !== 'undefined') {
        $('#Nek').prop('readonly', false);
        $('#Nek').val('');
        var ManorathType = ManorathTypies.find(x => x.Id === parseInt($('#ManorathType').val())).ManorathType;

        $('#ChequeBank').val('');
        $('#ChequeBranch').val('');
        $('#ChequeNumber').val('');
        $('#ChequeDate').val('');

        if (ManorathType === 4) {
            $('.salabadi').show();
            $('#Cash').attr("disabled", true);
            $('#Cheque').prop("checked", true);
            $('.Cheque').show();

        } else {
            $('#ManorathMonth').val('');
            $('#ManorathPaksh').val('');
            $('#ManorathTithi').val('');
            $('.salabadi').hide();
            $('#Cash').prop("checked", true);
            $('.Cheque').hide();
        }

        var Nyochavar = ManorathTypies.find(x => x.Id === parseInt($('#ManorathType').val())).Nyochhawar;
        $('#Manorath').val(ManorathType);
        if (Nyochavar > 0) {
            $('#Nek').val(Nyochavar);
            //$('#Nek').prop('readonly', true);
            $(".Nek").hide();

        }
        else {
            $(".Nek").show();

        }
    } else {
        alert("Receipt configuration is missing. Please do it first.");
        window.location.replace("/Configuration/Configuration");
    }
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
            $('.Manorathi').attr("disabled", true);
            $('#ManorathiName').val(ui.item.id.FirstName);
            $('#VaishnavId').val(ui.item.id.Id);
            $('#email').val(ui.item.id.Email);
            var mobileNo = ui.item.id.MobileNo;
            if ((mobileNo.charAt(0) === '9' || mobileNo.charAt(0) === '1') && mobileNo.length === 10) {
                mobileNo = '91' + mobileNo;
            }
            $('#MobileNo').val(mobileNo);
        },
        minLength: 2
    });
}

function GetMandirList() {

    $.ajax({
        url: "/Mandir/MandirList",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#Mandir").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Mandir'
            }).appendTo("#Mandir");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#Mandir");
            });

            $("#Mandir").val($("#Mandir option:eq(1)").val());

            GetAccountHeadForBhet($("#Mandir option:eq(1)").val());
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function GetAccountHeadForBhet(mandirId) {
    showProgress();

    var reportParamObj = new Object();
    reportParamObj.MandirId = parseInt(mandirId);
    reportParamObj.AccountId = 0;

    $.ajax({
        url: "/Manorath/ManorathDropdown/",
        data: JSON.stringify(reportParamObj),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#ManorathType").empty();

            ManorathTypies = jsondata;

            $("<option />", {
                val: 0,
                text: 'Please Select Manorath for receipt transaction'
            }).appendTo("#ManorathType");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.ManorathName
                }).appendTo("#ManorathType");
            });

            CheckReceiptConfiguration();

        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function ResetForm() {
    GetMandirList();

    $('input[name="TransactionType"]').prop('checked', false);
    $('#ManorathMonth').val('');
    $('#ManorathPaksh').val('');
    $('#ManorathTithi').val('');
    $("#VaishnavIds").val('');
    $('.salabadi').hide();
    $('#Nek').val('');
    $('#ManorathiName').val('Vaishnav');
    $('#email').val('');
    $('#PhoneNo').val('');
    $(".DarshanDate").datepicker().datepicker("setDate", new Date());
    $(".Nek").hide();
    $('#Cash').prop("checked", true);
    $('#ChequeBank').val('');
    $('#ChequeBranch').val('');
    $('#ChequeNumber').val('');
    $('#ChequeDate').val('');
    $('.Cheque').hide();

    BhandarList = [];
    selectedbhandar = {};
    transactionDetails = [];
    $('.Bhandar').hide();
    $('.UOM').hide();
    $('#StockTransactionQuantity').val('');
    $('#SamagriTransaction').hide();
}

function SaveForm(allowprint) {
    showProgress();
    var reportParamObj = new Object();
    reportParamObj.Nek = parseFloat($('#Nek').val().substr(2).replace(/,/g, ''));
    reportParamObj.ManorathId = parseInt($("#ManorathType").val());
    reportParamObj.ManorathType = parseInt($("#Manorath").val());
    reportParamObj.TrasactionType = $('input[name=TransactionType]:checked').val();
    reportParamObj.VaishnavId = $("#VaishnavId").val();
    reportParamObj.ManorathiName = $("#ManorathiName").val();
    reportParamObj.Email = $("#email").val();
    reportParamObj.MobileNo = $("#MobileNo").val();
    reportParamObj.ManorathDate = $("#ManorathDate").val();
    reportParamObj.ChequeBank = $("#ChequeBank").val();
    reportParamObj.ChequeBranch = $("#ChequeBranch").val();
    reportParamObj.ChequeNumber = $("#ChequeNumber").val();
    reportParamObj.ChequeDate = $("#ChequeDate").val();
    reportParamObj.ChequeStatus = parseInt($("#ChequeStatus").val());

    reportParamObj.ManorathTithi = $("#ManorathTithi").val();
    reportParamObj.ManorathTithiMaas = $("#ManorathMonth").val();
    reportParamObj.ManorathTithiPaksh = $("#ManorathPaksh").val();
    reportParamObj.Description = $("#Description").val();
    reportParamObj.ItemDetails = transactionDetails;
    
    $.ajax({
        url: "/Receipt/SaveManorathReceipt",
        data: JSON.stringify(reportParamObj),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null) {
                
                if (allowprint) {

                    var url = '/Receipt/ReceiptDetail?Id=' + jsondata.Id;
                    var win = window.open(url, '_blank');
                    if (win) {
                        //Browser has allowed it to be opened
                        win.focus();
                    } else {
                        //Browser has blocked it
                        alert('Please allow popups for this website');
                    }

                } else {
                    alert('Receipt generated successfully.');
                    //alert('Receipt No ' + parseInt(reportParamObj.Description) + ' generated successfully.');
                   
                    ////$('#Nek').val('');
                    //$("#Description").val(parseInt(reportParamObj.Description) + 1);
                    //$('#ManorathiName').val('Vaishnav');
                    //$("#ManorathDate").val(reportParamObj.ManorathDate);
                }
                ResetForm();
                //window.location.href = '/Receipt/Receipt';
            }
            hideProgress();
            //Reset();
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);

                if (customErrorMessage === "Please select vaishnav.") {
                    $("#VaishnavId").focus();
                }
                else if (customErrorMessage === "Please select manorath tithi maas.") {
                    $("#ManorathMonth").focus();
                }
                else if (customErrorMessage === "Please select manorath tithi paksh.") {
                    $("#ManorathPaksh").focus();
                }
                else if (customErrorMessage === "Please select manorath tithi.") {
                    $("#ManorathTithi").focus();
                }
                else if (customErrorMessage === "Please enter Nyochavar.") {
                    $("#Nek").focus();
                }
                else if (customErrorMessage === "Please provie Cheque Bank name.") {
                    $("#ChequeBank").focus();
                }
                else if (customErrorMessage === "Please provie Cheque Branch name.") {
                    $("#ChequeBranch").focus();
                }
                else if (customErrorMessage === "Please provie Cheque Number.") {
                    $("#ChequeNumber").focus();
                }
                else if (customErrorMessage === "Please provie Cheque Date.") {
                    $("#ChequeDate").focus();
                }
            }
            else {
                alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            }
            hideProgress();
        }
    });
}

function CheckReceiptConfiguration() {
    var reportParamObj = new Object();
    reportParamObj.keyName = 'DefaultReceiptId';

    $.ajax({
        url: "/Configuration/GetConfigurationByName",
        data: JSON.stringify(reportParamObj),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null) {
                $('#ManorathType').val(parseInt(jsondata[0].KeyValue));
                ManorathTypeCHanged();
            }
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            hideProgress();
        }
    });
}

function ResetDetail() {
    $('.Bhandar').hide();
    $('.UOM').hide();
    $('#StockTransactionQuantity').val('');
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
            $('#staticModal').modal('toggle');
        }

        $('#SamagriTransaction').show();
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