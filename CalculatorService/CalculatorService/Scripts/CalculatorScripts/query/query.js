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
        var query;

        try {
            query = getOperands();
        } catch{
            return;
        }

        e.preventDefault();
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Journal/Query',
            headers: { 'X-Evi-Tracking-Id': window.trackingId },
            data: {
                Id: query
            },
            success: function (response) {
                manageResponse(response);
            },
            error: function (error) {
                showErrorMessage(error.responseJSON.Message);
            }
        });
    });
});

function manageResponse(response) {
    if (response.Code === 200) {
        hideButtons();
        $.each(response.Message.Operations, function (index, operation) {
            $('#calculation-result').append(
                '<tr>'
                + '<td>' + operation.Operation + '</td>'
                + '<td>' + operation.Calculation + '</td>'
                + '<td>' + operation.Date + '</td>'
                + '</tr>'
            );
        });
    } else {
        showErrorMessage(response.message);
    }
}
