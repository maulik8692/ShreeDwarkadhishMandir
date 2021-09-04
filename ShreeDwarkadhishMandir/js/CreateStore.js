var StoreDetail = {};

$(document).ready(function () {
    hideProgress();
    ResetForm();

    $("#Mandir").change(function () {
        //GetAccountHeadForBhet($('#Mandir').val());
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
    var Store = {
        Id: $('#Id').val() == '' ? 0 : parseInt($('#Id').val()),
        MandirId: parseInt($('#Mandir').val()),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        IsActive: $('#IsActive').is(":checked")
    };
    $.ajax({
        url: "/Store/CreateStore",
        data: JSON.stringify(Store),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Store has been saved successfully.");
            hideProgress();

            window.location.href = '/Store/Store';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {

            alert(customErrorMessage);
            if (xhr.status === 406) {
                if (customErrorMessage === "Name is require.") {
                    $('#Name').focus();
                }
            }
            hideProgress();
        },
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

            if (typeof StoreDetail.MandirId !== "undefined" && StoreDetail.MandirId !== 0) {
                $("#Mandir").val(StoreDetail.MandirId);
            }
            else {
                $("#Mandir").val($("#Mandir option:eq(1)").val());
            }
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function ResetForm() {
    GetDetail();
}

function GetDetail() {

    var Id = getUrlParameter('Id');

    $('#Id').val(Id);

    if (typeof Id !== "undefined" && Id !== null && Id !== '') {
        showProgress();
        var Store = {
            Id: $('#Id').val()
        };

        $.ajax({
            url: "/Store/StoreDetail",
            data: JSON.stringify(Store),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                StoreDetail = jsondata;
                setdetail();
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {

                if (xhr.status === 406) {
                    alert(customErrorMessage);
                    if (customErrorMessage === "Name is require.") {
                        $('#Name').focus();
                    }
                }
                hideProgress();
            },
        });
    }
    else {
        $('#IsActive').prop('checked', true);
        GetMandirList();
        hideProgress();
    }
}

function setdetail() {
    $('#Name').val(StoreDetail.Name);
    $('#Description').val(StoreDetail.Description);
    $('#IsActive').prop('checked', StoreDetail.IsActive);
    GetMandirList();
}