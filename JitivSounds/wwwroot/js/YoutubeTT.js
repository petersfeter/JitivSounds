$(document).ready(function () {
    $('.video-row').each(function () {

        var LinkId = $(this).data('id');
        var rawlink = $('#ytlink-' + LinkId)[0].href;
        
        console.log(LinkId);

        var videoid = rawlink.match(/(?:https?:\/{2})?(?:w{3}\.)?youtu(?:be)?\.(?:com|be)(?:\/watch\?v=|\/)([^\s&]+)/);
            
        if (videoid != null) {
            console.log("video id = ", videoid[1]);
        } else {
            console.log("The youtube url is not valid.");
        }
        

        $.getJSON("https://www.googleapis.com/youtube/v3/videos", {
            key: "AIzaSyBepHmm58_B-4EjmKpO491vdpl78dfkO5Q",
            part: "snippet",
            id: videoid[1]
        }, function (data) {

            $('<img>', {
                src: data.items[0].snippet.thumbnails.default.url,
                width: data.items[0].snippet.thumbnails.default.width,
                height: data.items[0].snippet.thumbnails.default.height
            }).appendTo('#thumbnail-' + LinkId);
            $('<p></p>').text(data.items[0].snippet.title).appendTo('#yttitle-' + LinkId);
        })
    })
});