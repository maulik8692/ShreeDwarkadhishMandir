$(document).ready(function () {
    hideProgress();
    LoadAccountHead();
});

function LoadAccountHead() {
    var grid = $("#AccountHead"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/AccountHead/AccountHeadList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Account Name', 'GroupName', 'BalanceAmount', 'Edit'],
            colModel: [
                //{ name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'AccountName', width:30, index: 'AccountName', align: 'left', sortable: false },
                { name: 'GroupName', width: 30, index: 'GroupName', align: 'left', sortable: false, formatter: GroupNameFormatter },
                { name: 'BalanceAmount', width: 20, index: 'BalanceAmount', align: 'right', sortable: false, formatter: BalanceAmountFormatter },
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 10, sortable: false, formatter: editoperation }
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Account Head Found.',
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

    $('#AccountHead').setGridWidth($('#divAccountHead').width());
}

function editoperation(cellvalue, options, rowObject) {
    if (rowObject.IsEditable === true) {
        return "<div><a href=/AccountHead/CreateAccountHead?Id=" + rowObject.Id + "><i class='fa fa-edit'></i></a></div>";
    }
    else {
        return '';
    }
}

function GroupNameFormatter(cellvalue, options, rowObject) {
    return rowObject.GroupName + ' (' + rowObject.NatureOfGroup + ')';
}

function BalanceAmountFormatter(cellvalue, options, rowObject) {
    return rowObject.BalanceAmount.toFixed(2) + ' ' + (rowObject.DebitCredit ==='Debit' ? 'Dr.' : 'Cr.');
}