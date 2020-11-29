// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Login-Logout
if (getUserId() != null) {
    $('#logout-btn').removeClass('d-none');
}
if (getTypeOfUser() == 'ProjectCreator') {
    $('#admin-layout').addClass('d-none');
    $('#projectCreator-layout').removeClass('d-none');
}
else if (getTypeOfUser() == 'Backer') {
    $('#backer-layout').removeClass('d-none');
    $('#admin-layout').addClass('d-none');
}
else {
    $('#projectCreator-layout').addClass('d-none');
    $('#backer-layout').addClass('d-none');
    $('#admin-layout').removeClass('d-none');

}


function getUserId() {
    return localStorage.getItem('userId');
}
function getTypeOfUser() {
    return localStorage.getItem('typeOfUser');
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
            if (data.typeOfUser == "ProjectCreator") window.location.replace('/home/projectCreatorProfile?projectCreatorId=' + localStorage.getItem('userId'));
            if (data.typeOfUser == "Backer") window.location.replace('/home/backerprofile?backerId=' + localStorage.getItem('userId'));
            $('#login-link').addClass('d-none');
            
        },
        error: function () {
           
            console.log('Error');
        }
    });
});
function logout() {
    localStorage.removeItem('userId');
    localStorage.removeItem('typeOfUser');
    $('#logout-btn').addClass('d-none');
    $('#login-link').removeClass('d-none');
    window.location.replace('/');
}
//P R O J E C T  C R E A T O R 
function getDashboard() {
    if (localStorage.getItem('typeOfUser') == 'ProjectCreator') {
        console.log(localStorage.getItem('userId'));
        window.open("/home/dashboard?projectCreatorId=" + localStorage.getItem('userId'), "_self");
    }
}

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
            success: function () {
                alert(json)
                window.open("/home/login", "_self")
               
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
    debugger;
    $(this).parents(".dropdown").find('.btn').html($(this).text() + ' <span class="caret"></span>');
    $(this).parents(".dropdown").find('.btn').val($(this).data('value'));
});

function viewProject(projectId) {
    console.log("inviewprojectc" + projectId)
    //storeProjectId(projectId);
    window.open("/home/viewproject?projectId=" + projectId, "_self")
}
function addProject() {
    var actionUrl = "/api/project";
    var formData = new FormData();


    formData.append("Title", $('#Title').val());
    formData.append("Category", $('#Category').val());
    formData.append("Description", $('#Description').val());
    formData.append("TargetBudget", $('#TargetBudget').val());
    //formData.append("ProjectCreatorId", parseInt($('#ProjectCreatorId').val()));
    formData.append("ProjectCreatorId", parseInt(localStorage.getItem('userId')));
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
    console.log(id);

    actionUrl = "/api/project/" + id
    actiontype = "PUT"

    var formData = new FormData();


    formData.append("Title", $('#Title').val());
    formData.append("Category", $('#Category').val());
    formData.append("Description", $('#Description').val());
    formData.append("TargetBudget", $('#TargetBudget').val());

    console.log(formData);
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
function prepareForMediaAdd(projectId) {
    localStorage.setItem('projectId', projectId);
    console.log('preparedformediawithid' + projectId);
    window.open("/home/addmedia", "_self");
}

function addMedia() {
    var actionUrl = "/api/media";
    var formData = new FormData();

    formData.append("Type", $('#MediaType').val());
    formData.append("Payload", $('#Link').val());
    formData.append("ProjectId", localStorage.getItem('projectId'));
    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                alert('successful Media add');
             //   window.open("/home/project", "_self")

            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
}