function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        FormID: $('#FormID').val(),
        ModuleID: $('#ModuleID').val(),
        FormName: $('#FormName').val(),
        FormLevel: $('#FormLevel').val(),
        FormController: $('#FormController').val(),
        ViewName: $('#ViewName').val(),
        SubModuleID: $('#SubModuleID').val(),
    };
    $.ajax({
        url: "/MgtForm/Add",
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
        FormID: $('#FormID').val(),
        ModuleID: $('#ModuleID').val(),
        FormName: $('#FormName').val(),
        FormLevel: $('#FormLevel').val(),
        FormController: $('#FormController').val(),
        ViewName: $('#ViewName').val(),
        SubModuleID: $('#SubModuleID').val()
    };
    $.ajax({
        url: "/MgtForm/Update",
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

    FormID: $('#FormID').val();
    ModuleID: $('#ModuleID').val();
    FormName: $('#FormName').val();
    FormLevel: $('#FormLevel').val();
    FormController: $('#FormController').val();
    ViewName: $('#ViewName').val();
    SubModuleID: $('#SubModuleID').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;

    if ($('#FormName').val().trim() === "") {
        $('#FormName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FormName').css('border-color', 'lightgrey');
    }
    if ($('#ModuleID').val().trim() === "") {
        $('#ModuleID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ModuleID').css('border-color', 'lightgrey');
    }
    if ($('#SubModuleID').val().trim() === "") {
        $('#SubModuleID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SubModuleID').css('border-color', 'lightgrey');
    }
    if ($('#FormLevel').val().trim() === "") {
        $('#FormLevel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FormLevel').css('border-color', 'lightgrey');
    }
    if ($('#FormController').val().trim() === "") {
        $('#FormController').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FormController').css('border-color', 'lightgrey');
    }
    if ($('#ViewName').val().trim() === "") {
        $('#ViewName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ViewName').css('border-color', 'lightgrey');
    }
    return isValid;
}