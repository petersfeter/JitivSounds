$(document).ready(function () {

    $(document).on('click', '.like', (function () {
                
        //var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        if ((!$('#like-' + LinkId).hasClass("disabled"))) {
            event.preventDefault();


            $.ajax({
                url: '/Links/CountLikes?linkId=' + LinkId + '&like=' + true,
                type: 'GET',

                //success: (function (e) {
                //    $('#like-' + LinkId).text(e);
                //})
            })
        }

    }));
    $(document).on('click', '.dislike', (function () {

        //var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        if (!($('#like-' + LinkId).hasClass('disabled'))) {
            event.preventDefault();


            $.ajax({
                url: '/Links/CountDislikes?linkId=' + LinkId + '&like=' + false,
                type: 'GET',

                // success: (function (e) {
                //    $('#dislike-' + LinkId).text(e);
                //})

            });
        }
    }));
});
