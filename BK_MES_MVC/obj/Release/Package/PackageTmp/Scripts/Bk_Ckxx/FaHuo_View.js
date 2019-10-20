$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //查询
    $('#btn_find').click(function () {
        $("#ArbetTable").bootstrapTable('selectPage', 1);
    });

    $("#myModal").on("hidden.bs.modal", function () {
        $(this).removeData("bs.modal");
        $(this).find(".modal-content").children().remove();
    });
    /////
    ////1.初始化Table
    //var oTable_Ch = new TableInit_Ch();
    //oTable_Ch.Init();

    //var oTable_PJ = new TableInit_PJ();
    //oTable_PJ.Init();

    //$('#btn_add_Ch').click(function () {

    //    var count = $('#table_ch').bootstrapTable('getData').length;
    //    // alert(count);
    //    $('#table_ch').bootstrapTable('insertRow', { index: count, row: { Id: count + 1, Ch: "" } });
    //    // $('#table_ch').bootstrapTable('append', { row: { Id: count + 1, Ch: "" } });
    //});

    //$('#btn_add_Pj').click(function () {

    //    var count = $('#table_pjxx').bootstrapTable('getData').length;
    //    $('#table_pjxx').bootstrapTable('insertRow', { index: count, row: { Id: count + 1, Pjmc: "", Pjsl: "", Pjdw: "", Pjhs: "" } });
    //});


    //$('#btn_save').click(function () {

    //    alert(JSON.stringify($('#table_ch').bootstrapTable('getData')));
    //    alert(JSON.stringify($('#table_pjxx').bootstrapTable('getData')));
    //});


});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            height: tableHeight(),              //高度调整
            url: '/BK_Ckxx/FaHuo_Find',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            searchOnEnterKey: true, //ENTER键搜索 ,
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "zdbh",                     //每一行的唯一标识，一般为主键列
            detailView: true,                   //是否显示父子表
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#ArbetTable').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    witdh: 10
                }, {
                    field: 'dhrq',
                    title: '订单日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        return value.substring(0, 10);
                    }
                }, {
                    field: 'khmc',
                    title: '客户名称',
                    witdh: 200,
                    formatter: function (value, row, index) {
                        return value + (row.khhz == "" ? "" : "_" + row.khhz);
                    }
                }, {
                    field: 'bz',
                    title: '备注',
                    width: 200
                }, {
                    field: 'jlrq',
                    title: '操作日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        return value.substring(0, 10);
                    }
                }, {
                    field: 'ddzt',
                    title: '订单状态',
                    width: 150
                }, {
                    field: 'zdbh',
                    title: '订单编号',
                    visible: true
                },{
                    field: 'zcxx',
                    title: '装车车号',
                    formatter: function (value, row, index) {
                        if (value == null) {
                            return '/'
                        }
                        else {
                            var select = '';
                            $.each(value.split(";"), function (index2, value2) {
                                var _str = '';
                                _str += (value2.split(",")[0]=='1'?'汽车;':'')+'' + value2.split(",")[1] + ';' + value2.split(",")[2];
                                select += '<option ' + (index2 == 0 ? 'selected="selected"' : '') + '>' + _str + '</option>\n';
                            });
                            return '<select class="selectpicker show-tick" data-style="btn-white" >\n' +
                                            select +
                                            '</select>';
                            
                        }
                    }
                }, {
                    field: 'pjxx',
                    title: '装车配件',
                    formatter: function (value, row, index) {
                        if (value == null) {
                            return '/'
                        }
                        else {
                            var select = '';
                            $.each(value.split(";"), function (index, value2) {
                                select += '<option ' + (index == 0 ?'selected="selected"':'')+'>' + value2 + '</option>\n';
                            });
                            return '<select class="selectpicker show-tick" data-style="btn-white">\n' +
                                select+
                                '</select>';
                        }
                    }
                }, {
                    field: 'zcbz',
                    title: '装车备注'
                }, {
                    field: 'jsrbm',
                    title: '接收人编码',
                    visible: false
                }, {
                    field: 'zdbh',
                    title: '自动编号'
                },{
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter //自定义方法，添加操作按钮\
                    , width: 100
                },
            ],
            onLoadSuccess: function () {
                $('.selectpicker').selectpicker({}) 
            },
            onExpandRow: function (value, row, $Subdetail) {
                oTableInit.InitSubTable_2(value, row, $Subdetail);
            },
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            ddzt: $('#ddzt').val(),
            search_ch: $("#search_ch").val(),
            search_ddh: $("#search_ddh").val(),
            search_kh: $("#search_kh").val()
        };
        return temp;
    };
    //
  
    //初始化子表格
    oTableInit.InitSubTable_2 = function (value, row, $detai2) {
        var cur_table_2 = $detai2.html('<table id="table_2"></table>').find('table');

        $(cur_table_2).bootstrapTable({
            url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + row.zdbh,
            method: 'get',
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/json",
            dataType: "json",
            queryParams: oTableInit.queryParams2,
            clickToSelect: true,
            pagination: true,                   //是否显示分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            uniqueId: "zdbh",
            pageSize: 1000,
            contentType: "application/x-www-form-urlencoded",
            columns: [
                {
                    field: 'cpmc',
                    title: '成品名称'
                },
                {
                    field: 'gh',
                    title: '钢号'
                },
                {
                    field: 'gg',
                    title: '规格'
                },
                {
                    field: 'zb',
                    title: '组别'
                },
                {
                    field: 'bzfs',
                    title: '包装方式'
                },
                {
                    field: 'yjl',
                    title: '应交量'
                },
                {
                    field: 's_zl',
                    title: '配货量'
                },
                {
                    field: 's_bl',
                    title: '比例'
                },
                {
                    field: 's_sl',
                    title: '配货件数'
                },
                {
                    field: 'bz1',
                    title: '备注1'
                },
                {
                    field: 'bz2',
                    title: '备注2'
                },
                {
                    field: 'czrq',
                    title: '操作日期'
                },
                {
                    field: 'zdbh',
                    title: '明细编号',
                    visible: false
                },
            ],
        });
    };

    //得到查询的参数
    oTableInit.queryParams2 = function (params, row) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
        };
        return temp;
    };
   

    return oTableInit;
};

