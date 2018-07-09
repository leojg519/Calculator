$(document).ready(function () {
    
    $('#reset-form').click(function () {
        $('#calculation-result').text('');
        $('#operands-actions').show();
        $('#calculate-total').show();
        $('#reset-form').hide();
        $('#result-container').hide();
        $('.op0 input').val('');
        $('.operand input').prop('disabled', false);
        $('#error-message').hide();
    });

    $('#calculate-total').click(function (e) {
        e.preventDefault();
        var operandValue = $('.op0 input').val();

        if (operandValue === '') {
            $('.op0 input').addClass('error');
            showErrorMessage('Operands can not be empty values. '
                + 'Please provide positive integer values for all the operands or remove the empty ones.');
            return;
        }

        $.ajax({
            method: 'POST',
            dataType: 'json',
            url: '/Calculator/Sqrt',
            headers: { 'X-Evi-Tracking-Id': window.trackingId },
            data: {
                Number: operandValue
            },
            success: function (response) {
                manageResponse(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});

function manageResponse(response) {
    if (response.Code === 200) {
        hideButtons();
        $('#calculation-result').text(response.Message.Square);
    } else {
        showErrorMessage(response.message);
    }
}