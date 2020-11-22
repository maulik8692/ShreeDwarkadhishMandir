$(document).ready(function () {
    LoadApplicationUser();
});

function LoadApplicationUser() {
    if ($.fn.DataTable.isDataTable("#ApplicationUserList")) {
        $('#ApplicationUserList').DataTable().clear().destroy();
    }

    var applicationUserRequest = {
        Id: 0,
        UserName: '',
        Password: '',
        DisplayName: '',
        MandirId: 0,
        UserTypeId: 0,
        UserTypeName: '',
        Email: '',
        PhoneNumber: '',
        Address: ''
    };

    $.ajax({
        url: "/ApplicationUser/ApplicationUserList",
        data: JSON.stringify(applicationUserRequest),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (jsondata) {

            if (jsondata !== null) {
                $('#ApplicationUserList').DataTable({
                    destroy: true,
                    fixedHeader: true,
                    "data": jsondata,
                    "columns": [
                        { "data": "DisplayName", "title": "Name", "width": "30%", "className": "dt-body-left text-wrap" },
                        { "data": "UserName", "title": "UserName", "width": "30%", "className": "dt-body-left text-wrap" },
                        { "data": "Email", "title": "Email", "width": "20%", "className": "dt-body-left text-wrap" },
                        { "data": "PhoneNumber", "title": "PhoneNumber", "width": "20%", "className": "dt-body-left text-wrap" },
                        { "data": "MandirName", "title": "Mandir", "width": "20%", "className": "dt-body-left text-wrap" },
                        { "data": "UserTypeName", "title": "User Type", "width": "20%", "className": "dt-body-left text-wrap" },
                        {
                            data: "Id",
                            title: "Edit",
                            "width": "10%",
                            render: function (data, type, row) {
                                return '<a href="/ApplicationUser/ApplicationUser?Id=' + row.Id + '"><i class="fas fa-edit"></i></a>';
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
            }

            hideProgress();
        },
        error: function (xhr) {
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        }
    });
}