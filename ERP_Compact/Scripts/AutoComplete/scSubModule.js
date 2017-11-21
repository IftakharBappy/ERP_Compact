function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        SubModuleID: $('#SubModuleID').val(),
        ModuleID: $('#ModuleID').val(),
        SubModuleName: $('#SubModuleName').val(),
        SubModuleLevel: $('#SubModuleLevel').val(),

    };
    $.ajax({
        url: "/MgtSubModule/Add",
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
        SubModuleID: $('#SubModuleID').val(),
        ModuleID: $('#ModuleID').val(),
        SubModuleName: $('#SubModuleName').val(),
        SubModuleLevel: $('#SubModuleLevel').val(),
    };
    $.ajax({
        url: "/MgtSubModule/Update",
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

function clearTextBox() {

    SubModuleID: $('#SubModuleID').val();
    ModuleID: $('#ModuleID').val();
    SubModuleName: $('#SubModuleName').val();
    SubModuleLevel: $('#SubModuleLevel').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#SubModuleName').val().trim() === "") {
        $('#SubModuleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SubModuleName').css('border-color', 'lightgrey');
    }
    if ($('#SubModuleLevel').val().trim() === "") {
        $('#SubModuleLevel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SubModuleLevel').css('border-color', 'lightgrey');
    }

    if ($('#ModuleID').val().trim() === "") {
        $('#ModuleID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ModuleID').css('border-color', 'lightgrey');
    }

    return isValid;
}