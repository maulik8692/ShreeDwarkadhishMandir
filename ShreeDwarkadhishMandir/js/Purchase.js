$(document).ready(function () {
    ResetForm();
    $('input[type=radio][name=TransactionFrom]').change(function () {
        if (this.value === 'Cash') {
            $('.Cheque').hide();
        }
        else if (this.value === 'Cheque') {
            $('.Cheque').show();
        }
       
        $('#ChequeNumber').val('');
        $('#ChequeDate').val('');

    });
});

function ResetForm() {
    $('.Cheque').hide();
    $('input[name="TransactionFrom"]').prop('checked', false);
    //showProgress();
    //$(".Bhandar").hide();
    //$(".UOM").hide();
    //GetStoreList();
    hideProgress();
}