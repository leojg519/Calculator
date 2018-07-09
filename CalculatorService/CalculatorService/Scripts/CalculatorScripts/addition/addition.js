$(document).ready(function () {
    $('#new-operand').click(function (e) {
        e.preventDefault();
        numberOfOperands++;

        $('#operands-container').append(
            '<span class= "op' + (numberOfOperands - 1) + '">+</span >'
            + '<div class= "operand op' + (numberOfOperands - 1) + '">'
            + '<input />'
            + '</div>'
        );
    });
    
    $('#reset-form').click(function () {        
        reset('+');
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
            type: 'POST',
            dataType: 'json',
            url: '/Calculator/Add',
            headers: { 'X-Evi-Tracking-Id': window.trackingId },
            data: {
                Addends: operandsList
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
        $('#calculation-result').text(response.Message.Sum);
    } else {
        showErrorMessage(response.message);
    }
}