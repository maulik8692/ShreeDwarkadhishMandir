$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#MandirVoucher"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/MandirVoucher/MandirVoucherList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id','Voucher No', 'Account Name', 'Voucher Amount', 'Display Voucher Date'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'VoucherNo', index: 'VoucherNo', align: 'right', sortable: false },
                { name: 'AccountName', index: 'AccountName', align: 'left', sortable: false },
                { name: 'DispalyAmount', index: 'DispalyAmount', align: 'right', sortable: false },
                { name: 'DisplayVoucherDate', index: 'DisplayVoucherDate', align: 'left', sortable: false}
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Voucher found.',
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
};

function SetStyle() {
    $('.HeaderButton').hide();

    $('#MandirVoucher').setGridWidth($('#divMandirVoucher').width());
}