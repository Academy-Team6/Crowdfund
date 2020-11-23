// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addProjectCreator() {

    var actionUrl = "/api/projectcreator";
    var formData = new FormData();


    formData.append("firstName", $('#FirstName').val());
    formData.append("lastName", $('#LastName').val());
    formData.append("description", $('#Description').val());
    formData.append("email", $('#Email').val());

    var object = {};
    formData.forEach(function (value, key) {
        object[key] = value;
    });
    var json = JSON.stringify(object);
    $.ajax(
        {
            url: actionUrl,
            dataType:"json",
            data: json,
            processData: false,
            contentType: 'application/json',
            type: "POST",
            success: function (data) {
                alert(json)
                window.open("/home/projectcreator", "_self")
               
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
}
function updateProjectCreator() {
    id = $("#Id").val()

    actionUrl = "/api/projectcreator/" + id
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "firstName": $("#FirstName").val(),
        "lastName": $("#LastName").val(),
        "description": $("#Description").val(),
        "email": $("#Email").val(),
    }


    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open("/home/projectcreator", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}
function deleteProjectCreator(Id) {
    id = $("#id").val()

    console.log(id);
    console.log(Id);

    actionUrl = "/api/projectcreator/" + id
    actiontype = "DELETE"
    actionDataType = "json"

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,

        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
            window.open("/home/projectcreator", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}