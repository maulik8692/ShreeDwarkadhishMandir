$(document).ready(function () {
    GetDetail();
});

function GetDetail() {
    var receiptId = getUrlParameter('Id');

    if (typeof receiptId !== "undefined" && receiptId !== null && receiptId !== '') {
        var receiptRequest = {
            Id: parseInt(receiptId)
        };

        $.ajax({
            url: "/Receipt/ReceiptDetail",
            data: JSON.stringify(receiptRequest),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (jsondata) {

                var createdOn = new Date(parseInt(jsondata.CreatedOn.substr(6)));
                var ManorathDate = new Date(parseInt(jsondata.ManorathDate.substr(6)));

                $('#ReceiptCreatedDate').html(createdOn.format("dd-mmm-yyyy"));

                $('#ImageUrl').attr("src", jsondata.ImageUrl);
                $('#MandirName').html(jsondata.MandirName);
                $('#MandirAddress').html(jsondata.MandirAddress);
                $('#ReceiptNo').html(jsondata.ReceiptNo);
                $('#ManorathName').html(jsondata.ManorathName);
                $('#MandirHeader').html(jsondata.MandirHeader);
                $('#GurudevName').html(jsondata.GurudevName);
                $('#RegistrationNumber').html(jsondata.RegistrationNumber !== null && jsondata.RegistrationNumber !== '' ? 'Registration No: ' + jsondata.RegistrationNumber : '');
                if (jsondata.ManorathiName !== null && jsondata.ManorathiName !== '') {
                    $('#ManorathiName').html(' by Shree ' + jsondata.ManorathiName);
                }

                $('#ManorathDate').html(' on date ' + ManorathDate.format("dd-mmm-yyyy"));

                $('#Nek').html('₹ ' + parseFloat(jsondata.Nek).toFixed(2));
                $('#TotalNek').html('₹ ' + parseFloat(jsondata.Nek).toFixed(2));
            },
            error: function (xhr, httpStatusMessage, customErrorMessage) {
                if (xhr.status === 410) {
                    alert(customErrorMessage);
                }
                hideProgress();
            },
        });
    }
    //receiptRequest
    //$('#SupplierId').val(SupplierId);
}