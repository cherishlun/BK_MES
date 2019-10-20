$(function () {
    $('#btn_print').click(function () {
        if ($("#ckmc").val() == '') {
            swal("请选择仓库!");
            return;
        }
        if ($("#pmc").val() == '') {
            swal("请选择排!");
            return;
        }
        if ($("#ceng1").val() == '') {
            swal("请输入层号!");
            return;
        }
        window.location.href = "/Bk_Ckxx/CangKu_Print?ph=" + $("#pmc").val()+"&l1=" + $("#ceng1").val() + "&l2=" + $("#ceng2").val() + "&h1=" + $("#wei1").val() + "&h2=" + $("#wei2").val();
    });

    $("#ckmc").change(function () {

        var url = "/Bk_Ckxx/CangKu_Lie_List?id=" + $("#ckmc").val();
        //alert(url);
        $.getJSON(url, function (data) {
            $('#pmc').html('');
            //alert('hello');
            $("#pmc").append("<option value=''>请选择排</option>")
            $.each(data, function (i, item) {
                //alert(item.pmc);
                $('#pmc').append("<option value='" + item.zdbh + "'>" + item.pmc + "</option>").appendTo("#pmc");

            });
            $('#pmc').selectpicker('refresh');
        });
    });
});
