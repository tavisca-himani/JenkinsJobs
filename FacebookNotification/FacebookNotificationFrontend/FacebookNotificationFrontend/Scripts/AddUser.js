$(document).ready(function () {
    $("#CreateUser").click(function () {
                jQuery.support.cors = true;
                var userName = $("#UserName").val();
                var password = $("#password").val();
                var user = {
                    UserName: userName,
                    Password: password
                };
                var url = "http://localhost:58258/api/login/Subscriber";
                $.ajax({
                    url: url,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(user),
                    success: function (response) {
                        alert("Success");
                        
                        console.log("Successfully recieved Get Database");
                    },
                    error: function (error) {
                        alert(error);
                    }
                });
            });
        });