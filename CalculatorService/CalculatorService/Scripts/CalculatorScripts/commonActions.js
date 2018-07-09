var numberOfOperands = 2;

$(document).ready(function () {
    $('#remove-operand').click(function (e) {
        e.preventDefault();
        if (numberOfOperands > 2) {
            var selector = '.op' + (numberOfOperands - 1);
            $(selector).remove();
            numberOfOperands--;
        }
    });
    
    // Allow only numeric values in the operand inputs
    $(document).on('keydown', '.operand input', function (e) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            e.preventDefault();
        }
    });

    $(document).on('keydown', '.operand input.error', function () {
        $(this).removeClass('error');
        $('#error-message span').text('');
        $('#error-message').hide();
    });    
});

function getOperands() {
    var operands = [];
    var error = 0;

    $('.operand input').map(function (index, element) {
        if ($(element).val() === '') {
            $(element).addClass('error');
            showErrorMessage('Operands can not be empty values. '
                + 'Please provide positive integer values for all the operands or remove the empty ones.');
            error++;
        }
        operands.push(parseInt($(element).val()));
    });

    if (error === 0) {
        return operands;
    } else {
        throw false;
    }
}

function reset(operator) {
    $('#operands-container').html(
        '<div class="operand op0">'
        + '<input />'
        + '</div>'
        + '<span>' + operator + '</span>'
        + '<div class="operand op1">'
        + '<input />'
        + '</div>');
    $('#calculation-result').text('');
    $('#quotient-result').text('');
    $('#remainder-result').text('');
    $('#operands-actions').show();
    $('#calculate-total').show();
    $('#reset-form').hide();
    $('#result-container').hide();
    $('.op0 input').val('');
    $('.op1 input').val('');
    $('.operand input').prop('disabled', false);
    $('#error-message').hide();
}

function hideButtons() {
    $('#operands-actions').hide();
    $('#calculate-total').hide();
    $('#reset-form').show();
    $('#result-container').show();
    $('.operand input').prop('disabled', true);
}

function showErrorMessage(message) {
    $('#error-message span').text(message);
    $('#error-message').show();
}