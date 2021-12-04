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

function GetBhandarGroupDropdown() {
    $.ajax({
        url: "/BhandarGroup/GetBhandarGroupDropdown",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            $("#BhandarGroup").empty();

            $("<option />", {
                val: 0,
                text: 'Please Select Bhandar Group'
            }).appendTo("#BhandarGroup");

            $(jsondata).each(function () {

                $("<option />", {
                    val: this.Id,
                    text: this.Name
                }).appendTo("#BhandarGroup");
            });

            if (typeof BhandarCategoryDetail.GroupId !== "undefined" && BhandarCategoryDetail.GroupId !== 0) {
                $("#BhandarGroup").val(BhandarCategoryDetail.GroupId);
            }
            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);

            hideProgress();
        }
    });
}

function SaveForm() {
    showProgress();
    
    var bhandarCategory = {
        Id: parseInt($('#Id').val()),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        CategoryCode: $('#CategoryCode').val(),
        GroupId: parseInt($("#BhandarGroup").val()),
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
                BhandarCategoryDetail = jsondata;
                GetBhandarGroupDropdown();
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
    else {
        $('#IsActive').prop('checked', true);
        GetBhandarGroupDropdown();
    }

    hideProgress();
}

function setdetail() {
    $('#Name').val(BhandarCategoryDetail.Name);
    $('#CategoryCode').val(BhandarCategoryDetail.CategoryCode);
    $('#Description').val(BhandarCategoryDetail.Description);
    if (BhandarCategoryDetail.IsDefaultRecord == true) {
        $('.IsActive').hide();
    } else {
        $('.IsActive').show();
    }

    $('#IsActive').prop('checked', BhandarCategoryDetail.IsActive);
}

function ResetForm() {
    $('#Name').val('');
    $('#IsActive').prop('checked', false);
    GetDetail();
}