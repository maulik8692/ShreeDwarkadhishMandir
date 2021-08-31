$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#UnitConversion"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/UnitConversion/UnitConversionList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Unit Conversion'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'MainUnitDescription', index: 'MainUnitDescription', align: 'left', sortable: false, formatter: UnitConversionFormatter }
                //{ name: 'MainUnitQuantity', index: 'MainUnitQuantity', align: 'left', sortable: false },
                //{ name: 'ConversionDescription', index: 'ConversionDescription', align: 'left', sortable: false },
                //{ name: 'ConversionUnitQuantity', index: 'ConversionUnitQuantity', align: 'left', sortable: false }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No bhandar category found.',
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

    $('#UnitConversion').setGridWidth($('#divUnitConversion').width());
}

function UnitConversionFormatter(cellvalue, options, rowObject) {
    return "<div>" + rowObject.MainUnitQuantity.toFixed(5) + ' <b>' + rowObject.MainUnitDescription + '</b> is equal of ' + rowObject.ConversionUnitQuantity.toFixed(5) + ' <b>' + rowObject.ConversionDescription+"</b></div>";
}