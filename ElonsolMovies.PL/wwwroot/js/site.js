// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let actorId = null;

$(".actor-delete").on("click", function (e) {
    actorId = Number(e.target.getAttribute("actor-id"));
    console.log(actorId)
})
document.getElementById("delete_button").addEventListener("click", function () {
    console.log(actorId);
    deleteActor(actorId);
})

function deleteActor(id) {
    $.ajax({
        url: "/Actor/Delete",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(id), // Send the id as a JSON string in the request body
        success: function (result) {
            console.log(result);
            if (result.success) {
                window.location.reload();
            }
        },
        error: function () {
            console.log("error" + id);
        }
    });
}

    


