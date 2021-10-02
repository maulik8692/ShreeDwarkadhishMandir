var ManorathTypies = [];
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
                    alert('Receipt No ' + parseInt(reportParamObj.Description)+' generated successfully.');
                    ResetForm();
                    //$('#Nek').val('');
                    $("#Description").val(parseInt(reportParamObj.Description)+ 1);
                    $('#ManorathiName').val('Vaishnav');
                    $("#ManorathDate").val(reportParamObj.ManorathDate);
                }
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