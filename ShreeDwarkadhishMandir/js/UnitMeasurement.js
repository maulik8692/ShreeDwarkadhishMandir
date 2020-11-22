$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#unitMeasurement"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/UnitMeasurement/UnitMeasurementList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Unit Description', 'Unit Abbreviation', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'UnitDescription', index: 'UnitDescription', align: 'left', sortable: false },
                { name: 'UnitAbbreviation', index: 'UnitAbbreviation', align: 'left', sortable: false },
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 40, sortable: false, formatter: EditUnitMeasurement },
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No unit of measurement found.',
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
    console.log($('#divUnitMeasurement').width());
    $('#pager').setGridWidth($('#divUnitMeasurement').width());
    $('#unitMeasurement').setGridWidth($('#divUnitMeasurement').width());
}

function EditUnitMeasurement(cellvalue, options, rowObject) {
    return "<div><a href=/UnitMeasurement/CreateUnitMeasurement?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
}