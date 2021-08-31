$(document).ready(function () {
    hideProgress();
    LoadIncomExpenditure();
});
function LoadIncomExpenditure() {
    $.ajax({
        url: "/Report/GetIncomeExpenditure",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            
            if (jsondata !== null && jsondata.length > 0) {
                $('#divIncome').html('');
                $('#divExpenditure').html('');

                var Incomes = jsondata.filter(x => x.NatureOfGroup === 'Income');
                if (Incomes !== null && Incomes.length > 0) {
                    for (var i = 0; i < Incomes.length; i++) {
                        var Income =
                            '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left">'
                            + Incomes[i].AccountName +
                            '</div>' +
                            '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                            + '₹ ' + Incomes[i].Credit.toFixed(2) +
                            '</div>';
                        $('#divIncome').append(Income);
                    }


                }

                var Expenses = jsondata.filter(x => x.NatureOfGroup === 'Expenses');
                if (Expenses !== null && Expenses.length > 0) {
                    for (var i = 0; i < Expenses.length; i++) {
                        var Expense =
                            '<div class="col-md-6 col-lg-6 p-l-25 p-t-10 text-left">'
                            + Expenses[i].AccountName +
                            '</div>' +
                            '<div class="col-md-6 col-lg-6 p-t-10 p-r-25 text-right">'
                            + '₹ ' + Expenses[i].Debit.toFixed(2) +
                            '</div>';
                        $('#divExpenditure').append(Expense);
                    }
                }

                if (jsondata[0].TotalRight > 0) {
                    var TotalRight =
                        '<hr />' +
                        '<div class="row">' +
                        '<div class="col-md-6 col-lg-6 p-l-15 text-left">'
                        + '<b>Total</b>' +
                        '</div>' +
                        '<div class="col-md-6 col-lg-6 p-r-15 text-right">'
                        + '₹ ' + jsondata[0].TotalRight.toFixed(2) +
                        '</div></div>';
                    $('#TotalLeft').append(TotalRight);
                }

                if (jsondata[0].TotalLeft > 0) {
                    var TotalLeft =
                        '<hr />' +
                        '<div class="row">' +
                        '<div class="col-md-6 col-lg-6 p-l-15 text-left">'
                        + '<b>Total</b>' +
                        '</div>' +
                        '<div class="col-md-6 col-lg-6 p-r-15 text-right">'
                        + '₹ ' + jsondata[0].TotalLeft.toFixed(2) +
                        '</div></div>';
                    $('#TotalRight').append(TotalLeft);
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