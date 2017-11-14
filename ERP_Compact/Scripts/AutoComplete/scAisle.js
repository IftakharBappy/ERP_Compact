
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        AisleKey: $('#AisleKey').val(),
        AisleID: $('#AisleID').val(),
        AisleName: $('#AisleName').val(),
        AisleLevel: $('#AisleLevel').val()
    };
    $.ajax({
        url: "/MgtStore/Add",
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
        AisleKey: $('#AisleKey').val(),
        AisleID: $('#AisleID').val(),
        AisleName: $('#AisleName').val(),
        AisleLevel: $('#AisleLevel').val()
    };
    $.ajax({
        url: "/MgtStore/Update",
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

    $('#AisleKey').val("");
    $('#AisleID').val("");
    $('#AisleName').val("");
    $('#AisleLevel').val("");

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#AisleName').val().trim() === "") {
        $('#AisleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#AisleName').css('border-color', 'lightgrey');
    }
    if ($('#AisleID').val().trim() === "") {
        $('#AisleID').val($('#AisleName').val());
        $('#AisleID').css('border-color', 'lightgrey');
    }
    else {
        $('#AisleID').css('border-color', 'lightgrey');
    }

    return isValid;
}