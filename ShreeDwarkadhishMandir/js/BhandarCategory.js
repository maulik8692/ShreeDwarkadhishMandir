$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#bhandarCategory"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/BhandarCategory/BhandarCategoryList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Name', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'Name', index: 'Name', align: 'left', sortable: false },
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 40, sortable: false, formatter: EditBhandarCategory },
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
            multiselect: false

        });

    hideProgress();
    SetStyle();
};

function SetStyle() {
    $('.HeaderButton').hide();

    $('#bhandarCategory').setGridWidth($('#divBhandarCategory').width());
}

function EditBhandarCategory(cellvalue, options, rowObject) {
    debugger;
    return "<div><a href=/BhandarCategory/CreateBhandarCategory?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
}