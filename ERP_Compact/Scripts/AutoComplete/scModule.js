
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        ModuleID: $('#ModuleID').val(),
        ModuleName: $('#ModuleName').val(),
        ModuleLevel: $('#ModuleLevel').val(),

    };
    $.ajax({
        url: "/MgtModules/Add",
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
        ModuleID: $('#ModuleID').val(),
        ModuleName: $('#ModuleName').val(),
        ModuleLevel: $('#ModuleLevel').val(),
    };
    $.ajax({
        url: "/MgtModules/Update",
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

    ModuleID: $('#ModuleID').val();
    ModuleName: $('#ModuleName').val();
    ModuleLevel: $('#ModuleLevel').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#ModuleName').val().trim() === "") {
        $('#ModuleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ModuleName').css('border-color', 'lightgrey');
    }
    if ($('#ModuleLevel').val().trim() === "") {
        $('#ModuleLevel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ModuleLevel').css('border-color', 'lightgrey');
    }

    return isValid;
}