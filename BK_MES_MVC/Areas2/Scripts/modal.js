$('#Save').attr({ "data-target": "#myModal", "data-dismiss": "modal" });

//遍历后台返回的入库成功的成品条码 和 失败的的成品条码
function back_status(s1, s2) {


    var add_success = "";
    var add_error = "";
    var su = [].concat(s1);
    var er = [] = s2;
    //console.info(su + "A");
    //console.info(er + "B");

    var bool = 0;

    for (var i = 0; i < su.length; i++) {
        add_success += "<tr class='success'><td>" + bool + "</td><td>" + su[i] + "</td><td>成功</td></tr>";
        bool += 1;
    }

    for (var j = 0; j < er.length; j++) {
        bool += 1;
        add_error += "<tr class='warning'><td>" + bool + "</td><td>" + er[j] + "</td><td>失败</td></tr>";
    }

    $('#back_body').append(add_success + add_error);

    bool = 0;
}


//页面重新加载
function Dropbox_clear() {

    window.location.reload();
}

//模拟框关闭触发清空内容
$('#myModal').on('hide.bs.modal', function () {

    Dropbox_clear();
    $('#back_body').empty();
});