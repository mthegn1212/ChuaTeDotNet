$("#dienTich, #mucGia").on("input", function () {
	this.value = this.value.replace(/[^0-9]/g, "");
	if (this.value.length > 3) {
		var tmp = "";
		for (var i = this.value.length - 1; i >= 0; i--) {
			if ((this.value.length - i - 1) % 3 == 0 && i != this.value.length-1) {
				tmp = "." + tmp;
			}
			tmp = this.value.charAt(i) + tmp;
		}
		this.value = tmp;
	}
});
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
