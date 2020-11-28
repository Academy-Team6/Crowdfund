// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addRewardPackage() {
    var actionUrl = "/api/rewardpackage/" + localStorage.getItem('projectId');
    var formData = new FormData();

    formData.append("price", $('#Price').val());
    formData.append("reward", $('#Reward').val());
    formData.append("projectId", parseInt(localStorage.getItem('projectId')));

    var json = JSON.stringify(formData);
    console.log(json);
    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function () {
                alert(json)
                window.open("/home/rewardpackage", "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
}
function updateRewardPackage() {
    id = $("#Id").val()

    actionUrl = "/api/rewardpackage/" + id
    actiontype = "PUT"

    var formData = new FormData();


    formData.append("Price", $('#Price').val());
    formData.append("Reward", $('#Reward').val());
    formData.append("ProjectId", $('#ProjectId').val());

    $.ajax({
        url: actionUrl,
        type: actiontype,
        data: formData,
        contentType: false,
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open("/home/rewardpackage", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}
function deleteRewardPackage(Id) {
    console.log(Id);

    actionUrl = "/api/rewardpackage/" + Id
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
            window.open("/home/rewardpackage", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}

//workaround for add reward package from project button.To work uncomment line 14.
function addRewardPackageWithId(projectId) {
    console.log("inaddrewardpackagec" + projectId)
    storeProjectId(projectId);
    window.open("/home/addrewardpackage/" + projectId, "_self")

}
//Useful to select reward packages acording to current project
function storeProjectId(projectId) {
    localStorage.setItem('projectId', projectId);
}

