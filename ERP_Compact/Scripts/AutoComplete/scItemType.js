
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        TypeKey: $('#TypeKey').val(),
        TypeName: $('#TypeName').val(),
        TypeID: $('#TypeID').val(),

    };
    $.ajax({
        url: "/MgtItemType/Add",
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
        TypeKey: $('#TypeKey').val(),
        TypeName: $('#TypeName').val(),
        TypeID: $('#TypeID').val(),
    };
    $.ajax({
        url: "/MgtItemType/Update",
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

    TypeKey: $('#TypeKey').val();
    TypeName: $('#TypeName').val();
    TypeID: $('#TypeID').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#TypeName').val().trim() === "") {
        $('#TypeName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TypeName').css('border-color', 'lightgrey');
    }
    if ($('#TypeID').val().trim() === "") {
        $('#TypeID').val($('#TypeName').val());
        $('#TypeID').css('border-color', 'lightgrey');
    }
    else {
        $('#TypeID').css('border-color', 'lightgrey');
    }

    return isValid;
}