$(document).ready(function () {
    $('#reset-form').click(function () {
        reset('-');
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
            url: '/Calculator/Sub',
            headers: { 'X-Evi-Tracking-Id': window.trackingId },
            data: {
                Minuend: operandsList.shift(),
                Subtrahend: operandsList
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
        $('#calculation-result').text(response.Message.Difference);
    } else {
        showErrorMessage(response.message);
    }
}
