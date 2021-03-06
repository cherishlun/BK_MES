﻿$(function () {

    //1.初始化Table
    var oTable_PeiHuo = new TableInit_PeiHuo();
    oTable_PeiHuo.Init();

    $('#btn_dingdan_select').click(function () {
        $('#Arbet_PeiHuo_Table').bootstrapTable('refresh', { 'url': '/BK_Ckxx/DingDan_Find' });
    });

    $('#Arbet_PeiHuo_Table').on('uncheck.bs.table check.bs.table check-all.bs.table uncheck-all.bs.table', function (e, rows) {
        var datas = $.isArray(rows) ? rows : [rows];        // 点击时获取选中的行或取消选中的行
        examine(e.type, datas);                                 // 保存到全局 Set() 里
    });

    $('#btn_dingdan_save').click(function () {
        if (overAllIds.length <= 0) {
            swal("请选择需要拣货的订单!");
            return;
        }

        swal({
            title: "保存确认"
            , text: "是否确认选择的信息？"
            , type: "info"
            , cancelButtonText: "取消"
            , confirmButtonText: "确认！"
            , showCancelButton: true
            , closeOnConfirm: false
            , showLoaderOnConfirm: true,
        }, function () {
            var _bh = [];
            overAllIds.forEach(function (element, index, array) {
                _bh.push({
                    zdbh: element
                });
            });

            $.ajax({
                url: "/Bk_Ckxx/ChuKu_Receive"
                , data: JSON.stringify(_bh)
                , type: 'POST'
                , contentType: 'application/json;charset=utf-8'
                , success: function (data) {
                    swal(data.info, "", data.status == 1 ? "success" : "error");
                    if (data.status == 1) {
                        $('#ArbetTable').bootstrapTable('refresh', { 'url': '/BK_Ckxx/DingDan_Find' });
                        swal("接收成功");
                        $("#myModal_PeiHuo").modal('hide');
                    }
                }
                , error: function (result) {
                    swal("接收失败！", result.responseText.substring(0, 100), "error");
                }
            });
        });

    });


});

var TableInit_PeiHuo = function () {
    var oTable_PeiHuoInit = new Object();
    //初始化Table
    oTable_PeiHuoInit.Init = function () {
        $('#Arbet_PeiHuo_Table').bootstrapTable({
            url: '',         //请求后台的URL（*）
            width:700,
            method: 'get',                      //请求方式（*）
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTable_PeiHuoInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            contentType: "application/x-www-form-urlencoded",
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "zdbh",                     //每一行的唯一标识，一般为主键列
            detailView: true,                   //是否显示父子表
            columns: [
                    {
                        align: 'center',
                        checkbox: true,                          // 显示复选框
                        formatter: function (i, row) {            // 每次加载 checkbox 时判断当前 row 的 id 是否已经存在全局 Set() 里
                            if ($.inArray(row.zdbh, Array.from(overAllIds)) != -1) {    // 因为 Set是集合,需要先转换成数组  
                                return {
                                    checked: true               // 存在则选中
                                }
                            }
                        }
                    },
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#ArbetTable').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    witdh: 10
                },
                {
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
                },
                {
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
                }, {
                    field: 'ddztm',
                    title: '订单状态码',
                    visible: false
                }
            ],
            onExpandRow: function (value, row, $Subdetail) {
                oTable_PeiHuoInit.InitSubTable_2(row.ddztm, row, $Subdetail);
            },
        });
    };

    //得到查询的参数
    oTable_PeiHuoInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            ddzt: 3,
            rq1: $("#dhrq1").val(),
            rq2: $("#dhrq2").val(),
            search: $("#dingdan_cpbm").val() != "" ? $("#dingdan_cpbm").find("option:selected").text() : ""
        };
        return temp;
    };


    oTable_PeiHuoInit.InitSubTable_2 = function (value, row, $detai2) {
        //row是父表的值
        var cur_table_2 = $detai2.html('<table id="table_select"></table>').find('table');

        $(cur_table_2).bootstrapTable({
            url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + row.zdbh,
            method: 'get',
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/json",
            dataType: "json",
            clickToSelect: true,
            pagination: true,                   //是否显示分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            uniqueId: "zdbh",
            pageSize: 10,
            pageList: [10, 25],
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
                    field: 'bz',
                    title: '备注'
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
            onLoadError: function () {
                swal("数据加载失败！");
            },
        });
    };


    return oTable_PeiHuoInit;
};

var overAllIds = [];                // 全局保存选中行的对象

function examine(type, datas) {
    if (type.indexOf('uncheck') == -1) {
        $.each(datas, function (i, v) {
            var id = v.zdbh;
            // 添加时，判断一行或多行的 id 是否已经在数组里 不存则添加　
            overAllIds.indexOf(id) == -1 ? overAllIds.push(id) : -1;
        });
    } else {
        $.each(datas, function (i, v) {
            var id = v.zdbh;
            overAllIds.splice(overAllIds.indexOf(id), 1);    //删除取消选中行
        });
    }

    //   console.log(overAllIds);
}