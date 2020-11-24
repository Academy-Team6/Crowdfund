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

    actionUrl = "/api/projectcreator/" + Id
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

$(".dropdown-menu li a").click(function () {
    $(this).parents(".dropdown").find('.btn').html($(this).text() + ' <span class="caret"></span>');
    $(this).parents(".dropdown").find('.btn').val($(this).data('value'));
});


function addProject() {
    var actionUrl = "/api/project";
    var formData = new FormData();


    formData.append("Title", $('#Title').val());
    formData.append("Category", $('#Category').val());
    formData.append("Description", $('#Description').val());
    formData.append("TargetBudget", $('#TargetBudget').val());
    formData.append("ProjectCreatorId", parseInt($('#ProjectCreatorId').val()));

    var object = {};
    formData.forEach(function (value, key) {
        object[key] = value;
    });
    var json = JSON.stringify(formData);
    console.log(json);
    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                alert(json)
                window.open("/home/project", "_self")

            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
}
function updateProject() {
    id = $("#Id").val()

    actionUrl = "/api/project/" + id
    actiontype = "PUT"

    var formData = new FormData();


    formData.append("Title", $('#Title').val());
    formData.append("Category", $('#Category').val());
    formData.append("Description", $('#Description').val());
    formData.append("TargetBudget", $('#TargetBudget').val());


    $.ajax({
        url: actionUrl,
        type: actiontype,
        data: formData,
        contentType: false,
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open("/home/project", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}

$(document).ready(function testProject() {
    $.ajax(
        {
            type: "GET",
            url: "localhost:49207/api/project",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                parsedData = JSON.parse(data);
                console.log(parsedData);
                $.each(parsedData.id, function (i, item) {
                    $("#personDataTable tbody").append(
                        "<tr>" + "<td>" + data.Id + "</td>"
                        + "<td>" + data.Title + "</td>"
                        + "<td>" + data.Category + "</td>"
                        + "<td>" + data.Descreption + "</td>"
                        + "<td>" + data.TargetBudget + "</td>"
                        + "</tr>")
                })
            },
            error: function (msg) {

                alert(msg.responseText);
            }
        });
});
   