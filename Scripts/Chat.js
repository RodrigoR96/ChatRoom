$(document).ready(function () {
    setInterval(loadLog, 2500);
});

$("#submitmsg").click(function () {
    var clientmsg = $("#usermsg").val();
    $.ajax({
        type: "post",
        url: "/Chat/SendMessage",
        data: { "message": clientmsg },
        success: function () {
            $("#usermsg").attr("value", "");
        }
    });
});

function loadLog() {
    $.ajax({
        url: "/Chat/RetrieveMessages",
        cache: false,
        async: false,
        success: function (e) {
            $("#chatbox").html(e); //Insert chat log into the #chatbox div	

            //Auto-scroll			
            var newscrollHeight = $("#chatbox").attr("scrollHeight") - 20; //Scroll height after the request
            if (newscrollHeight > oldscrollHeight) {
                $("#chatbox").animate({ scrollTop: newscrollHeight }, 'normal'); //Autoscroll to bottom of div
            }
        },
    });
}