var BhandarCategoryDetail = {};

$(document).ready(function () {
    ResetForm();
    $("#reset").click(function (e) {
        ResetForm();
    });

    $("#Save").click(function (e) {
        SaveForm();
    });
});

function SaveForm() {
    showProgress();
    var bhandarCategory = {
        Id: parseInt($('#Id').val()),
        Name: $('#Name').val(),
        IsActive: $('#IsActive').is(":checked")
    };

    $.ajax({
        url: "/BhandarCategory/CreateBhandarCategory",
        data: JSON.stringify(bhandarCategory),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            alert("Bhandar category has been saved successfully.");
            hideProgress();
            
            window.location.href = '/BhandarCategory/BhandarCategory';
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            alert(customErrorMessage);
            hideProgress();
        },
    });
}

function GetDetail() {
    var BhandarCategoryId = getUrlParameter('Id');
    $('#Id').val(BhandarCategoryId);
    
    if (typeof BhandarCategoryId !== "undefined" && BhandarCategoryId !== null && BhandarCategoryId !== '') {
        showProgress();
        var bhandarCategory = {
            Id: parseInt($('#Id').val()),
            Name: '',
            IsActive: false
        };

        $.ajax({
            url: "/BhandarCategory/BhandarCategoryDetail",
            data: JSON.stringify(bhandarCategory),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {
                BhandarCategoryDetail  = jsondata;
                setdetail();

            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                if (xhr.status === 410) {
                    alert(customErrorMessage);
                }
                hideProgress();
            },
        });
    }

    hideProgress();
}

function setdetail() {
    $('#Name').val(BhandarCategoryDetail.Name);
    $('#IsActive').prop('checked', BhandarCategoryDetail.IsActive);
}

function ResetForm() {
    $('#Name').val('');
    $('#IsActive').prop('checked', false);
    GetDetail();
}