$(document).ready(function () {
    $("#Authenticate").click(function () {
        var url = "http://localhost:58258/api/login/AuthenticateUser";
        var credentials = {
            UserName: $('#UserName').val(),
            Password: $('#password').val()
            };
        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(credentials),
            success: function (response) {

                if (response) {
                    window.location.href = "http://localhost:58905/FacebookNotification.html";
                    console.log("Successfully recieved");
                    localStorage.user = credentials.UserName;
                }
                else {
                    $('<div class="alert alert-danger">').appendTo($('#incorrect_Password'));
                    $('<strong>Incorrect Password!</strong></div>').appendTo($('#incorrect_Password'));


                   }
            },
            error: function (error) {
               
                alert("User Name Does Not Exists");
            }
        });
    });
});
