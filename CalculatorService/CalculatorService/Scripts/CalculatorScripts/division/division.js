$(document).ready(function () {
    $('#reset-form').click(function () {
        reset('&#247;');
    });

    $('#calculate-total').click(function (e) {
        var operandsList;

        try {
            operandsList = getOperands();
        } catch{
            return;
        }

        e.preventDefault();
        $.ajax({
            method: 'POST',
            dataType: 'json',
            url: '/Calculator/Div',
            headers: { 'X-Evi-Tracking-Id': window.trackingId },
            data: {
                Dividend: operandsList.shift(),
                Divisor: operandsList
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
        $('#quotient-result').text(response.Message.Quotient);
        $('#remainder-result').text(response.Message.Remainder);
    } else {
        showErrorMessage(response.message);
    }
}
