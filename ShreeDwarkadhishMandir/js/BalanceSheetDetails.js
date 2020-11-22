$(document).ready(function () {
    hideProgress();
    LoadBalanceSheet();
});

function LoadBalanceSheet() {
    var balanceSheetRequest = {
        Id: parseInt($('#Id').val())
    };

    $.ajax({
        url: "/Report/GetBalanceSheetDetails",
        data: JSON.stringify(balanceSheetRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null && jsondata.length > 0) {
                var grouped = _.chain(jsondata).groupBy("GroupName").map(function (offers, GroupName) {
                    // Optionally remove product_id from each record
                    var cleanOffers = _.map(offers, function (it) {
                        return _.omit(it, "GroupName");
                    });
                    return {
                        GroupName: GroupName,
                        Data: cleanOffers
                    };
                }).value();

                $('#GroupName').html(grouped[0].GroupName);

                var annexure = '';
                for (var i = 0; i < grouped.length; i++) {
                    var subGrouped = _.chain(grouped[i].Data).groupBy("AccountGroup").map(function (offers, AccountGroup) {
                        // Optionally remove product_id from each record
                        var cleanOffers = _.map(offers, function (it) {
                            return _.omit(it, "AccountGroup");
                        });
                        return {
                            AccountGroup: AccountGroup,
                            Data: cleanOffers
                        };
                    }).value();

                    //annexure += '<div class="bradius7 bgWhite row m-t-10">' +
                    //    '<div class="col-md-6 col-lg-12 p-t-10 text-center">' +
                    //        '<h4>' + grouped[i].AnnexureName + '</h4><hr>' +
                    //    '</div>';

                    for (var j = 0; j < subGrouped.length; j++) {

                        annexure += '<div class="bradius7 bgWhite row m-t-10">'
                        if (subGrouped.length > 1) {
                            annexure += '<div class="col-md-6 col-lg-12 p-t-10 text-center">' +
                                    '<h5 class="m-t-10">' + subGrouped[j].AccountGroup + '</h5><hr>' +
                                '</div>';
                        }

                        for (var k = 0; k < subGrouped[j].Data.length; k++) {
                            annexure +=
                                '<div class="col-md-6 col-lg-6 p-t-10 text-left">' +
                                    subGrouped[j].Data[k].AccountName +
                                '</div> ' +
                                '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right" >' +
                                    '₹ ' + subGrouped[j].Data[k].BalanceAmount.toFixed(2) +
                                '</div>';
                        }
                        annexure +=
                            '<div class="col-md-6 col-lg-12 p-t-10 text-left">' +
                                '<hr>' +
                            '</div>';
                        annexure +=
                            '<div class="col-md-6 col-lg-6 p-t-10 text-left">' +
                                '<b>Total</b>' +
                            '</div> ' +
                            '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right" >' +
                                '<b>₹ ' + subGrouped[j].Data[0].TotalPerAnnexure.toFixed(2) +
                            '</b></div>';
                        annexure +=
                            '<div class="col-md-6 col-lg-12 p-t-10 text-left">' +
                                '<hr>' +
                            '</div>';
                        //if (subGrouped.length > 1) {
                        annexure += '</div>';
                        //}
                    }

                }
                $('#divBalanceSheetDetails').html(annexure);

            }
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
            }
            hideProgress();
        },
    });
}