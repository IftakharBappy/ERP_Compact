
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        RowKey: $('#RowKey').val(),
        RowID: $('#RowID').val(),
        RowName: $('#RowName').val(),
        RowLevel: $('#RowLevel').val(),
    };
    $.ajax({
        url: "/MgtStoreRaws/Add",
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
        RowKey: $('#RowKey').val(),
        RowID: $('#RowID').val(),
        RowName: $('#RowName').val(),
        RowLevel: $('#RowLevel').val(),
    };
    $.ajax({
        url: "/MgtStoreRaws/Update",
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

    RowKey: $('#RowKey').val();
    RowID: $('#RowID').val();
    RowName: $('#RowName').val();
    RowLevel: $('#RowLevel').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#RowName').val().trim() === "") {
        $('#RowName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#RowName').css('border-color', 'lightgrey');
    }
    if ($('#RowLevel').val().trim() === "") {
        $('#RowLevel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#RowLevel').css('border-color', 'lightgrey');
    }
    if ($('#RowID').val().trim() === "") {
        $('#RowID').val($('#RowName').val());
        $('#RowID').css('border-color', 'lightgrey');
    }
    else {
        $('#RowID').css('border-color', 'lightgrey');
    }

    return isValid;
}