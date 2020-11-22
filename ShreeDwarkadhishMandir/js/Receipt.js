$(document).ready(function () {

    GetDetail();
});

function GetDetail() {

    var grid = $("#Receipt"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Receipt/GetReceiptList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Receipt No', 'Manorath Name', 'Manorathi', 'Nek', 'Manorath Date', 'Created User','View'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'ReceiptNo', index: 'ReceiptNo', align: 'left', sortable: false },
                { name: 'ManorathName', index: 'ManorathName', align: 'left', sortable: false },
                { name: 'ManorathiName', index: 'ManorathiName', align: 'left', sortable: false },
                { name: 'Nek', index: 'Nek', align: 'right', sortable: false, formatter: DisplayNek },
                { name: 'ManorathDate', index: 'ManorathDate', align: 'right', sortable: false, formatter: ManorathDate },
                { name: 'CreatedDisplayName', index: 'CreatedDisplayName', align: 'left', sortable: false },
                { name: 'editoperation', index: 'editoperation', align: 'center',  sortable: false, formatter: EditReceipt },
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
};

function SetStyle() {
    $('.HeaderButton').hide();

    $('#Receipt').setGridWidth($('#divReceipt').width());
}

function ManorathDate(cellvalue, options, rowObject) {
    var ManorathDate = new Date(parseInt(rowObject.ManorathDate.substr(6)));

    return "<div>" + ManorathDate.format("dd-mmm-yyyy") + "</div>";
}

function DisplayNek(cellvalue, options, rowObject) {
    
    return "<div>₹ " + parseFloat(rowObject.Nek).toFixed(2) + "</div>";
}

function EditReceipt(cellvalue, options, rowObject) {
    return "<div><a target='_blank' href=/Receipt/ReceiptDetail?Id=" + rowObject.Id + 
        "><i class='fa fa-eye'></i></a></div>";
}