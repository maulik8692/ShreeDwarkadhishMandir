$(document).ready(function () {
    DashboardData();

    $("#bhet").click(function (e) {
        GetTodaysBhet();
    });
    
});

function GetTodaysBhet() {
    $.redirect('/Report/ManorathReceiptReport', {
        'FromDate': new Date().format('dd-mmm-yyyy'),
        'ToDate': new Date().format('dd-mmm-yyyy'),
        'ManorathFromDate': null,
        'ManorathToDate': null,
        'AccountId': 0,
        'OnlyManorath': false,
        'CreatedBy': 0,
        'MandirId': 0
    }, 'POST', '_Blank');
}

function LoadDarshan() {
    if ($.fn.DataTable.isDataTable("#DarshanTime")) {
        $('#DarshanTime').DataTable().clear().destroy();
    }

    Date.prototype.toShortFormat = function () {

        var month_names = ["Jan", "Feb", "Mar",
            "Apr", "May", "Jun",
            "Jul", "Aug", "Sep",
            "Oct", "Nov", "Dec"];

        var day = this.getDate();
        var month_index = this.getMonth();
        var year = this.getFullYear();

        return "" + day + "-" + month_names[month_index] + "-" + year;
    }

    // Now any Date object can be declared 
    var today = new Date();

    var reportParamObj = new Object();

    reportParamObj.darshanDate = today.toShortFormat();
    $.ajax({
        url: "/Darshan/GetDarshanTime",
        data: JSON.stringify(reportParamObj),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                $('#DarshanTime').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "DarshanName", "title": "Darshan", "className": "dt-body-left" },
                        {
                            data: "FromTime",
                            title: "FromTime",
                            render: function (data, type, row) {
                                var date = new Date(parseInt(data.replace('/Date(', '')));
                                var hours = date.getHours();
                                var minutes = date.getMinutes();
                                var ampm = hours >= 12 ? 'PM' : 'AM';
                                hours = hours % 12;
                                hours = hours ? hours : 12; // the hour '0' should be '12'
                                minutes = minutes < 10 ? '0' + minutes : minutes;
                                var strTime = hours + ':' + minutes + ' ' + ampm;
                                return strTime;
                            },
                            className: "dt-body-Center"
                        },
                        {
                            data: "ToTime",
                            title: "ToTime",
                            render: function (data, type, row) {

                                var date = new Date(parseInt(data.replace('/Date(', '')));

                                var hours = date.getHours();
                                var minutes = date.getMinutes();
                                var ampm = hours >= 12 ? 'PM' : 'AM';
                                hours = hours % 12;
                                hours = hours ? hours : 12; // the hour '0' should be '12'
                                minutes = minutes < 10 ? '0' + minutes : minutes;
                                var strTime = hours + ':' + minutes + ' ' + ampm;
                                return strTime;
                            },
                            className: "dt-body-Center"
                        },

                        { "data": "AdditionalNote", "title": "Additional Note", "className": "dt-body-left" },
                    ],
                    "language": {
                        "zeroRecords": "Darshan not available.",
                        "emptyTable": "Darshan not available."
                    },
                    ordering: false,
                    searching: false,
                    paging: false,
                    "bInfo": false
                });

                $('#DarshanTime').attr('style', 'width: ' + $('.table-responsive').width() + ' !important');

                $('#DarshanTime thead').hide();
                $('.fg-toolbar').hide();

                LoadManorathReceiptReport();
               
            }
        },
        error: function (xhr) {
            LoadManorathReceiptReport();
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function DashboardData() {
    showProgress();
    $.ajax({
        url: "/Home/DashboardData",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {
            if (jsondata !== null) {
                $('#Bhet').html(jsondata.Bhet)
                $('#Vaishnavs').html(jsondata.Vaishnavs)
                $('#Manorath').html(jsondata.Manorath)
                $('#Balance').html('₹ '+jsondata.Balance)
            }

            LoadDarshan();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}

function LoadManorathReceiptReport() {
    if ($.fn.DataTable.isDataTable("#ManorathListForToday")) {
        $('#ManorathListForToday').DataTable().clear().destroy();
    }

    var manorathReceiptReport = {
        FromDate: null,
        ToDate: null,
        ManorathFromDate: new Date().format('dd-mmm-yyyy'),
        ManorathToDate: new Date().format('dd-mmm-yyyy'),
        AccountId: 0,
        OnlyManorath: true,
        CreatedBy: 0,
        MandirId: 0
    };

    $.ajax({
        url: "/Report/GetManorathReceiptReport",
        data: JSON.stringify(manorathReceiptReport ),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                $('#ManorathListForToday').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "ManorathiName", "title": "Manorathi", "width": "20%", "className": "dt-body-left text-wrap" },
                        { "data": "ManorathName", "title": "Manorath Name", "width": "20%", "className": "dt-body-left text-wrap" },
                        { "data": "Email", "title": "Email", "width": "20%", "className": "dt-body-left text-wrap" },
                        {
                            data: "Nek",
                            title: "Nek",
                            "width": "20%",
                            render: function (data, type, row) {
                                return '₹ ' + parseFloat(row.Nek).toFixed(2);
                            },
                            className: "dt-body-right"
                        },
                        {
                            data: "ManorathDate",
                            title: "Manorath Date",
                            "width": "20%",
                            render: function (data, type, row) {
                                var ManorathDate = new Date(parseInt(row.ManorathDate.substr(6)));
                                return "<div>" + ManorathDate.format("dd-mmm-yyyy") + "</div>";
                            },
                            className: "dt-body-Center"
                        },
                        //{ "data": "ManorathName", "title": "Manorath Name", "width": "30%", "className": "dt-body-left text-wrap" },
                        //{ "data": "ManorathName", "title": "Manorath Name", "width": "30%", "className": "dt-body-left text-wrap" },

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
                hideProgress();
            }
        },
        error: function (xhr) {
            hideProgress();
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}