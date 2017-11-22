
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        ShelfKey: $('#ShelfKey').val(),
        ShelfID: $('#ShelfID').val(),
        ShelfName: $('#ShelfName').val(),
        ShelfLevel: $('#ShelfLevel').val(),
    };
    $.ajax({
        url: "/MgtStoreShelf/Add",
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
        ShelfKey: $('#ShelfKey').val(),
        ShelfID: $('#ShelfID').val(),
        ShelfName: $('#ShelfName').val(),
        ShelfLevel: $('#ShelfLevel').val(),
    };
    $.ajax({
        url: "/MgtStoreShelf/Update",
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

    ShelfKey: $('#ShelfKey').val();
    ShelfID: $('#ShelfID').val();
    ShelfName: $('#ShelfName').val();
    ShelfLevel: $('#ShelfLevel').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#ShelfName').val().trim() === "") {
        $('#ShelfName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ShelfName').css('border-color', 'lightgrey');
    }
    if ($('#ShelfLevel').val().trim() === "") {
        $('#ShelfLevel').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ShelfLevel').css('border-color', 'lightgrey');
    }
    if ($('#ShelfID').val().trim() === "") {
        $('#ShelfID').val($('#ShelfName').val());
        $('#ShelfID').css('border-color', 'lightgrey');
    }
    else {
        $('#ShelfID').css('border-color', 'lightgrey');
    }

    return isValid;
}