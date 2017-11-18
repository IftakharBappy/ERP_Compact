
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        ProcessKey: $('#ProcessKey').val(),
        ProcessID: $('#ProcessID').val(),
        ProcessName: $('#ProcessName').val(),
        ProcessLevel: $('#ProcessLevel').val(),
        Description: $('#Description').val()
    };
    $.ajax({
        url: "/MgtProductionProcessSetup/Add",
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
        ProcessKey: $('#ProcessKey').val(),
        ProcessID: $('#ProcessID').val(),
        ProcessName: $('#ProcessName').val(),
        ProcessLevel: $('#ProcessLevel').val(),
        Description: $('#Description').val()
    };
    $.ajax({
        url: "/MgtProductionProcessSetup/Update",
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

    ProcessKey: $('#ProcessKey').val();
    ProcessID: $('#ProcessID').val();
    ProcessName: $('#ProcessName').val();
    ProcessLevel: $('#ProcessLevel').val();
    Description: $('#Description').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#ProcessName').val().trim() === "") {
        $('#ProcessName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProcessName').css('border-color', 'lightgrey');
    }
    if ($('#ProcessLevel').val().trim() === "") {
        $('#ProcessLevel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProcessLevel').css('border-color', 'lightgrey');
    }
    if ($('#ProcessID').val().trim() === "") {
        $('#ProcessID').val($('#ProcessName').val());
        $('#ProcessID').css('border-color', 'lightgrey');
    }
    else {
        $('#ProcessID').css('border-color', 'lightgrey');
    }

    return isValid;
}