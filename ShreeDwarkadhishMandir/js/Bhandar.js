$(document).ready(function () {
    hideProgress();
    GetDetail();
});

function GetDetail() {

    var grid = $("#bhandar"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Bhandar/BhandarList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Bhandar Name', 'Category Name', 'Balance', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'Name', index: 'Name', align: 'left', sortable: false },
                { name: 'CategoryName', index: 'CategoryName', align: 'left', sortable: false },
                { name: 'Balance', index: 'Balance', align: 'right', sortable: false, formatter: BhandarBalance },
                //{ name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: AdjustBhandar },
                { name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: EditBhandar },
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No bhandar found.',
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

    $('#bhandar').setGridWidth($('#divBhandar').width());
}

function BhandarBalance(cellvalue, options, rowObject) {
    return parseFloat(rowObject.Balance).toFixed(4) + " " + rowObject.UnitAbbreviation;
}

function AdjustBhandar(cellvalue, options, rowObject) {

    return "<div><a href=/BhandarTransaction/AdjustBhandar?Id=" + rowObject.Id + "><i class='fa fa-adjust'></i></a></div>";
}

function EditBhandar(cellvalue, options, rowObject) {
   
    return "<div><a href=/Bhandar/CreateBhandar?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
}