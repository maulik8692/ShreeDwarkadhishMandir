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
        url: "/Report/GetBhandarTransactionReport",
        data: JSON.stringify(receiptReportRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                
                $('#divSamagriTransaction').html('');
                var grouped = _.chain(jsondata).groupBy("BhandarName").map(function (offers, BhandarName) {
                    // Optionally remove product_id from each record
                    var cleanOffers = _.map(offers, function (it) {
                        return _.omit(it, "BhandarName");
                    });
                    return {
                        BhandarName: BhandarName,
                        Data: cleanOffers
                    };
                }).value();

                if (grouped !== null && grouped.length > 0) {

                    for (var j = 0; j < grouped.length; j++) {

                        var header =
                            '<div class="card">' +
                                '<div class="card-header">' +
                                    '<strong>' + grouped[j].BhandarName + '</strong>' +
                                '</div>' 

                        var Storedgrouped = _.chain(grouped[j].Data).groupBy("StoreName").map(function (offers, StoreName) {
                            // Optionally remove product_id from each record
                            var cleanOffers = _.map(offers, function (it) {
                                return _.omit(it, "StoreName");
                            });
                            return {
                                StoreName: StoreName,
                                Data: cleanOffers
                            };
                        }).value();

                        if (Storedgrouped !== null && Storedgrouped.length > 0) {
                            for (var i = 0; i < Storedgrouped.length; i++) {
                                header +=
                                    '<div class="card-body">' +
                                        '<div class="form-group row m-l-5">' +
                                            '<h5>' + Storedgrouped[i].StoreName + '</h5>' +
                                        '</div>'


                                if (Storedgrouped[i].Data !== null && Storedgrouped[i].Data.length > 0) {
                                    header +=
                                        '<hr><div class="row form-group">' +

                                            '<div class="col col-md-2">' +
                                                '<h6><label for="Transaction Date" class="form-control-label">Transaction Date</label></h6>' +
                                            '</div>' +

                                            '<div class="col col-md-6">' +
                                                '<h6><label for="TransactionType" class="form-control-label">Transaction Type</label></h6>' +
                                            '</div>' +

                                            '<div class="col col-md-2"> ' +
                                                '<h6><label for= "Debit" class= "form-control-label" >Credit</label></h6>' +
                                            '</div> ' +

                                            '<div class="col col-md-2"> ' +
                                                '<h6><label for= "Credit" class= "form-control-label" >Debit</label></h6> ' +
                                            '</div> ' +

                                        '</div><hr>'

                                    for (var k = 0; k < Storedgrouped[i].Data.length; k++) {
                                        var CreatedOn = new Date(parseInt(Storedgrouped[i].Data[k].CreatedOn.substr(6)));
                                        var debit =
                                            Storedgrouped[i].Data[k].MultiplicationWith === 1 ?
                                                Storedgrouped[i].Data[k].StockTransactionQuantity.toFixed(5) + ' ' + Storedgrouped[i].Data[k].UnitAbbreviation
                                                : '';
                                        var Credit =
                                            Storedgrouped[i].Data[k].MultiplicationWith !== 1 ?
                                                Storedgrouped[i].Data[k].StockTransactionQuantity.toFixed(5) + ' ' + Storedgrouped[i].Data[k].UnitAbbreviation
                                                : '';

                                        var displaytext = ''
                                        switch (Storedgrouped[i].Data[k].TransactionType) {
                                            case 'Opening':
                                                displaytext = 'Opening Stock'
                                                break;
                                            case 'Purchase':
                                                displaytext = 'Purchase from vendors or supplier.'
                                                break;
                                            case 'Donation':
                                                displaytext = 'Donated by someone to the mandir'
                                                break;
                                            case 'IssueFrom':
                                                displaytext = 'Issued From one Store/Bhandar for other Store/Bhandar.'
                                                break;
                                            case 'IssueTo':
                                                displaytext = 'Issued to this Store/Bhandar form other Store/Bhandar.'
                                                break;
                                            case 'ReciptConsumption':
                                                displaytext = 'Consumption against receipt.'
                                                break;
                                            case 'ManorathConsumption':
                                                displaytext = 'Consumption against Manorath.'
                                                break;
                                            case 'NekConsumption':
                                                displaytext = 'Consumption against Nek.'
                                                break;
                                            case 'ComplementaryConsumption':
                                                displaytext = 'Consumption against Complementary.'
                                                break;
                                            case 'Scrap':
                                                displaytext = 'Scrapped or expired stock.'
                                                break;
                                            case 'SoldOut':
                                                displaytext = 'Soldout stock.'
                                                break;
                                            case 'SamagriIssue':
                                                displaytext = 'Issue for Samagri to Rasoi ghar.'
                                                break;
                                            case 'IssueForSamagri':
                                                displaytext = 'Issue for Samagri from Bhandar ghar.'
                                                break;
                                            case 'CorrectionOfIncreased':
                                                displaytext = 'Correction Increased'
                                                break;
                                            case 'CorrectionOfDecreased':
                                                displaytext = 'Correction Decreased'
                                                break;
                                            default:
                                                break;
                                        }

                                        header +=
                                            '<div class="row form-group">' +

                                                '<div class="col col-md-2">' +
                                                    '<label for="Transaction Date" class="form-control-label">' + CreatedOn.format("dd-mmm-yyyy")+'</label>' +
                                                '</div>' +

                                                '<div class="col col-md-6">' +
                                                    '<label for="Transaction Date" class="form-control-label">' + displaytext+'</label>' +
                                                '</div>' +

                                                '<div class="col col-md-2"> ' +
                                                    '<label for= "Debit" class= "form-control-label" >' + debit+'</label >' +
                                                '</div> ' +

                                                '<div class="col col-md-2"> ' +
                                                    '<label for= "Credit" class= "form-control-label" >' + Credit+'</label > ' +
                                                '</div> ' +

                                            '</div><hr>'
                                    }
                                }
                                //card-body
                                header += '</div>'
                            }
                        }

                        header +=
                            '<div class="card-footer">' +
                                '<strong>Balance to date</strong>' +
                                '<strong style="float: right;">' + grouped[j].Data[0].CurrentBalance+' '+grouped[j].Data[0].BhandarUnitAbbreviation+ '</strong>' +
                            '</div>' 

                        //card
                        header += '</div>'
                        
                        $('#divSamagriTransaction').append(header);
                    }
                }

                $('#TransactionReport').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "BhandarName", "title": "Bhandar Name", "width": "30%", "className": "dt-body-left text-wrap" },
                        { "data": "StoreName", "title": "Store Name", "width": "20%", "className": "dt-body-left text-wrap" },
                        {
                            data: "TransactionType",
                            title: "Transaction Type",
                            "width": "30%",
                            render: function (data, type, row) {
                                var displaytext = ''
                                switch (row.TransactionType) {
                                    case 'Opening':
                                        displaytext = 'Opening Stock'
                                        break;
                                    case 'Purchase':
                                        displaytext = 'Purchase from vendors or supplier.'
                                        break;
                                    case 'Donation':
                                        displaytext = 'Donated by someone to the mandir'
                                        break;
                                    case 'IssueFrom':
                                        displaytext = 'Issued From one Store/Bhandar for other Store/Bhandar.'
                                        break;
                                    case 'IssueTo':
                                        displaytext = 'Issued to this Store/Bhandar form other Store/Bhandar.'
                                        break;
                                    case 'ReciptConsumption':
                                        displaytext = 'Consumption against receipt.'
                                        break;
                                    case 'ManorathConsumption':
                                        displaytext = 'Consumption against Manorath.'
                                        break;
                                    case 'NekConsumption':
                                        displaytext = 'Consumption against Nek.'
                                        break;
                                    case 'ComplementaryConsumption':
                                        displaytext = 'Consumption against Complementary.'
                                        break;
                                    case 'Scrap':
                                        displaytext = 'Scrapped or expired stock.'
                                        break;
                                    case 'SoldOut':
                                        displaytext = 'Soldout stock.'
                                        break;
                                    case 'SamagriIssue':
                                        displaytext = 'Issue for Samagri to Rasoi ghar.'
                                        break;
                                    case 'IssueForSamagri':
                                        displaytext = 'Issue for Samagri from Bhandar ghar.'
                                        break;
                                    case 'CorrectionOfIncreased':
                                        displaytext = 'Correction Increased'
                                        break;
                                    case 'CorrectionOfDecreased':
                                        displaytext = 'Correction Decreased'
                                        break;
                                    default:
                                        break;
                                }
                                return displaytext;
                            },
                            "className": "dt-body-left text-wrap",
                        },
                        {
                            data: "TransactionQuantity",
                            title: "Transaction Quantity",
                            "width": "10%",
                            render: function (data, type, row) {
                                return parseFloat(row.StockTransactionQuantity).toFixed(5) + ' ' + row.UnitAbbreviation;
                            },
                            className: "dt-body-left"
                        },
                        {
                            data: "CreatedOn",
                            title: "Transaction Date",
                            "width": "10%",
                            render: function (data, type, row) {
                                var CreatedOn = new Date(parseInt(row.CreatedOn.substr(6)));
                                return "<div>" + CreatedOn.format("dd-mmm-yyyy") + "</div>";
                            },
                            className: "dt-body-Center"
                        },
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