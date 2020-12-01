// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function addBacker() {

    var actionUrl = "/api/backer";
    var formData = new FormData();
    formData.append("firstName", $('#FirstName').val());
    formData.append("lastName", $('#LastName').val());
    formData.append("email", $('#Email').val());
    
    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                window.open("/home/login", "_self")
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


function updateBacker() {
    id = $("#Id").val()

    actionUrl = "/api/backer/" + id
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "FirstName": $("#FirstName").val(),
        "LastName": $("#LastName").val(),
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
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}

//Transaction

function createTransaction(rewardPackageId) {
    //console.log("increatetransactionc" + rewardpackageId)
    //storeProjectId(projectId);
    console.log(rewardPackageId);
    var actionUrl = "/api/transaction";
    var formData = new FormData();
    formData.append("backerId", localStorage.getItem("userId"));
    formData.append("rewardPackageId", rewardPackageId);
    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                window.open("/home/getmytransactions?backerId=" + localStorage.getItem('userId'), "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
    //window.open("/home/createtransaction?backerId="+localStorage.getItem("userId")+"?rewardPackageOptionId=" + rewardpackageId, "_self")
}
function getMyTransactions() {
    if (localStorage.getItem('typeOfUser') == 'Backer') {
        console.log(localStorage.getItem('userId'));
        window.open("/home/getmytransactions?backerId=" + localStorage.getItem('userId'), "_self");
    }
}
function backedProjects() {
    if (localStorage.getItem('typeOfUser') == 'Backer') {
        console.log(localStorage.getItem('userId'));
        window.open("/home/backedprojects?backerId=" + localStorage.getItem('userId'), "_self");
    }
}