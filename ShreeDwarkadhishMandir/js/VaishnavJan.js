$(document).ready(function () {
    LoadVaishnavList();


});

function LoadVaishnavList() {


    var grid = $("#VaishnavList"), headerRow, rowHight, resizeSpanHeight;

    $("#VaishnavId").on('keyup change', function () {
        if (this.value.length > 5 || this.value.length === 0) {
            //console.log(this.value);
            var postData = jQuery('#VaishnavList').jqGrid("getGridParam", "postData");
            postData.VaishnavId = jQuery('#VaishnavId').val().trim(),
                //postData.bookingType = jQuery('#ddlBookingType').val(),
                //postData.fromDate = jQuery('#txtFromDate').val().trim(),
                //postData.toDate = jQuery('#txtToDate').val().trim(),
                //postData.status = jQuery('#ddlStatus').val().trim()
                jQuery('#VaishnavList').jqGrid("setGridParam", { vaishnavId: true });
            //jQuery('#tblSMSLog').jqGrid("setGridParam", { bookingType: true });
            //jQuery('#tblSMSLog').jqGrid("setGridParam", { fromDate: true });
            //jQuery('#tblSMSLog').jqGrid("setGridParam", { toDate: true });
            //jQuery('#tblSMSLog').jqGrid("setGridParam", { status: true });
            jQuery('#VaishnavList').trigger("reloadGrid", [{ page: 1, current: true }]);
            SetStyle();
        }
    });


    grid.jqGrid
        ({
            url: "/Vaishnav/VaishnavList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Vaishnav Id', 'Vaishnav Name', 'Mobile No', 'Email', 'IsActive', 'Edit'],
            colModel: [
                { name: 'VaishnavId', width: 30, index: 'VaishnavId', align: 'left', sortable: false },
                { name: 'FirstName', width: 30, index: 'FirstName', align: 'left', sortable: false },
                { name: 'MobileNo', width: 30, index: 'MobileNo', align: 'left', sortable: false, formatter: MobileNoOperation },
                { name: 'Email', width: 30, index: 'Email', align: 'left', sortable: false, formatter: EmailOperation },
                { name: 'IsActive', width: 20, index: 'IsActive', align: 'right', sortable: false, formatter: ActiveFormatter },
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 10, sortable: false, formatter: editoperation }
            ],
            pager: jQuery('#pager'),
            rowNum: 500,
            rowList: [500, 1000, 1250, 1500, 5000],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Vaishnav found.',
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
}

function SetStyle() {
    $('.HeaderButton').hide();

    $('#VaishnavList').setGridWidth($('#divVaishnav').width());
}

function ActiveFormatter(cellvalue, options, rowObject) {
    if (rowObject.IsActive === true) {
        return "<div style='text-align:center;' class='form-check checkbox disabled'><label><input type='checkbox' checked disabled></label></div >";
    }
    else {
        return "<div style='text-align:center;' class='form-check checkbox disabled'><label><input type='checkbox' disabled></label></div >";;
    }
}

function MobileNoOperation(cellvalue, options, rowObject) {
    return "<div><a href=tel:" + rowObject.MobileNo + ">" + rowObject.MobileNo + "</a></div>";
}

function EmailOperation(cellvalue, options, rowObject) {
    return "<div><a href=mailto:" + rowObject.Email + ">" + rowObject.Email + "</a></div>";
}

function editoperation(cellvalue, options, rowObject) {
    return "<div><a href=/Vaishnav/Vaishnav?Id=" + rowObject.EncryptedId + "><i class='fa fa-edit'></i></a></div>";
}