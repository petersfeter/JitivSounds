$(document).ready(function () {

    $(document).on('click', '.like', (function () {

        var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        $.ajax({
            url: '/Links/CountLikes?linkId=' + LinkId + '&lajk=' + true ,
            type: 'GET',
            
            success: function () {
                                
            }
        });
    }));
    $(document).on('click', '.dislike', (function () {

        var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        $.ajax({
            url: '/Links/CountDislikes?linkId=' + LinkId + '&lajk=' + false,
            type: 'GET',

            success: function () {

            }
        });
    }));

});
