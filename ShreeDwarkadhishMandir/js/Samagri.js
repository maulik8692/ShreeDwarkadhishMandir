$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#Samagri"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Samagri/SamagriList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Bhandar Name', 'Balance', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'Name', index: 'Name', align: 'left', sortable: false },
                //{ name: 'CategoryName', index: 'CategoryName', align: 'left', sortable: false },
                { name: 'Balance', index: 'Balance', align: 'right', sortable: false, formatter: BhandarBalance },
                //{ name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: AdjustBhandar },
                { name: 'Id', index: 'Id', align: 'center', width: 40, sortable: false, formatter: EditBhandar },
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Samagri found.',
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

    $('#Samagri').setGridWidth($('#divSamagri').width());
}


function BhandarBalance(cellvalue, options, rowObject) {
    return parseFloat(rowObject.Balance).toFixed(4) + " " + rowObject.UnitAbbreviation;
}

function AdjustBhandar(cellvalue, options, rowObject) {

    return "<div><a href=/Samagri/AdjustSamagri?Id=" + rowObject.Id + "><i class='fa fa-adjust'></i></a></div>";
}

function EditBhandar(cellvalue, options, rowObject) {

    return "<div><a href=/Samagri/CreateSamagri?Id=" + rowObject.Id + "><i style='font-size: 1.2em; color:#ffab00 !important;' class='las la-pencil-alt'></i></a></div>";
}