
$(function () {
    $("#Send").click(
        function () {
            let message = $("#message").val();

            let token = $("#tokenBox").val();

            let stringURL = "api/Chat";

            $.ajax({
                type: "POST",
                url: stringURL,
                async: false,
                data: { message: message, token: token },

                success: function (data) {
                    $("#displayMessage").append(">>> " + message + "\n");
                    $("#displayMessage").append(data.message + "\n");

                    $("#message").val("");
                }
            });
        }
    );
});