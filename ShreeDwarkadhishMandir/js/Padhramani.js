$(function () {

    var grid = $("#padhramni"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Padhramani/GetPadhramaniRequestList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'VaishnavId', 'Vaishnav Name', 'Request Number', 'Request Status'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false},
                { name: 'VaishnavId', index: 'VaishnavId', align: 'left', sortable: false},
                { name: 'VaishnavName', index: 'VaishnavName', align: 'left', sortable: false},
                { name: 'RequestNumber', index: 'RequestNumber', align: 'left', sortable: false},
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 40, sortable: false, formatter: EditFormatMovieShow },
                //{ name: 'deleteoperation', index: 'deleteoperation', align: 'center', width: 40, sortable: false, formatter: DeleteFormatMovieShow }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            //caption: 'Padhramani Request',
            emptyrecords: 'No Padhramani found.',
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
            multiselect: false

        });
    hideProgress();
    SetStyle();
});

function SetStyle() {
    $('.HeaderButton').hide();
    
    $('#padhramni').setGridWidth($('#divpadhramni').width());
}

function EditFormatMovieShow(cellvalue, options, rowObject) {
    if (rowObject.RequestStatus === 0) {
        return "<div class='btn btn-warning'>Pending</div>";
    }
    else if (rowObject.RequestStatus === 2) {
        return "<div class='btn btn-success'>Completed</div>";
    }
    else if (rowObject.RequestStatus === 1) {
        return "<div class='btn btn-primary'>Accepted</div>";
    }
    else {
        return "<div class='btn btn-danger'>Reject</div>";
    }
    
}

//function LoadSMSLogGrid() {

//    jQuery('#btnSearch').click(function (e) {
//        var StartDate = document.getElementById('txtFromDate').value;
//        var EndDate = document.getElementById('txtToDate').value;
//        var eDate = new Date(EndDate);
//        var sDate = new Date(StartDate);
//        if (StartDate != '' && StartDate != '' && sDate > eDate) {
//            alert("Please ensure that the To Date is greater than or equal to the From Date.");
//            return false;
//        }

//        var postData = jQuery('#tblSMSLog').jqGrid("getGridParam", "postData");
//        postData.search = jQuery('#txtSMSLogSearch').val().trim(),
//            postData.bookingType = jQuery('#ddlBookingType').val(),
//            postData.fromDate = jQuery('#txtFromDate').val().trim(),
//            postData.toDate = jQuery('#txtToDate').val().trim(),
//            postData.status = jQuery('#ddlStatus').val().trim()
//        jQuery('#tblSMSLog').jqGrid("setGridParam", { search: true });
//        jQuery('#tblSMSLog').jqGrid("setGridParam", { bookingType: true });
//        jQuery('#tblSMSLog').jqGrid("setGridParam", { fromDate: true });
//        jQuery('#tblSMSLog').jqGrid("setGridParam", { toDate: true });
//        jQuery('#tblSMSLog').jqGrid("setGridParam", { status: true });
//        jQuery('#tblSMSLog').trigger("reloadGrid", [{ page: 1, current: true }]);
//        SetStyle();
//    });

//    //jQuery('#txtSMSLogSearch').on('keyup', function (e) {
//    //    var postData = jQuery('#tblSMSLog').jqGrid("getGridParam", "postData");
//    //    postData.search = jQuery('#txtSMSLogSearch').val().trim();
//    //    jQuery('#tblSMSLog').jqGrid("setGridParam", { search: true });
//    //    jQuery('#tblSMSLog').trigger("reloadGrid", [{ page: 1, current: true }]);
//    //    SetStyle();
//    //});

//    //jQuery('#ddlBookingType').on('change', function () {
//    //    var postData = jQuery('#tblSMSLog').jqGrid("getGridParam", "postData");
//    //    postData.BookingType = jQuery('#ddlBookingType').val();
//    //    jQuery('#tblSMSLog').jqGrid("setGridParam", { BookingType: true });
//    //    jQuery('#tblSMSLog').trigger("reloadGrid", [{ page: 1, current: true }]);
//    //    SetStyle();
//    //});

//    jQuery('#tblSMSLog').jqGrid({
//        url: '/SMSLog/BindSMSLogGrid/',
//        datatype: 'json',
//        postData: {
//            search: jQuery('#txtSMSLogSearch').val().trim(),
//            bookingType: jQuery('#ddlBookingType').val(),
//            fromDate: jQuery('#txtFromDate').val().trim(),
//            toDate: jQuery('#txtToDate').val().trim(),
//            status: jQuery('#ddlStatus').val().trim()
//        },
//        mtype: 'GET',
//        colNames: [
//            'Id', 'Relavent Id', 'Module Name', 'Mobile No', 'text', 'Sent On', 'Status'],
//        colModel: [
//            { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true },
//            { name: 'RelaventId', index: 'RelaventId', align: 'right', formatter: 'integer', hidden: true },
//            { name: 'ModuleName', index: 'ModuleName', align: 'left' },
//            { name: 'MobileNo', index: 'MobileNo', align: 'left' },
//            { name: 'text', index: 'text', align: 'left' },
//            { name: 'SentOn', index: 'SentOn', align: 'left' },
//            { name: 'Status', index: 'Status', align: 'left' }
//        ],
//        pager: jQuery('#dvSMSLogFooter'),
//        rowNum: kcs_Common.GridPageSize,
//        rowList: kcs_Common.GridPageArray,
//        sortname: 'SentOn',
//        sortorder: 'DESC',
//        viewrecords: true,
//        caption: 'List of SMS Log',
//        height: '100%',
//        width: '100%',
//        loadComplete: function (data) {
//            if (data.records == 0) {
//                $('#tblSMSLog').prev()[0].innerHTML = kcs_Message.GridNoDataFound;
//            }
//            else {
//                $('#tblSMSLog').prev()[0].innerHTML = '';
//            }
//            jQuery('input:checkbox.cbox').uniform();
//        }
//    });
//    SetStyle();
//}