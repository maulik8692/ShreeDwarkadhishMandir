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
    LoadManorathReceiptReport();
});

function LoadManorathReceiptReport() {
    if ($.fn.DataTable.isDataTable("#ManorathReceiptReport")) {
        $('#ManorathReceiptReport').DataTable().clear().destroy();
    }

    var receiptReportRequest = {
        FromDate: $('#FromDate').val(),
        ToDate: $('#ToDate').val(),
        ManorathFromDate: $('#ManorathFromDate').val(),
        ManorathToDate: $('#ManorathToDate').val(),
        AccountId: $('#AccountId').val(),
        OnlyManorath: $('#OnlyManorath').val(),
        CreatedBy: $('#CreatedBy').val(),
        MandirId: $('#MandirId').val()
    };

    $.ajax({
        url: "/Report/GetManorathReceiptReport",
        data: JSON.stringify(receiptReportRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                $('#ManorathReceiptReport').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "ReceiptNo", "title": "Receipt No", "width": "30%", "className": "dt-body-left text-wrap" },
                        { "data": "ManorathName", "title": "Manorath Name", "width": "30%", "className": "dt-body-left text-wrap" },
                        { "data": "ManorathiName", "title": "Manorathi", "width": "30%", "className": "dt-body-left text-wrap" },
                        {
                            data: "Nek",
                            title: "Nek",
                            "width": "10%",
                            render: function (data, type, row) {
                                return '₹ ' + parseFloat(row.Nek).toFixed(2);
                            },
                            className: "dt-body-right"
                        },
                        {
                            data: "ManorathDate",
                            title: "Manorath Date",
                            "width": "10%",
                            render: function (data, type, row) {
                                var ManorathDate = new Date(parseInt(row.ManorathDate.substr(6)));
                                return "<div>" + ManorathDate.format("dd-mmm-yyyy") + "</div>";
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