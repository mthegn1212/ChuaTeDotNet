
$("#tiepTuc1").on("click", function () {
    $("#form2").removeClass("d-none");
    $(this).addClass("d-none");
});
$(document).ready(function () {
    $('#uploadAnh').on('change', function () {
        var files = $(this)[0].files;
        var preview = $('#previewImages');
        preview.empty();
        $.each(files, function (i, file) {
            var reader = new FileReader();
            reader.onload = function (e) {
                var img = $('<img>').attr('src', e.target.result).css({
                    'max-width': '150px',
                    'margin': '10px'
                });
                preview.append(img);
            };
            reader.readAsDataURL(file);
        });
    });
});