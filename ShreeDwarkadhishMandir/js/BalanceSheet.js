$(document).ready(function () {
    hideProgress();
    LoadBalanceSheet();
});

function LoadBalanceSheet() {
    $.ajax({
        url: "/Report/GetBalanceSheet",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null && jsondata.length > 0) {
                $('#FinancialYear').html(jsondata[0].FinancialYear)
                $('#divLiabilities').html('');
                $('#divAssets').html('');
                $('#TotalLeft').html('');
                $('#TotalRight').html('');

                var Liabilities = jsondata.filter(x => x.NatureOfGroup === 'Liabilities');
                if (Liabilities !== null && Liabilities.length > 0) {
                    var grouped = _.chain(Liabilities).groupBy("GroupName").map(function (offers, GroupName) {
                        // Optionally remove product_id from each record
                        var cleanOffers = _.map(offers, function (it) {
                            return _.omit(it, "GroupName");
                        });
                        return {
                            GroupName: GroupName,
                            Data: cleanOffers
                        };
                    }).value();
                        
                    if (grouped !== null && grouped.length > 0) {
                        for (var j = 0; j < grouped.length; j++) {
                            var GroupName =
                                '<div class="col-md-6 col-lg-12 p-l-25 p-t-10 text-left"><b><a target="_blank" href="/Report/BalanceSheetDetails?GroupId=' + grouped[j].Data[0].Id + '">'
                                + grouped[j].GroupName +
                                '</a></b></div>';
                            $('#divLiabilities').append(GroupName);
                            for (var i = 0; i < grouped[j].Data.length; i++) {
                                var Liability =
                                    '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left">'
                                    + grouped[j].Data[i].AccountGroup +
                                    '</div>' +
                                    '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                                    + '₹ ' + grouped[j].Data[i].Credit.toFixed(2) +
                                    '</div>';
                                $('#divLiabilities').append(Liability);
                            }
                        }

                    }
                }

                var ProfitLoss = jsondata.filter(x => x.NatureOfGroup === 'ProfitLoss');
                if (ProfitLoss !== null && ProfitLoss.length > 0) {
                    if (ProfitLoss[0].Credit > 0) {
                        for (var i = 0; i < ProfitLoss.length; i++) {
                            var Loss =
                                '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left"><b><a target="_blank" href="/Report/IncomeExpenditure">'
                                + ProfitLoss[i].GroupName +
                                '</a></b></div>' +
                                '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                                + '₹ ' + ProfitLoss[i].Credit.toFixed(2) +
                                '</div>';
                            $('#divLiabilities').append(Loss);
                        }
                    }
                    else if (ProfitLoss[0].Debit > 0) {
                        for (var i = 0; i < ProfitLoss.length; i++) {
                            var Profit =
                                '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left"><b><a target="_blank" href="/Report/IncomeExpenditure">'
                                + ProfitLoss[i].GroupName +
                                '</a></b></div>' +
                                '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                                + '₹ ' + ProfitLoss[i].Debit.toFixed(2) +
                                '</div>';
                            $('#divAssets').append(Profit);
                        }
                    }
                }

                var Assets = jsondata.filter(x => x.NatureOfGroup === 'Assets');
                if (Assets !== null && Assets.length > 0) {
                    var grouped = _.chain(Assets).groupBy("GroupName").map(function (offers, GroupName) {
                        // Optionally remove product_id from each record
                        var cleanOffers = _.map(offers, function (it) {
                            return _.omit(it, "GroupName");
                        });
                        return {
                            GroupName: GroupName,
                            Data: cleanOffers
                        };
                    }).value();

                    if (grouped !== null && grouped.length > 0) {
                        for (var j = 0; j < grouped.length; j++) {
                            var GroupName =
                                '<div class="col-md-6 col-lg-12 p-l-25 p-t-10 text-left"><b><a target="_blank" href="/Report/BalanceSheetDetails?GroupId=' + grouped[j].Data[0].Id + '">'
                                + grouped[j].GroupName +
                                '</a></b></div>';
                            $('#divAssets').append(GroupName);
                            for (var i = 0; i < grouped[j].Data.length; i++) {
                                var Asset =
                                    '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left">'
                                    + grouped[j].Data[i].AccountGroup +
                                    '</div>' +
                                    '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                                    + '₹ ' + grouped[j].Data[i].Debit.toFixed(2) +
                                    '</div>';
                                $('#divAssets').append(Asset);
                            }
                        }

                    }
                }

                //if (jsondata[0].AdjustAmountRight > 0) {
                //    var AdjustAmountRight =
                //        '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left">'
                //            + 'Amount Adjustment in Asset' +
                //        '</div>' +
                //        '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                //            + '₹ ' + Assets[0].AdjustAmountRight.toFixed(2) +
                //        '</div>';;
                //    $('#divAssets').append(AdjustAmountRight)
                //}

                //if (jsondata[0].AdjustAmountLeft > 0) {
                //    var AdjustAmountLeft =
                //        '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left">'
                //            + 'Amount Adjustment in Liabilities' +
                //        '</div>' +
                //        '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                //            + '₹ ' + Assets[0].AdjustAmountLeft.toFixed(2) +
                //        '</div>';;
                //    $('#divLiabilities').append(AdjustAmountLeft)
                //}

                if (jsondata[0].TotalRight > 0) {
                    var TotalRight =
                        '<hr />' +
                        '<div class="row">' +
                        '<div class="col-md-6 col-lg-6 p-l-15 text-left">'
                        + '<b>Total</b>' +
                        '</div>' +
                        '<div class="col-md-6 col-lg-6 p-r-15 text-right">'
                        + '₹ ' + Assets[0].TotalRight.toFixed(2) +
                        '</div></div>';
                    $('#TotalRight').append(TotalRight)
                }

                if (jsondata[0].TotalLeft > 0) {
                    var TotalLeft =
                        '<hr />' +
                        '<div class="row">' +
                        '<div class="col-md-6 col-lg-6 p-l-15 text-left">'
                        + '<b>Total</b>' +
                        '</div>' +
                        '<div class="col-md-6 col-lg-6 p-r-15 text-right">'
                        + '₹ ' + Assets[0].TotalLeft.toFixed(2) +
                        '</div></div>';
                    $('#TotalLeft').append(TotalLeft)
                }
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