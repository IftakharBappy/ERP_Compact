function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        SubcategoryKey: $('#SubcategoryKey').val(),
        SubcategoryID: $('#SubcategoryID').val(),
        SubcategoryName: $('#SubcategoryName').val(),
        CategoryKey: $('#CategoryKey').val(),

    };
    $.ajax({
        url: "/MgtAssetSubcategory/Add",
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
        SubcategoryKey: $('#SubcategoryKey').val(),
        SubcategoryID: $('#SubcategoryID').val(),
        SubcategoryName: $('#SubcategoryName').val(),
    };
    $.ajax({
        url: "/MgtAssetSubcategory/Update",
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

    SubcategoryKey: $('#SubcategoryKey').val();
    SubcategoryID: $('#SubcategoryID').val();
    SubcategoryName: $('#SubcategoryName').val();
    CategoryKey: $('#CategoryKey').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#SubcategoryName').val().trim() === "") {
        $('#SubcategoryName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SubcategoryName').css('border-color', 'lightgrey');
    }
    if ($('#SubcategoryID').val().trim() === "") {
        $('#SubcategoryID').val($('#SubcategoryName').val());
        $('#SubcategoryID').css('border-color', 'lightgrey');
    }
    else {
        $('#SubcategoryID').css('border-color', 'lightgrey');
    }

    if ($('#CategoryKey').val().trim() === "") {
        $('#CategoryKey').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CategoryKey').css('border-color', 'lightgrey');
    }

    return isValid;
}