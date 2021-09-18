var SomethingWentWrong = 'Something Went Wrong. Please contact your Administrator'
$(document).ready(function () {
    $('.number').inputmask("numeric", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 0,
        autoGroup: true,
        //prefix: '₹ ', //Space after $, this will not truncate the first character.
        rightAlign: false,
        oncleared: function () { self.Value(''); }
    });

    $('.money').inputmask("numeric", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 2,
        autoGroup: true,
        prefix: '₹ ', //Space after $, this will not truncate the first character.
        rightAlign: false,
        oncleared: function () { self.Value(''); }
    });

    $('.Units').inputmask("numeric", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 5,
        autoGroup: true,
        //prefix: '₹ ', //Space after $, this will not truncate the first character.
        rightAlign: false,
        oncleared: function () { self.Value(''); }
    });

    $('.bhandar1').inputmask("numeric", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 5,
        autoGroup: true,
        suffix: ' G', //Space after $, this will not truncate the first character.
        rightAlign: false,
        oncleared: function () { self.Value(''); }
    });

    $('.interest').inputmask("percentage", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 2,
        min: 0,
        max: 100,
        autoGroup: true,
        //prefix: "[%]",
        rightAlign: false,
        oncleared: function () { self.Value(''); }
    });

    $('.phone').inputmask("numeric", {
        radixPoint: "",
        groupSeparator: "",
        digits: 0,
        autoGroup: true,
        prefix: '+91 ', //Space after $, this will not truncate the first character.
        rightAlign: false
    });

    $(".wait").height($(".page-wrapper").get(0).scrollHeight);

    $('.searchableDropdown').select2();

    $(".model-dropdown").select2({
        tags: true,
        dropdownParent: $("#staticModal")
    });
    
});

function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
};

function showProgress() {
    $(".wait").css("display", "block");

};
function hideProgress() {
    $(".wait").css("display", "none");
    $(".LoadingText").html("Please wait..");
};

function isValidDate(s) {
    if (s !== null && s !== '') {
        var bits = s.split('-');

        var month = 0;
        switch (bits[1].toLowerCase()) {
            case 'jan':
                month = 1;
                break;
            case 'feb':
                month = 2;
                break;
            case 'mar':
                month = 3;
                break;
            case 'apr':
                month = 4;
                break;
            case 'may':
                month = 5;
                break;
            case 'jun':
                month = 6;
                break;
            case 'jul':
                month = 7;
                break;
            case 'aug':
                month = 8;
                break;
            case 'sep':
                month = 9;
                break;
            case 'oct':
                month = 10;
                break;
            case 'nov':
                month = 11;
                break;
            case 'dec':
                month = 12;
                break;
            default:
                month = bits[1];
                break;
        }
        var d = new Date(bits[2] + '-' + month + '-' + bits[0]);
        return !!(d && (d.getMonth() + 1) == month && d.getDate() == Number(bits[0]));
    }
    else {
        return false;
    }
}