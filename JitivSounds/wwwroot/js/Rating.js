$(document).ready(function () {

    $(document).on('click', '.like', (function () {

        //var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        $.ajax({
            url: '/Links/CountLikes?linkId=' + LinkId + '&like=' + true,
            type: 'GET',
            success: (function (e) {
                $('.like-count-' + LinkId)[0].innerText = e.howManyLikes;
                $('.dislike-count-' + LinkId)[0].innerText = e.howManyDislikes;
            })
        })
    }));

    $(document).on('click', '.dislike', (function () {

        //var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        $.ajax({
            url: '/Links/CountDislikes?linkId=' + LinkId + '&like=' + false,
            type: 'GET',

            success: (function (e) {
                $('.like-count-' + LinkId)[0].innerText = e.howManyLikes;
                $('.dislike-count-' + LinkId)[0].innerText = e.howManyDislikes;
            })
        });
    }));
});