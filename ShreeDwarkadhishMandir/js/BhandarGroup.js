$(document).ready(function () {
    hideProgress();
    GetDetail();
});

function GetDetail() {

    var grid = $("#bhandarGroup"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/BhandarGroup/BhandarList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Bhandar Group', 'Group Code', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'Name', index: 'Name', align: 'left', sortable: false },
                { name: 'GroupCode', index: 'CategoryName', align: 'left', sortable: false },
                { name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: EditBhandar }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Bhandar Group found.',
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

    $('#bhandarGroup').setGridWidth($('#divBhandarGroup').width());
}

function BhandarBalance(cellvalue, options, rowObject) {
    return parseFloat(rowObject.Balance).toFixed(4) + " " + rowObject.UnitAbbreviation;
}

function AdjustBhandar(cellvalue, options, rowObject) {

    return "<div><a href=/BhandarTransaction/AdjustBhandar?Id=" + rowObject.Id + "><i class='fa fa-adjust'></i></a></div>";
}

function EditBhandar(cellvalue, options, rowObject) {

    return "<div><a href=/BhandarGroup/CreateBhandarGroup?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
}