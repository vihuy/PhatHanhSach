
window.onload = function () {
    $(document).ready(function () {
        console.log("ready!");
        $("#datepicker").datepicker({
            dateFormat: 'dd-mm-yy',
            changeMonth: true, //Tùy chọn này cho phép người dùng chọn tháng
            changeYear: true //Tùy chọn này cho phép người dùng lựa chọn từ phạm vi năm
        });
        $("#TenSach").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/BAOCAODLs/Search/',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return item;
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("#masach").val(i.item.id);
            },
            minLength: 1
        });
    });
}


var dynamicId = 0;
$('#btnAdd').click(function () {
    dynamicId += 1
    $('#chitiet').append(
        "<tr>" +
        "<td>" + $("#masach").val() + "</td>" +
        "<td>" + $("#TenSach").val() + "</td>" +
        '<td><input type="number" class="form-control" id = "DonGia"/></td>' +
        '<td><input type="number" class="form-control" id = "SLBan"/></td>' +
        '<td><input type="number" class="form-control" id = "ThanhTien"/></td>' +
        '<td><button class="btn btn-danger btnDelete">Delete</button></td>' +
        '<input type="hidden" name="ct[' + (dynamicId - 1) + '].MaBCDL" value="0" />' +
        '<input type="hidden" name="ct[' + (dynamicId - 1) + '].MaSach" value="' + $("#masach").val() + '" />' +
        '<input type="hidden" name="ct[' + (dynamicId - 1) + '].SoLuongBan" value="' + $('#SLBan').val() + '" />' +
        '<input type="hidden" name="ct[' + (dynamicId - 1) + '].DonGiaBan" value="' + $('#DonGia').val() + '" />' +
        '<input type="hidden" name="ct[' + (dynamicId - 1) + '].ThanhTien" value="' + $('#ThanhTien').val() + '" />' +
        "</tr>"
    )
});

$("#chitiet").on('click', '.btn.btn-danger.btnDelete', function () {
    $(this).closest('tr').find("input[type='hidden']").remove();
    $(this).closest('tr').remove();
});
