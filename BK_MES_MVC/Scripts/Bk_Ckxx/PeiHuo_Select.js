$(function () {

    //1.初始化Table
    var oTable_Top = new Table_Top_Init();
    oTable_Top.Init();

    var oTable_Bottom = new Table_Bottom_Init();
    oTable_Bottom.Init();


    $('#btn_peihuo_save').click(function () {

        if ($('#Arbet_Bottom_Table').bootstrapTable("getData") == "") {
            swal("请选择记录");
            return;
        }

        swal({
            title: "保存确认"
            , text: "是否保存配货信息？"
            , type: "info"
            , cancelButtonText: "取消"
            , confirmButtonText: "保存！"
            , showCancelButton: true
            , closeOnConfirm: false
            , showLoaderOnConfirm: true,
        }, function () {
            //循环Bottom表取出ckbh
            var _bh = [];
            var data = $('#Arbet_Bottom_Table').bootstrapTable("getData");
            for (var rows in data) {
                _bh.push({
                    cpbh: data[rows].cpbh
                    , xxdbh: $("#st_peihuo_id").val()
                });
            }

            $.ajax({
                url: "/Bk_Ckxx/PeiHuo_Save"
                , data: JSON.stringify(_bh)
                , type: 'POST'
                , contentType: 'application/json;charset=utf-8'
                , success: function (data) {
                    swal(data.info, "", data.status == 1 ? "success" : "error");
                    if (data.status == 1) {
                        $("#myModal_PeiHuo").modal('hide');
                        $('#table_2').bootstrapTable('refresh', {
                            url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + $("#id_2").val()
                        });
                    }
                }
                , error: function (result) {
                    swal("数据增加失败！", result.responseText.substring(0, 100), "error");
                }
            });
        });

    });

    $('#btn_peihuo_select').click(function () {
        $('#Arbet_Top_Table').bootstrapTable('selectPage', 1);
        if ($('#Arbet_Top_Table').bootstrapTable('getData').length==0)
            $('#Arbet_Top_Table').bootstrapTable('refresh', { 'url': '/BK_Ckxx/PeiHuo_Select_Find' });
    });

    $('#Arbet_Top_Table').on('check.bs.table check-all.bs.table ' +
        'uncheck.bs.table uncheck-all.bs.table', function (e, rows) {
            var ids = $.map(!$.isArray(rows) ? [rows] : rows, function (row) {
                return row.cpbh;//注意这里的row.cpbh 中的cpbhd指的是列表的主键
            }),
                func = $.inArray(e.type, ['check', 'check-all']) > -1 ? 'union' : 'difference';
            if (func == 'union') {
                btnSelect_Top(ids);
            }
            if (func == 'difference') {
              btnSelect_Bottom(ids) 
            }
            
            selections = _[func](selections, ids);
        });


});

var Table_Top_Init = function () {
    var oTable_Top_Init = new Object();
    //初始化Table
    oTable_Top_Init.Init = function () {
        $('#Arbet_Top_Table').bootstrapTable({
            url: '',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTable_Top_Init.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 5,                       //每页的记录行数（*）
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            //clickToSelect: true,                //是否启用点击选中行
            height: 240,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "cpbh",                     //每一行的唯一标识，一般为主键列
            detailView: false,                   //是否显示父子表
            columns: [
                {
                    field: 'state',
                    checkbox: true,
                },
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
                    field: 'ph',
                    title: '批号'
                },
                {
                    field: 'khbm',
                    title: '客户代码'
                },
                {
                    field: 'scrq',
                    title: '生产日期'
                },
                {
                    field: 'zl',
                    title: '重量'
                },
                {
                    field: 'kwmc',
                    title: '库位名称'
                },
                {
                    field: 'cpbh',
                    title: '成品编号',
                    visible: false
                },
            ],
            rowStyle: function (row, index) {
                var classesArr = ['success', 'info'];
                var strclass = "";
                if (row.ckzt == "可用") {
                    strclass = classesArr[0];
                } else {
                    strclass = classesArr[1];
                }
                return { classes: strclass };
            },
            responseHandler: responseHandler
        });

    };

    //得到查询的参数
    oTable_Top_Init.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            cpmc: $('#st_peihuo_cp').val(),   //查询条件
            gg: $('#st_peihuo_gg').val(),
            gh: $('#st_peihuo_gh').val(),
            zb: $('#st_peihuo_zb').val(),
            ph: $('#st_peihuo_ph').val(),
            khbm: $('#st_peihuo_khbm').val(),
            zl1: $('#st_peihuo_zl1').val(),
            zl2: $('#st_peihuo_zl2').val()
        };
        return temp;
    };
    return oTable_Top_Init;
};

