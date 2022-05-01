$(document).ready(function () {
    hideProgress();
    GetDetail();
});

function GetDetail() {

    var grid = $("#Store"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Store/StoreList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Store Name', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'Name', index: 'Name', align: 'left', sortable: false },
                { name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: EditBhandar }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Store found.',
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

    $('#Store').setGridWidth($('#divStore').width());
}

function BhandarBalance(cellvalue, options, rowObject) {
    return parseFloat(rowObject.Balance).toFixed(4) + " " + rowObject.UnitAbbreviation;
}

function EditBhandar(cellvalue, options, rowObject) {

    return "<div><a href=/Store/CreateStore?Id=" + rowObject.Id + "><i style='font-size: 1.2em; color:#ffab00 !important;' class='las la-pencil-alt'></i></a></div>";
}