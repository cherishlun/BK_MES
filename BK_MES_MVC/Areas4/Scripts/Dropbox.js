//库位显示（全选or显示未使用的库位）
var bool = false;

$('#pmc').change(function () {

    var v = $('#pmc').find("option:selected").val();

    if (v != "请选择" && v != "") {

        var obj = { ph: v };
        var url = "/APP_BK_Ckxx/Ph_empty";
        var id = "#_wh";
        var mark = "wh";
        search(url, obj, id, mark);
        //清除第三级下拉框的值
        $('#_cs').find('option').remove();
    } else {
        $('#_cs').find('option').remove();
        $('#_wh').find('option').remove();
    }
});

$('#_wh').change(function () {
    var v = $('#_wh').find("option:selected").val();

    if (v != "请选择") {

        var obj = {
            ph: $('#pmc').find("option:selected").val(),
            wh: v
        };
        var url = "/APP_BK_Ckxx/Ph_empty";
        var id = "#_cs";
        var mark = "ch";

        search(url, obj, id, mark);
    } else {
        $('#_cs').find('option').remove();
    }
});



//多级菜单查询
function search(url, obj_condition, id, mark) {

    var add = "<option>请选择</option>";
    $(id).empty();

    //添加确认框判断属性
    obj_condition._bool = bool;

    console.info(obj_condition);

    $.getJSON(url, obj_condition, function (data) {
        //console.info(data);
        $.each(JSON.parse(data), function (i, item) {
            //console.info(item);
            $.each(item, function (key, value) {
                if (key == mark) {
                    add += "<option id=" + item['zdbh'] + ">" + value + "</option>";
                }
            })
        })

        $(id).append(add);
    })

}


function _checked(src) {
    bool = src.checked ? true : false;
    console.info(bool);
}



