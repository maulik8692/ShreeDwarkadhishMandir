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

   

    $('#NewDarshan').click(function (e) {
        LoadDarshan();
    });
});

function LoadDarshan() {
    //if ($.fn.DataTable.isDataTable("#DarshanTime")) {
    //    $('#DarshanTime').DataTable().clear().destroy();
    //}

    //var reportParamObj = new Object();
    //reportParamObj.darshanDate = jQuery('#DarshanDate').val();
    var grid = $("#DarshanTime")

    $('#SearchDarshan').click(function (e) {
        //LoadDarshan();
        var postData = jQuery('#DarshanTime').jqGrid("getGridParam", "postData");
        postData.darshanDate = jQuery('#DarshanDate').val();
        jQuery('#DarshanTime').jqGrid("setGridParam", { vaishnavId: true });
        jQuery('#DarshanTime').trigger("reloadGrid", [{ page: 1, current: true }]);
        SetStyle();
    });

    grid.jqGrid
        ({
            url: "/Darshan/GetDarshanTime",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Darshan', 'Darshan Time', 'AdditionalNote'],
            colModel: [
                {
                    name: 'DarshanName', index: 'DarshanName', align: 'left', key: true, sortable: false,
                    formatter: function (cellvalue, options, rowObject) {
                        var imagewithText=
                        '<div>'+
                            '<Image src="\\images\\Darshan\\' + cellvalue + '.jpg" style="max-width: 15%;"/>          '+ cellvalue+
                            '</div>';

                        return imagewithText;
                    }
                },
                {
                    name: 'FromTime', index: 'FromTime', align: 'left', sortable: false,
                    formatter: function (cellvalue, options, rowObject) {
                        var ManorathDateFrom = new Date(parseInt(rowObject.FromTime.substr(6)));
                        var ManorathDateTo = new Date(parseInt(rowObject.ToTime.substr(6)));
                        return ManorathDateFrom.format('hh:MM tt').toUpperCase() + ' - ' + ManorathDateTo.format('hh:MM tt').toUpperCase()

                    }},
                { name: 'AdditionalNote', index: 'AdditionalNote', align: 'left', sortable: false }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No receipt found.',
            jsonReader:
            {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            multiselect: false,
            gridComplete: function () {
                SetStyle();
            }
        });

    hideProgress();

    //$.ajax({
    //    url: "/Darshan/GetDarshanTime",
    //    data: JSON.stringify(reportParamObj),
    //    dataType: "json",
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (jsondata) {

    //        if (jsondata !== null) {
    //            $('#DarshanTime').DataTable({
    //                destroy: true,
    //                fixedHeader: true,
    //                "data": jsondata,
    //                "columns": [
    //                    { "data": "DarshanName", "title": "Darshan", "className": "dt-body-left" },
    //                    {
    //                        data: "FromTime",
    //                        title: "FromTime",
    //                        render: function (data, type, row) {
    //                            var date = new Date(parseInt(data.replace('/Date(', '')));
    //                            var hours = date.getHours();
    //                            var minutes = date.getMinutes();
    //                            var ampm = hours >= 12 ? 'PM' : 'AM';
    //                            hours = hours % 12;
    //                            hours = hours ? hours : 12; // the hour '0' should be '12'
    //                            minutes = minutes < 10 ? '0' + minutes : minutes;
    //                            var strTime = hours + ':' + minutes + ' ' + ampm;
                                
    //                            return strTime;
    //                        },
    //                        className: "dt-body-Center"
    //                    },
    //                    {
    //                        data: "ToTime",
    //                        title: "ToTime",
    //                        render: function (data, type, row) {

    //                            var date = new Date(parseInt(data.replace('/Date(', '')));

    //                            var hours = date.getHours();
    //                            var minutes = date.getMinutes();
    //                            var ampm = hours >= 12 ? 'PM' : 'AM';
    //                            hours = hours % 12;
    //                            hours = hours ? hours : 12; // the hour '0' should be '12'
    //                            minutes = minutes < 10 ? '0' + minutes : minutes;
    //                            var strTime = hours + ':' + minutes + ' ' + ampm;
                                
    //                            return strTime;
    //                        },
    //                        className: "dt-body-Center"
    //                    },

    //                    { "data": "AdditionalNote", "title": "Additional Note", "className": "dt-body-left" },
    //                ],
    //                "language": {
    //                    "zeroRecords": "Darshan not available.",
    //                    "emptyTable": "Darshan not available."
    //                },
    //                ordering: false,
    //                searching: false,
    //                paging: false,
    //                "bInfo": false
    //            });

    //            $('#DarshanTime thead').hide();
    //            $('.fg-toolbar').hide();
    //            hideProgress();
    //        }
    //    },
    //    error: function (xhr) {
    //        alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
    //        hideProgress();
    //    }
    //});
}

function SetStyle() {
    $('.HeaderButton').hide();

    $('#Receipt').setGridWidth($('#divReceipt').width());
    $("#Pager").css({ "height": "0px", "border": "0px" });
}
