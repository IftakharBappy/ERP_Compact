
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        CategoryKey: $('#CategoryKey').val(),
        CategoryID: $('#CategoryID').val(),
        CategoryName: $('#CategoryName').val(),

    };
    $.ajax({
        url: "/MgtAssetCategory/Add",
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
        CategoryKey: $('#CategoryKey').val(),
        CategoryID: $('#CategoryID').val(),
        CategoryName: $('#CategoryName').val(),
    };
    $.ajax({
        url: "/MgtAssetCategory/Update",
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

    CategoryKey: $('#CategoryKey').val();
    CategoryID: $('#CategoryID').val();
    CategoryName: $('#CategoryName').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#CategoryName').val().trim() === "") {
        $('#CategoryName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CategoryName').css('border-color', 'lightgrey');
    }
    if ($('#CategoryID').val().trim() === "") {
        $('#CategoryID').val($('#CategoryName').val());
        $('#CategoryID').css('border-color', 'lightgrey');
    }
    else {
        $('#CategoryID').css('border-color', 'lightgrey');
    }

    return isValid;
}