// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function addBacker() {

    var actionUrl = "/api/backer";
    var formData = new FormData();



    formData.append("Name", $('#Name').val());
    formData.append("email", $('#Email').val());

    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                window.open("/home/backer", "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
}


function findBacker() {
    searchText = $("#searchText").val()
    actionUrl = "/Home/FindBackerDisplay?text=" + searchText

    window.open(actionUrl, "_self");
}

function findToUpdateBacker() {

    id = $("#Id").val()
    actionUrl = "/Home/UpdateBackerWithDetails/" + id

    window.open(actionUrl, "_self");

}



function updateBacker() {
    id = $("#Id").val()

    actionUrl = "/api/backer/" + id
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "Name": $("#Name").val(),
        "email": $("#Email").val()
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

            window.open("/home/backer", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}




function deleteBacker() {

    id = $("#Id").val()

    actionUrl = "/api/backer/" + id
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
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}