// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Login-Logout
if (getUserId()!=null) {
    $('#logout-btn').show();
}


function getUserId() {
    return localStorage.getItem('userId');
}

// Events

$('#login-btn').on('click', function () {
    let firstname = $('#username').val();
    let lastname = $('#password').val();
    let loginOptions = {
        Username: firstname,
        Password: lastname
    };
    let json3 = JSON.stringify(loginOptions);
    $.ajax({
        url: '/api/login',
        contentType: 'application/json',
        type: 'POST',
        data: json3,
        dataType: 'json',
        processData:false,
        success: function (data) {
            localStorage.setItem('userId', data.id);
            localStorage.setItem('typeOfUser', data.typeOfUser);
            $('#logout-btn').show();
            $('#login-btn').hide();
            $('#login-link').hide();
        },
        error: function () {
           
            console.log('Error');
        }
    });
});

$('#logout-btn').on('click', function () {
    localStorage.removeItem('userId');
    $('#logout-btn').hide();
    $('#login-btn').show();
    $('#login-link').show();
});

//P R O J E C T  C R E A T O R 

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
//P R O J E C T

//dropdown project.Category menu
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
function deleteProject(Id) {
    id = $("#id").val()

    console.log(id);
    console.log(Id);

    actionUrl = "/api/project/" + Id
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
            window.open("/home/project", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}
