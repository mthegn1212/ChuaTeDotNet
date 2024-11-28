$("#dienTich, #mucGia").on("input", function () {
    this.value = this.value.replace(/[^0-9,]/g, "");
    var parts = this.value.split(",");
    if (parts.length > 2) {
        parts = [parts[0], parts.slice(1).join("")]; // Nếu có nhiều dấu phẩy, chỉ giữ lại 1 dấu phẩy
    }
    if (parts[0].length > 3) {
        var tmp = "";
        for (var i = parts[0].length - 1; i >= 0; i--) {
            if ((parts[0].length - i - 1) % 3 == 0 && i != parts[0].length - 1) {
                tmp = "." + tmp;
            }
            tmp = parts[0].charAt(i) + tmp;
        }
        parts[0] = tmp;
    }
    this.value = parts.join(",");
});
$("#tieptuc2").on("click", function () {
    var dienTich = $("#dienTich").val();
    var mucGia = $("#mucGia").val();
    
    dienTich = dienTich.replace(/\./g, "").replace(",", ".");
    mucGia = mucGia.replace(/\./g, "").replace(",", ".");
    dienTich = parseFloat   (dienTich);
    mucGia = parseDouble(mucGia);
    
    $("#dienTich").val(dienTich);
    $("#mucGia").val(mucGia);
});

$("#tiepTuc1").on("click", function () {
    $("#form2").removeClass("d-none");  
    $(this).addClass("d-none");
    console.log("Form 1 đã hoàn thành");
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
