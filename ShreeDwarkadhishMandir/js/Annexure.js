$(document).ready(function () {
    hideProgress();
    LoadAnnexure();
});

function LoadAnnexure() {
    showProgress();
    $.ajax({
        url: "/Report/GetAnnexure",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null && jsondata.length > 0) {
                var grouped = _.chain(jsondata).groupBy("AnnexureName").map(function (offers, AnnexureName) {
                    // Optionally remove product_id from each record
                    var cleanOffers = _.map(offers, function (it) {
                        return _.omit(it, "AnnexureName");
                    });
                    return {
                        AnnexureName: AnnexureName,
                        Data: cleanOffers
                    };
                }).value();
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

                    annexure += '<div class="bradius7 bgWhite row m-t-10">' +
                        '<div class="col-md-6 col-lg-12 p-t-10 text-center">' +
                            '<h3>' + grouped[i].AnnexureName + '</h3><hr>' +
                        '</div>';

                    for (var j = 0; j < subGrouped.length; j++) {
                        if (subGrouped.length > 1) {
                            annexure +=
                                '<div class="col-md-6 col-lg-12 p-t-10 text-left">' +
                                    '<h4>' + subGrouped[j].AccountGroup + '</h4><hr>' +
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
                                '₹ ' + subGrouped[j].Data[0].TotalPerAnnexure.toFixed(2) +
                            '</div>';
                        annexure +=
                            '<div class="col-md-6 col-lg-12 p-t-10 text-left">' +
                                '<hr>' +
                            '</div>';
                    }
                    annexure += '</div>';
                    
                }
                $('#divAnnexure').html(annexure);
            }

            hideProgress();
        },
        error: function (xhr, httpStatusMessage, customErrorMessage) {
            if (xhr.status === 410) {
                alert(customErrorMessage);
            }
            hideProgress();
        },
    });
}