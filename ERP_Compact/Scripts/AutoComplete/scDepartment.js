function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        DepartmentKey: $('#DepartmentKey').val(),
        DepartmentID: $('#DepartmentID').val(),
        DepartmentName: $('#DepartmentName').val(),

    };
    $.ajax({
        url: "/MgtDepartment/Add",
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
        DepartmentKey: $('#DepartmentKey').val(),
        DepartmentID: $('#DepartmentID').val(),
        DepartmentName: $('#DepartmentName').val(),
    };
    console.log(empObj);
    $.ajax({
        url: "/MgtDepartment/Update",
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

    DepartmentKey: $('#DepartmentKey').val();
    DepartmentID: $('#DepartmentID').val();
    DepartmentName: $('#DepartmentName').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#DepartmentName').val().trim() === "") {
        $('#DepartmentName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DepartmentName').css('border-color', 'lightgrey');
    }
    if ($('#DepartmentID').val().trim() === "") {
        $('#DepartmentID').val($('#DepartmentName').val());
        $('#DepartmentID').css('border-color', 'lightgrey');
    }
    else {
        $('#DepartmentID').css('border-color', 'lightgrey');
    }
    return isValid;
}