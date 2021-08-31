$(document).ready(function () {
    LoadMandir();
});


function LoadMandir() {
    showProgress();
    if ($.fn.DataTable.isDataTable("#mandirList")) {
        $('#mandirList').DataTable().clear().destroy();
    }

    var mandirRequest = {
        Id: 0,
        Name: '',
        Address: '',
        CountryId: 0,
        StateId: 0,
        CityId: 0,
        VillageId: 0,
        PostalCode: '',
        PhoneNumber: '',
        Email: '',
        CreatedBy: 0,
        CreatedOn: new Date()
    };

    $.ajax({
        url: "/Mandir/MandirList",
        data: JSON.stringify(mandirRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                $('#mandirList').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "Name", "title": "Mandir Name", "width": "25%", "className": "dt-body-left text-wrap" },
                        { "data": "Address", "title": "Address", "width": "35%", "className": "dt-body-left text-wrap" },
                        { "data": "PhoneNumber", "title": "Number", "width": "20%", "className": "dt-body-left text-wrap" },
                        { "data": "Email", "title": "Email", "width": "20%", "className": "dt-body-left text-wrap" },
                        {
                            data: "Id",
                            title: "Edit",
                            "width": "10%",
                            render: function (data, type, row) {
                                
                                return '<a href="/Mandir/Mandir?Id=' + row.Id + '"><i class="fas fa-edit"></i></a>';
                            },
                            className: "dt-body-Center"
                        }
                    ],
                    "language": {
                        "zeroRecords": "Mandir data not available.",
                        "emptyTable": "Mandir data not available."
                    },
                    ordering: false,
                    searching: false,
                    paging: false,
                    "bInfo": false
                });

                $('.fg-toolbar').hide();

                hideProgress();
            }
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}