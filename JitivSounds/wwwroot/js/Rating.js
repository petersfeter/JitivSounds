$(document).ready(function () {
    $(function () {
        $('.like').click(function () { likeFunction(this); });
        $('.dislike').click(function () { dislikeFunction(this); });
    });


    function likeFunction(caller) {
        var postId = caller.parentElement.getAttribute('postid');
        $.ajax({
            type: "POST",
            url: "rate.php",
            data: 'Action=LIKE&PostID=' + postId,
            success: function () { }
        });
    }
    function dislikeFunction(caller) {
        var postId = caller.parentElement.getAttribute('postid');
        $.ajax({
            type: "POST",
            url: "rate.php",
            data: 'Action=DISLIKE&PostID=' + postId,
            success: function () { }
        });
    }
});