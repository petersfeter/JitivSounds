$(document).ready(function () {

    $('.btn-delete').click(function (e) {
        var delId = $(this).data("id");

        e.preventDefault();
        $.ajax({

            url: 'Links/Delete/' + delId,
            type: 'GET',
            contentType: 'application/html',
            success: function (content) {
                $('#DeleteModal div.modal-content').html(content);
                $('#DeleteModal').modal('show');


            },
            error: function (e) { }
        });
    });

    $('.btn-create').click(function (e) {
        
        e.preventDefault();
        $.ajax({

            url: 'Links/Create/',
            type: 'GET',
            contentType: 'application/html',
            success: function (content) {
                $('#CreateModal div.modal-content').html(content);
                $('#CreateModal').modal('show');


            },
            error: function (e) { }
        });
    });

});