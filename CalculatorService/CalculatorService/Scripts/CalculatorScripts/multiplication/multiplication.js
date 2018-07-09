$(document).ready(function () {
    $('#new-operand').click(function (e) {
        e.preventDefault();
        numberOfOperands++;

        $('#operands-container').append(
            '<span class= "op' + (numberOfOperands - 1) + '">x</span >'
            + '<div class= "operand op' + (numberOfOperands - 1) + '">'
            + '<input />'
            + '</div>'
        );
    });

    $('#reset-form').click(function () {
        reset('x');
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
            url: '/Calculator/Mult',
            headers: { 'X-Evi-Tracking-Id': window.trackingId },
            data: {
                Factors: operandsList
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
        $('#calculation-result').text(response.Message.Product);
    } else {
        showErrorMessage(response.message);
    }
}
