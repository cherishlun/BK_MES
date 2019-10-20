$(function () {
    //1.初始化Table
    var oTable_Ch = new TableInit_Ch();
    oTable_Ch.Init();

    var oTable_PJ = new TableInit_PJ();
    oTable_PJ.Init();


    $('#btn_add_Ch').click(function () {
        var count = $('#table_ch').bootstrapTable('getData').length;
        // alert(count);
        $('#table_ch').bootstrapTable('insertRow', { index: count, row: { zdbh: count + 1, zch: "" } });
        // $('#table_ch').bootstrapTable('append', {row: {Id: count + 1, Ch: "" } });
    });

    $('#btn_add_Pj').click(function () {

        var count = $('#table_pjxx').bootstrapTable('getData').length;
        $('#table_pjxx').bootstrapTable('insertRow', { index: count, row: { zdbh: count + 1, pjmc: "", pjsl: "", pjjldw: "", sfhs: "" } });
    });


    $('#btn_save').click(function () {

        alert(JSON.stringify($('#table_ch').bootstrapTable('getData')));
        alert(JSON.stringify($('#table_pjxx').bootstrapTable('getData')));

        $.ajax({
            url: "/Bk_Ckxx/FaHuo_Input_Save"
            , type: "post"
            , data: { "chb": JSON.stringify($('#table_ch').bootstrapTable('getData')), "pjb": JSON.stringify($('#table_pjxx').bootstrapTable('getData')) }
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    tablerefesh();
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("数据删除失败！", result.responseText.substring(0, 100), "error");
            }
        });

    });


});

    var TableInit_Ch = function () {
        var oTable_ChInit = new Object();
    //初始化Table
        oTable_ChInit.Init = function () {
        $("#table_ch").bootstrapTable({
            idField: "zdbh",
            clickToSelect: true,
            data: [{ zdbh: "1", zch: "" }],
            columns: [{
                checkbox: true
            }, {
                field: "zch",
                title: "车号",
                editable: {
                    type: 'text',
                    title: '车号',
                    emptytext: "请输入车号",          //空值的默认文本
                    validate: function (v) {
                        if (!v) return '车号不能为空';

                    }
                }
            }, {
                field: 'zdbh',
                title: '操作',
                formatter: operateFormatter_ch //自定义方法，添加操作按钮\
                , width: 100
            },
            {
                field: "zdbh",
                title: "id"
            }
            ]
            //onEditableSave: function (field, row, oldValue, $el) {
            //    $.ajax({
            //        type: "post",
            //        url: "/#",
            //        data: row,
            //        dataType: 'JSON',
            //        success: function (data, status) {
            //            if (status == "success") {
            //                alert('提交数据成功');
            //            }
            //        },
            //        error: function () {
            //            alert('编辑失败');
            //        },
            //        complete: function () {

            //        }

            //    });
            //}
        });
    };
    return oTable_ChInit;
};


var TableInit_PJ = function () {
    var oTable_PjInit = new Object();
    //初始化Table
    oTable_PjInit.Init = function () {
        $("#table_pjxx").bootstrapTable({
            data: [{ zdbh: 1, pjmc: "", pjsl: "", pjjldw: "", sfhs: "" }],
            columns: [{
                checkbox: true
            }, {
                field: "pjmc",
                title: "配件名称",
                editable: {
                    type: 'text',
                    title: '配件名称',
                    emptytext: "请输入配件名称",          //空值的默认文本
                    validate: function (v) {
                        if (!v) return '配件名称不能为空';

                    }
                }
            }, {
                field: "pjsl",
                title: "配件数量",
                editable: {
                    type: 'text',
                    title: '配件数量',
                    emptytext: "请输入配件数量",          //空值的默认文本
                    validate: function (v) {
                        if (!v) return '配件数量不能为空';

                    }
                }

            },
            {
                field: "pjjldw",
                title: "配件计量单位",
                editable: {
                    type: 'text',
                    title: '配件计量单位',
                    emptytext: "请输入配件计量单位",          //空值的默认文本
                    validate: function (v) {
                        if (!v) return '配件计量单位不能为空';

                    }
                }
            }, {
                field: "sfhs",
                title: "是否回收",
                editable: {
                    type: 'text',
                    title: '是否回收',
                    emptytext: "请输入是否回收",          //空值的默认文本
                    validate: function (v) {
                        if (!v) return '是否回收单位不能为空';
                    }
                }
            }, {
                field: 'zdbh',
                title: '操作',
                formatter: operateFormatter_pj, //自定义方法，添加操作按钮\
                width: 100,
                //events: operateEvent2,
            }
            ],
        }
        );
    }
    return oTable_PjInit;

};

    //window.operateEvent2 = {
        //    "click #btnDel2": function (e, value, row, index) {
        //        //alert(row.Id);
        //        $("#table_2").bootstrapTable('remove', { field: 'Id', values: [row.Id] });//field:根据field的值来判断要删除的行  values：删除行所对应的值
        //    }
        //}

function operateFormatter_ch(value, row, index) {//赋予的参数
    return [
        "<div class='btn-group btn-group-xs'>" +
        "<button type = 'button' class= 'btn btn-info' onclick = 'btnDel(" + row.zdbh + ")' > 删除</button>" +
        "</div>"
    ].join('');
}

function operateFormatter_pj(value, row, index) {//赋予的参数
    return [
        "<div class='btn-group btn-group-xs'>" +
        "<button type='button' class='btn btn-info' onclick='btnDel2(" + row.zdbh + ")'> 删除</button>" +
        "</div>"
    ].join('');
}

function btnDel(id) {
    var count = $('#table_ch').bootstrapTable('getData').length;
    if (count == 1) {
        swal("已经是最后一条，不能删除!");
        return;
    }
    $("#table_ch").bootstrapTable('remove', { field: 'zdbh', values: [id] });//field:根据field的值来判断要删除的行  values：删除行所对应的值
}

function btnDel2(id) {
    $("#table_pjxx").bootstrapTable('remove', { field: 'zdbh', values: [id] });//field:根据field的值来判断要删除的行  values：删除行所对应的值
}

//function btn_add_Ch() {
//    alert("c");
//    var count = $('#table_ch').bootstrapTable('getData').length;
//    // alert(count);
//    $('#table_ch').bootstrapTable('insertRow', { index: count, row: { Id: count + 1, Ch: "" } });
//    // $('#table_ch').bootstrapTable('append', {row: {Id: count + 1, Ch: "" } });
//}

//function btn_add_Pj() {
//    var count = $('#table_pjxx').bootstrapTable('getData').length;
//    $('#table_pjxx').bootstrapTable('insertRow', { index: count, row: { Id: count + 1, Pjmc: "", Pjsl: "", Pjdw: "", Pjhs: "" } });
//}
