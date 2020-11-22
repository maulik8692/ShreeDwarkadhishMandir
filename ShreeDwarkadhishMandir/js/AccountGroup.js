$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#AccountGroup"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/AccountGroup/AccountGroupList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Group Name', 'Main Group','Nature Of Group', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'GroupName', index: 'GroupName', align: 'left', sortable: false },
                { name: 'DefaultGroupsName', index: 'DefaultGroupsName', align: 'left', sortable: false },
                { name: 'NatureOfGroup', index: 'NatureOfGroup', align: 'left', sortable: false },
                { name: 'Edit', index: 'Edit', align: 'center', width: 40, sortable: false, formatter: EditAccountGroup },
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Account Group Found.',
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

    $('#AccountGroup').setGridWidth($('#divAccountGroup').width());
}

function EditAccountGroup(cellvalue, options, rowObject) {
    if (rowObject.IsEditable === true) {
        return "<div><a href=/AccountGroup/CreateAccountGroup?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
    }
    else {
        return ''
    }
}