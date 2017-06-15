$(document).ready(function () {
    !function GetNotificationCount() {
        setTimeout(function () {
            $.ajax({
                url: "http://localhost:58258/api/count/" + localStorage.user,
                success: function (result) {
                    $("#notification_Count").html(result);
                    document.getElementById("notification").setAttribute("value", result);

                    if (Number(result) > 0 && $("#notification_area").is(":visible")) {
                        GetNotification();
                    }
                    GetNotificationCount();
                }
            });
        }, 1000);
    }();

    $("#logout").click(function () {

        localStorage.clear();
        window.location.href = "LoginPage.html";

    });

    $("#notification").click(function () {
        GetNotification();
    });

    function GetNotification() {
        var url = "http://localhost:58258/api/notification/get/" + localStorage.user;
        var x = 1;
        var unreadNotification = document.getElementById("notification_Count").innerHTML;

        $.ajax({
            url: url,
            type: 'GET',
            success: function (response) {
                $("notification_area").show();

                var node = document.getElementById("notification_area");
                while (node.hasChildNodes()) {
                    node.removeChild(node.lastChild);
                }

                $.each(response, function (key, response) {
                    //alert(response.Message);

                    if (x <= unreadNotification)
                        $("#notification_area").append($("<li style=\"background-color:rgb(72, 145, 255); color:white;\">").text(response.Message));
                    else
                        $("#notification_area").append($("<li>").text(response.Message));
                    x++;
                    //$("#notification_area").append($("<hr>"));
                });

                console.log("Successfully recieved Get Database");
            }
        });
    }
});