var Table_Bottom_Init = function () {
    var oTable_Bottom_Init = new Object();
    //初始化Table
    oTable_Bottom_Init.Init = function () {
        $('#Arbet_Bottom_Table').bootstrapTable({
            height: 200,              //高度调整
            showFooter: true,
            uniqueId: "cpbh",                     //每一行的唯一标识，一般为主键列
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#Arbet_Bottom_Table').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    witdh: 10
                },
                {
                    field: 'cpmc',
                    title: '成品名称'
                    , footerFormatter: function (data) {
                        var _icount = 0;
                        for (var rows in data) {
                            _icount += 1;
                        }
                        return _icount.toString() + "条记录被加入!";
                    }
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
                    field: 'ph',
                    title: '批号'
                },
                {
                    field: 'khbm',
                    title: '客户代码'
                },
                {
                    field: 'scrq',
                    title: '生产日期'
                },
                {
                    field: 'zl',
                    title: '重量'
                    , footerFormatter: function (data) {
                        //统计
                        var _sum = 0;
                        for (var rows in data) {
                            _sum += data[rows].zl;
                        }
                        var _zl = $("#st_peihuo_zl0").val()- _sum;
                        if (_zl < 0)
                            $("#st_peihuo_zl").css("background-color", "red")
                        else
                            $("#st_peihuo_zl").css("background-color", "white")

                        $("#st_peihuo_zl").val(_zl.toFixed(2));
                        return _sum.toFixed(2);//保留两位小数;
                    }
                },
                {
                    field: 'kwmc',
                    title: '库位名称'
                },
                {
                    field: 'cpbh',
                    title: '成品编号',
                    visible: true
                },
                {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter_Bottom //自定义方法，添加操作按钮\
                    , width: 200
                },
            ]
        });

    };
    return oTable_Bottom_Init;
};

function tableHeight_select() {
    return $(window).height() - 10;
}

function operateFormatter_Top(value, row, index) {//赋予的参数
    //var PySheDingID = row.cpbh; //;
    //// 利用 row 获取点击这行的ID
    //return [
    //    "<div class='btn-group btn-group-xs'>" +
    //    "<button type='button' class='btn btn-info' onclick='btnSelect_Top(" + PySheDingID + ")' >选择</button>" +
    //    "</div>"
    //].join('');
    return;
}

function operateFormatter_Bottom(value, row, index) {//赋予的参数
    var PySheDingID = row.cpbh; //;
    // 利用 row 获取点击这行的ID
    var ids = new Array();
    ids.push(row.cpbh);
    return [
        "<div class='btn-group btn-group-xs'>" +
        "<button type='button' class='btn btn-info' onclick='btnSelect_Bottom(" + ids + ")' >移除</button>" +
        "</div>"
    ].join('');
}

function btnSelect_Top(ids) {
    //alert(id);

    $table_top = $('#Arbet_Top_Table').bootstrapTable();
    $table_bottom = $('#Arbet_Bottom_Table').bootstrapTable();

    for (var i = 0; i < ids.length; i++) {
        var selectedContent1 = $table_bottom.bootstrapTable('getRowByUniqueId', ids[i]);
        if (selectedContent1 == null) {
            var selectedContent2 = $table_top.bootstrapTable('getRowByUniqueId', ids[i]);
            $table_bottom.bootstrapTable("append", selectedContent2);
        }
    }

}


function btnSelect_Bottom(ids) {
    //alert(id);

    $table_top = $('#Arbet_Top_Table').bootstrapTable();
    $table_bottom = $('#Arbet_Bottom_Table').bootstrapTable();

    if (typeof (ids) == "number") {
        var _ids = new Array();
        _ids.push(ids);
        selections = _.difference(selections, _ids);

        $table_bottom.bootstrapTable('remove', {
            field: "cpbh", values: [parseInt(ids)]
        });
    }
    else {
        for (var i = 0; i < ids.length; i++) {
            $table_bottom.bootstrapTable('remove', {
                field: "cpbh", values: [ids[i]]
            });
        }
    }

    $table_top.bootstrapTable("refresh");

}

function stxt_set(id,cpmc,gg,gh,zb,khbm,zl) {
    $("#st_peihuo_cp").val(cpmc);
    $("#st_peihuo_gg").val(gg);
    $("#st_peihuo_gh").val(gh);
    $("#st_peihuo_zb").val(zb);
    $("#st_peihuo_id").val(id);
    $("#st_peihuo_khbm").val(khbm);
    $("#st_peihuo_zl").val(zl);
    $("#st_peihuo_zl0").val(zl);

}

function clearNoNum(obj) {
    obj.value = obj.value.replace(/[^\d.]/g, ""); //清除"数字"和"."以外的字符
    obj.value = obj.value.replace(/\.{2,}/g, "."); //只保留第一个. 清除多余的  
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
}

function responseHandler(res) {
    $.each(res.rows, function (i, row) {
        //注意这里的row.cpbh 中的id指的是列表的主键
        row.state = $.inArray(row.cpbh, selections) !== -1;
    });
    return res;
}    

$('#cpbm').selectpicker({});
$('#ddzt21').selectpicker({});

