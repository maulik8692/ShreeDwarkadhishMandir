var max_pages = 100;
var page_count = 0;

function snipMe() {
    page_count++;
    if (page_count > max_pages) {
        return;
    }
    var long = $(this)[0].scrollHeight - Math.ceil($(this).innerHeight());
    var children = $(this).children().toArray();
    var removed = [];
    while (long > 0 && children.length > 0) {
        var child = children.pop();
        $(child).detach();
        removed.unshift(child);
        long = $(this)[0].scrollHeight - Math.ceil($(this).innerHeight());
    }
    if (removed.length > 0) {
        var a4 = $('<div class="A4"></div>');
        a4.append(removed);
        $(this).after(a4);
        snipMe.call(a4[0]);
    }
}

$(document).ready(function () {
    $('.A4').each(function () {
        snipMe.call(this);
    });
    LoadTransactionReport();
});

function LoadTransactionReport() {
    if ($.fn.DataTable.isDataTable("#TransactionReport")) {
        $('#TransactionReport').DataTable().clear().destroy();
    }

    var accountTransactionRequest = {
        FromDate: $('#FromDate').val(),
        ToDate: $('#ToDate').val(),
        AccountId: $('#AccountId').val(),
        MandirId: $('#MandirId').val()
    };

    $.ajax({
        url: "/Report/GetAccountTransactionReport",
        data: JSON.stringify(accountTransactionRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                $('#TransactionReport').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "AccountName", "title": "Transaction Name", "width": "30%", "className": "dt-body-left text-wrap" },
                        {
                            data: "DebitTransactionAmount",
                            title: "Debit Transaction",
                            "width": "10%",
                            render: function (data, type, row) {
                                return '₹ ' + parseFloat(row.DebitTransactionAmount).toFixed(2);
                            },
                            className: "dt-body-right"
                        },
                        {
                            data: "CreditTransactionAmount",
                            title: "Credit Transaction",
                            "width": "10%",
                            render: function (data, type, row) {
                                return '₹ ' + parseFloat(row.CreditTransactionAmount).toFixed(2);
                            },
                            className: "dt-body-right"
                        },
                        {
                            data: "TransactionDate",
                            title: "Transaction Date",
                            "width": "10%",
                            render: function (data, type, row) {
                                var TransactionDate = new Date(parseInt(row.TransactionDate.substr(6)));
                                return "<div>" + TransactionDate.format("dd-mmm-yyyy") + "</div>";
                            },
                            className: "dt-body-Center"
                        },
                        //{ "data": "AccountName", "title": "Manorath Name", "width": "30%", "className": "dt-body-left text-wrap" },
                        //{ "data": "AccountName", "title": "Manorath Name", "width": "30%", "className": "dt-body-left text-wrap" },

                    ],
                    "language": {
                        "zeroRecords": "No Record Found.",
                        "emptyTable": "No Record Found."
                    },
                    ordering: false,
                    searching: false,
                    paging: false,
                    "bInfo": false
                });

                $('.fg-toolbar').hide();
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}