
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        TaxKey: $('#TaxKey').val(),
        TaxID: $('#TaxID').val(),
        Amt: $('#Amt').val(),

    };
    $.ajax({
        url: "/MgtTax/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearTextBox();
            $('#msgSuccess').show();
            setTimeout(function () {
                window.location.reload(1);
            }, 1000);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Update() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        TaxKey: $('#TaxKey').val(),
        TaxID: $('#TaxID').val(),
        Amt: $('#Amt').val(),
    };
    $.ajax({
        url: "/MgtTax/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            clearTextBox();
            $('#msgSuccess').show();
            setTimeout(function () {
                window.location.reload(1);
            }, 1000);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for clearing the textboxes  
function clearTextBox() {

    TaxKey: $('#TaxKey').val();
    TaxID: $('#TaxID').val();
    Amt: $('#Amt').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#TaxID').val().trim() === "") {
        $('#TaxID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TaxID').css('border-color', 'lightgrey');
    }
    if ($('#Amt').val().trim() === "") {
        $('#Amt').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Amt').css('border-color', 'lightgrey');
    }

    return isValid;
}