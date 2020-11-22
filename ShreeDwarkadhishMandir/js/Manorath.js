$(document).ready(function () {
    hideProgress();
    LoadManorath();
});

function LoadManorath() {
    var grid = $("#Manorath"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Manorath/ManorathList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Manorath Name','Manorath Type', 'Nyochhawar', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'ManorathName', index: 'ManorathName', align: 'left', sortable: false },
                { name: 'ManorathTypeName', index: 'ManorathTypeName', align: 'left', sortable: false },
                { name: 'Nyochhawar', index: 'Nyochhawar', align: 'right', sortable: false, formatter: NyochhawarFormatter },
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 40, sortable: false, formatter: editoperation }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Manorath found.',
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

    $('#Manorath').setGridWidth($('#divManorath').width());
}

function editoperation(cellvalue, options, rowObject) {

    return "<div><a href=/Manorath/CreateManorath?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
}

function NyochhawarFormatter(cellvalue, options, rowObject) {
    return rowObject.Nyochhawar.toFixed(2);
}