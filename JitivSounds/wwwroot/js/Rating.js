$(document).ready(function () {

    $(document).on('click', '.like', (function () {

        //var UserId = $(this).data('id');
        var LinkId = $(this).data('id');
       // $('#like-' + LinkId).on('click', firstClick)



        if ((!$('#like-' + LinkId).hasClass("disabled"))) {
            event.preventDefault();


            $.ajax({
                url: '/Links/CountLikes?linkId=' + LinkId + '&like=' + true,
                type: 'GET',

                success: (function (e) {
                    $('.like-count-' + LinkId)[0].innerText = e
                        $('#like-' + LinkId).addClass('disabled')
                        $('#dislike-' + LinkId).addClass('disabled')
                })
            })
        }



    }));





    $(document).on('click', '.dislike', (function () {

        //var UserId = $(this).data('id');
        var LinkId = $(this).data('id');

        if (!($('#dislike-' + LinkId).hasClass('disabled'))) {
            event.preventDefault();


            $.ajax({
                url: '/Links/CountDislikes?linkId=' + LinkId + '&like=' + false,
                type: 'GET',

                success: (function (e) {
                    $('.dislike-count-' + LinkId)[0].innerText = e
                        $('#dislike-' + LinkId).addClass('disabled')
                        $('#like-' + LinkId).addClass('disabled')

                })

            });
        }
    }));
});