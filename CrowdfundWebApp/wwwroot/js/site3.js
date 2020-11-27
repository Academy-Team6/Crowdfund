// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addRewardPackage() {

    var actionUrl = "/api/rewardpackage";
    var formData = new FormData();

    formData.append("price", $('#Price').val());
    formData.append("reward", $('#Reward').val());
    formData.append("projectId", parseInt($('#ProjectId').val()));

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
    actionDataType = "json"

    sendData = {
        "Price": $("#Price").val(),
        "Reward": $("#Reward").val()
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

            window.open("/home/rewardpackage", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}
function deleteRewardPackage(Id) {
    id = $("#id").val()

    console.log(id);
    console.log(Id);

    actionUrl = "/api/rewardpackage/" + id
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