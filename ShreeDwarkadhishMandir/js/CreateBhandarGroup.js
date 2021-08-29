var BhandarGroupDetail = {};

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

    $('#IsJewellery').change(function () {
        if (this.checked) {
            $(this).prop("checked", true);
            $('#IsSamagri').attr("disabled", true);
        } else {
            $('#IsSamagri').removeAttr("disabled");
        }
    });

    $('#IsSamagri').change(function () {
        if (this.checked) {
            $(this).prop("checked", true);
            $('#IsJewellery').attr("disabled", true);
        } else {
            $('#IsJewellery').removeAttr("disabled");
        }
    });
});

function SaveForm() {
    showProgress();
    var BhandarGroup = {
        Id: $('#Id').val() == '' ? 0 : parseInt($('#Id').val()),
        MandirId: parseInt($('#Mandir').val()),
        Name: $('#Name').val(),
        GroupCode: $('#GroupCode').val(),
        Description: $('#Description').val(),
        IsJewellery: $('#IsJewellery').is(":checked"),
        IsSamagri: $('#IsSamagri').is(":checked"),
        IsActive: $('#IsActive').is(":checked")
    };
    $.ajax({
        url: "/BhandarGroup/CreateBhandarGroup",
        data: JSON.stringify(BhandarGroup),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Bhandar Group has been saved successfully.");
            hideProgress();

            window.location.href = '/BhandarGroup/BhandarGroup';
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

            if (typeof BhandarGroupDetail.MandirId !== "undefined" && BhandarGroupDetail.MandirId !== 0) {
                $("#Mandir").val(BhandarGroupDetail.MandirId);
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
        var BhandarGroup = {
            Id: $('#Id').val()
        };

        $.ajax({
            url: "/BhandarGroup/BhandarGroupDetail",
            data: JSON.stringify(BhandarGroup),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                BhandarGroupDetail = jsondata;
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
    $('#Name').val(BhandarGroupDetail.Name);
    $('#GroupCode').val(BhandarGroupDetail.GroupCode);
    $('#Description').val(BhandarGroupDetail.Description);
    $('#IsActive').prop('checked', BhandarGroupDetail.IsActive);
    if (BhandarGroupDetail.IsJewellery) {
        $('#IsSamagri').attr("disabled", true);
    }
    if (BhandarGroupDetail.IsSamagri) {
        $('#IsJewellery').attr("disabled", true);
    }
    $('#IsSamagri').prop('checked', BhandarGroupDetail.IsSamagri);
    $('#IsJewellery').prop('checked', BhandarGroupDetail.IsJewellery);
    GetMandirList();
}