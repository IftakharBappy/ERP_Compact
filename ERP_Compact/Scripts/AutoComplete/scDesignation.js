
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        DesignationKey: $('#DesignationKey').val(),
        DesignationtID: $('#DesignationtID').val(),
        DesignationName: $('#DesignationName').val(),
        DesignationLevel: $('#DesignationLevel').val(),

    };
    $.ajax({
        url: "/MgtDesignation/Add",
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
        DesignationKey: $('#DesignationKey').val(),
        DesignationtID: $('#DesignationtID').val(),
        DesignationName: $('#DesignationName').val(),
        DesignationLevel: $('#DesignationLevel').val(),
    };
    $.ajax({
        url: "/MgtDesignation/Update",
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

    DesignationKey: $('#DesignationKey').val();
    DesignationtID: $('#DesignationtID').val();
    DesignationName: $('#DesignationName').val();
    DesignationLevel: $('#DesignationLevel').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#DesignationName').val().trim() === "") {
        $('#DesignationName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DesignationName').css('border-color', 'lightgrey');
    }
    if ($('#DesignationtID').val().trim() === "") {
        $('#DesignationtID').val($('#DesignationName').val());
        $('#DesignationtID').css('border-color', 'lightgrey');
    }
    else {
        $('#DesignationtID').css('border-color', 'lightgrey');
    }

    return isValid;
}