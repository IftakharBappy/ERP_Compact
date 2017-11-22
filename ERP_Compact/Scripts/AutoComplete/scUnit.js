
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        UnitKey: $('#UnitKey').val(),
        UnitID: $('#UnitID').val(),
        UnitName: $('#UnitName').val(),

    };
    $.ajax({
        url: "/MgtUnit/Add",
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
        UnitKey: $('#UnitKey').val(),
        UnitID: $('#UnitID').val(),
        UnitName: $('#UnitName').val(),
    };
    $.ajax({
        url: "/MgtUnit/Update",
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

    UnitKey: $('#UnitKey').val();
    UnitID: $('#UnitID').val();
    UnitName: $('#UnitName').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#UnitName').val().trim() === "") {
        $('#UnitName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UnitName').css('border-color', 'lightgrey');
    }
    if ($('#UnitID').val().trim() === "") {
        $('#UnitID').val($('#UnitName').val());
        $('#UnitID').css('border-color', 'lightgrey');
    }
    else {
        $('#UnitID').css('border-color', 'lightgrey');
    }

    return isValid;
}