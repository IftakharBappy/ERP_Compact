function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        DistrictKey: $('#DistrictKey').val(),
        DistrictID: $('#DistrictID').val(),
        DistrictName: $('#DistrictName').val(),
        DivisionKey: $('#DivisionKey').val(),

    };
    $.ajax({
        url: "/MgtDistrict/Add",
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
        DistrictKey: $('#DistrictKey').val(),
        DistrictID: $('#DistrictID').val(),
        DistrictName: $('#DistrictName').val(),
        DivisionKey: $('#DivisionKey').val(),
    };
    $.ajax({
        url: "/MgtDistrict/Update",
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

    DistrictKey: $('#DistrictKey').val();
    DistrictID: $('#DistrictID').val();
    DistrictName: $('#DistrictName').val();
    DivisionKey: $('#DivisionKey').val();

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#DistrictName').val().trim() === "") {
        $('#DistrictName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DistrictName').css('border-color', 'lightgrey');
    }
    if ($('#DistrictID').val().trim() === "") {
        $('#DistrictID').val($('#DistrictName').val());
        $('#DistrictID').css('border-color', 'lightgrey');
    }
    else {
        $('#DistrictID').css('border-color', 'lightgrey');
    }

    if ($('#DivisionKey').val().trim() === "") {
        $('#DivisionKey').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DivisionKey').css('border-color', 'lightgrey');
    }

    return isValid;
}