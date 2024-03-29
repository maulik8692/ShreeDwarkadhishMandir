﻿$(document).ready(function () {
    GetDetail();
});

function GetDetail() {

    var grid = $("#supplier"), headerRow, rowHight, resizeSpanHeight;

    grid.jqGrid
        ({
            url: "/Supplier/SupplierList",
            datatype: 'json',
            mtype: 'Get',
            hoverrows: false,
            colNames: [
                'Id', 'Supplier Id', 'Supplier Name', 'Edit'],
            colModel: [
                { name: 'Id', index: 'Id', align: 'left', key: true, hidden: true, sortable: false },
                { name: 'SupplierId', index: 'SupplierId', align: 'left', sortable: false },
                { name: 'SupplierName', index: 'SupplierName', align: 'left', sortable: false },
                { name: 'editoperation', index: 'editoperation', align: 'center', width: 40, sortable: false, formatter: EditSupplier },
            ],
            pager: jQuery('#pager'),
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            height: '100%',
            viewrecords: true,
            emptyrecords: 'No Supplier found.',
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

    $('#supplier').setGridWidth($('#divsupplier').width());
}

function EditSupplier(cellvalue, options, rowObject) {
    
    return "<div><a href=/Supplier/CreateSupplier?Id=" + rowObject.SupplierId + "><i style='font-size: 1.2em; color:#ffab00 !important;' class='las la-pencil-alt'></i></a></div>";
}