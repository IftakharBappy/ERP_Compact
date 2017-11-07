//Add Data Function   
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        DivisionKey: $('#DivisionKey').val(),
        DivisionID: $('#DivisionID').val(),
        DivisionName: $('#DivisionName').val()
    };
    $.ajax({
        url: "/MgtDivision/Add",
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

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var empObj = {
        DivisionKey: $('#DivisionKey').val(),
        DivisionID: $('#DivisionID').val(),
        DivisionName: $('#DivisionName').val()
    };
    $.ajax({
        url: "/MgtDivision/Update",
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

function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/MgtDivision/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                clearTextBox();
                $('#msgSuccess').show();
                setTimeout(function () {
                    window.location.reload();
                }, 1000);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for clearing the textboxes  
function clearTextBox() {

    $('#DivisionKey').val("");
    $('#DivisionID').val("");
    $('#DivisionName').val("");

}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#DivisionName').val().trim() === "") {
        $('#DivisionName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DivisionName').css('border-color', 'lightgrey');
    }
    if ($('#DivisionID').val().trim() === "") {
        $('#DivisionID').val($('#DivisionName').val());       
        $('#DivisionID').css('border-color', 'lightgrey');
    }
    else {
        $('#DivisionID').css('border-color', 'lightgrey');
    }

    return isValid;
}