$(document).ready(function () {

    $("#DarshanDate").datepicker({
        dateFormat: 'dd-M-yy',
        changeMonth: true,
        changeYear: true,
        minDate: 0//,
        //onSelect: function (dateText) {
        //    alert("Selected date: " + dateText + "; input's current value: " + this.value);
        //}
    });

    $("#DarshanDate").datepicker().datepicker("setDate", new Date());

    LoadDarshan();

    $('#SearchDarshan').click(function (e) {
        LoadDarshan();
    });

    $('#NewDarshan').click(function (e) {
        LoadDarshan();
    });
});

function LoadDarshan() {
    if ($.fn.DataTable.isDataTable("#DarshanTime")) {
        $('#DarshanTime').DataTable().clear().destroy();
    }

    var reportParamObj = new Object();
    reportParamObj.darshanDate = jQuery('#DarshanDate').val();

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
                                debugger;
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
                                debugger;
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

                $('#DarshanTime thead').hide();
                $('.fg-toolbar').hide();
                hideProgress();
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
            hideProgress();
        }
    });
}