function operateFormatter(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;
    // 利用 row 获取点击这行的ID
    if (row.jsrbm == null) {
        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' onclick='btnZc(" + PySheDingID + ")' >输入装车信息</button>" +
            "</div>"
        ].join('');
    }
    else
        return;
}

function btnZc(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/FaHuo_Input_Ch",
        backdrop: "static"
    });
}



function tableHeight() {
    return $(window).height() - 10;
}

$('.selectpicker').selectpicker({}) 

//

//var TableInit_Ch = function () {
//    var oTable_ChInit = new Object();
//    //初始化Table
//    oTable_ChInit.Init = function () {
//        $("#table_ch").bootstrapTable({
//            toolbar: "#toolbar",
//            idField: "Id",
//            clickToSelect: true,
//            data: [{ Id: "1", Ch: "" }],
//            columns: [{
//                checkbox: true
//            }, {
//                field: "Ch",
//                title: "车号",
//                editable: {
//                    type: 'text',
//                    title: '车号',
//                    emptytext: "请输入车号",          //空值的默认文本
//                    validate: function (v) {
//                        if (!v) return '车号不能为空';

//                    }
//                }
//            }, {
//                field: 'Id',
//                title: '操作',
//                formatter: operateFormatter_ch //自定义方法，添加操作按钮\
//                , width: 100
//            },
//            {
//                field: "Id",
//                title: "id"
//            }
//            ]
//            //onEditableSave: function (field, row, oldValue, $el) {
//            //    $.ajax({
//            //        type: "post",
//            //        url: "/#",
//            //        data: row,
//            //        dataType: 'JSON',
//            //        success: function (data, status) {
//            //            if (status == "success") {
//            //                alert('提交数据成功');
//            //            }
//            //        },
//            //        error: function () {
//            //            alert('编辑失败');
//            //        },
//            //        complete: function () {

