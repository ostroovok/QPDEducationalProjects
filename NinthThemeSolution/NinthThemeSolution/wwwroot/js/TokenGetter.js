
$(document).ready(function () {
    let res =
        $.ajax({
            type: "GET",
            url: "api/Token",
            async: false,
        }).responseJSON;

    $("#tokenBox").append(res);
});