//            //        }

//            //    });
//            //}
//        });
//    };
//    return oTable_ChInit;
//};


//var TableInit_PJ = function () {
//    var oTable_PjInit = new Object();
//    //初始化Table
//    oTable_PjInit.Init = function () {
//        $("#table_pjxx").bootstrapTable({
//            data: [{ Id: 1, Pjmc: "", Pjsl: "", Pjdw: "", Pjhs: "" }],
//            columns: [{
//                checkbox: true
//            }, {
//                field: "Pjmc",
//                title: "配件名称",
//                editable: {
//                    type: 'text',
//                    title: '配件名称',
//                    emptytext: "请输入配件名称",          //空值的默认文本
//                    validate: function (v) {
//                        if (!v) return '配件名称不能为空';

//                    }
//                }
//            }, {
//                field: "Pjsl",
//                title: "配件数量",
//                editable: {
//                    type: 'text',
//                    title: '配件数量',
//                    emptytext: "请输入配件数量",          //空值的默认文本
//                    validate: function (v) {
//                        if (!v) return '配件数量不能为空';

//                    }
//                }

//            },
//            {
//                field: "Pjdw",
//                title: "配件计量单位",
//                editable: {
//                    type: 'text',
//                    title: '配件计量单位',
//                    emptytext: "请输入配件计量单位",          //空值的默认文本
//                    validate: function (v) {
//                        if (!v) return '配件计量单位不能为空';

//                    }
//                }
//            }, {
//                field: "Pjhs",
//                title: "是否回收",
//                editable: {
//                    type: 'text',
//                    title: '是否回收',
//                    emptytext: "请输入是否回收",          //空值的默认文本
//                    validate: function (v) {
//                        if (!v) return '是否回收单位不能为空';
//                    }
//                }
//            }, {
//                field: 'Id',
//                title: '操作',
//                formatter: operateFormatter_pj, //自定义方法，添加操作按钮\
//                width: 100,
//                //events: operateEvent2,
//            }, {
//                field: 'Pid',
//                title: 'Pid'
//            }
//            ],
//        }
//        );
//    }
//    return oTable_PjInit;

//};

////window.operateEvent2 = {
////    "click #btnDel2": function (e, value, row, index) {
////        //alert(row.Id);
////        $("#table_2").bootstrapTable('remove', { field: 'Id', values: [row.Id] });//field:根据field的值来判断要删除的行  values：删除行所对应的值
////    }
////}

//function operateFormatter_ch(value, row, index) {//赋予的参数
//    return [
//        "<div class='btn-group btn-group-xs'>" +
//        "<button type = 'button' class= 'btn btn-info' onclick = 'btnDel(" + row.Id + ")' > 删除</button>" +
//        "</div>"
//    ].join('');
//}

//function operateFormatter_pj(value, row, index) {//赋予的参数
//    return [
//        "<div class='btn-group btn-group-xs'>" +
//        "<button type = 'button' class= 'btn btn-info' onclick='btnDel2(" + row.Id + ")'> 删除</button>" +
//        "</div>"
//    ].join('');
//}

//function btnDel(id) {
//    var count = $('#table_ch').bootstrapTable('getData').length;
//    if (count == 1) {
//        swal("已经是最后一条，不能删除!");
//        return;
//    }
//    $("#table_ch").bootstrapTable('remove', { field: 'Id', values: [id] });//field:根据field的值来判断要删除的行  values：删除行所对应的值
//}

//function btnDel2(id) {
//    $("#table_pjxx").bootstrapTable('remove', { field: 'Id', values: [id] });//field:根据field的值来判断要删除的行  values：删除行所对应的值
//}

